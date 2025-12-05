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
using BATODA.Modules.Tricycle_Module.Tricycle_Classes;

namespace BATODA
{
    public partial class TransferVehicleUForm : UserControl
    {
        public TransferVehicleUForm()
        {
            InitializeComponent();
        }

        private void RegisteredVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TricycleUForm());
        }

        private void TransferVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferVehicleUForm());
        }

        private void TransferRecordButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordVehicleUForm());
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OwnerSearchGrid.Visible = true;
                TransferTricSearchOwner search = new TransferTricSearchOwner();
                search.SearchOwner(VehicOwnerSearch, OwnerSearchGrid);
                DataGridCustom.ApplyCustomGridSearch(OwnerSearchGrid);
                OwnerSearchGrid.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void OwnerSearchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string bodyNumberStr = OwnerSearchGrid.Rows[e.RowIndex].Cells["BodyNumber"].Value?.ToString();
            if (string.IsNullOrEmpty(bodyNumberStr)) return;

            string digitsOnly = new string(bodyNumberStr.Where(char.IsDigit).ToArray());
            if (!int.TryParse(digitsOnly, out int bodyNumber)) return;

            TransferTricLoadOwner loader = new TransferTricLoadOwner();
            loader.LoadOwnerDetails(digitsOnly,
                BodyNumberLbl,
                MemberTypeLbl,
                FirstNameLbl,
                MiddleLbl,
                LastNameLbl,
                BrandTxt,
                PlateTxt,
                ChassisTxt,
                EngineTxt,
                ModelTxt);

            BodyNumberLbl.Text = bodyNumber.ToString("D3");

            OwnerSearchGrid.Visible = false;
        }


        private void TransferBtn_Click(object sender, EventArgs e)
        {
            try
            {
                TricycleRepository repo = new TricycleRepository();

                repo.TransferTricycle(
                    int.Parse(BodyNumberLbl.Text),
                    MemberTypeLbl.Text,
                    FirstNameLbl.Text,
                    MiddleLbl.Text,
                    LastNameLbl.Text,
                    BrandTxt.Text,
                    ModelTxt.Text,
                    PlateTxt.Text,
                    ChassisTxt.Text,
                    EngineTxt.Text
                );

                string fullName = $"{FirstNameLbl.Text} {MiddleLbl.Text}. {LastNameLbl.Text}";
                string processType = "Tricycle Transfer";
                string reason = TricTransReasonCmb.Text;

                repo.SaveTricycleTransferHistory(
                    int.Parse(BodyNumberLbl.Text),
                    fullName,
                    processType,
                    reason
                );

                MessageBox.Show("Transfer saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving transfer: " + ex.Message);
            }
        }


    }
}
