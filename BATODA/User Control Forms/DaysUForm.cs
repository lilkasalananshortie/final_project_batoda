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
    public partial class DaysUForm : UserControl
    {
        public DaysUForm()
        {
            InitializeComponent();
        }

        private void DaysUForm_Load(object sender, EventArgs e)
        {

        }

        public void days(int daysCount)
        {
            lbDays.Text = daysCount + "";
        }

    }
}
