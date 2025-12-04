namespace BATODA.UI_Displays
{
    partial class ExceptionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new BATODA.ButtonStyle();
            this.MessageError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 43);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.btnClose.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.btnClose.BorderRadius = 0;
            this.btnClose.BorderSize = 0;
            this.btnClose.ButtonImage = null;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverBorderColor = System.Drawing.Color.DarkRed;
            this.btnClose.HoverColor = System.Drawing.Color.DarkRed;
            this.btnClose.ImageColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.ImagePosition = new System.Drawing.Point(20, 0);
            this.btnClose.ImageSize = new System.Drawing.Size(32, 32);
            this.btnClose.IsToggled = false;
            this.btnClose.Location = new System.Drawing.Point(283, 181);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.btnClose.Name = "btnClose";
            this.btnClose.PaddingX = 0;
            this.btnClose.PaddingY = 0;
            this.btnClose.Size = new System.Drawing.Size(123, 35);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.TextOffset = 5;
            this.btnClose.ToggleColor = System.Drawing.Color.Empty;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // MessageError
            // 
            this.MessageError.AutoSize = true;
            this.MessageError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageError.Location = new System.Drawing.Point(73, 106);
            this.MessageError.Name = "MessageError";
            this.MessageError.Size = new System.Drawing.Size(284, 25);
            this.MessageError.TabIndex = 38;
            this.MessageError.Text = "Message: SAMPLE ERRO";
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 229);
            this.ControlBox = false;
            this.Controls.Add(this.MessageError);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ExceptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ButtonStyle btnClose;
        private System.Windows.Forms.Label MessageError;
    }
}