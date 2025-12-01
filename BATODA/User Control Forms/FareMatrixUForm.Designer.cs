namespace BATODA.User_Control_Forms
{
    partial class FareMatrixUForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.FairMatrixDataGridView = new System.Windows.Forms.DataGridView();
            this.UpdateButton = new BATODA.ButtonStyle();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FairMatrixDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.UpdateButton);
            this.panel2.Controls.Add(this.FairMatrixDataGridView);
            this.panel2.Location = new System.Drawing.Point(65, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1465, 817);
            this.panel2.TabIndex = 1;
            // 
            // FairMatrixDataGridView
            // 
            this.FairMatrixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FairMatrixDataGridView.Location = new System.Drawing.Point(21, 18);
            this.FairMatrixDataGridView.MultiSelect = false;
            this.FairMatrixDataGridView.Name = "FairMatrixDataGridView";
            this.FairMatrixDataGridView.Size = new System.Drawing.Size(1419, 714);
            this.FairMatrixDataGridView.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.UpdateButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.UpdateButton.BorderColor = System.Drawing.Color.Red;
            this.UpdateButton.BorderRadius = 0;
            this.UpdateButton.BorderSize = 0;
            this.UpdateButton.ButtonImage = null;
            this.UpdateButton.FlatAppearance.BorderSize = 0;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.HoverBorderColor = System.Drawing.Color.DarkRed;
            this.UpdateButton.HoverColor = System.Drawing.Color.DarkRed;
            this.UpdateButton.ImageColor = System.Drawing.Color.Black;
            this.UpdateButton.ImagePosition = new System.Drawing.Point(10, 8);
            this.UpdateButton.ImageSize = new System.Drawing.Size(24, 24);
            this.UpdateButton.IsToggled = false;
            this.UpdateButton.Location = new System.Drawing.Point(1313, 758);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateButton.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.PaddingX = 0;
            this.UpdateButton.PaddingY = 0;
            this.UpdateButton.Size = new System.Drawing.Size(127, 33);
            this.UpdateButton.TabIndex = 91;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.TextColor = System.Drawing.Color.White;
            this.UpdateButton.TextOffset = 20;
            this.UpdateButton.ToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // FareMatrixUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Name = "FareMatrixUForm";
            this.Size = new System.Drawing.Size(1853, 1293);
            this.Load += new System.EventHandler(this.FareMatrixUForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FairMatrixDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView FairMatrixDataGridView;
        private ButtonStyle UpdateButton;
    }
}
