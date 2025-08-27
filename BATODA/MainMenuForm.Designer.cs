namespace BATODA
{
    partial class DashboardForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.RegisteredContainer = new System.Windows.Forms.Panel();
            this.RegisteredVehiclesButton = new System.Windows.Forms.Button();
            this.TransferRecordButton = new System.Windows.Forms.Button();
            this.TransferVehicleButton = new System.Windows.Forms.Button();
            this.FinanceContainer = new System.Windows.Forms.Panel();
            this.FinanceButton = new System.Windows.Forms.Button();
            this.MembershipRenewalButton = new System.Windows.Forms.Button();
            this.ButawButton = new System.Windows.Forms.Button();
            this.AssistanceLogContainer = new System.Windows.Forms.Panel();
            this.AssistanceLogButton = new System.Windows.Forms.Button();
            this.ARHButton = new System.Windows.Forms.Button();
            this.AssistanceRequestButton = new System.Windows.Forms.Button();
            this.MembersContainer = new System.Windows.Forms.Panel();
            this.MembersButton = new System.Windows.Forms.Button();
            this.TransferRecordsButton = new System.Windows.Forms.Button();
            this.TransferMembershipButton = new System.Windows.Forms.Button();
            this.SettingsContainer = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.BackupButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.NavBarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.HomeButton = new System.Windows.Forms.Button();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.TopBarPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RegisteredContainer.SuspendLayout();
            this.FinanceContainer.SuspendLayout();
            this.AssistanceLogContainer.SuspendLayout();
            this.MembersContainer.SuspendLayout();
            this.SettingsContainer.SuspendLayout();
            this.NavBarPanel.SuspendLayout();
            this.TopBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            // 
            // RegisteredContainer
            // 
            this.RegisteredContainer.BackColor = System.Drawing.Color.Transparent;
            this.RegisteredContainer.Controls.Add(this.RegisteredVehiclesButton);
            this.RegisteredContainer.Controls.Add(this.TransferRecordButton);
            this.RegisteredContainer.Controls.Add(this.TransferVehicleButton);
            this.RegisteredContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.RegisteredContainer.Location = new System.Drawing.Point(3, 288);
            this.RegisteredContainer.Name = "RegisteredContainer";
            this.RegisteredContainer.Size = new System.Drawing.Size(293, 91);
            this.RegisteredContainer.TabIndex = 6;
            // 
            // RegisteredVehiclesButton
            // 
            this.RegisteredVehiclesButton.BackColor = System.Drawing.Color.IndianRed;
            this.RegisteredVehiclesButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisteredVehiclesButton.ForeColor = System.Drawing.Color.Black;
            this.RegisteredVehiclesButton.Location = new System.Drawing.Point(-12, 0);
            this.RegisteredVehiclesButton.Name = "RegisteredVehiclesButton";
            this.RegisteredVehiclesButton.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.RegisteredVehiclesButton.Size = new System.Drawing.Size(321, 90);
            this.RegisteredVehiclesButton.TabIndex = 3;
            this.RegisteredVehiclesButton.Text = "Registered Vehicles";
            this.RegisteredVehiclesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RegisteredVehiclesButton.UseVisualStyleBackColor = false;
            this.RegisteredVehiclesButton.Click += new System.EventHandler(this.btnRegistered_Click);
            // 
            // TransferRecordButton
            // 
            this.TransferRecordButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferRecordButton.ForeColor = System.Drawing.Color.Black;
            this.TransferRecordButton.Location = new System.Drawing.Point(-12, 190);
            this.TransferRecordButton.Name = "TransferRecordButton";
            this.TransferRecordButton.Size = new System.Drawing.Size(321, 89);
            this.TransferRecordButton.TabIndex = 5;
            this.TransferRecordButton.Text = "Transfer Record";
            this.TransferRecordButton.UseVisualStyleBackColor = true;
            this.TransferRecordButton.Click += new System.EventHandler(this.TransferRecordButton_Click);
            // 
            // TransferVehicleButton
            // 
            this.TransferVehicleButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferVehicleButton.ForeColor = System.Drawing.Color.Black;
            this.TransferVehicleButton.Location = new System.Drawing.Point(-12, 95);
            this.TransferVehicleButton.Name = "TransferVehicleButton";
            this.TransferVehicleButton.Size = new System.Drawing.Size(321, 89);
            this.TransferVehicleButton.TabIndex = 4;
            this.TransferVehicleButton.Text = "Transfer Vehicle \r\nRegistration\r\n";
            this.TransferVehicleButton.UseVisualStyleBackColor = true;
            this.TransferVehicleButton.Click += new System.EventHandler(this.TransferVehicleButton_Click);
            // 
            // FinanceContainer
            // 
            this.FinanceContainer.BackColor = System.Drawing.Color.Transparent;
            this.FinanceContainer.Controls.Add(this.FinanceButton);
            this.FinanceContainer.Controls.Add(this.MembershipRenewalButton);
            this.FinanceContainer.Controls.Add(this.ButawButton);
            this.FinanceContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.FinanceContainer.Location = new System.Drawing.Point(3, 385);
            this.FinanceContainer.Name = "FinanceContainer";
            this.FinanceContainer.Size = new System.Drawing.Size(293, 89);
            this.FinanceContainer.TabIndex = 8;
            // 
            // FinanceButton
            // 
            this.FinanceButton.BackColor = System.Drawing.Color.IndianRed;
            this.FinanceButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinanceButton.ForeColor = System.Drawing.Color.Black;
            this.FinanceButton.Location = new System.Drawing.Point(-12, 0);
            this.FinanceButton.Name = "FinanceButton";
            this.FinanceButton.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.FinanceButton.Size = new System.Drawing.Size(321, 90);
            this.FinanceButton.TabIndex = 3;
            this.FinanceButton.Text = "Finance";
            this.FinanceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FinanceButton.UseVisualStyleBackColor = false;
            this.FinanceButton.Click += new System.EventHandler(this.btnFinance_Click);
            // 
            // MembershipRenewalButton
            // 
            this.MembershipRenewalButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembershipRenewalButton.ForeColor = System.Drawing.Color.Black;
            this.MembershipRenewalButton.Location = new System.Drawing.Point(-12, 190);
            this.MembershipRenewalButton.Name = "MembershipRenewalButton";
            this.MembershipRenewalButton.Size = new System.Drawing.Size(321, 89);
            this.MembershipRenewalButton.TabIndex = 5;
            this.MembershipRenewalButton.Text = "Membership Renewal";
            this.MembershipRenewalButton.UseVisualStyleBackColor = true;
            this.MembershipRenewalButton.Click += new System.EventHandler(this.MembershipRenewalButton_Click);
            // 
            // ButawButton
            // 
            this.ButawButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButawButton.ForeColor = System.Drawing.Color.Black;
            this.ButawButton.Location = new System.Drawing.Point(-12, 95);
            this.ButawButton.Name = "ButawButton";
            this.ButawButton.Size = new System.Drawing.Size(321, 89);
            this.ButawButton.TabIndex = 4;
            this.ButawButton.Text = "Butaw";
            this.ButawButton.UseVisualStyleBackColor = true;
            this.ButawButton.Click += new System.EventHandler(this.ButawButton_Click);
            // 
            // AssistanceLogContainer
            // 
            this.AssistanceLogContainer.BackColor = System.Drawing.Color.Transparent;
            this.AssistanceLogContainer.Controls.Add(this.AssistanceLogButton);
            this.AssistanceLogContainer.Controls.Add(this.ARHButton);
            this.AssistanceLogContainer.Controls.Add(this.AssistanceRequestButton);
            this.AssistanceLogContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.AssistanceLogContainer.Location = new System.Drawing.Point(3, 195);
            this.AssistanceLogContainer.Name = "AssistanceLogContainer";
            this.AssistanceLogContainer.Size = new System.Drawing.Size(293, 87);
            this.AssistanceLogContainer.TabIndex = 7;
            // 
            // AssistanceLogButton
            // 
            this.AssistanceLogButton.BackColor = System.Drawing.Color.IndianRed;
            this.AssistanceLogButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceLogButton.ForeColor = System.Drawing.Color.Black;
            this.AssistanceLogButton.Location = new System.Drawing.Point(-12, 0);
            this.AssistanceLogButton.Name = "AssistanceLogButton";
            this.AssistanceLogButton.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.AssistanceLogButton.Size = new System.Drawing.Size(321, 90);
            this.AssistanceLogButton.TabIndex = 3;
            this.AssistanceLogButton.Text = "Assistance Log";
            this.AssistanceLogButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AssistanceLogButton.UseVisualStyleBackColor = false;
            this.AssistanceLogButton.Click += new System.EventHandler(this.btnAssistance_Click);
            // 
            // ARHButton
            // 
            this.ARHButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARHButton.ForeColor = System.Drawing.Color.Black;
            this.ARHButton.Location = new System.Drawing.Point(-12, 190);
            this.ARHButton.Name = "ARHButton";
            this.ARHButton.Size = new System.Drawing.Size(321, 89);
            this.ARHButton.TabIndex = 5;
            this.ARHButton.Text = "Approved Reqest History";
            this.ARHButton.UseVisualStyleBackColor = true;
            this.ARHButton.Click += new System.EventHandler(this.ARHButton_Click);
            // 
            // AssistanceRequestButton
            // 
            this.AssistanceRequestButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceRequestButton.ForeColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.Location = new System.Drawing.Point(-12, 95);
            this.AssistanceRequestButton.Name = "AssistanceRequestButton";
            this.AssistanceRequestButton.Size = new System.Drawing.Size(321, 89);
            this.AssistanceRequestButton.TabIndex = 4;
            this.AssistanceRequestButton.Text = "Assistance Request";
            this.AssistanceRequestButton.UseVisualStyleBackColor = true;
            this.AssistanceRequestButton.Click += new System.EventHandler(this.AssistanceRequestButton_Click);
            // 
            // MembersContainer
            // 
            this.MembersContainer.BackColor = System.Drawing.Color.Transparent;
            this.MembersContainer.Controls.Add(this.MembersButton);
            this.MembersContainer.Controls.Add(this.TransferRecordsButton);
            this.MembersContainer.Controls.Add(this.TransferMembershipButton);
            this.MembersContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.MembersContainer.Location = new System.Drawing.Point(3, 98);
            this.MembersContainer.Name = "MembersContainer";
            this.MembersContainer.Size = new System.Drawing.Size(293, 91);
            this.MembersContainer.TabIndex = 2;
            // 
            // MembersButton
            // 
            this.MembersButton.BackColor = System.Drawing.Color.IndianRed;
            this.MembersButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembersButton.ForeColor = System.Drawing.Color.Black;
            this.MembersButton.Location = new System.Drawing.Point(-12, 0);
            this.MembersButton.Name = "MembersButton";
            this.MembersButton.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.MembersButton.Size = new System.Drawing.Size(311, 89);
            this.MembersButton.TabIndex = 3;
            this.MembersButton.Text = "Members";
            this.MembersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MembersButton.UseVisualStyleBackColor = false;
            this.MembersButton.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // TransferRecordsButton
            // 
            this.TransferRecordsButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferRecordsButton.ForeColor = System.Drawing.Color.Black;
            this.TransferRecordsButton.Location = new System.Drawing.Point(-12, 190);
            this.TransferRecordsButton.Name = "TransferRecordsButton";
            this.TransferRecordsButton.Size = new System.Drawing.Size(321, 89);
            this.TransferRecordsButton.TabIndex = 5;
            this.TransferRecordsButton.Text = "Transfer Record";
            this.TransferRecordsButton.UseVisualStyleBackColor = true;
            this.TransferRecordsButton.Click += new System.EventHandler(this.TransferRecordsButton_Click);
            // 
            // TransferMembershipButton
            // 
            this.TransferMembershipButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferMembershipButton.ForeColor = System.Drawing.Color.Black;
            this.TransferMembershipButton.Location = new System.Drawing.Point(-12, 95);
            this.TransferMembershipButton.Name = "TransferMembershipButton";
            this.TransferMembershipButton.Size = new System.Drawing.Size(321, 89);
            this.TransferMembershipButton.TabIndex = 4;
            this.TransferMembershipButton.Text = "Transfer Membership";
            this.TransferMembershipButton.UseVisualStyleBackColor = true;
            this.TransferMembershipButton.Click += new System.EventHandler(this.TransferMembershipButton_Click);
            // 
            // SettingsContainer
            // 
            this.SettingsContainer.BackColor = System.Drawing.Color.Transparent;
            this.SettingsContainer.Controls.Add(this.SettingsButton);
            this.SettingsContainer.Controls.Add(this.BackupButton);
            this.SettingsContainer.Controls.Add(this.LogOutButton);
            this.SettingsContainer.Location = new System.Drawing.Point(3, 480);
            this.SettingsContainer.Name = "SettingsContainer";
            this.SettingsContainer.Size = new System.Drawing.Size(293, 89);
            this.SettingsContainer.TabIndex = 9;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.IndianRed;
            this.SettingsButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.Black;
            this.SettingsButton.Location = new System.Drawing.Point(-12, 0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.SettingsButton.Size = new System.Drawing.Size(321, 90);
            this.SettingsButton.TabIndex = 3;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // BackupButton
            // 
            this.BackupButton.Font = new System.Drawing.Font("Ubuntu", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupButton.ForeColor = System.Drawing.Color.Black;
            this.BackupButton.Location = new System.Drawing.Point(-12, 190);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(321, 89);
            this.BackupButton.TabIndex = 5;
            this.BackupButton.Text = "Back UP";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.Black;
            this.LogOutButton.Location = new System.Drawing.Point(-12, 95);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(321, 89);
            this.LogOutButton.TabIndex = 4;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // NavBarPanel
            // 
            this.NavBarPanel.BackColor = System.Drawing.Color.IndianRed;
            this.NavBarPanel.Controls.Add(this.HomeButton);
            this.NavBarPanel.Controls.Add(this.MembersContainer);
            this.NavBarPanel.Controls.Add(this.AssistanceLogContainer);
            this.NavBarPanel.Controls.Add(this.RegisteredContainer);
            this.NavBarPanel.Controls.Add(this.FinanceContainer);
            this.NavBarPanel.Controls.Add(this.SettingsContainer);
            this.NavBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavBarPanel.Location = new System.Drawing.Point(0, 0);
            this.NavBarPanel.Name = "NavBarPanel";
            this.NavBarPanel.Size = new System.Drawing.Size(305, 728);
            this.NavBarPanel.TabIndex = 1;
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.IndianRed;
            this.HomeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.HomeButton.Font = new System.Drawing.Font("Ubuntu", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.Black;
            this.HomeButton.Location = new System.Drawing.Point(3, 3);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.HomeButton.Size = new System.Drawing.Size(299, 89);
            this.HomeButton.TabIndex = 6;
            this.HomeButton.Text = "Home";
            this.HomeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.SystemColors.Control;
            this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayPanel.Location = new System.Drawing.Point(305, 0);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(709, 728);
            this.DisplayPanel.TabIndex = 2;           
            // 
            // TopBarPanel
            // 
            this.TopBarPanel.BackColor = System.Drawing.Color.Lime;
            this.TopBarPanel.Controls.Add(this.label1);
            this.TopBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBarPanel.Location = new System.Drawing.Point(305, 0);
            this.TopBarPanel.Name = "TopBarPanel";
            this.TopBarPanel.Size = new System.Drawing.Size(709, 66);
            this.TopBarPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(479, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notif Acc Calendar";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1014, 728);
            this.Controls.Add(this.TopBarPanel);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.NavBarPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashboardForm";
            this.Text = "BATODA Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.RegisteredContainer.ResumeLayout(false);
            this.FinanceContainer.ResumeLayout(false);
            this.AssistanceLogContainer.ResumeLayout(false);
            this.MembersContainer.ResumeLayout(false);
            this.SettingsContainer.ResumeLayout(false);
            this.NavBarPanel.ResumeLayout(false);
            this.TopBarPanel.ResumeLayout(false);
            this.TopBarPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel RegisteredContainer;
        private System.Windows.Forms.Button RegisteredVehiclesButton;
        private System.Windows.Forms.Button TransferRecordButton;
        private System.Windows.Forms.Button TransferVehicleButton;
        private System.Windows.Forms.Panel FinanceContainer;
        private System.Windows.Forms.Button FinanceButton;
        private System.Windows.Forms.Button MembershipRenewalButton;
        private System.Windows.Forms.Button ButawButton;
        private System.Windows.Forms.Panel AssistanceLogContainer;
        private System.Windows.Forms.Button AssistanceLogButton;
        private System.Windows.Forms.Button ARHButton;
        private System.Windows.Forms.Button AssistanceRequestButton;
        private System.Windows.Forms.Panel MembersContainer;
        private System.Windows.Forms.Button MembersButton;
        private System.Windows.Forms.Button TransferRecordsButton;
        private System.Windows.Forms.Button TransferMembershipButton;
        private System.Windows.Forms.Panel SettingsContainer;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.FlowLayoutPanel NavBarPanel;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Panel TopBarPanel;
        private System.Windows.Forms.Label label1;
    }
}