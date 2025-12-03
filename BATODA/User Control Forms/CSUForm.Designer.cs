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
            this.EditBodyNoPreviewLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InboxFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TESTPANEL = new System.Windows.Forms.Button();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.CloseMessage = new System.Windows.Forms.Button();
            this.DateLbl = new System.Windows.Forms.Label();
            this.FromLbl = new System.Windows.Forms.Label();
            this.ContentTxt = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBodyNoPreviewLbl
            // 
            this.EditBodyNoPreviewLbl.AutoSize = true;
            this.EditBodyNoPreviewLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBodyNoPreviewLbl.Location = new System.Drawing.Point(31, 64);
            this.EditBodyNoPreviewLbl.Name = "EditBodyNoPreviewLbl";
            this.EditBodyNoPreviewLbl.Size = new System.Drawing.Size(440, 42);
            this.EditBodyNoPreviewLbl.TabIndex = 54;
            this.EditBodyNoPreviewLbl.Text = "Messages / Placeholder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1251, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 42);
            this.label1.TabIndex = 55;
            this.label1.Text = "Time / Placeholder";
            // 
            // InboxFlowLayoutPanel
            // 
            this.InboxFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.InboxFlowLayoutPanel.Location = new System.Drawing.Point(50, 137);
            this.InboxFlowLayoutPanel.Name = "InboxFlowLayoutPanel";
            this.InboxFlowLayoutPanel.Size = new System.Drawing.Size(1547, 1000);
            this.InboxFlowLayoutPanel.TabIndex = 57;
            // 
            // TESTPANEL
            // 
            this.TESTPANEL.Location = new System.Drawing.Point(477, 64);
            this.TESTPANEL.Name = "TESTPANEL";
            this.TESTPANEL.Size = new System.Drawing.Size(190, 42);
            this.TESTPANEL.TabIndex = 58;
            this.TESTPANEL.Text = "PANG TEST";
            this.TESTPANEL.UseVisualStyleBackColor = true;
            this.TESTPANEL.Click += new System.EventHandler(this.TESTPANEL_Click);
            // 
            // MessagePanel
            // 
            this.MessagePanel.Controls.Add(this.CloseMessage);
            this.MessagePanel.Controls.Add(this.DateLbl);
            this.MessagePanel.Controls.Add(this.FromLbl);
            this.MessagePanel.Controls.Add(this.ContentTxt);
            this.MessagePanel.Controls.Add(this.label4);
            this.MessagePanel.Controls.Add(this.label3);
            this.MessagePanel.Controls.Add(this.label2);
            this.MessagePanel.Location = new System.Drawing.Point(504, 168);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(694, 650);
            this.MessagePanel.TabIndex = 1;
            this.MessagePanel.Visible = false;
            // 
            // CloseMessage
            // 
            this.CloseMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseMessage.Location = new System.Drawing.Point(35, 17);
            this.CloseMessage.Name = "CloseMessage";
            this.CloseMessage.Size = new System.Drawing.Size(38, 34);
            this.CloseMessage.TabIndex = 6;
            this.CloseMessage.Text = "<";
            this.CloseMessage.UseVisualStyleBackColor = true;
            this.CloseMessage.Click += new System.EventHandler(this.CloseMessage_Click);
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DateLbl.Location = new System.Drawing.Point(558, 65);
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
            this.ContentTxt.Enabled = false;
            this.ContentTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentTxt.Location = new System.Drawing.Point(35, 134);
            this.ContentTxt.Name = "ContentTxt";
            this.ContentTxt.Size = new System.Drawing.Size(623, 487);
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
            this.label3.Location = new System.Drawing.Point(513, 65);
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
            // CSUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.MessagePanel);
            this.Controls.Add(this.TESTPANEL);
            this.Controls.Add(this.InboxFlowLayoutPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditBodyNoPreviewLbl);
            this.Name = "CSUForm";
            this.Size = new System.Drawing.Size(1768, 938);
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label EditBodyNoPreviewLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel InboxFlowLayoutPanel;
        private System.Windows.Forms.Button TESTPANEL;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Button CloseMessage;
        private System.Windows.Forms.Label DateLbl;
        private System.Windows.Forms.Label FromLbl;
        private System.Windows.Forms.RichTextBox ContentTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
