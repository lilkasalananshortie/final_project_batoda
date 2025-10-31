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
    public partial class MembersEditPanel : UserControl
    {
        public MembersEditPanel()
        {
            InitializeComponent();
        }

        private void MembersEditPanel_Load(object sender, EventArgs e)
        {
           
           
        }

        private void SaveEditBtn_Click(object sender, EventArgs e)
        {
            DisplayClass.CloseMini(this);
            DisplayClass.ShowMain(new MembersUForm());
           
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DisplayClass.CloseMini(this);
            DisplayClass.ShowMain(new MembersUForm());
        }
    }
}
