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
            this.panel2 = new System.Windows.Forms.Panel();
            this.SettingsButton = new BATODA.ButtonStyle();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.TopBarPanel.SuspendLayout();
            this.NotificationPanel.SuspendLayout();
            this.NavBarPanel.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 55);
            this.label3.TabIndex = 0;
            this.label3.Text = "BATODA";
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
            this.TopBarPanel.Size = new System.Drawing.Size(1444, 90);
            this.TopBarPanel.TabIndex = 3;
            this.TopBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TopBarPanel_Paint);
            // 
            // CalendarButton
            // 
            this.CalendarButton.BackColor = System.Drawing.Color.White;
            this.CalendarButton.BackgroundColor = System.Drawing.Color.White;
            this.CalendarButton.BorderColor = System.Drawing.Color.Red;
            this.CalendarButton.BorderRadius = 0;
            this.CalendarButton.BorderSize = 0;
            this.CalendarButton.ButtonImage = null;
            this.CalendarButton.FlatAppearance.BorderSize = 0;
            this.CalendarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalendarButton.ForeColor = System.Drawing.Color.Black;
            this.CalendarButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.CalendarButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.CalendarButton.ImageColor = System.Drawing.Color.Black;
            this.CalendarButton.ImagePosition = new System.Drawing.Point(10, 8);
            this.CalendarButton.ImageSize = new System.Drawing.Size(24, 24);
            this.CalendarButton.IsToggled = false;
            this.CalendarButton.Location = new System.Drawing.Point(1443, 30);
            this.CalendarButton.MouseDownColor = System.Drawing.Color.White;
            this.CalendarButton.Name = "CalendarButton";
            this.CalendarButton.PaddingX = 10;
            this.CalendarButton.PaddingY = 5;
            this.CalendarButton.Size = new System.Drawing.Size(106, 40);
            this.CalendarButton.TabIndex = 6;
            this.CalendarButton.Text = "Calendar";
            this.CalendarButton.TextColor = System.Drawing.Color.Black;
            this.CalendarButton.TextOffset = 8;
            this.CalendarButton.ToggleColor = System.Drawing.Color.DarkGray;
            this.CalendarButton.UseVisualStyleBackColor = false;
            this.CalendarButton.Click += new System.EventHandler(this.CalendarButton_Click);
            // 
            // NotificationButton
            // 
            this.NotificationButton.BackColor = System.Drawing.Color.White;
            this.NotificationButton.BackgroundColor = System.Drawing.Color.White;
            this.NotificationButton.BorderColor = System.Drawing.Color.Red;
            this.NotificationButton.BorderRadius = 0;
            this.NotificationButton.BorderSize = 0;
            this.NotificationButton.ButtonImage = null;
            this.NotificationButton.FlatAppearance.BorderSize = 0;
            this.NotificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NotificationButton.ForeColor = System.Drawing.Color.Black;
            this.NotificationButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.NotificationButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.NotificationButton.ImageColor = System.Drawing.Color.Black;
            this.NotificationButton.ImagePosition = new System.Drawing.Point(10, 8);
            this.NotificationButton.ImageSize = new System.Drawing.Size(24, 24);
            this.NotificationButton.IsToggled = false;
            this.NotificationButton.Location = new System.Drawing.Point(1331, 30);
            this.NotificationButton.MouseDownColor = System.Drawing.Color.White;
            this.NotificationButton.Name = "NotificationButton";
            this.NotificationButton.PaddingX = 10;
            this.NotificationButton.PaddingY = 5;
            this.NotificationButton.Size = new System.Drawing.Size(106, 40);
            this.NotificationButton.TabIndex = 5;
            this.NotificationButton.Text = "Notification";
            this.NotificationButton.TextColor = System.Drawing.Color.Black;
            this.NotificationButton.TextOffset = 8;
            this.NotificationButton.ToggleColor = System.Drawing.Color.DarkGray;
            this.NotificationButton.UseVisualStyleBackColor = false;
            this.NotificationButton.Click += new System.EventHandler(this.NotificationButton_Click);
            // 
            // AccountButton
            // 
            this.AccountButton.BackColor = System.Drawing.Color.White;
            this.AccountButton.BackgroundColor = System.Drawing.Color.White;
            this.AccountButton.BorderColor = System.Drawing.Color.Red;
            this.AccountButton.BorderRadius = 0;
            this.AccountButton.BorderSize = 0;
            this.AccountButton.ButtonImage = null;
            this.AccountButton.FlatAppearance.BorderSize = 0;
            this.AccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountButton.ForeColor = System.Drawing.Color.Black;
            this.AccountButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.AccountButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.AccountButton.ImageColor = System.Drawing.Color.Black;
            this.AccountButton.ImagePosition = new System.Drawing.Point(10, 8);
            this.AccountButton.ImageSize = new System.Drawing.Size(24, 24);
            this.AccountButton.IsToggled = false;
            this.AccountButton.Location = new System.Drawing.Point(1219, 30);
            this.AccountButton.MouseDownColor = System.Drawing.Color.White;
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.PaddingX = 10;
            this.AccountButton.PaddingY = 5;
            this.AccountButton.Size = new System.Drawing.Size(106, 40);
            this.AccountButton.TabIndex = 4;
            this.AccountButton.Text = "Account";
            this.AccountButton.TextColor = System.Drawing.Color.Black;
            this.AccountButton.TextOffset = 8;
            this.AccountButton.ToggleColor = System.Drawing.Color.DarkGray;
            this.AccountButton.UseVisualStyleBackColor = false;
            this.AccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // TopPanelText
            // 
            this.TopPanelText.AutoSize = true;
            this.TopPanelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPanelText.Location = new System.Drawing.Point(20, 10);
            this.TopPanelText.Name = "TopPanelText";
            this.TopPanelText.Size = new System.Drawing.Size(410, 55);
            this.TopPanelText.TabIndex = 0;
            this.TopPanelText.Text = "BAMBANG TODA";
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
            this.NavBarPanel.BackColor = System.Drawing.Color.White;
            this.NavBarPanel.Controls.Add(this.panel1);
            this.NavBarPanel.Controls.Add(this.HomeButton);
            this.NavBarPanel.Controls.Add(this.MembersMainButton);
            this.NavBarPanel.Controls.Add(this.RegisteredVehiclesButton);
            this.NavBarPanel.Controls.Add(this.AssistanceLogButton);
            this.NavBarPanel.Controls.Add(this.FinanceButton);
            this.NavBarPanel.Controls.Add(this.panel2);
            this.NavBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavBarPanel.Location = new System.Drawing.Point(0, 0);
            this.NavBarPanel.Name = "NavBarPanel";
            this.NavBarPanel.Size = new System.Drawing.Size(300, 898);
            this.NavBarPanel.TabIndex = 1;
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.White;
            this.HomeButton.BackgroundColor = System.Drawing.Color.White;
            this.HomeButton.BorderColor = System.Drawing.Color.White;
            this.HomeButton.BorderRadius = 0;
            this.HomeButton.BorderSize = 0;
            this.HomeButton.ButtonImage = global::BATODA.Properties.Resources.dashboard_icon;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.HomeButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.HomeButton.HoverColor = System.Drawing.Color.Silver;
            this.HomeButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.HomeButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.HomeButton.ImageSize = new System.Drawing.Size(32, 32);
            this.HomeButton.IsToggled = false;
            this.HomeButton.Location = new System.Drawing.Point(3, 161);
            this.HomeButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.HomeButton.PaddingX = 0;
            this.HomeButton.PaddingY = 0;
            this.HomeButton.Size = new System.Drawing.Size(300, 75);
            this.HomeButton.TabIndex = 8;
            this.HomeButton.Text = "Dashboard";
            this.HomeButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.HomeButton.TextOffset = 20;
            this.HomeButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // MembersMainButton
            // 
            this.MembersMainButton.BackColor = System.Drawing.Color.White;
            this.MembersMainButton.BackgroundColor = System.Drawing.Color.White;
            this.MembersMainButton.BorderColor = System.Drawing.Color.White;
            this.MembersMainButton.BorderRadius = 0;
            this.MembersMainButton.BorderSize = 0;
            this.MembersMainButton.ButtonImage = global::BATODA.Properties.Resources.members_nav_bar_icon;
            this.MembersMainButton.FlatAppearance.BorderSize = 0;
            this.MembersMainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MembersMainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembersMainButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MembersMainButton.HoverBorderColor = System.Drawing.Color.Black;
            this.MembersMainButton.HoverColor = System.Drawing.Color.Silver;
            this.MembersMainButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MembersMainButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.MembersMainButton.ImageSize = new System.Drawing.Size(32, 32);
            this.MembersMainButton.IsToggled = false;
            this.MembersMainButton.Location = new System.Drawing.Point(3, 242);
            this.MembersMainButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.MembersMainButton.Name = "MembersMainButton";
            this.MembersMainButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.MembersMainButton.PaddingX = 0;
            this.MembersMainButton.PaddingY = 0;
            this.MembersMainButton.Size = new System.Drawing.Size(300, 75);
            this.MembersMainButton.TabIndex = 9;
            this.MembersMainButton.Text = "Members";
            this.MembersMainButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MembersMainButton.TextOffset = 20;
            this.MembersMainButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.MembersMainButton.UseVisualStyleBackColor = false;
            this.MembersMainButton.Click += new System.EventHandler(this.MembersMainButton_Click);
            // 
            // RegisteredVehiclesButton
            // 
            this.RegisteredVehiclesButton.BackColor = System.Drawing.Color.White;
            this.RegisteredVehiclesButton.BackgroundColor = System.Drawing.Color.White;
            this.RegisteredVehiclesButton.BorderColor = System.Drawing.Color.White;
            this.RegisteredVehiclesButton.BorderRadius = 0;
            this.RegisteredVehiclesButton.BorderSize = 0;
            this.RegisteredVehiclesButton.ButtonImage = global::BATODA.Properties.Resources.registered_vehicle_nav_bar_icon;
            this.RegisteredVehiclesButton.FlatAppearance.BorderSize = 0;
            this.RegisteredVehiclesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisteredVehiclesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisteredVehiclesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegisteredVehiclesButton.HoverBorderColor = System.Drawing.Color.Black;
            this.RegisteredVehiclesButton.HoverColor = System.Drawing.Color.Silver;
            this.RegisteredVehiclesButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegisteredVehiclesButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.RegisteredVehiclesButton.ImageSize = new System.Drawing.Size(32, 32);
            this.RegisteredVehiclesButton.IsToggled = false;
            this.RegisteredVehiclesButton.Location = new System.Drawing.Point(3, 323);
            this.RegisteredVehiclesButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.RegisteredVehiclesButton.Name = "RegisteredVehiclesButton";
            this.RegisteredVehiclesButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.RegisteredVehiclesButton.PaddingX = 0;
            this.RegisteredVehiclesButton.PaddingY = 0;
            this.RegisteredVehiclesButton.Size = new System.Drawing.Size(300, 75);
            this.RegisteredVehiclesButton.TabIndex = 10;
            this.RegisteredVehiclesButton.Text = "Registered Vehicles";
            this.RegisteredVehiclesButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegisteredVehiclesButton.TextOffset = 20;
            this.RegisteredVehiclesButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.RegisteredVehiclesButton.UseVisualStyleBackColor = false;
            this.RegisteredVehiclesButton.Click += new System.EventHandler(this.RegisteredVehiclesButton_Click);
            // 
            // AssistanceLogButton
            // 
            this.AssistanceLogButton.BackColor = System.Drawing.Color.White;
            this.AssistanceLogButton.BackgroundColor = System.Drawing.Color.White;
            this.AssistanceLogButton.BorderColor = System.Drawing.Color.White;
            this.AssistanceLogButton.BorderRadius = 0;
            this.AssistanceLogButton.BorderSize = 0;
            this.AssistanceLogButton.ButtonImage = global::BATODA.Properties.Resources.assistance_log_nav_bar_icon;
            this.AssistanceLogButton.FlatAppearance.BorderSize = 0;
            this.AssistanceLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AssistanceLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceLogButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AssistanceLogButton.HoverBorderColor = System.Drawing.Color.Black;
            this.AssistanceLogButton.HoverColor = System.Drawing.Color.Silver;
            this.AssistanceLogButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AssistanceLogButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.AssistanceLogButton.ImageSize = new System.Drawing.Size(32, 32);
            this.AssistanceLogButton.IsToggled = false;
            this.AssistanceLogButton.Location = new System.Drawing.Point(3, 404);
            this.AssistanceLogButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.AssistanceLogButton.Name = "AssistanceLogButton";
            this.AssistanceLogButton.PaddingX = 0;
            this.AssistanceLogButton.PaddingY = 0;
            this.AssistanceLogButton.Size = new System.Drawing.Size(300, 75);
            this.AssistanceLogButton.TabIndex = 11;
            this.AssistanceLogButton.Text = "Assistance Log";
            this.AssistanceLogButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AssistanceLogButton.TextOffset = 20;
            this.AssistanceLogButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.AssistanceLogButton.UseVisualStyleBackColor = false;
            this.AssistanceLogButton.Click += new System.EventHandler(this.AssistanceLogButton_Click);
            // 
            // FinanceButton
            // 
            this.FinanceButton.BackColor = System.Drawing.Color.White;
            this.FinanceButton.BackgroundColor = System.Drawing.Color.White;
            this.FinanceButton.BorderColor = System.Drawing.Color.White;
            this.FinanceButton.BorderRadius = 0;
            this.FinanceButton.BorderSize = 0;
            this.FinanceButton.ButtonImage = global::BATODA.Properties.Resources.finance_nav_bar_icon;
            this.FinanceButton.FlatAppearance.BorderSize = 0;
            this.FinanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinanceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FinanceButton.HoverBorderColor = System.Drawing.Color.Black;
            this.FinanceButton.HoverColor = System.Drawing.Color.Silver;
            this.FinanceButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FinanceButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.FinanceButton.ImageSize = new System.Drawing.Size(32, 32);
            this.FinanceButton.IsToggled = false;
            this.FinanceButton.Location = new System.Drawing.Point(3, 485);
            this.FinanceButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.FinanceButton.Name = "FinanceButton";
            this.FinanceButton.PaddingX = 0;
            this.FinanceButton.PaddingY = 0;
            this.FinanceButton.Size = new System.Drawing.Size(300, 75);
            this.FinanceButton.TabIndex = 12;
            this.FinanceButton.Text = "Finance";
            this.FinanceButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FinanceButton.TextOffset = 20;
            this.FinanceButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.FinanceButton.UseVisualStyleBackColor = false;
            this.FinanceButton.Click += new System.EventHandler(this.FinanceButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SettingsButton);
            this.panel2.Location = new System.Drawing.Point(3, 566);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 609);
            this.panel2.TabIndex = 14;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.White;
            this.SettingsButton.BackgroundColor = System.Drawing.Color.White;
            this.SettingsButton.BorderColor = System.Drawing.Color.White;
            this.SettingsButton.BorderRadius = 0;
            this.SettingsButton.BorderSize = 0;
            this.SettingsButton.ButtonImage = global::BATODA.Properties.Resources.settings_nav_bar_icon;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SettingsButton.HoverBorderColor = System.Drawing.Color.Black;
            this.SettingsButton.HoverColor = System.Drawing.Color.Silver;
            this.SettingsButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SettingsButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.SettingsButton.ImageSize = new System.Drawing.Size(32, 32);
            this.SettingsButton.IsToggled = false;
            this.SettingsButton.Location = new System.Drawing.Point(0, 405);
            this.SettingsButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.PaddingX = 0;
            this.SettingsButton.PaddingY = 0;
            this.SettingsButton.Size = new System.Drawing.Size(300, 75);
            this.SettingsButton.TabIndex = 13;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SettingsButton.TextOffset = 20;
            this.SettingsButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.Silver;
            this.DisplayPanel.Location = new System.Drawing.Point(322, 522);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(304, 176);
            this.DisplayPanel.TabIndex = 5;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1604, 915);
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
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel DisplayPanel;
    }
}