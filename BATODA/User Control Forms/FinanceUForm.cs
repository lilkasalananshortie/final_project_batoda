using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA
{
    public partial class FinanceUForm : UserControl
    {
        public FinanceUForm()
        {
            InitializeComponent();
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(PaymentStatusComboBox, "Status", "Paid", "Unpaid");
            DisplayClass.SetPlaceholder(YearComboBox, "Year", "2025", "2024");
            DisplayClass.SetPlaceholder(SortComboBox, "Sort By" , "Body Number", "ETC ETC");

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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {

        }

        private void RenewalHistoryButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ButawUForm());
        }
    }
}
