namespace SkypeBase
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatHistory = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.Button_SendMessage = new System.Windows.Forms.Button();
            this.FriendsList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChatHistory
            // 
            this.ChatHistory.Location = new System.Drawing.Point(4, 4);
            this.ChatHistory.Multiline = true;
            this.ChatHistory.Name = "ChatHistory";
            this.ChatHistory.ReadOnly = true;
            this.ChatHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatHistory.Size = new System.Drawing.Size(333, 226);
            this.ChatHistory.TabIndex = 0;
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(4, 239);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(333, 20);
            this.ChatBox.TabIndex = 1;
            // 
            // Button_SendMessage
            // 
            this.Button_SendMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Button_SendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_SendMessage.Location = new System.Drawing.Point(343, 236);
            this.Button_SendMessage.Name = "Button_SendMessage";
            this.Button_SendMessage.Size = new System.Drawing.Size(102, 23);
            this.Button_SendMessage.TabIndex = 2;
            this.Button_SendMessage.Text = "SendMessage";
            this.Button_SendMessage.UseVisualStyleBackColor = false;
            this.Button_SendMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Button_SendMessage_MouseClick);
            // 
            // FriendsList
            // 
            this.FriendsList.FormattingEnabled = true;
            this.FriendsList.Location = new System.Drawing.Point(341, 18);
            this.FriendsList.Name = "FriendsList";
            this.FriendsList.Size = new System.Drawing.Size(103, 212);
            this.FriendsList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Friends List";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 266);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FriendsList);
            this.Controls.Add(this.Button_SendMessage);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.ChatHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatHistory;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.Button Button_SendMessage;
        internal System.Windows.Forms.ListBox FriendsList;
        private System.Windows.Forms.Label label1;
    }
}

