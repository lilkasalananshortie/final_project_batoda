namespace BATODA
{
    partial class MembersUForm
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
            this.MemberTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OrderComboBox = new System.Windows.Forms.ComboBox();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.TransferMembershipButton = new System.Windows.Forms.Button();
            this.TransferRecordsButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.MembersTopPanel = new System.Windows.Forms.Panel();
            this.buttonStyle1 = new BATODA.ButtonStyle();
            this.ApplyButton = new BATODA.ButtonStyle();
            this.ClearButton = new BATODA.ButtonStyle();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.MembersTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Members";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(361, 247);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(285, 40);
            this.SearchTextBox.TabIndex = 4;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search Member";
            // 
            // MemberTypeComboBox
            // 
            this.MemberTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberTypeComboBox.FormattingEnabled = true;
            this.MemberTypeComboBox.Location = new System.Drawing.Point(877, 252);
            this.MemberTypeComboBox.Name = "MemberTypeComboBox";
            this.MemberTypeComboBox.Size = new System.Drawing.Size(188, 41);
            this.MemberTypeComboBox.TabIndex = 6;
            this.MemberTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.MemberTypeComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(664, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 42);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filter by :";
            // 
            // OrderComboBox
            // 
            this.OrderComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderComboBox.FormattingEnabled = true;
            this.OrderComboBox.Location = new System.Drawing.Point(1115, 252);
            this.OrderComboBox.Name = "OrderComboBox";
            this.OrderComboBox.Size = new System.Drawing.Size(188, 41);
            this.OrderComboBox.TabIndex = 8;
            this.OrderComboBox.SelectedIndexChanged += new System.EventHandler(this.OrderComboBox_SelectedIndexChanged);
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(1352, 252);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(188, 41);
            this.StatusComboBox.TabIndex = 9;
            this.StatusComboBox.SelectedIndexChanged += new System.EventHandler(this.StatusComboBox_SelectedIndexChanged);
            // 
            // TransferMembershipButton
            // 
            this.TransferMembershipButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.TransferMembershipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferMembershipButton.ForeColor = System.Drawing.Color.Black;
            this.TransferMembershipButton.Location = new System.Drawing.Point(793, 0);
            this.TransferMembershipButton.Name = "TransferMembershipButton";
            this.TransferMembershipButton.Size = new System.Drawing.Size(321, 89);
            this.TransferMembershipButton.TabIndex = 12;
            this.TransferMembershipButton.Text = "Transfer Membership";
            this.TransferMembershipButton.UseVisualStyleBackColor = false;
            this.TransferMembershipButton.Click += new System.EventHandler(this.TransferMembershipButton_Click);
            // 
            // TransferRecordsButton
            // 
            this.TransferRecordsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.TransferRecordsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferRecordsButton.ForeColor = System.Drawing.Color.Black;
            this.TransferRecordsButton.Location = new System.Drawing.Point(451, 0);
            this.TransferRecordsButton.Name = "TransferRecordsButton";
            this.TransferRecordsButton.Size = new System.Drawing.Size(321, 89);
            this.TransferRecordsButton.TabIndex = 13;
            this.TransferRecordsButton.Text = "Transfer Record";
            this.TransferRecordsButton.UseVisualStyleBackColor = false;
            this.TransferRecordsButton.Click += new System.EventHandler(this.TransferRecordsButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(63, 371);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1488, 548);
            this.dataGridView1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(870, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 42);
            this.label5.TabIndex = 17;
            this.label5.Text = "Filter by :";
            // 
            // MembersTopPanel
            // 
            this.MembersTopPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersTopPanel.Controls.Add(this.TransferRecordsButton);
            this.MembersTopPanel.Controls.Add(this.TransferMembershipButton);
            this.MembersTopPanel.Controls.Add(this.buttonStyle1);
            this.MembersTopPanel.Location = new System.Drawing.Point(63, 4);
            this.MembersTopPanel.Name = "MembersTopPanel";
            this.MembersTopPanel.Size = new System.Drawing.Size(1477, 98);
            this.MembersTopPanel.TabIndex = 18;
            // 
            // buttonStyle1
            // 
            this.buttonStyle1.BackColor = System.Drawing.Color.Red;
            this.buttonStyle1.BackgroundColor = System.Drawing.Color.Red;
            this.buttonStyle1.BorderColor = System.Drawing.Color.Red;
            this.buttonStyle1.BorderRadius = 0;
            this.buttonStyle1.BorderSize = 0;
            this.buttonStyle1.FlatAppearance.BorderSize = 0;
            this.buttonStyle1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStyle1.ForeColor = System.Drawing.Color.Black;
            this.buttonStyle1.Location = new System.Drawing.Point(63, 3);
            this.buttonStyle1.Name = "buttonStyle1";
            this.buttonStyle1.Size = new System.Drawing.Size(367, 81);
            this.buttonStyle1.TabIndex = 19;
            this.buttonStyle1.Text = "buttonStyle1";
            this.buttonStyle1.TextColor = System.Drawing.Color.Black;
            this.buttonStyle1.UseVisualStyleBackColor = false;
            // 
            // ApplyButton
            // 
            this.ApplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.ApplyButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.ApplyButton.BorderColor = System.Drawing.Color.Red;
            this.ApplyButton.BorderRadius = 0;
            this.ApplyButton.BorderSize = 0;
            this.ApplyButton.FlatAppearance.BorderSize = 0;
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.ForeColor = System.Drawing.Color.Black;
            this.ApplyButton.Location = new System.Drawing.Point(76, 303);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(188, 62);
            this.ApplyButton.TabIndex = 14;
            this.ApplyButton.Text = "Apply Filter";
            this.ApplyButton.TextColor = System.Drawing.Color.Black;
            this.ApplyButton.UseVisualStyleBackColor = false;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.ClearButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.ClearButton.BorderColor = System.Drawing.Color.Red;
            this.ClearButton.BorderRadius = 0;
            this.ClearButton.BorderSize = 0;
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.Black;
            this.ClearButton.Location = new System.Drawing.Point(282, 303);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(188, 62);
            this.ClearButton.TabIndex = 15;
            this.ClearButton.Text = "Clear Filter";
            this.ClearButton.TextColor = System.Drawing.Color.Black;
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MembersUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.MembersTopPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.StatusComboBox);
            this.Controls.Add(this.OrderComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MemberTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearButton);
            this.Name = "MembersUForm";
            this.Size = new System.Drawing.Size(1863, 922);
            this.Load += new System.EventHandler(this.MembersUForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.MembersTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MemberTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox OrderComboBox;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.Button TransferMembershipButton;
        private System.Windows.Forms.Button TransferRecordsButton;
        private ButtonStyle ApplyButton;
        private ButtonStyle ClearButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel MembersTopPanel;
        private ButtonStyle buttonStyle1;
    }
}
