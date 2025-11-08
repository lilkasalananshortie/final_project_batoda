namespace BATODA.User_Control_Forms
{
    partial class ActivityassistanceLog
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
            this.PictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.LabelRequestAction = new System.Windows.Forms.Label();
            this.LabelRequestInfo = new System.Windows.Forms.Label();
            this.LabelTimeStamp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxStatus
            // 
            this.PictureBoxStatus.Location = new System.Drawing.Point(9, 12);
            this.PictureBoxStatus.Name = "PictureBoxStatus";
            this.PictureBoxStatus.Size = new System.Drawing.Size(57, 50);
            this.PictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxStatus.TabIndex = 0;
            this.PictureBoxStatus.TabStop = false;
            // 
            // LabelRequestAction
            // 
            this.LabelRequestAction.AutoSize = true;
            this.LabelRequestAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRequestAction.Location = new System.Drawing.Point(72, 13);
            this.LabelRequestAction.Name = "LabelRequestAction";
            this.LabelRequestAction.Size = new System.Drawing.Size(52, 18);
            this.LabelRequestAction.TabIndex = 1;
            this.LabelRequestAction.Text = "label1";
            // 
            // LabelRequestInfo
            // 
            this.LabelRequestInfo.AutoSize = true;
            this.LabelRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRequestInfo.Location = new System.Drawing.Point(72, 36);
            this.LabelRequestInfo.Name = "LabelRequestInfo";
            this.LabelRequestInfo.Size = new System.Drawing.Size(44, 16);
            this.LabelRequestInfo.TabIndex = 1;
            this.LabelRequestInfo.Text = "label1";
            // 
            // LabelTimeStamp
            // 
            this.LabelTimeStamp.AutoSize = true;
            this.LabelTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTimeStamp.Location = new System.Drawing.Point(254, 4);
            this.LabelTimeStamp.Name = "LabelTimeStamp";
            this.LabelTimeStamp.Size = new System.Drawing.Size(35, 13);
            this.LabelTimeStamp.TabIndex = 1;
            this.LabelTimeStamp.Text = "label1";
            // 
            // ActivityassistanceLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LabelTimeStamp);
            this.Controls.Add(this.LabelRequestInfo);
            this.Controls.Add(this.LabelRequestAction);
            this.Controls.Add(this.PictureBoxStatus);
            this.Name = "ActivityassistanceLog";
            this.Size = new System.Drawing.Size(318, 79);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxStatus;
        private System.Windows.Forms.Label LabelRequestAction;
        private System.Windows.Forms.Label LabelRequestInfo;
        private System.Windows.Forms.Label LabelTimeStamp;
    }
}
