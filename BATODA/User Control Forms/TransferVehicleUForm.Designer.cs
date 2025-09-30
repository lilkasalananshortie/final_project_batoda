namespace BATODA
{
    partial class TransferVehicleUForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TransferPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new BATODA.ButtonStyle();
            this.SaveButton = new BATODA.ButtonStyle();
            this.SearchButton = new BATODA.ButtonStyle();
            this.TransferRecordButton = new BATODA.ButtonStyle();
            this.RegisteredVehicleButton = new BATODA.ButtonStyle();
            this.TransferVehicleButton = new BATODA.ButtonStyle();
            this.MembersTopPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TransferPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MembersTopPanel
            // 
            this.MembersTopPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersTopPanel.Controls.Add(this.TransferRecordButton);
            this.MembersTopPanel.Controls.Add(this.RegisteredVehicleButton);
            this.MembersTopPanel.Controls.Add(this.TransferVehicleButton);
            this.MembersTopPanel.Location = new System.Drawing.Point(16, 19);
            this.MembersTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MembersTopPanel.Name = "MembersTopPanel";
            this.MembersTopPanel.Size = new System.Drawing.Size(1532, 128);
            this.MembersTopPanel.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.TransferPanel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.SearchTextBox);
            this.panel1.Location = new System.Drawing.Point(16, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1532, 690);
            this.panel1.TabIndex = 23;
            // 
            // TransferPanel
            // 
            this.TransferPanel.BackColor = System.Drawing.Color.LightGray;
            this.TransferPanel.Controls.Add(this.CancelButton);
            this.TransferPanel.Controls.Add(this.SaveButton);
            this.TransferPanel.Location = new System.Drawing.Point(232, 170);
            this.TransferPanel.Name = "TransferPanel";
            this.TransferPanel.Size = new System.Drawing.Size(1035, 485);
            this.TransferPanel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 40);
            this.label3.TabIndex = 6;
            this.label3.Text = "Transfer Vehicle";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(85, 101);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(352, 44);
            this.SearchTextBox.TabIndex = 4;
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.White;
            this.CancelButton.BackgroundColor = System.Drawing.Color.White;
            this.CancelButton.BorderColor = System.Drawing.Color.DarkRed;
            this.CancelButton.BorderRadius = 0;
            this.CancelButton.BorderSize = 0;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.Black;
            this.CancelButton.Location = new System.Drawing.Point(637, 414);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(188, 54);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.TextColor = System.Drawing.Color.Black;
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.SaveButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.SaveButton.BorderColor = System.Drawing.Color.DarkRed;
            this.SaveButton.BorderRadius = 0;
            this.SaveButton.BorderSize = 0;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.Black;
            this.SaveButton.Location = new System.Drawing.Point(831, 414);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(188, 54);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.TextColor = System.Drawing.Color.Black;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.SearchButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.SearchButton.BorderColor = System.Drawing.Color.DarkRed;
            this.SearchButton.BorderRadius = 0;
            this.SearchButton.BorderSize = 0;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.ForeColor = System.Drawing.Color.Black;
            this.SearchButton.Location = new System.Drawing.Point(455, 101);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(188, 54);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Search";
            this.SearchButton.TextColor = System.Drawing.Color.Black;
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TransferRecordButton
            // 
            this.TransferRecordButton.BackColor = System.Drawing.Color.LightGray;
            this.TransferRecordButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.TransferRecordButton.BorderColor = System.Drawing.Color.LightGray;
            this.TransferRecordButton.BorderRadius = 0;
            this.TransferRecordButton.BorderSize = 0;
            this.TransferRecordButton.FlatAppearance.BorderSize = 0;
            this.TransferRecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransferRecordButton.Font = new System.Drawing.Font("Ubuntu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferRecordButton.ForeColor = System.Drawing.Color.Black;
            this.TransferRecordButton.Location = new System.Drawing.Point(1014, 14);
            this.TransferRecordButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TransferRecordButton.Name = "TransferRecordButton";
            this.TransferRecordButton.Size = new System.Drawing.Size(494, 100);
            this.TransferRecordButton.TabIndex = 21;
            this.TransferRecordButton.Text = "Transfer Records";
            this.TransferRecordButton.TextColor = System.Drawing.Color.Black;
            this.TransferRecordButton.UseVisualStyleBackColor = false;
            this.TransferRecordButton.Click += new System.EventHandler(this.TransferRecordButton_Click);
            // 
            // RegisteredVehicleButton
            // 
            this.RegisteredVehicleButton.BackColor = System.Drawing.Color.LightGray;
            this.RegisteredVehicleButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.RegisteredVehicleButton.BorderColor = System.Drawing.Color.LightGray;
            this.RegisteredVehicleButton.BorderRadius = 0;
            this.RegisteredVehicleButton.BorderSize = 0;
            this.RegisteredVehicleButton.FlatAppearance.BorderSize = 0;
            this.RegisteredVehicleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisteredVehicleButton.Font = new System.Drawing.Font("Ubuntu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisteredVehicleButton.ForeColor = System.Drawing.Color.Black;
            this.RegisteredVehicleButton.Location = new System.Drawing.Point(14, 14);
            this.RegisteredVehicleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RegisteredVehicleButton.Name = "RegisteredVehicleButton";
            this.RegisteredVehicleButton.Size = new System.Drawing.Size(494, 100);
            this.RegisteredVehicleButton.TabIndex = 20;
            this.RegisteredVehicleButton.Text = "Vehicle Information";
            this.RegisteredVehicleButton.TextColor = System.Drawing.Color.Black;
            this.RegisteredVehicleButton.UseVisualStyleBackColor = false;
            this.RegisteredVehicleButton.Click += new System.EventHandler(this.RegisteredVehicleButton_Click);
            // 
            // TransferVehicleButton
            // 
            this.TransferVehicleButton.BackColor = System.Drawing.Color.LightGray;
            this.TransferVehicleButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.TransferVehicleButton.BorderColor = System.Drawing.Color.LightGray;
            this.TransferVehicleButton.BorderRadius = 0;
            this.TransferVehicleButton.BorderSize = 0;
            this.TransferVehicleButton.FlatAppearance.BorderSize = 0;
            this.TransferVehicleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransferVehicleButton.Font = new System.Drawing.Font("Ubuntu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferVehicleButton.ForeColor = System.Drawing.Color.Black;
            this.TransferVehicleButton.Location = new System.Drawing.Point(514, 14);
            this.TransferVehicleButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TransferVehicleButton.Name = "TransferVehicleButton";
            this.TransferVehicleButton.Size = new System.Drawing.Size(494, 100);
            this.TransferVehicleButton.TabIndex = 19;
            this.TransferVehicleButton.Text = "Transfer Vehicle Registration";
            this.TransferVehicleButton.TextColor = System.Drawing.Color.Black;
            this.TransferVehicleButton.UseVisualStyleBackColor = false;
            this.TransferVehicleButton.Click += new System.EventHandler(this.TransferVehicleButton_Click);
            // 
            // TransferVehicleUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MembersTopPanel);
            this.Name = "TransferVehicleUForm";
            this.Size = new System.Drawing.Size(1583, 978);
            this.Load += new System.EventHandler(this.TransferVehicleUForm_Load);
            this.MembersTopPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TransferPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MembersTopPanel;
        private ButtonStyle TransferRecordButton;
        private ButtonStyle RegisteredVehicleButton;
        private ButtonStyle TransferVehicleButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private ButtonStyle SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Panel TransferPanel;
        private ButtonStyle CancelButton;
        private ButtonStyle SaveButton;
    }
}
