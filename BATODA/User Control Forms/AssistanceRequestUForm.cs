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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
