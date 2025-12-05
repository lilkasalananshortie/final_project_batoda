using BATODA.Helpers.Data;
using BATODA.Helpers.DataGrid;
using BATODA.Helpers.DataGrids;
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
    public partial class ButawUForm : UserControl
    {
        TaxRepository repo = new TaxRepository();

        public ButawUForm()
        {
            InitializeComponent();
            
            repo.LoadMemberPaymentsGrid(ButawGrid, DateTime.Today.Year);
            DataGridCustom.ApplyCustomGrid(ButawGrid);
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

        }
    }
}
