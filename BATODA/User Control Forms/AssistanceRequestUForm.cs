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
    public partial class AssistanceRequestUForm : UserControl
    {
        public AssistanceRequestUForm()
        {
            InitializeComponent();
            DisplayClass.SetPlaceholder(SearchTextBox, "Enter Tricycle Brand");
            DisplayClass.SetPlaceholder(RequestTypeTextBox, "Enter Type of Request");
            DisplayClass.SetPlaceholder(RequestReasonTextBox2, "Enter Reason For Request");



        }

        private void AssistanceHomeButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceLogUForm());
        }

        private void AssistanceRequestButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceRequestUForm());
        }

        private void ARHButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ARHUForm());
        }

        
    }
}
