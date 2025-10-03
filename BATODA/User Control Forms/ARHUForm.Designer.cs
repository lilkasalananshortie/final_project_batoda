namespace BATODA
{
    partial class ARHUForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARHUForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MembersTopPanel = new System.Windows.Forms.Panel();
            this.ARHButton = new BATODA.ButtonStyle();
            this.AssistanceHomeButton = new BATODA.ButtonStyle();
            this.AssistanceRequestButton = new BATODA.ButtonStyle();
            this.panel1.SuspendLayout();
            this.MembersTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1408, 168);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1532, 670);
            this.panel1.TabIndex = 26;
            // 
            // MembersTopPanel
            // 
            this.MembersTopPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersTopPanel.Controls.Add(this.ARHButton);
            this.MembersTopPanel.Controls.Add(this.AssistanceHomeButton);
            this.MembersTopPanel.Controls.Add(this.AssistanceRequestButton);
            this.MembersTopPanel.Location = new System.Drawing.Point(16, 19);
            this.MembersTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MembersTopPanel.Name = "MembersTopPanel";
            this.MembersTopPanel.Size = new System.Drawing.Size(1532, 128);
            this.MembersTopPanel.TabIndex = 25;
            // 
            // ARHButton
            // 
            this.ARHButton.BackColor = System.Drawing.Color.LightGray;
            this.ARHButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.ARHButton.BorderColor = System.Drawing.Color.LightGray;
            this.ARHButton.BorderRadius = 0;
            this.ARHButton.BorderSize = 0;
            this.ARHButton.ButtonImage = global::BATODA.Properties.Resources.history;
            this.ARHButton.FlatAppearance.BorderSize = 0;
            this.ARHButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ARHButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARHButton.ForeColor = System.Drawing.Color.Black;
            this.ARHButton.ImageColor = System.Drawing.Color.Black;
            this.ARHButton.ImagePosition = new System.Drawing.Point(22, 22);
            this.ARHButton.ImageSize = new System.Drawing.Size(50, 50);
            this.ARHButton.Location = new System.Drawing.Point(1025, 14);
            this.ARHButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ARHButton.Name = "ARHButton";
            this.ARHButton.Size = new System.Drawing.Size(494, 100);
            this.ARHButton.TabIndex = 21;
            this.ARHButton.Text = "Approved Request History";
            this.ARHButton.TextColor = System.Drawing.Color.Black;
            this.ARHButton.TextPadding = 20;
            this.ARHButton.UseVisualStyleBackColor = false;
            this.ARHButton.Click += new System.EventHandler(this.ARHButton_Click);
            // 
            // AssistanceHomeButton
            // 
            this.AssistanceHomeButton.BackColor = System.Drawing.Color.LightGray;
            this.AssistanceHomeButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.AssistanceHomeButton.BorderColor = System.Drawing.Color.LightGray;
            this.AssistanceHomeButton.BorderRadius = 0;
            this.AssistanceHomeButton.BorderSize = 0;
            this.AssistanceHomeButton.ButtonImage = global::BATODA.Properties.Resources.pending_assistance;
            this.AssistanceHomeButton.FlatAppearance.BorderSize = 0;
            this.AssistanceHomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AssistanceHomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceHomeButton.ForeColor = System.Drawing.Color.Black;
            this.AssistanceHomeButton.ImageColor = System.Drawing.Color.Black;
            this.AssistanceHomeButton.ImagePosition = new System.Drawing.Point(22, 22);
            this.AssistanceHomeButton.ImageSize = new System.Drawing.Size(50, 50);
            this.AssistanceHomeButton.Location = new System.Drawing.Point(14, 14);
            this.AssistanceHomeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AssistanceHomeButton.Name = "AssistanceHomeButton";
            this.AssistanceHomeButton.Size = new System.Drawing.Size(494, 100);
            this.AssistanceHomeButton.TabIndex = 20;
            this.AssistanceHomeButton.Text = "Assistance Dashboard";
            this.AssistanceHomeButton.TextColor = System.Drawing.Color.Black;
            this.AssistanceHomeButton.TextPadding = 20;
            this.AssistanceHomeButton.UseVisualStyleBackColor = false;
            this.AssistanceHomeButton.Click += new System.EventHandler(this.AssistanceHomeButton_Click);
            // 
            // AssistanceRequestButton
            // 
            this.AssistanceRequestButton.BackColor = System.Drawing.Color.LightGray;
            this.AssistanceRequestButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.AssistanceRequestButton.BorderColor = System.Drawing.Color.LightGray;
            this.AssistanceRequestButton.BorderRadius = 0;
            this.AssistanceRequestButton.BorderSize = 0;
            this.AssistanceRequestButton.ButtonImage = global::BATODA.Properties.Resources.add;
            this.AssistanceRequestButton.FlatAppearance.BorderSize = 0;
            this.AssistanceRequestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AssistanceRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceRequestButton.ForeColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.ImageColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.ImagePosition = new System.Drawing.Point(22, 30);
            this.AssistanceRequestButton.ImageSize = new System.Drawing.Size(32, 32);
            this.AssistanceRequestButton.Location = new System.Drawing.Point(514, 14);
            this.AssistanceRequestButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AssistanceRequestButton.Name = "AssistanceRequestButton";
            this.AssistanceRequestButton.Size = new System.Drawing.Size(494, 100);
            this.AssistanceRequestButton.TabIndex = 19;
            this.AssistanceRequestButton.Text = "Assistance Request";
            this.AssistanceRequestButton.TextColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.TextPadding = 10;
            this.AssistanceRequestButton.UseVisualStyleBackColor = false;
            this.AssistanceRequestButton.Click += new System.EventHandler(this.AssistanceRequestButton_Click);
            // 
            // ARHUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MembersTopPanel);
            this.Name = "ARHUForm";
            this.Size = new System.Drawing.Size(1898, 994);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MembersTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MembersTopPanel;
        private ButtonStyle ARHButton;
        private ButtonStyle AssistanceHomeButton;
        private ButtonStyle AssistanceRequestButton;
    }
}
