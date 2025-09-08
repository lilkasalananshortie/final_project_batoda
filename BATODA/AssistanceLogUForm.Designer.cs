namespace BATODA
{
    partial class AssistanceLogUForm
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
            this.ARHButton = new System.Windows.Forms.Button();
            this.AssistanceRequestButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(851, 225);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assistance Log \r\nthe main button in assistance\r\n- the defalult view when the butt" +
    "on is pressed \r\n- must have a dashboard with the ff\r\n - log - last approved - mo" +
    "re ??? to be added";
            // 
            // ARHButton
            // 
            this.ARHButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARHButton.ForeColor = System.Drawing.Color.Black;
            this.ARHButton.Location = new System.Drawing.Point(123, 56);
            this.ARHButton.Name = "ARHButton";
            this.ARHButton.Size = new System.Drawing.Size(321, 89);
            this.ARHButton.TabIndex = 6;
            this.ARHButton.Text = "Approved Reqest History";
            this.ARHButton.UseVisualStyleBackColor = true;
            // 
            // AssistanceRequestButton
            // 
            this.AssistanceRequestButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceRequestButton.ForeColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.Location = new System.Drawing.Point(464, 56);
            this.AssistanceRequestButton.Name = "AssistanceRequestButton";
            this.AssistanceRequestButton.Size = new System.Drawing.Size(321, 89);
            this.AssistanceRequestButton.TabIndex = 7;
            this.AssistanceRequestButton.Text = "Assistance Request";
            this.AssistanceRequestButton.UseVisualStyleBackColor = true;
            // 
            // AssistanceLogUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.AssistanceRequestButton);
            this.Controls.Add(this.ARHButton);
            this.Controls.Add(this.label1);
            this.Name = "AssistanceLogUForm";
            this.Size = new System.Drawing.Size(1176, 704);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ARHButton;
        private System.Windows.Forms.Button AssistanceRequestButton;
    }
}
