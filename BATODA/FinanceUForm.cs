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
        }

        private void FinanceUForm_Load(object sender, EventArgs e)
        {

        }

        private void FinanceButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new FinanceUForm());
        }

        private void ButawButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ButawUForm());
        }

        private void MembershipRenewalButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembershipRenewalUForm());
        }
    }
}
