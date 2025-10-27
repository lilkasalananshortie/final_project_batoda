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
            ResultPanel.Hide();
            


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

        private void AssistanceRequestUForm_Load(object sender, EventArgs e)
        {

        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            ResultPanel.Hide();
            SaveButton.Enabled = true;

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            ResultPanel.Show();
            ResultPanel.BringToFront();
            SaveButton.Enabled = false;

        }
    }
}
