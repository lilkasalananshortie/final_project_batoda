using System;
using System.Windows.Forms;
using BATODA.Modules.FareMatrix_Classes;

namespace BATODA.User_Control_Forms
{
    public partial class FareMatrixPanelUForm : UserControl
    {
        private bool isEditing = false;
        private FareMatrixRepository repo = new FareMatrixRepository();
        public int RouteID { get; set; }

        public FareMatrixPanelUForm()
        {
            InitializeComponent();

            BaseFareTextBox.KeyDown += BaseFareTextBox_KeyDown;
            EditFareMatrix.Click += EditFareMatrix_Click;

            BaseFareTextBox.Visible = false;
        }

        private void FareMatrixPanelUForm_Load(object sender, EventArgs e)
        {
            BaseFareTextBox.Location = BaseFarelbl.Location;
            BaseFareTextBox.Size = BaseFarelbl.Size;
        }

        public decimal BaseFare
        {
            get => decimal.TryParse(BaseFarelbl.Text.Replace("₱", ""), out var val) ? val : 0;
            set
            {
                BaseFarelbl.Text = $"₱{value:0.00}";
                UpdateDiscounted();
            }
        }

        public string Route
        {
            get => Routelbl.Text;
            set => Routelbl.Text = value;
        }


        public decimal Student
        {
            get => decimal.TryParse(Studentlbl.Text.Replace("₱", ""), out var val) ? val : 0;
            set => Studentlbl.Text = $"₱{value:0.00}";
        }

        public decimal Discounted
        {
            get => decimal.TryParse(Discountedlbl.Text.Replace("₱", ""), out var val) ? val : 0;
            set => Discountedlbl.Text = $"₱{value:0.00}";
        }

        private void UpdateDiscounted()
        {
            decimal discounted = BaseFare * 0.8m;
            Discounted = discounted;
            Student = discounted;
        }

        private void EditFareMatrix_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                BaseFareTextBox.Text = BaseFare.ToString("0.00");
                BaseFareTextBox.Visible = true;
                BaseFareTextBox.BringToFront();

                BaseFarelbl.Visible = false;
                EditFareMatrix.Text = "Save";

                BaseFareTextBox.Focus();
                BaseFareTextBox.SelectAll();
            }
            else
            {
                SaveBaseFare();
            }
        }

        private void BaseFareTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 

                if (string.IsNullOrWhiteSpace(BaseFareTextBox.Text))
                {
                    MessageBox.Show("Please enter a fare before saving.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BaseFareTextBox.Focus();
                    return;
                }

                isEditing = true;
                SaveBaseFare();
            }
        }


        private void SaveBaseFare()
        {
            if (decimal.TryParse(BaseFareTextBox.Text.Trim(), out decimal baseFare))
            {
                BaseFare = baseFare;

                FareInfo updatedFare = new FareInfo
                {
                    RouteID = this.RouteID,  
                    BaseFare = this.BaseFare,
                    SeniorFare = this.Discounted,
                    StudentFare = this.Student
                };
                repo.UpdateFare(updatedFare);  

                BaseFareTextBox.Visible = false;
                BaseFarelbl.Visible = true;
                EditFareMatrix.Text = "Edit";
                isEditing = false;
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric fare.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BaseFareTextBox.Focus();
            }
        }


        private void BaseFareTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
