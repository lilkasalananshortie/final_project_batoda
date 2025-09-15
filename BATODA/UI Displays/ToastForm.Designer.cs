using System.Windows.Forms;

namespace BATODA.UI_Displays
{
    
    partial class ToastForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox iconTextBox;
        private Label label1;
        private Panel progressBarPanel;
        private Panel progressFillPanel;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.iconTextBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarPanel = new System.Windows.Forms.Panel();
            this.progressFillPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SideColorPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.iconTextBox)).BeginInit();
            this.progressBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconTextBox
            // 
            this.iconTextBox.Location = new System.Drawing.Point(43, 19);
            this.iconTextBox.Name = "iconTextBox";
            this.iconTextBox.Size = new System.Drawing.Size(36, 32);
            this.iconTextBox.TabIndex = 2;
            this.iconTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "message placeholder";
            // 
            // progressBarPanel
            // 
            this.progressBarPanel.BackColor = System.Drawing.Color.LightGray;
            this.progressBarPanel.Controls.Add(this.progressFillPanel);
            this.progressBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarPanel.Location = new System.Drawing.Point(0, 69);
            this.progressBarPanel.Name = "progressBarPanel";
            this.progressBarPanel.Size = new System.Drawing.Size(374, 3);
            this.progressBarPanel.TabIndex = 3;
            // 
            // progressFillPanel
            // 
            this.progressFillPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.progressFillPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.progressFillPanel.Location = new System.Drawing.Point(0, 0);
            this.progressFillPanel.Name = "progressFillPanel";
            this.progressFillPanel.Size = new System.Drawing.Size(0, 3);
            this.progressFillPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(348, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 21);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            // 
            // SideColorPanel
            // 
            this.SideColorPanel.Location = new System.Drawing.Point(0, 0);
            this.SideColorPanel.Name = "SideColorPanel";
            this.SideColorPanel.Size = new System.Drawing.Size(21, 69);
            this.SideColorPanel.TabIndex = 4;
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 72);
            this.Controls.Add(this.SideColorPanel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iconTextBox);
            this.Controls.Add(this.progressBarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToastForm";
            ((System.ComponentModel.ISupportInitialize)(this.iconTextBox)).EndInit();
            this.progressBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel SideColorPanel;
    }
}