namespace BATODA
{
    partial class RegisteredVehicleUForm
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
            this.TransferVehicleButton = new System.Windows.Forms.Button();
            this.TransferRecordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1556, 129);
            this.label1.TabIndex = 2;
            this.label1.Text = "REGISTERED VEHCILE\r\n- MUST HAVE A MINI DASHBOARD OVERVIEW NG KUNG ANO YUNG REGIS " +
    "VEHICLE\r\n- DUNNO PA BUT CAN ADD BUTTON THAT WILL SHOW OR MAPUNTA SA SUB BUTTON N" +
    "ETO\r\n";
            // 
            // TransferVehicleButton
            // 
            this.TransferVehicleButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferVehicleButton.ForeColor = System.Drawing.Color.Black;
            this.TransferVehicleButton.Location = new System.Drawing.Point(186, 57);
            this.TransferVehicleButton.Name = "TransferVehicleButton";
            this.TransferVehicleButton.Size = new System.Drawing.Size(321, 89);
            this.TransferVehicleButton.TabIndex = 6;
            this.TransferVehicleButton.Text = "Transfer Vehicle \r\nRegistration\r\n";
            this.TransferVehicleButton.UseVisualStyleBackColor = true;
            // 
            // TransferRecordButton
            // 
            this.TransferRecordButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferRecordButton.ForeColor = System.Drawing.Color.Black;
            this.TransferRecordButton.Location = new System.Drawing.Point(627, 334);
            this.TransferRecordButton.Name = "TransferRecordButton";
            this.TransferRecordButton.Size = new System.Drawing.Size(321, 89);
            this.TransferRecordButton.TabIndex = 7;
            this.TransferRecordButton.Text = "Transfer Record";
            this.TransferRecordButton.UseVisualStyleBackColor = true;
            // 
            // RegisteredVehicleUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.Controls.Add(this.TransferRecordButton);
            this.Controls.Add(this.TransferVehicleButton);
            this.Controls.Add(this.label1);
            this.Name = "RegisteredVehicleUForm";
            this.Size = new System.Drawing.Size(1574, 756);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TransferVehicleButton;
        private System.Windows.Forms.Button TransferRecordButton;
    }
}
