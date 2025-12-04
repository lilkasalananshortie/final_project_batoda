namespace BATODA.User_Control_Forms
{
    partial class GFormUForm
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
            this.MembersTopPanel = new System.Windows.Forms.Panel();
            this.GFormFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.DateLbl = new System.Windows.Forms.Label();
            this.FromLbl = new System.Windows.Forms.Label();
            this.ContentTxt = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReplyButton = new BATODA.ButtonStyle();
            this.CloseMessage = new BATODA.ButtonStyle();
            this.ARHButton = new BATODA.ButtonStyle();
            this.EmailRcvButton = new BATODA.ButtonStyle();
            this.MembersTopPanel.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MembersTopPanel
            // 
            this.MembersTopPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersTopPanel.Controls.Add(this.ARHButton);
            this.MembersTopPanel.Controls.Add(this.EmailRcvButton);
            this.MembersTopPanel.Location = new System.Drawing.Point(50, 3);
            this.MembersTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MembersTopPanel.Name = "MembersTopPanel";
            this.MembersTopPanel.Size = new System.Drawing.Size(1534, 62);
            this.MembersTopPanel.TabIndex = 61;
            this.MembersTopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MembersTopPanel_Paint);
            // 
            // GFormFlowLayoutPanel
            // 
            this.GFormFlowLayoutPanel.AutoScroll = true;
            this.GFormFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.GFormFlowLayoutPanel.Location = new System.Drawing.Point(50, 70);
            this.GFormFlowLayoutPanel.Name = "GFormFlowLayoutPanel";
            this.GFormFlowLayoutPanel.Size = new System.Drawing.Size(1534, 1067);
            this.GFormFlowLayoutPanel.TabIndex = 62;
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
            this.MessagePanel.Location = new System.Drawing.Point(818, 118);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(653, 381);
            this.MessagePanel.TabIndex = 63;
            this.MessagePanel.Visible = false;
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DateLbl.Location = new System.Drawing.Point(477, 65);
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
            this.FromLbl.Location = new System.Drawing.Point(86, 65);
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
            this.ContentTxt.Location = new System.Drawing.Point(11, 134);
            this.ContentTxt.Name = "ContentTxt";
            this.ContentTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ContentTxt.Size = new System.Drawing.Size(628, 232);
            this.ContentTxt.TabIndex = 3;
            this.ContentTxt.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Content:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(432, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "From:";
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
            this.ReplyButton.Location = new System.Drawing.Point(412, 92);
            this.ReplyButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.ReplyButton.Name = "ReplyButton";
            this.ReplyButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ReplyButton.PaddingX = 0;
            this.ReplyButton.PaddingY = 0;
            this.ReplyButton.Size = new System.Drawing.Size(141, 33);
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
            this.CloseMessage.Location = new System.Drawing.Point(12, 3);
            this.CloseMessage.MouseDownColor = System.Drawing.Color.LightGray;
            this.CloseMessage.Name = "CloseMessage";
            this.CloseMessage.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.CloseMessage.PaddingX = 0;
            this.CloseMessage.PaddingY = 0;
            this.CloseMessage.Size = new System.Drawing.Size(71, 59);
            this.CloseMessage.TabIndex = 9;
            this.CloseMessage.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CloseMessage.TextOffset = 20;
            this.CloseMessage.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CloseMessage.UseVisualStyleBackColor = false;
            this.CloseMessage.Click += new System.EventHandler(this.CloseMessage_Click);
            // 
            // ARHButton
            // 
            this.ARHButton.BackColor = System.Drawing.Color.LightGray;
            this.ARHButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.ARHButton.BorderColor = System.Drawing.Color.Black;
            this.ARHButton.BorderRadius = 0;
            this.ARHButton.BorderSize = 0;
            this.ARHButton.ButtonImage = global::BATODA.Properties.Resources.history;
            this.ARHButton.FlatAppearance.BorderSize = 0;
            this.ARHButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ARHButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARHButton.ForeColor = System.Drawing.Color.Black;
            this.ARHButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.ARHButton.HoverColor = System.Drawing.Color.Silver;
            this.ARHButton.ImageColor = System.Drawing.Color.Black;
            this.ARHButton.ImagePosition = new System.Drawing.Point(255, 0);
            this.ARHButton.ImageSize = new System.Drawing.Size(32, 32);
            this.ARHButton.IsToggled = false;
            this.ARHButton.Location = new System.Drawing.Point(763, 5);
            this.ARHButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ARHButton.MouseDownColor = System.Drawing.Color.DarkGray;
            this.ARHButton.Name = "ARHButton";
            this.ARHButton.PaddingX = 0;
            this.ARHButton.PaddingY = 0;
            this.ARHButton.Size = new System.Drawing.Size(766, 49);
            this.ARHButton.TabIndex = 21;
            this.ARHButton.Text = "Form Recieved";
            this.ARHButton.TextColor = System.Drawing.Color.Black;
            this.ARHButton.TextOffset = 20;
            this.ARHButton.ToggleColor = System.Drawing.Color.LightGray;
            this.ARHButton.UseVisualStyleBackColor = false;
            // 
            // EmailRcvButton
            // 
            this.EmailRcvButton.BackColor = System.Drawing.Color.White;
            this.EmailRcvButton.BackgroundColor = System.Drawing.Color.White;
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
            this.EmailRcvButton.Click += new System.EventHandler(this.EmailRcvButton_Click);
            // 
            // GFormUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.GFormFlowLayoutPanel);
            this.Controls.Add(this.MembersTopPanel);
            this.Name = "GFormUForm";
            this.Size = new System.Drawing.Size(1813, 1000);
            this.MembersTopPanel.ResumeLayout(false);
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MembersTopPanel;
        private ButtonStyle ARHButton;
        private ButtonStyle EmailRcvButton;
        private System.Windows.Forms.FlowLayoutPanel GFormFlowLayoutPanel;
        private System.Windows.Forms.Panel MessagePanel;
        private ButtonStyle ReplyButton;
        private ButtonStyle CloseMessage;
        private System.Windows.Forms.Label DateLbl;
        private System.Windows.Forms.Label FromLbl;
        private System.Windows.Forms.RichTextBox ContentTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
