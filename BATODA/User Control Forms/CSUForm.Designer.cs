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
            // CSUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.TESTPANEL);
            this.Controls.Add(this.InboxFlowLayoutPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditBodyNoPreviewLbl);
            this.Name = "CSUForm";
            this.Size = new System.Drawing.Size(1768, 938);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label EditBodyNoPreviewLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel InboxFlowLayoutPanel;
        private System.Windows.Forms.Button TESTPANEL;
    }
}
