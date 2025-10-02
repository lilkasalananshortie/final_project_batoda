namespace BATODA
{
    partial class SettingsUForm
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
            this.BackupButton = new BATODA.ButtonStyle();
            this.LogOutButton = new BATODA.ButtonStyle();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 78);
            this.label1.TabIndex = 2;
            this.label1.Text = "SETTINGS\r\n- DUUNO KUNG ANO LALAGAY DITO\r\n";
            // 
            // BackupButton
            // 
            this.BackupButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackupButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.BackupButton.BorderColor = System.Drawing.Color.LightGray;
            this.BackupButton.BorderRadius = 0;
            this.BackupButton.BorderSize = 0;
            this.BackupButton.ButtonImage = global::BATODA.Properties.Resources.Backup;
            this.BackupButton.FlatAppearance.BorderSize = 0;
            this.BackupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupButton.ForeColor = System.Drawing.Color.Black;
            this.BackupButton.ImageColor = System.Drawing.Color.Black;
            this.BackupButton.ImagePosition = new System.Drawing.Point(120, 22);
            this.BackupButton.ImageSize = new System.Drawing.Size(50, 50);
            this.BackupButton.Location = new System.Drawing.Point(29, 31);
            this.BackupButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(494, 100);
            this.BackupButton.TabIndex = 20;
            this.BackupButton.Text = "Back UP";
            this.BackupButton.TextColor = System.Drawing.Color.Black;
            this.BackupButton.TextPadding = 20;
            this.BackupButton.UseVisualStyleBackColor = false;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LogOutButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.LogOutButton.BorderColor = System.Drawing.Color.LightGray;
            this.LogOutButton.BorderRadius = 0;
            this.LogOutButton.BorderSize = 0;
            this.LogOutButton.ButtonImage = global::BATODA.Properties.Resources.logout;
            this.LogOutButton.FlatAppearance.BorderSize = 0;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.Black;
            this.LogOutButton.ImageColor = System.Drawing.Color.Black;
            this.LogOutButton.ImagePosition = new System.Drawing.Point(120, 22);
            this.LogOutButton.ImageSize = new System.Drawing.Size(50, 50);
            this.LogOutButton.Location = new System.Drawing.Point(529, 31);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(494, 100);
            this.LogOutButton.TabIndex = 21;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.TextColor = System.Drawing.Color.Black;
            this.LogOutButton.TextPadding = 20;
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // SettingsUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.BackupButton);
            this.Controls.Add(this.label1);
            this.Name = "SettingsUForm";
            this.Size = new System.Drawing.Size(998, 723);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ButtonStyle BackupButton;
        private ButtonStyle LogOutButton;
    }
}
