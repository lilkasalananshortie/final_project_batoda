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
            this.MembersTopPanel = new System.Windows.Forms.Panel();
            this.ARHButton = new BATODA.ButtonStyle();
            this.AssistanceRequestButton = new BATODA.ButtonStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AssistanceHistoryGrid = new System.Windows.Forms.DataGridView();
            this.MembersTopPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssistanceHistoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MembersTopPanel
            // 
            this.MembersTopPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MembersTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MembersTopPanel.Controls.Add(this.ARHButton);
            this.MembersTopPanel.Controls.Add(this.AssistanceRequestButton);
            this.MembersTopPanel.Location = new System.Drawing.Point(14, 14);
            this.MembersTopPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MembersTopPanel.Name = "MembersTopPanel";
            this.MembersTopPanel.Size = new System.Drawing.Size(1595, 62);
            this.MembersTopPanel.TabIndex = 25;
            // 
            // ARHButton
            // 
            this.ARHButton.BackColor = System.Drawing.Color.LightGray;
            this.ARHButton.BackgroundColor = System.Drawing.Color.LightGray;
            this.ARHButton.BorderColor = System.Drawing.Color.Black;
            this.ARHButton.BorderRadius = 0;
            this.ARHButton.BorderSize = 1;
            this.ARHButton.ButtonImage = global::BATODA.Properties.Resources.history;
            this.ARHButton.FlatAppearance.BorderSize = 0;
            this.ARHButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ARHButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARHButton.ForeColor = System.Drawing.Color.Black;
            this.ARHButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.ARHButton.HoverColor = System.Drawing.Color.Silver;
            this.ARHButton.ImageColor = System.Drawing.Color.Black;
            this.ARHButton.ImagePosition = new System.Drawing.Point(255, 0);
            this.ARHButton.ImageSize = new System.Drawing.Size(32, 32);
            this.ARHButton.IsToggled = false;
            this.ARHButton.Location = new System.Drawing.Point(800, 5);
            this.ARHButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ARHButton.MouseDownColor = System.Drawing.Color.DarkGray;
            this.ARHButton.Name = "ARHButton";
            this.ARHButton.PaddingX = 0;
            this.ARHButton.PaddingY = 0;
            this.ARHButton.Size = new System.Drawing.Size(788, 49);
            this.ARHButton.TabIndex = 21;
            this.ARHButton.Text = "Approved Request History";
            this.ARHButton.TextColor = System.Drawing.Color.Black;
            this.ARHButton.TextOffset = 20;
            this.ARHButton.ToggleColor = System.Drawing.Color.LightGray;
            this.ARHButton.UseVisualStyleBackColor = false;
            this.ARHButton.Click += new System.EventHandler(this.ARHButton_Click);
            // 
            // AssistanceRequestButton
            // 
            this.AssistanceRequestButton.BackColor = System.Drawing.Color.White;
            this.AssistanceRequestButton.BackgroundColor = System.Drawing.Color.White;
            this.AssistanceRequestButton.BorderColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.BorderRadius = 0;
            this.AssistanceRequestButton.BorderSize = 1;
            this.AssistanceRequestButton.ButtonImage = global::BATODA.Properties.Resources.add;
            this.AssistanceRequestButton.FlatAppearance.BorderSize = 0;
            this.AssistanceRequestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AssistanceRequestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssistanceRequestButton.ForeColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.HoverBorderColor = System.Drawing.Color.Silver;
            this.AssistanceRequestButton.HoverColor = System.Drawing.Color.Silver;
            this.AssistanceRequestButton.ImageColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.ImagePosition = new System.Drawing.Point(265, 0);
            this.AssistanceRequestButton.ImageSize = new System.Drawing.Size(32, 32);
            this.AssistanceRequestButton.IsToggled = false;
            this.AssistanceRequestButton.Location = new System.Drawing.Point(6, 5);
            this.AssistanceRequestButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AssistanceRequestButton.MouseDownColor = System.Drawing.Color.DarkGray;
            this.AssistanceRequestButton.Name = "AssistanceRequestButton";
            this.AssistanceRequestButton.PaddingX = 0;
            this.AssistanceRequestButton.PaddingY = 0;
            this.AssistanceRequestButton.Size = new System.Drawing.Size(788, 49);
            this.AssistanceRequestButton.TabIndex = 19;
            this.AssistanceRequestButton.Text = "Assistance Request";
            this.AssistanceRequestButton.TextColor = System.Drawing.Color.Black;
            this.AssistanceRequestButton.TextOffset = 20;
            this.AssistanceRequestButton.ToggleColor = System.Drawing.Color.LightGray;
            this.AssistanceRequestButton.UseVisualStyleBackColor = false;
            this.AssistanceRequestButton.Click += new System.EventHandler(this.AssistanceRequestButton_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.pictureBox7);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(19, 94);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1585, 75);
            this.panel7.TabIndex = 51;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::BATODA.Properties.Resources.history;
            this.pictureBox7.Location = new System.Drawing.Point(16, 16);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(40, 40);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 44;
            this.pictureBox7.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(62, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 31);
            this.label7.TabIndex = 43;
            this.label7.Text = "History";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.AssistanceHistoryGrid);
            this.panel1.Location = new System.Drawing.Point(19, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1585, 796);
            this.panel1.TabIndex = 50;
            // 
            // AssistanceHistoryGrid
            // 
            this.AssistanceHistoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssistanceHistoryGrid.Location = new System.Drawing.Point(2, 1);
            this.AssistanceHistoryGrid.Name = "AssistanceHistoryGrid";
            this.AssistanceHistoryGrid.Size = new System.Drawing.Size(1582, 792);
            this.AssistanceHistoryGrid.TabIndex = 0;
            // 
            // ARHUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(236)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MembersTopPanel);
            this.Name = "ARHUForm";
            this.Size = new System.Drawing.Size(1677, 992);
            this.Load += new System.EventHandler(this.ARHUForm_Load);
            this.MembersTopPanel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssistanceHistoryGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MembersTopPanel;
        private ButtonStyle ARHButton;
        private ButtonStyle AssistanceRequestButton;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView AssistanceHistoryGrid;
    }
}
