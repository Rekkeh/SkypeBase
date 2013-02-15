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
        internal Skype skype;
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
        /// <summary>
        /// The last message Id that was received by the bot
        /// </summary>
        int LastChatMessageId = 0;

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
            /// Add our Skype Message Event Handler.
            /// </summary>
            skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(SkypeMessageEvent);
        }

        /// <summary>
        /// Event for if someone is trying to call the user
        /// </summary>
        /// <param name="call">The current call.</param>
        /// <param name="status">The status of the call.</param>
        void SkypeCallEvent(Call call, TCallStatus status)
        {
            //Check to see if someone is trying to call
            if (status == TCallStatus.clsRinging)
            {
                //Check if TakeCalls is false
                if (!TakeCalls)
                {
                    //Send the person calling a message and try to end the call
                    skype.SendMessage(call.PartnerHandle.ToString(), "I'm sorry, but your call has been declined.");
                    try { call.Finish(); }
                    catch (Exception ex) { }
                }
            }
        }

        /// <summary>
        /// Event for when someone tries to add the user
        /// </summary>
        /// <param name="user">The user that is trying to add us.</param>
        void SkypeFriendEvent(User user)
        {
            //Check to see if TakeFriends is true
            if (TakeFriends)
            {
                //Get each friend from the user's friends list
                foreach (User friend in skype.Friends)
                {
                    //Check if the person adding the user is already on the list
                    if (!(friend.Handle == user.Handle))
                    {
                        //Grant access to add the user
                        user.IsAuthorized = true;
                    }
                }
            }
        }

        /// <summary>
        /// Event for every message sent in a chat
        /// </summary>
        /// <param name="Message">The message that has been sent in the chat</param>
        /// <param name="status">The status of the message</param>
        void SkypeMessageEvent(ChatMessage Message, TChatMessageStatus status)
        {
            if (Message.Status == TChatMessageStatus.cmsSending || Message.Status == TChatMessageStatus.cmsReceived)
            {
                MainForm.Instance.WriteToHistory("[" + Message.FromDisplayName + "] " + Message.Body);
            }
            if (Message.Status == TChatMessageStatus.cmsSending || Message.Status == TChatMessageStatus.cmsReceived && LastChatMessageId < Message.Id || Message.Status == TChatMessageStatus.cmsRead && LastChatMessageId < Message.Id)
            {
                string MessageSender = Message.Sender.Handle;
                string MessageSenderDisplayName = Message.Sender.FullName;
                //Looking for a better way to do this
                LastChatMessageId = Message.Id;

                if (Message.Body.IndexOf(CommandPrefix) == 0)
                {
                        string command = Message.Body.Remove(0, CommandPrefix.Length).ToLower().Split(' ')[0];
                        string[] args = new string[1];
                        if (Message.Body.IndexOf(' ') != 1)
                            args = Message.Body.Remove(0, Message.Body.IndexOf(' ') + 1).ToLower().Split(' ');

                        if (command.Equals("hello"))
                        {
                            if (args[0].Equals("world"))
                            {
                                Message.Chat.SendMessage("Hello World!");
                            }
                            else
                            {
                                Message.Chat.SendMessage("Hello!");
                            }
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
