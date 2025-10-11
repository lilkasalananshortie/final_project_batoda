using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.UI_Displays;

namespace BATODA
{
    public partial class FinanceUForm : UserControl
    {
        public FinanceUForm()
        {
            InitializeComponent();
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(PaymentStatusComboBox, "Status", "Paid", "Unpaid", "Overdue");
            DisplayClass.SetPlaceholder(YearComboBox, "Year", "2025", "2024");
            DisplayClass.SetPlaceholder(SortComboBox, "Sort By" , "Body Number", "Name");

        }

        private void FinanceUForm_Load(object sender, EventArgs e)
        {

        }

        private void FinanceButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new FinanceUForm());
        }

        

        

        private void MembershipRenewalButton_Click_1(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembershipRenewalUForm());
        }


        private void RenewalHistoryButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ButawUForm());
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PaymentStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
            ToastManager.Success("Filters Cleared Successfully!");
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ToastManager.Success("Filters Applied!");

        }

        private void ApplySearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
