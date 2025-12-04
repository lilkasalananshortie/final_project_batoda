namespace BATODA.User_Control_Forms
{
    partial class CSUForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InboxFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.ReplyButton = new BATODA.ButtonStyle();
            this.CloseMessage = new BATODA.ButtonStyle();
            this.DateLbl = new System.Windows.Forms.Label();
            this.FromLbl = new System.Windows.Forms.Label();
            this.ContentTxt = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReplyPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SendReplyButton = new BATODA.ButtonStyle();
            this.ReplyContentRTextbox = new System.Windows.Forms.RichTextBox();
            this.CancelReplyButton = new BATODA.ButtonStyle();
            this.MembersTopPanel = new System.Windows.Forms.Panel();
            this.GFormRcvButton = new BATODA.ButtonStyle();
            this.EmailRcvButton = new BATODA.ButtonStyle();
            this.MessagePanel.SuspendLayout();
            this.ReplyPanel.SuspendLayout();
            this.MembersTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InboxFlowLayoutPanel
            // 
            this.InboxFlowLayoutPanel.AutoScroll = true;
            this.InboxFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.InboxFlowLayoutPanel.Location = new System.Drawing.Point(105, 81);
            this.InboxFlowLayoutPanel.Name = "InboxFlowLayoutPanel";
            this.InboxFlowLayoutPanel.Size = new System.Drawing.Size(1095, 820);
            this.InboxFlowLayoutPanel.TabIndex = 57;
            // 
            // MessagePanel
            // 
            this.MessagePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MessagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessagePanel.Controls.Add(this.ReplyButton);
            this.MessagePanel.Controls.Add(this.CloseMessage);
            this.MessagePanel.Controls.Add(this.DateLbl);
            this.MessagePanel.Controls.Add(this.FromLbl);
            this.MessagePanel.Controls.Add(this.ContentTxt);
            this.MessagePanel.Controls.Add(this.label4);
            this.MessagePanel.Controls.Add(this.label3);
            this.MessagePanel.Controls.Add(this.label2);
            this.MessagePanel.Location = new System.Drawing.Point(905, 72);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(679, 865);
            this.MessagePanel.TabIndex = 1;
            this.MessagePanel.Visible = false;
            // 
            // ReplyButton
            // 
            this.ReplyButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReplyButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.ReplyButton.BorderColor = System.Drawing.Color.White;
            this.ReplyButton.BorderRadius = 0;
            this.ReplyButton.BorderSize = 0;
            this.ReplyButton.ButtonImage = global::BATODA.Properties.Resources.edit_hover;
            this.ReplyButton.FlatAppearance.BorderSize = 0;
            this.ReplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReplyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.ReplyButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.ReplyButton.HoverColor = System.Drawing.Color.Silver;
            this.ReplyButton.ImageColor = System.Drawing.Color.IndianRed;
            this.ReplyButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.ReplyButton.ImageSize = new System.Drawing.Size(32, 32);
            this.ReplyButton.IsToggled = false;
            this.ReplyButton.Location = new System.Drawing.Point(446, 95);
            this.ReplyButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.ReplyButton.Name = "ReplyButton";
            this.ReplyButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ReplyButton.PaddingX = 0;
            this.ReplyButton.PaddingY = 0;
            this.ReplyButton.Size = new System.Drawing.Size(127, 29);
            this.ReplyButton.TabIndex = 10;
            this.ReplyButton.Text = "Reply";
            this.ReplyButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.ReplyButton.TextOffset = 20;
            this.ReplyButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.ReplyButton.UseVisualStyleBackColor = false;
            this.ReplyButton.Click += new System.EventHandler(this.ReplyButton_Click);
            // 
            // CloseMessage
            // 
            this.CloseMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CloseMessage.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CloseMessage.BorderColor = System.Drawing.Color.White;
            this.CloseMessage.BorderRadius = 0;
            this.CloseMessage.BorderSize = 0;
            this.CloseMessage.ButtonImage = global::BATODA.Properties.Resources.back;
            this.CloseMessage.FlatAppearance.BorderSize = 0;
            this.CloseMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CloseMessage.HoverBorderColor = System.Drawing.Color.Silver;
            this.CloseMessage.HoverColor = System.Drawing.Color.Silver;
            this.CloseMessage.ImageColor = System.Drawing.Color.White;
            this.CloseMessage.ImagePosition = new System.Drawing.Point(20, 0);
            this.CloseMessage.ImageSize = new System.Drawing.Size(32, 32);
            this.CloseMessage.IsToggled = false;
            this.CloseMessage.Location = new System.Drawing.Point(3, 8);
            this.CloseMessage.MouseDownColor = System.Drawing.Color.LightGray;
            this.CloseMessage.Name = "CloseMessage";
            this.CloseMessage.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.CloseMessage.PaddingX = 0;
            this.CloseMessage.PaddingY = 0;
            this.CloseMessage.Size = new System.Drawing.Size(57, 42);
            this.CloseMessage.TabIndex = 9;
            this.CloseMessage.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CloseMessage.TextOffset = 20;
            this.CloseMessage.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CloseMessage.UseVisualStyleBackColor = false;
            this.CloseMessage.Click += new System.EventHandler(this.CloseMessage_Click_1);
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DateLbl.Location = new System.Drawing.Point(510, 65);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(100, 24);
            this.DateLbl.TabIndex = 5;
            this.DateLbl.Text = "12/25/2025";
            // 
            // FromLbl
            // 
            this.FromLbl.AutoSize = true;
            this.FromLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.FromLbl.Location = new System.Drawing.Point(77, 65);
            this.FromLbl.Name = "FromLbl";
            this.FromLbl.Size = new System.Drawing.Size(145, 24);
            this.FromLbl.TabIndex = 4;
            this.FromLbl.Text = "GmailUsername";
            // 
            // ContentTxt
            // 
            this.ContentTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentTxt.Enabled = false;
            this.ContentTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentTxt.Location = new System.Drawing.Point(24, 134);
            this.ContentTxt.Name = "ContentTxt";
            this.ContentTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ContentTxt.Size = new System.Drawing.Size(630, 713);
            this.ContentTxt.TabIndex = 3;
            this.ContentTxt.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Content:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(465, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "From:";
            // 
            // ReplyPanel
            // 
            this.ReplyPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReplyPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReplyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReplyPanel.Controls.Add(this.label6);
            this.ReplyPanel.Controls.Add(this.label5);
            this.ReplyPanel.Controls.Add(this.SendReplyButton);
            this.ReplyPanel.Controls.Add(this.ReplyContentRTextbox);
            this.ReplyPanel.Controls.Add(this.CancelReplyButton);
            this.ReplyPanel.Location = new System.Drawing.Point(341, 163);
            this.ReplyPanel.Name = "ReplyPanel";
            this.ReplyPanel.Size = new System.Drawing.Size(560, 655);
            this.ReplyPanel.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(367, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "GmailUsername";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(279, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Reply to : ";
            // 
            // SendReplyButton
            // 
            this.SendReplyButton.BackColor = System.Drawing.Color.White;
            this.SendReplyButton.BackgroundColor = System.Drawing.Color.White;
            this.SendReplyButton.BorderColor = System.Drawing.Color.White;
            this.SendReplyButton.BorderRadius = 0;
            this.SendReplyButton.BorderSize = 0;
            this.SendReplyButton.ButtonImage = global::BATODA.Properties.Resources.request;
            this.SendReplyButton.FlatAppearance.BorderSize = 0;
            this.SendReplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendReplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendReplyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.SendReplyButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.SendReplyButton.HoverColor = System.Drawing.Color.Silver;
            this.SendReplyButton.ImageColor = System.Drawing.Color.White;
            this.SendReplyButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.SendReplyButton.ImageSize = new System.Drawing.Size(32, 32);
            this.SendReplyButton.IsToggled = false;
            this.SendReplyButton.Location = new System.Drawing.Point(351, 603);
            this.SendReplyButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.SendReplyButton.Name = "SendReplyButton";
            this.SendReplyButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.SendReplyButton.PaddingX = 0;
            this.SendReplyButton.PaddingY = 0;
            this.SendReplyButton.Size = new System.Drawing.Size(189, 38);
            this.SendReplyButton.TabIndex = 12;
            this.SendReplyButton.Text = "Send Reply";
            this.SendReplyButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.SendReplyButton.TextOffset = 20;
            this.SendReplyButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.SendReplyButton.UseVisualStyleBackColor = false;
            this.SendReplyButton.Click += new System.EventHandler(this.SendReplyButton_Click);
            // 
            // ReplyContentRTextbox
            // 
            this.ReplyContentRTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReplyContentRTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReplyContentRTextbox.Location = new System.Drawing.Point(20, 52);
            this.ReplyContentRTextbox.Name = "ReplyContentRTextbox";
            this.ReplyContentRTextbox.Size = new System.Drawing.Size(520, 541);
            this.ReplyContentRTextbox.TabIndex = 11;
            this.ReplyContentRTextbox.Text = "";
            // 
            // CancelReplyButton
            // 
            this.CancelReplyButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelReplyButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CancelReplyButton.BorderColor = System.Drawing.Color.White;
            this.CancelReplyButton.BorderRadius = 0;
            this.CancelReplyButton.BorderSize = 0;
            this.CancelReplyButton.ButtonImage = global::BATODA.Properties.Resources.back;
            this.CancelReplyButton.FlatAppearance.BorderSize = 0;
            this.CancelReplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelReplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelReplyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CancelReplyButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.CancelReplyButton.HoverColor = System.Drawing.Color.Silver;
            this.CancelReplyButton.ImageColor = System.Drawing.Color.White;
            this.CancelReplyButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.CancelReplyButton.ImageSize = new System.Drawing.Size(32, 32);
            this.CancelReplyButton.IsToggled = false;
            this.CancelReplyButton.Location = new System.Drawing.Point(0, 6);
            this.CancelReplyButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.CancelReplyButton.Name = "CancelReplyButton";
            this.CancelReplyButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.CancelReplyButton.PaddingX = 0;
            this.CancelReplyButton.PaddingY = 0;
            this.CancelReplyButton.Size = new System.Drawing.Size(57, 44);
            this.CancelReplyButton.TabIndex = 10;
            this.CancelReplyButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CancelReplyButton.TextOffset = 20;
            this.CancelReplyButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CancelReplyButton.UseVisualStyleBackColor = false;
            this.CancelReplyButton.Click += new System.EventHandler(this.CancelReplyButton_Click);
            // 
            // MembersTopPanel
            // 
            this.MembersTopPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersTopPanel.Controls.Add(this.GFormRcvButton);
            this.MembersTopPanel.Controls.Add(this.EmailRcvButton);
            this.MembersTopPanel.Location = new System.Drawing.Point(50, 3);
            this.MembersTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MembersTopPanel.Name = "MembersTopPanel";
            this.MembersTopPanel.Size = new System.Drawing.Size(1534, 62);
            this.MembersTopPanel.TabIndex = 60;
            // 
            // GFormRcvButton
            // 
            this.GFormRcvButton.BackColor = System.Drawing.Color.White;
            this.GFormRcvButton.BackgroundColor = System.Drawing.Color.White;
            this.GFormRcvButton.BorderColor = System.Drawing.Color.Black;
            this.GFormRcvButton.BorderRadius = 0;
            this.GFormRcvButton.BorderSize = 0;
            this.GFormRcvButton.ButtonImage = global::BATODA.Properties.Resources.history;
            this.GFormRcvButton.FlatAppearance.BorderSize = 0;
            this.GFormRcvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GFormRcvButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GFormRcvButton.ForeColor = System.Drawing.Color.Black;
            this.GFormRcvButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.GFormRcvButton.HoverColor = System.Drawing.Color.Silver;
            this.GFormRcvButton.ImageColor = System.Drawing.Color.Black;
            this.GFormRcvButton.ImagePosition = new System.Drawing.Point(255, 0);
            this.GFormRcvButton.ImageSize = new System.Drawing.Size(32, 32);
            this.GFormRcvButton.IsToggled = false;
            this.GFormRcvButton.Location = new System.Drawing.Point(763, 5);
            this.GFormRcvButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GFormRcvButton.MouseDownColor = System.Drawing.Color.DarkGray;
            this.GFormRcvButton.Name = "GFormRcvButton";
            this.GFormRcvButton.PaddingX = 0;
            this.GFormRcvButton.PaddingY = 0;
            this.GFormRcvButton.Size = new System.Drawing.Size(766, 49);
            this.GFormRcvButton.TabIndex = 21;
            this.GFormRcvButton.Text = "Form Recieved";
            this.GFormRcvButton.TextColor = System.Drawing.Color.Black;
            this.GFormRcvButton.TextOffset = 20;
            this.GFormRcvButton.ToggleColor = System.Drawing.Color.LightGray;
            this.GFormRcvButton.UseVisualStyleBackColor = false;
            this.GFormRcvButton.Click += new System.EventHandler(this.GFormRcvButton_Click);
            // 
            // EmailRcvButton
            // 
            this.EmailRcvButton.BackColor = System.Drawing.Color.Gainsboro;
            this.EmailRcvButton.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.EmailRcvButton.BorderColor = System.Drawing.Color.Black;
            this.EmailRcvButton.BorderRadius = 0;
            this.EmailRcvButton.BorderSize = 0;
            this.EmailRcvButton.ButtonImage = global::BATODA.Properties.Resources.add;
            this.EmailRcvButton.FlatAppearance.BorderSize = 0;
            this.EmailRcvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmailRcvButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailRcvButton.ForeColor = System.Drawing.Color.Black;
            this.EmailRcvButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.EmailRcvButton.HoverColor = System.Drawing.Color.Silver;
            this.EmailRcvButton.ImageColor = System.Drawing.Color.Black;
            this.EmailRcvButton.ImagePosition = new System.Drawing.Point(265, 0);
            this.EmailRcvButton.ImageSize = new System.Drawing.Size(32, 32);
            this.EmailRcvButton.IsToggled = false;
            this.EmailRcvButton.Location = new System.Drawing.Point(6, 5);
            this.EmailRcvButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EmailRcvButton.MouseDownColor = System.Drawing.Color.DarkGray;
            this.EmailRcvButton.Name = "EmailRcvButton";
            this.EmailRcvButton.PaddingX = 0;
            this.EmailRcvButton.PaddingY = 0;
            this.EmailRcvButton.Size = new System.Drawing.Size(751, 49);
            this.EmailRcvButton.TabIndex = 19;
            this.EmailRcvButton.Text = "Email Recieved";
            this.EmailRcvButton.TextColor = System.Drawing.Color.Black;
            this.EmailRcvButton.TextOffset = 20;
            this.EmailRcvButton.ToggleColor = System.Drawing.Color.LightGray;
            this.EmailRcvButton.UseVisualStyleBackColor = false;
            // 
            // CSUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.MembersTopPanel);
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.ReplyPanel);
            this.Controls.Add(this.InboxFlowLayoutPanel);
            this.Name = "CSUForm";
            this.Size = new System.Drawing.Size(1768, 998);
            this.Load += new System.EventHandler(this.CSUForm_Load);
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            this.ReplyPanel.ResumeLayout(false);
            this.ReplyPanel.PerformLayout();
            this.MembersTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel InboxFlowLayoutPanel;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Label DateLbl;
        private System.Windows.Forms.Label FromLbl;
        private System.Windows.Forms.RichTextBox ContentTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ButtonStyle CloseMessage;
        private ButtonStyle ReplyButton;
        private System.Windows.Forms.Panel ReplyPanel;
        private ButtonStyle SendReplyButton;
        private System.Windows.Forms.RichTextBox ReplyContentRTextbox;
        private ButtonStyle CancelReplyButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel MembersTopPanel;
        private ButtonStyle GFormRcvButton;
        private ButtonStyle EmailRcvButton;
    }
}
