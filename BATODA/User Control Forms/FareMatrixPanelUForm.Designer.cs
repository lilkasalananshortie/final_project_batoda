namespace BATODA.User_Control_Forms
{
    partial class FareMatrixPanelUForm
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
            this.Studentlbl = new System.Windows.Forms.Label();
            this.Discountedlbl = new System.Windows.Forms.Label();
            this.BaseFarelbl = new System.Windows.Forms.Label();
            this.Routelbl = new System.Windows.Forms.Label();
            this.BaseFareTextBox = new System.Windows.Forms.TextBox();
            this.EditFareMatrix = new BATODA.ButtonStyle();
            this.SuspendLayout();
            // 
            // Studentlbl
            // 
            this.Studentlbl.AutoSize = true;
            this.Studentlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Studentlbl.Location = new System.Drawing.Point(968, 26);
            this.Studentlbl.Name = "Studentlbl";
            this.Studentlbl.Size = new System.Drawing.Size(60, 20);
            this.Studentlbl.TabIndex = 1;
            this.Studentlbl.Text = "₱35.00";
            // 
            // Discountedlbl
            // 
            this.Discountedlbl.AutoSize = true;
            this.Discountedlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Discountedlbl.Location = new System.Drawing.Point(763, 26);
            this.Discountedlbl.Name = "Discountedlbl";
            this.Discountedlbl.Size = new System.Drawing.Size(60, 20);
            this.Discountedlbl.TabIndex = 2;
            this.Discountedlbl.Text = "₱35.00";
            // 
            // BaseFarelbl
            // 
            this.BaseFarelbl.AutoSize = true;
            this.BaseFarelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseFarelbl.Location = new System.Drawing.Point(529, 25);
            this.BaseFarelbl.Name = "BaseFarelbl";
            this.BaseFarelbl.Size = new System.Drawing.Size(60, 20);
            this.BaseFarelbl.TabIndex = 3;
            this.BaseFarelbl.Text = "₱35.00";
            // 
            // Routelbl
            // 
            this.Routelbl.AutoSize = true;
            this.Routelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Routelbl.Location = new System.Drawing.Point(52, 26);
            this.Routelbl.Name = "Routelbl";
            this.Routelbl.Size = new System.Drawing.Size(149, 20);
            this.Routelbl.TabIndex = 4;
            this.Routelbl.Text = "Dulo, san sebastian";
            // 
            // BaseFareTextBox
            // 
            this.BaseFareTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaseFareTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseFareTextBox.Location = new System.Drawing.Point(532, 23);
            this.BaseFareTextBox.Name = "BaseFareTextBox";
            this.BaseFareTextBox.Size = new System.Drawing.Size(100, 26);
            this.BaseFareTextBox.TabIndex = 6;
            this.BaseFareTextBox.Visible = false;
            // 
            // EditFareMatrix
            // 
            this.EditFareMatrix.BackColor = System.Drawing.Color.White;
            this.EditFareMatrix.BackgroundColor = System.Drawing.Color.White;
            this.EditFareMatrix.BorderColor = System.Drawing.Color.White;
            this.EditFareMatrix.BorderRadius = 0;
            this.EditFareMatrix.BorderSize = 0;
            this.EditFareMatrix.ButtonImage = global::BATODA.Properties.Resources.edit;
            this.EditFareMatrix.FlatAppearance.BorderSize = 0;
            this.EditFareMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditFareMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditFareMatrix.ForeColor = System.Drawing.Color.White;
            this.EditFareMatrix.HoverBorderColor = System.Drawing.Color.White;
            this.EditFareMatrix.HoverColor = System.Drawing.Color.White;
            this.EditFareMatrix.ImageColor = System.Drawing.Color.Black;
            this.EditFareMatrix.ImagePosition = new System.Drawing.Point(10, 0);
            this.EditFareMatrix.ImageSize = new System.Drawing.Size(20, 20);
            this.EditFareMatrix.IsToggled = false;
            this.EditFareMatrix.Location = new System.Drawing.Point(1116, 21);
            this.EditFareMatrix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EditFareMatrix.MouseDownColor = System.Drawing.Color.White;
            this.EditFareMatrix.Name = "EditFareMatrix";
            this.EditFareMatrix.PaddingX = 0;
            this.EditFareMatrix.PaddingY = 0;
            this.EditFareMatrix.Size = new System.Drawing.Size(44, 32);
            this.EditFareMatrix.TabIndex = 60;
            this.EditFareMatrix.TextColor = System.Drawing.Color.White;
            this.EditFareMatrix.TextOffset = 20;
            this.EditFareMatrix.ToggleColor = System.Drawing.Color.White;
            this.EditFareMatrix.UseVisualStyleBackColor = false;
            this.EditFareMatrix.Click += new System.EventHandler(this.EditFareMatrix_Click);
            // 
            // FareMatrixPanelUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.EditFareMatrix);
            this.Controls.Add(this.BaseFareTextBox);
            this.Controls.Add(this.Studentlbl);
            this.Controls.Add(this.Discountedlbl);
            this.Controls.Add(this.BaseFarelbl);
            this.Controls.Add(this.Routelbl);
            this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.Name = "FareMatrixPanelUForm";
            this.Size = new System.Drawing.Size(1191, 77);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Studentlbl;
        public System.Windows.Forms.Label Discountedlbl;
        public System.Windows.Forms.Label BaseFarelbl;
        public System.Windows.Forms.Label Routelbl;
        private System.Windows.Forms.TextBox BaseFareTextBox;
        private ButtonStyle EditFareMatrix;
    }
}
