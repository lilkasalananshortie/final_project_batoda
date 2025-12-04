using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.User_Control_Forms
{
    public partial class FareMatrixPanelUForm : UserControl
    {
        public FareMatrixPanelUForm()
        {
            InitializeComponent();
            BaseFareTextBox.KeyDown += BaseFareTextBox_KeyDown;
        }

        private bool isEditing = false;

        public string Route
        {
            get => Routelbl.Text;
            set => Routelbl.Text = value;
        }

        public string BaseFare
        {
            get => BaseFarelbl.Text;
            set
            {
                BaseFarelbl.Text = value;
                UpdateDiscounted();
            }
        }


        public string Student
        {
            get => Studentlbl.Text;
            set => Studentlbl.Text = value;
        }

        public string Discounted
        {
            get => Discountedlbl.Text;
            set => Discountedlbl.Text = value;
        }

        private void UpdateDiscounted()
        {
            if (decimal.TryParse(BaseFarelbl.Text.Replace("₱", ""), out decimal baseFare))
            {
                decimal discounted = baseFare * 0.8m; // 20% off
                Discountedlbl.Text = $"₱{discounted:0.00}";
                Studentlbl.Text = $"₱{discounted:0.00}";
            }
            else
            {
                Discountedlbl.Text = "₱--";
                Studentlbl.Text = "₱--";
            }
        }

        private void BaseFareTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isEditing)
            {
                e.SuppressKeyPress = true; // prevent ding sound
                SaveBaseFare();
            }
        }

        private void SaveBaseFare()
        {
            string input = BaseFareTextBox.Text.Trim();
            if (decimal.TryParse(input, out decimal baseFare))
            {
                BaseFarelbl.Text = $"₱{baseFare:0.00}";
                UpdateDiscounted();
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric fare.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BaseFareTextBox.Visible = false;
            BaseFarelbl.Visible = true;
            EditFareMatrix.ButtonImage = Properties.Resources.edit;
            isEditing = false;
        }
        private void EditFareMatrix_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // Switch to edit mode
                BaseFareTextBox.Text = BaseFarelbl.Text.Replace("₱", "").Trim();
                BaseFareTextBox.Visible = true;
                BaseFarelbl.Visible = false;
                EditFareMatrix.ButtonImage = Properties.Resources.save;
                isEditing = true;
                BaseFareTextBox.Focus(); // focus for immediate typing
            }
            else
            {
                SaveBaseFare();
            }
        }
    }
}
