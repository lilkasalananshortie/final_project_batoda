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
            this.TopBarPanel = new System.Windows.Forms.Panel();
            this.MainTime = new System.Windows.Forms.Label();
            this.MainDate = new System.Windows.Forms.Label();
            this.SubTopPanel = new System.Windows.Forms.Label();
            this.TopPanelText = new System.Windows.Forms.Label();
            this.NavBarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateNewAdminAccountPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.ConfirmPasswordTextbox = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.NewPasswordTextbox = new System.Windows.Forms.TextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.NewEmailAddressTextbox = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.FullnameTextbox = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SwitchAdminAccountButton = new BATODA.ButtonStyle();
            this.CreateNewAdminAccountButton = new BATODA.ButtonStyle();
            this.LogOutButton = new BATODA.ButtonStyle();
            this.CreateNewAdminCancelButton = new BATODA.ButtonStyle();
            this.CreateAccountButton = new BATODA.ButtonStyle();
            this.HomeButton = new BATODA.ButtonStyle();
            this.MembersMainButton = new BATODA.ButtonStyle();
            this.RegisteredVehiclesButton = new BATODA.ButtonStyle();
            this.AssistanceLogButton = new BATODA.ButtonStyle();
            this.FinanceButton = new BATODA.ButtonStyle();
            this.CalendarBtn = new BATODA.ButtonStyle();
            this.FareMatrixButton = new BATODA.ButtonStyle();
            this.CSButton = new BATODA.ButtonStyle();
            this.SettingsButton = new BATODA.ButtonStyle();
            this.panel1.SuspendLayout();
            this.TopBarPanel.SuspendLayout();
            this.NavBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SettingsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.CreateNewAdminAccountPanel.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 152);
            this.panel1.TabIndex = 8;
            // 
            // TopBarPanel
            // 
            this.TopBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TopBarPanel.Controls.Add(this.pictureBox3);
            this.TopBarPanel.Controls.Add(this.pictureBox1);
            this.TopBarPanel.Controls.Add(this.MainTime);
            this.TopBarPanel.Controls.Add(this.MainDate);
            this.TopBarPanel.Controls.Add(this.SubTopPanel);
            this.TopBarPanel.Controls.Add(this.TopPanelText);
            this.TopBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBarPanel.Location = new System.Drawing.Point(300, 0);
            this.TopBarPanel.Name = "TopBarPanel";
            this.TopBarPanel.Size = new System.Drawing.Size(1624, 90);
            this.TopBarPanel.TabIndex = 3;
            // 
            // MainTime
            // 
            this.MainTime.AutoSize = true;
            this.MainTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTime.ForeColor = System.Drawing.Color.White;
            this.MainTime.Location = new System.Drawing.Point(1230, 18);
            this.MainTime.Name = "MainTime";
            this.MainTime.Size = new System.Drawing.Size(80, 20);
            this.MainTime.TabIndex = 8;
            this.MainTime.Text = "00:00AM";
            this.MainTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainDate
            // 
            this.MainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainDate.ForeColor = System.Drawing.Color.White;
            this.MainDate.Location = new System.Drawing.Point(929, 17);
            this.MainDate.Name = "MainDate";
            this.MainDate.Size = new System.Drawing.Size(303, 20);
            this.MainDate.TabIndex = 7;
            this.MainDate.Text = "Decenber 05, 2025 (Friday)";
            this.MainDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubTopPanel
            // 
            this.SubTopPanel.AutoSize = true;
            this.SubTopPanel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTopPanel.ForeColor = System.Drawing.Color.White;
            this.SubTopPanel.Location = new System.Drawing.Point(27, 57);
            this.SubTopPanel.Name = "SubTopPanel";
            this.SubTopPanel.Size = new System.Drawing.Size(345, 21);
            this.SubTopPanel.TabIndex = 0;
            this.SubTopPanel.Text = "Here’s what’s happening with your organization.";
            // 
            // TopPanelText
            // 
            this.TopPanelText.AutoSize = true;
            this.TopPanelText.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopPanelText.ForeColor = System.Drawing.Color.White;
            this.TopPanelText.Location = new System.Drawing.Point(23, 19);
            this.TopPanelText.Name = "TopPanelText";
            this.TopPanelText.Size = new System.Drawing.Size(325, 45);
            this.TopPanelText.TabIndex = 0;
            this.TopPanelText.Text = "BAMBANG TODA";
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
            this.NavBarPanel.Controls.Add(this.CalendarBtn);
            this.NavBarPanel.Controls.Add(this.FareMatrixButton);
            this.NavBarPanel.Controls.Add(this.CSButton);
            this.NavBarPanel.Controls.Add(this.SettingsButton);
            this.NavBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavBarPanel.Location = new System.Drawing.Point(0, 0);
            this.NavBarPanel.Name = "NavBarPanel";
            this.NavBarPanel.Size = new System.Drawing.Size(300, 1061);
            this.NavBarPanel.TabIndex = 1;
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.BackColor = System.Drawing.Color.Silver;
            this.DisplayPanel.Location = new System.Drawing.Point(316, 111);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(193, 119);
            this.DisplayPanel.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::BATODA.Properties.Resources.notification;
            this.pictureBox3.Location = new System.Drawing.Point(1523, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BATODA.Properties.Resources.settings_nav_bar_icon;
            this.pictureBox1.Location = new System.Drawing.Point(1566, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BATODA.Properties.Resources.BambangIUFBBTODA;
            this.pictureBox2.Location = new System.Drawing.Point(9, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(277, 111);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.BackColor = System.Drawing.Color.White;
            this.SettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SettingsPanel.Controls.Add(this.label1);
            this.SettingsPanel.Controls.Add(this.pictureBox5);
            this.SettingsPanel.Controls.Add(this.panel2);
            this.SettingsPanel.Controls.Add(this.SwitchAdminAccountButton);
            this.SettingsPanel.Controls.Add(this.CreateNewAdminAccountButton);
            this.SettingsPanel.Controls.Add(this.LogOutButton);
            this.SettingsPanel.Controls.Add(this.CreateNewAdminAccountPanel);
            this.SettingsPanel.Location = new System.Drawing.Point(1529, 90);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(390, 966);
            this.SettingsPanel.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(16, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 106);
            this.panel2.TabIndex = 28;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BATODA.Properties.Resources.unblur_bgc_toda;
            this.pictureBox4.Location = new System.Drawing.Point(25, 25);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(61, 56);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(100, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Account Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(100, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account Management";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BATODA.Properties.Resources.icon;
            this.pictureBox5.Location = new System.Drawing.Point(128, 164);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(150, 150);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(166, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Set proile photo";
            // 
            // CreateNewAdminAccountPanel
            // 
            this.CreateNewAdminAccountPanel.Controls.Add(this.CreateNewAdminCancelButton);
            this.CreateNewAdminAccountPanel.Controls.Add(this.CreateAccountButton);
            this.CreateNewAdminAccountPanel.Controls.Add(this.label12);
            this.CreateNewAdminAccountPanel.Controls.Add(this.label11);
            this.CreateNewAdminAccountPanel.Controls.Add(this.label13);
            this.CreateNewAdminAccountPanel.Controls.Add(this.label10);
            this.CreateNewAdminAccountPanel.Controls.Add(this.panel13);
            this.CreateNewAdminAccountPanel.Controls.Add(this.panel14);
            this.CreateNewAdminAccountPanel.Controls.Add(this.panel12);
            this.CreateNewAdminAccountPanel.Controls.Add(this.panel11);
            this.CreateNewAdminAccountPanel.Controls.Add(this.pictureBox7);
            this.CreateNewAdminAccountPanel.Controls.Add(this.label9);
            this.CreateNewAdminAccountPanel.Location = new System.Drawing.Point(10, 26);
            this.CreateNewAdminAccountPanel.Name = "CreateNewAdminAccountPanel";
            this.CreateNewAdminAccountPanel.Size = new System.Drawing.Size(373, 594);
            this.CreateNewAdminAccountPanel.TabIndex = 93;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.label12.Location = new System.Drawing.Point(35, 427);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Confirm Password *";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.label11.Location = new System.Drawing.Point(35, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Email Address *";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.label13.Location = new System.Drawing.Point(35, 342);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Password *";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.label10.Location = new System.Drawing.Point(35, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Full name *";
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.ConfirmPasswordTextbox);
            this.panel13.Location = new System.Drawing.Point(36, 450);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(300, 36);
            this.panel13.TabIndex = 25;
            // 
            // ConfirmPasswordTextbox
            // 
            this.ConfirmPasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfirmPasswordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextbox.Location = new System.Drawing.Point(6, 8);
            this.ConfirmPasswordTextbox.Name = "ConfirmPasswordTextbox";
            this.ConfirmPasswordTextbox.Size = new System.Drawing.Size(284, 19);
            this.ConfirmPasswordTextbox.TabIndex = 1;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.NewPasswordTextbox);
            this.panel14.Location = new System.Drawing.Point(36, 365);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(300, 36);
            this.panel14.TabIndex = 24;
            // 
            // NewPasswordTextbox
            // 
            this.NewPasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewPasswordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasswordTextbox.Location = new System.Drawing.Point(6, 8);
            this.NewPasswordTextbox.Name = "NewPasswordTextbox";
            this.NewPasswordTextbox.Size = new System.Drawing.Size(284, 19);
            this.NewPasswordTextbox.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.NewEmailAddressTextbox);
            this.panel12.Location = new System.Drawing.Point(36, 280);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(300, 36);
            this.panel12.TabIndex = 22;
            // 
            // NewEmailAddressTextbox
            // 
            this.NewEmailAddressTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewEmailAddressTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewEmailAddressTextbox.Location = new System.Drawing.Point(6, 8);
            this.NewEmailAddressTextbox.Name = "NewEmailAddressTextbox";
            this.NewEmailAddressTextbox.Size = new System.Drawing.Size(284, 19);
            this.NewEmailAddressTextbox.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.FullnameTextbox);
            this.panel11.Location = new System.Drawing.Point(36, 195);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(300, 36);
            this.panel11.TabIndex = 21;
            // 
            // FullnameTextbox
            // 
            this.FullnameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FullnameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullnameTextbox.Location = new System.Drawing.Point(6, 8);
            this.FullnameTextbox.Name = "FullnameTextbox";
            this.FullnameTextbox.Size = new System.Drawing.Size(284, 19);
            this.FullnameTextbox.TabIndex = 0;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::BATODA.Properties.Resources.BambangIUFBBTODA;
            this.pictureBox7.Location = new System.Drawing.Point(60, 7);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(258, 68);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 20;
            this.pictureBox7.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.label9.Location = new System.Drawing.Point(31, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(306, 29);
            this.label9.TabIndex = 17;
            this.label9.Text = "Create New Admin Account";
            // 
            // SwitchAdminAccountButton
            // 
            this.SwitchAdminAccountButton.BackColor = System.Drawing.Color.White;
            this.SwitchAdminAccountButton.BackgroundColor = System.Drawing.Color.White;
            this.SwitchAdminAccountButton.BorderColor = System.Drawing.Color.Black;
            this.SwitchAdminAccountButton.BorderRadius = 8;
            this.SwitchAdminAccountButton.BorderSize = 1;
            this.SwitchAdminAccountButton.ButtonImage = global::BATODA.Properties.Resources.transfer;
            this.SwitchAdminAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwitchAdminAccountButton.ForeColor = System.Drawing.Color.Black;
            this.SwitchAdminAccountButton.HoverBorderColor = System.Drawing.Color.Black;
            this.SwitchAdminAccountButton.HoverColor = System.Drawing.Color.LightGray;
            this.SwitchAdminAccountButton.ImageColor = System.Drawing.Color.Black;
            this.SwitchAdminAccountButton.ImagePosition = new System.Drawing.Point(60, 0);
            this.SwitchAdminAccountButton.ImageSize = new System.Drawing.Size(24, 24);
            this.SwitchAdminAccountButton.IsToggled = false;
            this.SwitchAdminAccountButton.Location = new System.Drawing.Point(16, 364);
            this.SwitchAdminAccountButton.MouseDownColor = System.Drawing.Color.White;
            this.SwitchAdminAccountButton.Name = "SwitchAdminAccountButton";
            this.SwitchAdminAccountButton.PaddingX = 0;
            this.SwitchAdminAccountButton.PaddingY = 0;
            this.SwitchAdminAccountButton.Size = new System.Drawing.Size(362, 59);
            this.SwitchAdminAccountButton.TabIndex = 27;
            this.SwitchAdminAccountButton.Text = "Set Municipal Gmail Account";
            this.SwitchAdminAccountButton.TextColor = System.Drawing.Color.Black;
            this.SwitchAdminAccountButton.TextOffset = 15;
            this.SwitchAdminAccountButton.ToggleColor = System.Drawing.Color.Empty;
            this.SwitchAdminAccountButton.UseVisualStyleBackColor = false;
            // 
            // CreateNewAdminAccountButton
            // 
            this.CreateNewAdminAccountButton.BackColor = System.Drawing.Color.White;
            this.CreateNewAdminAccountButton.BackgroundColor = System.Drawing.Color.White;
            this.CreateNewAdminAccountButton.BorderColor = System.Drawing.Color.Black;
            this.CreateNewAdminAccountButton.BorderRadius = 8;
            this.CreateNewAdminAccountButton.BorderSize = 1;
            this.CreateNewAdminAccountButton.ButtonImage = global::BATODA.Properties.Resources.add_user;
            this.CreateNewAdminAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewAdminAccountButton.ForeColor = System.Drawing.Color.Black;
            this.CreateNewAdminAccountButton.HoverBorderColor = System.Drawing.Color.Black;
            this.CreateNewAdminAccountButton.HoverColor = System.Drawing.Color.LightGray;
            this.CreateNewAdminAccountButton.ImageColor = System.Drawing.Color.Black;
            this.CreateNewAdminAccountButton.ImagePosition = new System.Drawing.Point(60, 0);
            this.CreateNewAdminAccountButton.ImageSize = new System.Drawing.Size(24, 24);
            this.CreateNewAdminAccountButton.IsToggled = false;
            this.CreateNewAdminAccountButton.Location = new System.Drawing.Point(16, 444);
            this.CreateNewAdminAccountButton.MouseDownColor = System.Drawing.Color.White;
            this.CreateNewAdminAccountButton.Name = "CreateNewAdminAccountButton";
            this.CreateNewAdminAccountButton.PaddingX = 0;
            this.CreateNewAdminAccountButton.PaddingY = 0;
            this.CreateNewAdminAccountButton.Size = new System.Drawing.Size(362, 59);
            this.CreateNewAdminAccountButton.TabIndex = 26;
            this.CreateNewAdminAccountButton.Text = "Create New Admin Account";
            this.CreateNewAdminAccountButton.TextColor = System.Drawing.Color.Black;
            this.CreateNewAdminAccountButton.TextOffset = 15;
            this.CreateNewAdminAccountButton.ToggleColor = System.Drawing.Color.Empty;
            this.CreateNewAdminAccountButton.UseVisualStyleBackColor = false;
            this.CreateNewAdminAccountButton.Click += new System.EventHandler(this.CreateNewAdminAccountButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.LogOutButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.LogOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogOutButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.LogOutButton.BorderRadius = 8;
            this.LogOutButton.BorderSize = 1;
            this.LogOutButton.ButtonImage = global::BATODA.Properties.Resources.logout__1_;
            this.LogOutButton.FlatAppearance.BorderSize = 0;
            this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.HoverBorderColor = System.Drawing.Color.DarkRed;
            this.LogOutButton.HoverColor = System.Drawing.Color.DarkRed;
            this.LogOutButton.ImageColor = System.Drawing.Color.White;
            this.LogOutButton.ImagePosition = new System.Drawing.Point(125, 0);
            this.LogOutButton.ImageSize = new System.Drawing.Size(24, 24);
            this.LogOutButton.IsToggled = false;
            this.LogOutButton.Location = new System.Drawing.Point(16, 898);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogOutButton.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.PaddingX = 0;
            this.LogOutButton.PaddingY = 0;
            this.LogOutButton.Size = new System.Drawing.Size(362, 59);
            this.LogOutButton.TabIndex = 25;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.TextColor = System.Drawing.Color.White;
            this.LogOutButton.TextOffset = 20;
            this.LogOutButton.ToggleColor = System.Drawing.Color.Empty;
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CreateNewAdminCancelButton
            // 
            this.CreateNewAdminCancelButton.BackColor = System.Drawing.Color.White;
            this.CreateNewAdminCancelButton.BackgroundColor = System.Drawing.Color.White;
            this.CreateNewAdminCancelButton.BorderColor = System.Drawing.Color.Black;
            this.CreateNewAdminCancelButton.BorderRadius = 40;
            this.CreateNewAdminCancelButton.BorderSize = 1;
            this.CreateNewAdminCancelButton.ButtonImage = null;
            this.CreateNewAdminCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateNewAdminCancelButton.ForeColor = System.Drawing.Color.Black;
            this.CreateNewAdminCancelButton.HoverBorderColor = System.Drawing.Color.Black;
            this.CreateNewAdminCancelButton.HoverColor = System.Drawing.Color.LightGray;
            this.CreateNewAdminCancelButton.ImageColor = System.Drawing.Color.Black;
            this.CreateNewAdminCancelButton.ImagePosition = new System.Drawing.Point(10, 0);
            this.CreateNewAdminCancelButton.ImageSize = new System.Drawing.Size(24, 24);
            this.CreateNewAdminCancelButton.IsToggled = false;
            this.CreateNewAdminCancelButton.Location = new System.Drawing.Point(57, 522);
            this.CreateNewAdminCancelButton.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.CreateNewAdminCancelButton.Name = "CreateNewAdminCancelButton";
            this.CreateNewAdminCancelButton.PaddingX = 0;
            this.CreateNewAdminCancelButton.PaddingY = 0;
            this.CreateNewAdminCancelButton.Size = new System.Drawing.Size(100, 40);
            this.CreateNewAdminCancelButton.TabIndex = 29;
            this.CreateNewAdminCancelButton.Text = "Cancel";
            this.CreateNewAdminCancelButton.TextColor = System.Drawing.Color.Black;
            this.CreateNewAdminCancelButton.TextOffset = 20;
            this.CreateNewAdminCancelButton.ToggleColor = System.Drawing.Color.Empty;
            this.CreateNewAdminCancelButton.UseVisualStyleBackColor = false;
            this.CreateNewAdminCancelButton.Click += new System.EventHandler(this.CreateNewAdminCancelButton_Click);
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.CreateAccountButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.CreateAccountButton.BorderColor = System.Drawing.Color.DarkRed;
            this.CreateAccountButton.BorderRadius = 40;
            this.CreateAccountButton.BorderSize = 0;
            this.CreateAccountButton.ButtonImage = null;
            this.CreateAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccountButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CreateAccountButton.HoverBorderColor = System.Drawing.Color.Empty;
            this.CreateAccountButton.HoverColor = System.Drawing.Color.DarkRed;
            this.CreateAccountButton.ImageColor = System.Drawing.Color.Black;
            this.CreateAccountButton.ImagePosition = new System.Drawing.Point(10, 0);
            this.CreateAccountButton.ImageSize = new System.Drawing.Size(24, 24);
            this.CreateAccountButton.IsToggled = false;
            this.CreateAccountButton.Location = new System.Drawing.Point(169, 522);
            this.CreateAccountButton.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.PaddingX = 0;
            this.CreateAccountButton.PaddingY = 0;
            this.CreateAccountButton.Size = new System.Drawing.Size(150, 40);
            this.CreateAccountButton.TabIndex = 28;
            this.CreateAccountButton.Text = "Create Account";
            this.CreateAccountButton.TextColor = System.Drawing.Color.WhiteSmoke;
            this.CreateAccountButton.TextOffset = 20;
            this.CreateAccountButton.ToggleColor = System.Drawing.Color.Empty;
            this.CreateAccountButton.UseVisualStyleBackColor = false;
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
            // CalendarBtn
            // 
            this.CalendarBtn.BackColor = System.Drawing.Color.White;
            this.CalendarBtn.BackgroundColor = System.Drawing.Color.White;
            this.CalendarBtn.BorderColor = System.Drawing.Color.Red;
            this.CalendarBtn.BorderRadius = 0;
            this.CalendarBtn.BorderSize = 0;
            this.CalendarBtn.ButtonImage = global::BATODA.Properties.Resources.calendar_module;
            this.CalendarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CalendarBtn.HoverBorderColor = System.Drawing.Color.Black;
            this.CalendarBtn.HoverColor = System.Drawing.Color.Silver;
            this.CalendarBtn.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CalendarBtn.ImagePosition = new System.Drawing.Point(20, 0);
            this.CalendarBtn.ImageSize = new System.Drawing.Size(36, 36);
            this.CalendarBtn.IsToggled = false;
            this.CalendarBtn.Location = new System.Drawing.Point(3, 566);
            this.CalendarBtn.MouseDownColor = System.Drawing.Color.LightGray;
            this.CalendarBtn.Name = "CalendarBtn";
            this.CalendarBtn.PaddingX = 0;
            this.CalendarBtn.PaddingY = 0;
            this.CalendarBtn.Size = new System.Drawing.Size(300, 75);
            this.CalendarBtn.TabIndex = 13;
            this.CalendarBtn.Text = "Calendar";
            this.CalendarBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CalendarBtn.TextOffset = 20;
            this.CalendarBtn.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CalendarBtn.UseVisualStyleBackColor = false;
            this.CalendarBtn.Click += new System.EventHandler(this.CalendarBtn_Click);
            // 
            // FareMatrixButton
            // 
            this.FareMatrixButton.BackColor = System.Drawing.Color.White;
            this.FareMatrixButton.BackgroundColor = System.Drawing.Color.White;
            this.FareMatrixButton.BorderColor = System.Drawing.Color.White;
            this.FareMatrixButton.BorderRadius = 0;
            this.FareMatrixButton.BorderSize = 0;
            this.FareMatrixButton.ButtonImage = global::BATODA.Properties.Resources.application;
            this.FareMatrixButton.FlatAppearance.BorderSize = 0;
            this.FareMatrixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FareMatrixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FareMatrixButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FareMatrixButton.HoverBorderColor = System.Drawing.Color.Black;
            this.FareMatrixButton.HoverColor = System.Drawing.Color.Silver;
            this.FareMatrixButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FareMatrixButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.FareMatrixButton.ImageSize = new System.Drawing.Size(40, 40);
            this.FareMatrixButton.IsToggled = false;
            this.FareMatrixButton.Location = new System.Drawing.Point(3, 647);
            this.FareMatrixButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.FareMatrixButton.Name = "FareMatrixButton";
            this.FareMatrixButton.PaddingX = 0;
            this.FareMatrixButton.PaddingY = 0;
            this.FareMatrixButton.Size = new System.Drawing.Size(300, 75);
            this.FareMatrixButton.TabIndex = 14;
            this.FareMatrixButton.Text = "Fare Matrix";
            this.FareMatrixButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FareMatrixButton.TextOffset = 20;
            this.FareMatrixButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.FareMatrixButton.UseVisualStyleBackColor = false;
            this.FareMatrixButton.Click += new System.EventHandler(this.FareMatrixButton_Click);
            // 
            // CSButton
            // 
            this.CSButton.BackColor = System.Drawing.Color.White;
            this.CSButton.BackgroundColor = System.Drawing.Color.White;
            this.CSButton.BorderColor = System.Drawing.Color.White;
            this.CSButton.BorderRadius = 0;
            this.CSButton.BorderSize = 0;
            this.CSButton.ButtonImage = global::BATODA.Properties.Resources.operator_icon;
            this.CSButton.FlatAppearance.BorderSize = 0;
            this.CSButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CSButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CSButton.HoverBorderColor = System.Drawing.Color.Black;
            this.CSButton.HoverColor = System.Drawing.Color.Silver;
            this.CSButton.ImageColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CSButton.ImagePosition = new System.Drawing.Point(20, 0);
            this.CSButton.ImageSize = new System.Drawing.Size(32, 32);
            this.CSButton.IsToggled = false;
            this.CSButton.Location = new System.Drawing.Point(3, 728);
            this.CSButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.CSButton.Name = "CSButton";
            this.CSButton.PaddingX = 0;
            this.CSButton.PaddingY = 0;
            this.CSButton.Size = new System.Drawing.Size(300, 75);
            this.CSButton.TabIndex = 13;
            this.CSButton.Text = "Customer Support";
            this.CSButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CSButton.TextOffset = 20;
            this.CSButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.CSButton.UseVisualStyleBackColor = false;
            this.CSButton.Click += new System.EventHandler(this.CSButton_Click);
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
            this.SettingsButton.Location = new System.Drawing.Point(3, 809);
            this.SettingsButton.MouseDownColor = System.Drawing.Color.LightGray;
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.PaddingX = 0;
            this.SettingsButton.PaddingY = 0;
            this.SettingsButton.Size = new System.Drawing.Size(300, 75);
            this.SettingsButton.TabIndex = 15;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SettingsButton.TextOffset = 20;
            this.SettingsButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.TopBarPanel);
            this.Controls.Add(this.NavBarPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DashboardForm";
            this.Text = "BATODA Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panel1.ResumeLayout(false);
            this.TopBarPanel.ResumeLayout(false);
            this.TopBarPanel.PerformLayout();
            this.NavBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.CreateNewAdminAccountPanel.ResumeLayout(false);
            this.CreateNewAdminAccountPanel.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel TopBarPanel;
        private System.Windows.Forms.Label TopPanelText;
        private System.Windows.Forms.Panel panel1;
        private ButtonStyle HomeButton;
        private ButtonStyle RegisteredVehiclesButton;
        private ButtonStyle AssistanceLogButton;
        private ButtonStyle FinanceButton;
        private ButtonStyle CSButton;
        private System.Windows.Forms.FlowLayoutPanel NavBarPanel;
        private System.Windows.Forms.Panel DisplayPanel;
        private ButtonStyle MembersMainButton;
        private ButtonStyle CalendarBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label MainDate;
        private System.Windows.Forms.Label MainTime;
        private System.Windows.Forms.Label SubTopPanel;
        private ButtonStyle FareMatrixButton;
        private ButtonStyle SettingsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ButtonStyle SwitchAdminAccountButton;
        private ButtonStyle CreateNewAdminAccountButton;
        private ButtonStyle LogOutButton;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel CreateNewAdminAccountPanel;
        private ButtonStyle CreateNewAdminCancelButton;
        private ButtonStyle CreateAccountButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox ConfirmPasswordTextbox;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox NewPasswordTextbox;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox NewEmailAddressTextbox;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox FullnameTextbox;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label9;
    }
}