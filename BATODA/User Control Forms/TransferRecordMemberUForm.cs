using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Member_Module.Member_Classes;

namespace BATODA
{
    public partial class TransferRecordMemberUForm : UserControl
    {
        public TransferRecordMemberUForm()
        {
            InitializeComponent();
            
        }

        private void ManageMembersButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembersUForm());
        }

        private void TransferMembershipButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }

        private void TransferRecordsButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordMemberUForm());
        }

        private void TransferRecordMemberUForm_Load(object sender, EventArgs e)
        {
            DataGridCustom.ApplyCustomGrid(TransferMembershipHistoryGrid);

            TransferMembershipHistoryRepository historyRepo = new TransferMembershipHistoryRepository();
            var table = historyRepo.GetAllTransferRecords();
            DataGridColumns.LoadMembershipTransferHistoryToGrid(TransferMembershipHistoryGrid, table);
        }


    }
}
