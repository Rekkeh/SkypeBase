/*
 * This program is licensed by Lrn2Network under a Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License.
 * You may obtain a copy of the license at: http://creativecommons.org/licenses/by-nc-sa/3.0/.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKYPE4COMLib;

namespace SkypeBase
{
    class SkypeBot
    {
        Skype skype;
        /// <summary>
        /// TakeCalls - Whether or not to let calls come through.
        /// TakeFriends - Whether or not to allow people to add you.
        /// </summary>
        Boolean TakeCalls, TakeFriends = true;
        /// <summary>
        /// The character that the bot should use to recognize a command.
        /// </summary>
        string CommandPrefix = "#";
        /// <summary>
        /// What you want your bot to be called.
        /// </summary>
        string BotName = "SkypeBase";
        /// <summary>
        /// The Skype Protocol Version that you're currently using.
        /// </summary>
        int SkypeVersion = 7;

        public SkypeBot()
        {
            /// <summary>
            /// Initialize Skype.
            /// </summary>
            skype = new Skype();
            /// <summary>
            /// Attach to the specified Skype Protocol Version.
            /// </summary>
            skype.Attach(SkypeVersion, false);
            /// <summary>
            /// Add our Skype Call Event Handler.
            /// </summary>
            skype.CallStatus += new _ISkypeEvents_CallStatusEventHandler(SkypeCallEvent);
            /// <summary>
            /// Add our Skype Friend Request Event Handler.
            /// </summary>
            skype.UserAuthorizationRequestReceived += new _ISkypeEvents_UserAuthorizationRequestReceivedEventHandler(SkypeFriendEvent);
            /// <summary>
            /// Add our Skype MEssage Event Handler.
            /// </summary>
            skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(SkypeMessageEvent);
        }

        /// <summary>
        /// Get the skype call and if TakeCalls is false we return "I'm sorry, but your call has been declined." and decline the call automatically.
        /// </summary>
        /// <param name="call">The current call.</param>
        /// <param name="status">The status of the call.</param>
        void SkypeCallEvent(Call call, TCallStatus status)
        {
            if (status == TCallStatus.clsRinging)
            {
                if (!TakeCalls)
                {
                    skype.SendMessage(call.PartnerHandle.ToString(), "I'm sorry, but your call has been declined.");
                    try { call.Finish(); }
                    catch (Exception ex) { }
                }
            }
        }

        /// <summary>
        /// Get who is trying to add us and if TakeFriends is true check if they are already on our friends list or if TakeFriends is false we do not accept the request
        /// </summary>
        /// <param name="user">The user that is trying to add us.</param>
        void SkypeFriendEvent(User user)
        {
            if (TakeFriends)
            {
                foreach (User friend in skype.Friends)
                {
                    if (!(friend.Handle == user.Handle))
                    {
                        user.IsAuthorized = true;
                    }
                }
            }
        }

        void SkypeMessageEvent(ChatMessage Message, TChatMessageStatus status)
        {
            if (Message.Status == TChatMessageStatus.cmsSending || Message.Status == TChatMessageStatus.cmsReceived || Message.Status == TChatMessageStatus.cmsRead)
            {
                string MessageSender = Message.Sender.Handle;
                string MessageSenderDisplayName = Message.Sender.FullName;

                if (Message.Body.IndexOf(CommandPrefix) == 0)
                {
                        string command = Message.Body.Remove(0, CommandPrefix.Length).ToLower().Split(' ')[0];
                        string[] args = new string[1];
                        if (Message.Body.IndexOf(' ') != 1)
                            args = Message.Body.Remove(0, Message.Body.IndexOf(' ') + 1).ToLower().Split(' ');

                        if (command.Equals("hello"))
                        {
                            Message.Chat.SendMessage("Hello world!");
                        }
                        else if (command.Equals("date"))
                        {
                            Message.Chat.SendMessage("Today's date is " + DateTime.Now.ToLongDateString() + ".");
                        }
                        else if (command.Equals("time"))
                        {
                            Message.Chat.SendMessage("It is currently " + DateTime.Now.ToLongTimeString() + ".");
                        }
                        else if (command.Equals("help"))
                        {
                            Message.Chat.SendMessage("Help menu coming soon!");
                        }
                        else
                        {
                            Message.Chat.SendMessage("I'm sorry, but I did not recognize that command. Please try " + CommandPrefix + "help.");
                        }
                }
            }
        }

    }
}
