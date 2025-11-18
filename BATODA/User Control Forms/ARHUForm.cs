using BATODA.Modules.Assistance_Request_Module;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;
using BATODA.Helpers;
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

namespace BATODA
{
    public partial class ARHUForm : UserControl
    {
        public ARHUForm()
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
        private void ARHUForm_Load(object sender, EventArgs e)
        {
            AssistanceRepository loader = new AssistanceRepository();
            DataGridCustom.ApplyCustomGrid(AssistanceHistoryGrid);
            loader.LoadTicketHistory(AssistanceHistoryGrid);
            AssistanceHistoryGrid.Columns["TicketID"].HeaderText = "Ticket ID";
            AssistanceHistoryGrid.Columns["BodyNumber"].HeaderText = "Body No.";
            AssistanceHistoryGrid.Columns["FullName"].HeaderText = "Name";
            AssistanceHistoryGrid.Columns["ContactNumber"].HeaderText = "Contact No.";
            AssistanceHistoryGrid.Columns["TypeOfAid"].HeaderText = "Aid";
            AssistanceHistoryGrid.Columns["RequestedBy"].HeaderText = "Requested By";
            AssistanceHistoryGrid.Columns["RequestedAmount"].HeaderText = "Amount";
            AssistanceHistoryGrid.Columns["AssistanceThru"].HeaderText = "Transfer Thru";
            AssistanceHistoryGrid.Columns["GcashNumber"].HeaderText = "Gcash No.";
            AssistanceHistoryGrid.Columns["DateRequested"].HeaderText = "Date Req.";
            AssistanceHistoryGrid.Columns["RequestStatus"].HeaderText = "Status";
            AssistanceHistoryGrid.Columns["ActionDate"].HeaderText = "Update Date";

        }

    }
}
