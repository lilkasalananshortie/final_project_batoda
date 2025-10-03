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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.TopBarPanel = new System.Windows.Forms.Panel();
            this.CalendarButton = new BATODA.ButtonStyle();
            this.NotificationButton = new BATODA.ButtonStyle();
            this.AccountButton = new BATODA.ButtonStyle();
            this.TopPanelText = new System.Windows.Forms.Label();
            this.NotificationPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CalendarXAccoutnContainerPanel = new System.Windows.Forms.Panel();
            this.NavBarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.HomeButton = new BATODA.ButtonStyle();
            this.MembersMainButton = new BATODA.ButtonStyle();
            this.RegisteredVehiclesButton = new BATODA.ButtonStyle();
            this.AssistanceLogButton = new BATODA.ButtonStyle();
            this.FinanceButton = new BATODA.ButtonStyle();
            this.SettingsButton = new BATODA.ButtonStyle();
            this.panel1.SuspendLayout();
            this.TopBarPanel.SuspendLayout();
            this.NotificationPanel.SuspendLayout();
            this.NavBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 152);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 55);
            this.label3.TabIndex = 0;
            this.label3.Text = "BATODA";
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.Silver;
            this.DisplayPanel.Location = new System.Drawing.Point(322, 552);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(304, 176);
            this.DisplayPanel.TabIndex = 2;
            // 
            // TopBarPanel
            // 
            this.TopBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TopBarPanel.Controls.Add(this.CalendarButton);
            this.TopBarPanel.Controls.Add(this.NotificationButton);
            this.TopBarPanel.Controls.Add(this.AccountButton);
            this.TopBarPanel.Controls.Add(this.TopPanelText);
            this.TopBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBarPanel.Location = new System.Drawing.Point(300, 0);
            this.TopBarPanel.Name = "TopBarPanel";
            this.TopBarPanel.Size = new System.Drawing.Size(1624, 90);
            this.TopBarPanel.TabIndex = 3;
            this.TopBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopBarPanel_Paint);
            // 
            // CalendarButton
            // 
            this.CalendarButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CalendarButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.CalendarButton.BorderColor = System.Drawing.Color.Red;
            this.CalendarButton.BorderRadius = 0;
            this.CalendarButton.BorderSize = 0;
            this.CalendarButton.ButtonImage = null;
            this.CalendarButton.FlatAppearance.BorderSize = 0;
            this.CalendarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalendarButton.ForeColor = System.Drawing.Color.Black;
            this.CalendarButton.ImageColor = System.Drawing.Color.Black;
            this.CalendarButton.ImagePosition = new System.Drawing.Point(10, 8);
            this.CalendarButton.ImageSize = new System.Drawing.Size(24, 24);
            this.CalendarButton.Location = new System.Drawing.Point(1443, 30);
            this.CalendarButton.Name = "CalendarButton";
            this.CalendarButton.Size = new System.Drawing.Size(106, 40);
            this.CalendarButton.TabIndex = 6;
            this.CalendarButton.Text = "Calendar";
            this.CalendarButton.TextColor = System.Drawing.Color.Black;
            this.CalendarButton.TextPadding = 10;
            this.CalendarButton.UseVisualStyleBackColor = false;
            this.CalendarButton.Click += new System.EventHandler(this.CalendarButton_Click);
            // 
            // NotificationButton
            // 
            this.NotificationButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NotificationButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.NotificationButton.BorderColor = System.Drawing.Color.Red;
            this.NotificationButton.BorderRadius = 0;
            this.NotificationButton.BorderSize = 0;
            this.NotificationButton.ButtonImage = null;
            this.NotificationButton.FlatAppearance.BorderSize = 0;
            this.NotificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NotificationButton.ForeColor = System.Drawing.Color.Black;
            this.NotificationButton.ImageColor = System.Drawing.Color.Black;
            this.NotificationButton.ImagePosition = new System.Drawing.Point(10, 8);
            this.NotificationButton.ImageSize = new System.Drawing.Size(24, 24);
            this.NotificationButton.Location = new System.Drawing.Point(1331, 30);
            this.NotificationButton.Name = "NotificationButton";
            this.NotificationButton.Size = new System.Drawing.Size(106, 40);
            this.NotificationButton.TabIndex = 5;
            this.NotificationButton.Text = "Notification";
            this.NotificationButton.TextColor = System.Drawing.Color.Black;
            this.NotificationButton.TextPadding = 10;
            this.NotificationButton.UseVisualStyleBackColor = false;
            this.NotificationButton.Click += new System.EventHandler(this.NotificationButton_Click);
            // 
            // AccountButton
            // 
            this.AccountButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AccountButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.AccountButton.BorderColor = System.Drawing.Color.Red;
            this.AccountButton.BorderRadius = 0;
            this.AccountButton.BorderSize = 0;
            this.AccountButton.ButtonImage = null;
            this.AccountButton.FlatAppearance.BorderSize = 0;
            this.AccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountButton.ForeColor = System.Drawing.Color.Black;
            this.AccountButton.ImageColor = System.Drawing.Color.Black;
            this.AccountButton.ImagePosition = new System.Drawing.Point(10, 8);
            this.AccountButton.ImageSize = new System.Drawing.Size(24, 24);
            this.AccountButton.Location = new System.Drawing.Point(1219, 30);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Size = new System.Drawing.Size(106, 40);
            this.AccountButton.TabIndex = 4;
            this.AccountButton.Text = "Account";
            this.AccountButton.TextColor = System.Drawing.Color.Black;
            this.AccountButton.TextPadding = 10;
            this.AccountButton.UseVisualStyleBackColor = false;
            this.AccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // TopPanelText
            // 
            this.TopPanelText.AutoSize = true;
            this.TopPanelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPanelText.Location = new System.Drawing.Point(20, 10);
            this.TopPanelText.Name = "TopPanelText";
            this.TopPanelText.Size = new System.Drawing.Size(389, 55);
            this.TopPanelText.TabIndex = 0;
            this.TopPanelText.Text = "Bambang TODA";
            // 
            // NotificationPanel
            // 
            this.NotificationPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NotificationPanel.Controls.Add(this.label2);
            this.NotificationPanel.Location = new System.Drawing.Point(1378, 80);
            this.NotificationPanel.Name = "NotificationPanel";
            this.NotificationPanel.Size = new System.Drawing.Size(366, 334);
            this.NotificationPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Notification";
            // 
            // CalendarXAccoutnContainerPanel
            // 
            this.CalendarXAccoutnContainerPanel.Location = new System.Drawing.Point(672, 237);
            this.CalendarXAccoutnContainerPanel.Name = "CalendarXAccoutnContainerPanel";
            this.CalendarXAccoutnContainerPanel.Size = new System.Drawing.Size(903, 522);
            this.CalendarXAccoutnContainerPanel.TabIndex = 4;
            // 
            // NavBarPanel
            // 
            this.NavBarPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.NavBarPanel.Controls.Add(this.panel1);
            this.NavBarPanel.Controls.Add(this.HomeButton);
            this.NavBarPanel.Controls.Add(this.MembersMainButton);
            this.NavBarPanel.Controls.Add(this.RegisteredVehiclesButton);
            this.NavBarPanel.Controls.Add(this.AssistanceLogButton);
            this.NavBarPanel.Controls.Add(this.FinanceButton);
            this.NavBarPanel.Controls.Add(this.SettingsButton);
            this.NavBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavBarPanel.Location = new System.Drawing.Point(0, 0);
            this.NavBarPanel.Name = "NavBarPanel";
            this.NavBarPanel.Size = new System.Drawing.Size(300, 969);
            this.NavBarPanel.TabIndex = 1;
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HomeButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.HomeButton.BorderColor = System.Drawing.Color.Red;
            this.HomeButton.BorderRadius = 0;
            this.HomeButton.BorderSize = 0;
            this.HomeButton.ButtonImage = global::BATODA.Properties.Resources.dashboard_icon;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.HomeButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.HomeButton.ImagePosition = new System.Drawing.Point(20, 20);
            this.HomeButton.ImageSize = new System.Drawing.Size(32, 32);
            this.HomeButton.Location = new System.Drawing.Point(3, 161);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.HomeButton.Size = new System.Drawing.Size(300, 75);
            this.HomeButton.TabIndex = 8;
            this.HomeButton.Text = "Dashboard";
            this.HomeButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.HomeButton.TextPadding = 20;
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // MembersMainButton
            // 
            this.MembersMainButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersMainButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.MembersMainButton.BorderColor = System.Drawing.Color.Red;
            this.MembersMainButton.BorderRadius = 0;
            this.MembersMainButton.BorderSize = 0;
            this.MembersMainButton.ButtonImage = global::BATODA.Properties.Resources.members_nav_bar_icon;
            this.MembersMainButton.FlatAppearance.BorderSize = 0;
            this.MembersMainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MembersMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembersMainButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MembersMainButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MembersMainButton.ImagePosition = new System.Drawing.Point(20, 20);
            this.MembersMainButton.ImageSize = new System.Drawing.Size(32, 32);
            this.MembersMainButton.Location = new System.Drawing.Point(3, 242);
            this.MembersMainButton.Name = "MembersMainButton";
            this.MembersMainButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.MembersMainButton.Size = new System.Drawing.Size(300, 75);
            this.MembersMainButton.TabIndex = 9;
            this.MembersMainButton.Text = "Members";
            this.MembersMainButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MembersMainButton.TextPadding = 20;
            this.MembersMainButton.UseVisualStyleBackColor = false;
            this.MembersMainButton.Click += new System.EventHandler(this.MembersMainButton_Click);
            // 
            // RegisteredVehiclesButton
            // 
            this.RegisteredVehiclesButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RegisteredVehiclesButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.RegisteredVehiclesButton.BorderColor = System.Drawing.Color.Red;
            this.RegisteredVehiclesButton.BorderRadius = 0;
            this.RegisteredVehiclesButton.BorderSize = 0;
            this.RegisteredVehiclesButton.ButtonImage = global::BATODA.Properties.Resources.registered_vehicle_nav_bar_icon;
            this.RegisteredVehiclesButton.FlatAppearance.BorderSize = 0;
            this.RegisteredVehiclesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisteredVehiclesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisteredVehiclesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegisteredVehiclesButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegisteredVehiclesButton.ImagePosition = new System.Drawing.Point(20, 20);
            this.RegisteredVehiclesButton.ImageSize = new System.Drawing.Size(32, 32);
            this.RegisteredVehiclesButton.Location = new System.Drawing.Point(3, 323);
            this.RegisteredVehiclesButton.Name = "RegisteredVehiclesButton";
            this.RegisteredVehiclesButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.RegisteredVehiclesButton.Size = new System.Drawing.Size(300, 75);
            this.RegisteredVehiclesButton.TabIndex = 10;
            this.RegisteredVehiclesButton.Text = "Registered Vehicles";
            this.RegisteredVehiclesButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegisteredVehiclesButton.TextPadding = 20;
            this.RegisteredVehiclesButton.UseVisualStyleBackColor = false;
            this.RegisteredVehiclesButton.Click += new System.EventHandler(this.RegisteredVehiclesButton_Click);
            // 
            // AssistanceLogButton
            // 
            this.AssistanceLogButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AssistanceLogButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.AssistanceLogButton.BorderColor = System.Drawing.Color.Red;
            this.AssistanceLogButton.BorderRadius = 0;
            this.AssistanceLogButton.BorderSize = 0;
            this.AssistanceLogButton.ButtonImage = global::BATODA.Properties.Resources.assistance_log_nav_bar_icon;
            this.AssistanceLogButton.FlatAppearance.BorderSize = 0;
            this.AssistanceLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AssistanceLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceLogButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AssistanceLogButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AssistanceLogButton.ImagePosition = new System.Drawing.Point(20, 20);
            this.AssistanceLogButton.ImageSize = new System.Drawing.Size(32, 32);
            this.AssistanceLogButton.Location = new System.Drawing.Point(3, 404);
            this.AssistanceLogButton.Name = "AssistanceLogButton";
            this.AssistanceLogButton.Size = new System.Drawing.Size(300, 75);
            this.AssistanceLogButton.TabIndex = 11;
            this.AssistanceLogButton.Text = "Assistance Log";
            this.AssistanceLogButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AssistanceLogButton.TextPadding = 20;
            this.AssistanceLogButton.UseVisualStyleBackColor = false;
            this.AssistanceLogButton.Click += new System.EventHandler(this.AssistanceLogButton_Click);
            // 
            // FinanceButton
            // 
            this.FinanceButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FinanceButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.FinanceButton.BorderColor = System.Drawing.Color.Red;
            this.FinanceButton.BorderRadius = 0;
            this.FinanceButton.BorderSize = 0;
            this.FinanceButton.ButtonImage = global::BATODA.Properties.Resources.finance_nav_bar_icon;
            this.FinanceButton.FlatAppearance.BorderSize = 0;
            this.FinanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinanceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FinanceButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FinanceButton.ImagePosition = new System.Drawing.Point(20, 20);
            this.FinanceButton.ImageSize = new System.Drawing.Size(32, 32);
            this.FinanceButton.Location = new System.Drawing.Point(3, 485);
            this.FinanceButton.Name = "FinanceButton";
            this.FinanceButton.Size = new System.Drawing.Size(300, 75);
            this.FinanceButton.TabIndex = 12;
            this.FinanceButton.Text = "Finance\r\n";
            this.FinanceButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FinanceButton.TextPadding = 20;
            this.FinanceButton.UseVisualStyleBackColor = false;
            this.FinanceButton.Click += new System.EventHandler(this.FinanceButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SettingsButton.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.SettingsButton.BorderColor = System.Drawing.Color.Red;
            this.SettingsButton.BorderRadius = 0;
            this.SettingsButton.BorderSize = 0;
            this.SettingsButton.ButtonImage = global::BATODA.Properties.Resources.settings_nav_bar_icon;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SettingsButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SettingsButton.ImagePosition = new System.Drawing.Point(20, 20);
            this.SettingsButton.ImageSize = new System.Drawing.Size(32, 32);
            this.SettingsButton.Location = new System.Drawing.Point(3, 566);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(300, 75);
            this.SettingsButton.TabIndex = 13;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SettingsButton.TextPadding = 20;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1924, 969);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.NotificationPanel);
            this.Controls.Add(this.TopBarPanel);
            this.Controls.Add(this.NavBarPanel);
            this.Controls.Add(this.CalendarXAccoutnContainerPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashboardForm";
            this.Text = "BATODA Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopBarPanel.ResumeLayout(false);
            this.TopBarPanel.PerformLayout();
            this.NotificationPanel.ResumeLayout(false);
            this.NotificationPanel.PerformLayout();
            this.NavBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Panel TopBarPanel;
        private System.Windows.Forms.Label TopPanelText;
        private System.Windows.Forms.Panel NotificationPanel;
        private System.Windows.Forms.Panel CalendarXAccoutnContainerPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private ButtonStyle HomeButton;
        private ButtonStyle MembersMainButton;
        private ButtonStyle RegisteredVehiclesButton;
        private ButtonStyle AssistanceLogButton;
        private ButtonStyle FinanceButton;
        private ButtonStyle SettingsButton;
        private ButtonStyle AccountButton;
        private ButtonStyle NotificationButton;
        private ButtonStyle CalendarButton;
        private System.Windows.Forms.FlowLayoutPanel NavBarPanel;
    }
}