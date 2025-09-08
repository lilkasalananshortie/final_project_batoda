namespace BATODA
{
    partial class FinanceUForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ButawButton = new System.Windows.Forms.Button();
            this.MembershipRenewalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1124, 129);
            this.label1.TabIndex = 2;
            this.label1.Text = "Finance\r\nMAIN button to kapag pinindot so mostly display only,\r\n- OVERVIEW NG PIN" +
    "AKA FINANCEIAL SITUATION NA NANGYAYARI\r\n";
            // 
            // ButawButton
            // 
            this.ButawButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButawButton.ForeColor = System.Drawing.Color.Black;
            this.ButawButton.Location = new System.Drawing.Point(454, 50);
            this.ButawButton.Name = "ButawButton";
            this.ButawButton.Size = new System.Drawing.Size(321, 89);
            this.ButawButton.TabIndex = 5;
            this.ButawButton.Text = "Butaw";
            this.ButawButton.UseVisualStyleBackColor = true;
            // 
            // MembershipRenewalButton
            // 
            this.MembershipRenewalButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembershipRenewalButton.ForeColor = System.Drawing.Color.Black;
            this.MembershipRenewalButton.Location = new System.Drawing.Point(114, 50);
            this.MembershipRenewalButton.Name = "MembershipRenewalButton";
            this.MembershipRenewalButton.Size = new System.Drawing.Size(321, 89);
            this.MembershipRenewalButton.TabIndex = 6;
            this.MembershipRenewalButton.Text = "Membership Renewal";
            this.MembershipRenewalButton.UseVisualStyleBackColor = true;
            // 
            // FinanceUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.Controls.Add(this.MembershipRenewalButton);
            this.Controls.Add(this.ButawButton);
            this.Controls.Add(this.label1);
            this.Name = "FinanceUForm";
            this.Size = new System.Drawing.Size(1143, 718);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButawButton;
        private System.Windows.Forms.Button MembershipRenewalButton;
    }
}
