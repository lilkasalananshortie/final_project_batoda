namespace BATODA
{
    partial class TransferMembershipUForm
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
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MembersTopPanel = new System.Windows.Forms.Panel();
            this.TransferMembershipButton = new BATODA.ButtonStyle();
            this.TransferRecordsButton = new BATODA.ButtonStyle();
            this.ManageMembersButton = new BATODA.ButtonStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchButton = new BATODA.ButtonStyle();
            this.MembersTopPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 45);
            this.label1.TabIndex = 0;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Ubuntu", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(242, 79);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(265, 44);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, -14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 34);
            this.label2.TabIndex = 2;
            // 
            // MembersTopPanel
            // 
            this.MembersTopPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersTopPanel.Controls.Add(this.TransferMembershipButton);
            this.MembersTopPanel.Controls.Add(this.TransferRecordsButton);
            this.MembersTopPanel.Controls.Add(this.ManageMembersButton);
            this.MembersTopPanel.Location = new System.Drawing.Point(16, 19);
            this.MembersTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MembersTopPanel.Name = "MembersTopPanel";
            this.MembersTopPanel.Size = new System.Drawing.Size(1532, 128);
            this.MembersTopPanel.TabIndex = 19;
            // 
            // TransferMembershipButton
            // 
            this.TransferMembershipButton.BackColor = System.Drawing.Color.LightGray;
            this.TransferMembershipButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.TransferMembershipButton.BorderColor = System.Drawing.Color.LightGray;
            this.TransferMembershipButton.BorderRadius = 0;
            this.TransferMembershipButton.BorderSize = 0;
            this.TransferMembershipButton.FlatAppearance.BorderSize = 0;
            this.TransferMembershipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransferMembershipButton.Font = new System.Drawing.Font("Ubuntu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferMembershipButton.ForeColor = System.Drawing.Color.Black;
            this.TransferMembershipButton.Location = new System.Drawing.Point(520, 11);
            this.TransferMembershipButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TransferMembershipButton.Name = "TransferMembershipButton";
            this.TransferMembershipButton.Size = new System.Drawing.Size(494, 100);
            this.TransferMembershipButton.TabIndex = 21;
            this.TransferMembershipButton.Text = "Transfer Membership";
            this.TransferMembershipButton.TextColor = System.Drawing.Color.Black;
            this.TransferMembershipButton.UseVisualStyleBackColor = false;
            this.TransferMembershipButton.Click += new System.EventHandler(this.TransferMembershipButton_Click);
            // 
            // TransferRecordsButton
            // 
            this.TransferRecordsButton.BackColor = System.Drawing.Color.LightGray;
            this.TransferRecordsButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.TransferRecordsButton.BorderColor = System.Drawing.Color.LightGray;
            this.TransferRecordsButton.BorderRadius = 0;
            this.TransferRecordsButton.BorderSize = 0;
            this.TransferRecordsButton.FlatAppearance.BorderSize = 0;
            this.TransferRecordsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransferRecordsButton.Font = new System.Drawing.Font("Ubuntu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferRecordsButton.ForeColor = System.Drawing.Color.Black;
            this.TransferRecordsButton.Location = new System.Drawing.Point(1027, 11);
            this.TransferRecordsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TransferRecordsButton.Name = "TransferRecordsButton";
            this.TransferRecordsButton.Size = new System.Drawing.Size(494, 100);
            this.TransferRecordsButton.TabIndex = 20;
            this.TransferRecordsButton.Text = "Transfer History";
            this.TransferRecordsButton.TextColor = System.Drawing.Color.Black;
            this.TransferRecordsButton.UseVisualStyleBackColor = false;
            this.TransferRecordsButton.Click += new System.EventHandler(this.TransferRecordsButton_Click);
            // 
            // ManageMembersButton
            // 
            this.ManageMembersButton.BackColor = System.Drawing.Color.LightGray;
            this.ManageMembersButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.ManageMembersButton.BorderColor = System.Drawing.Color.LightGray;
            this.ManageMembersButton.BorderRadius = 0;
            this.ManageMembersButton.BorderSize = 0;
            this.ManageMembersButton.FlatAppearance.BorderSize = 0;
            this.ManageMembersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManageMembersButton.Font = new System.Drawing.Font("Ubuntu", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageMembersButton.ForeColor = System.Drawing.Color.Black;
            this.ManageMembersButton.Location = new System.Drawing.Point(13, 11);
            this.ManageMembersButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ManageMembersButton.Name = "ManageMembersButton";
            this.ManageMembersButton.Size = new System.Drawing.Size(494, 100);
            this.ManageMembersButton.TabIndex = 19;
            this.ManageMembersButton.Text = "Manage Members";
            this.ManageMembersButton.TextColor = System.Drawing.Color.Black;
            this.ManageMembersButton.UseVisualStyleBackColor = false;
            this.ManageMembersButton.Click += new System.EventHandler(this.ManageMembersButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.SearchTextBox);
            this.panel1.Location = new System.Drawing.Point(45, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1532, 692);
            this.panel1.TabIndex = 20;
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
            this.SearchButton.Location = new System.Drawing.Point(520, 134);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(188, 54);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.TextColor = System.Drawing.Color.Black;
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TransferMembershipUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MembersTopPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TransferMembershipUForm";
            this.Size = new System.Drawing.Size(1678, 960);
            this.Load += new System.EventHandler(this.TransferMembershipUForm_Load);
            this.MembersTopPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel MembersTopPanel;
        private ButtonStyle TransferMembershipButton;
        private ButtonStyle TransferRecordsButton;
        private ButtonStyle ManageMembersButton;
        private System.Windows.Forms.Panel panel1;
        private ButtonStyle SearchButton;
    }
}
