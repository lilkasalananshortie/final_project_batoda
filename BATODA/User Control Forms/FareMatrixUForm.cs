using BATODA.Helpers.Database.Members;
using BATODA.Helpers.DataGrid;
using BATODA.Modules;
using BATODA.Modules.Assistance_Request_Module;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;
using BATODA.Modules.MemberModule;
using BATODA.User_Control_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.User_Control_Forms
{
    public partial class FareMatrixUForm : UserControl
    {
        public FareMatrixUForm()
        {
            InitializeComponent();
            LoadFareMatrix();
        }

        private void FareMatrixUForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadFareMatrix()
        {
            var dgv = FairMatrixDataGridView;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(173, 46, 36);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;

            Font gridFont = new Font("Microsoft Sans Serif", 12.75f, FontStyle.Regular);
            Font headerFont = new Font("Microsoft Sans Serif", 12.75f, FontStyle.Bold);

            dgv.DefaultCellStyle.Font = gridFont;
            dgv.ColumnHeadersDefaultCellStyle.Font = headerFont;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 30;
           
            dgv.RowTemplate.Height = 20;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.Dock = DockStyle.Fill;
            dgv.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Barangay",
                HeaderText = "BARANGAY",
                Width = 200,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Resizable = DataGridViewTriState.False
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Route",
                HeaderText = "ROUTE",
                Width = 350,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Resizable = DataGridViewTriState.False
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Fare1",
                HeaderText = "NEW FARE (REG)",
                Width = 280,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Resizable = DataGridViewTriState.False
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Fare2",
                HeaderText = "NEW FARE (SC, PWD)",
                Width = 280,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Resizable = DataGridViewTriState.False
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Fare3",
                HeaderText = "NEW FARE (STUDENT)",
                Width = 280,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Resizable = DataGridViewTriState.False
            });

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgv.Columns["Barangay"].Width = 200;
            dgv.Columns["Route"].Width = 350;
            dgv.Columns["Fare1"].Width = 280;
            dgv.Columns["Fare2"].Width = 280;
            dgv.Columns["Fare3"].Width = 280;


            dgv.ReadOnly = true;
            //ETO LANG YUG LAMAN PERO PWEDE PA MAIBA KUNG PAANO APPORACH MO SA DB <-- ARONE
            dgv.Rows.Add("TALIPTIP", "Dulo – San Sebastian", "35.00 PHP", "28.00 PHP", "28.00 PHP");
            dgv.Rows.Add("", "Binuangan", "25.00 PHP", "20.00 PHP", "20.00 PHP");
            dgv.Rows.Add("", "Sabang Daan", "21.00 PHP", "17.00 PHP", "17.00 PHP");
            dgv.Rows.Add("", "Dambanang Kawayan", "26.00 PHP", "21.00 PHP", "21.00 PHP");
            dgv.Rows.Add("", "Eskwelahan", "24.00 PHP", "19.20 PHP", "19.20 PHP");

            dgv.Rows.Add("PITPITAN", "Abada", "20.00 PHP", "16.00 PHP", "16.00 PHP");
            dgv.Rows.Add("", "Akasha", "21.00 PHP", "17.00 PHP", "17.00 PHP");
            dgv.Rows.Add("", "Tulay", "22.00 PHP", "18.00 PHP", "18.00 PHP");
            dgv.Rows.Add("", "Bungad", "22.00 PHP", "18.00 PHP", "18.00 PHP");

            dgv.Rows.Add("PEREZ", "Umbocan", "22.00 PHP", "20.00 PHP", "20.00 PHP");

            dgv.Rows.Add("SAN FRANCISCO", "Purok 3 (Bayan)", "25.00 PHP", "20.00 PHP", "20.00 PHP");
            dgv.Rows.Add("", "Purok 5 & 6", "22.00 PHP", "17.60 PHP", "17.60 PHP");
            dgv.Rows.Add("", "Marcos St. / Daang Kastila, Brgy. Pandayan", "22.00 PHP", "18.00 PHP", "18.00 PHP");
            dgv.Rows.Add("", "Purok Tia Vic / Francisco – Lipatan West", "21.00 PHP", "17.00 PHP", "17.00 PHP");

            dgv.Rows.Add("SAN NICOLAS", "Dulo", "20.00 PHP", "16.00 PHP", "16.00 PHP");
            dgv.Rows.Add("", "Purok 3", "18.00 PHP", "14.40 PHP", "14.40 PHP");
            dgv.Rows.Add("", "Dike / Resort", "20.00 PHP", "16.00 PHP", "16.00 PHP");
            dgv.Rows.Add("", "Dapa / Tulig 1 & Ilio-Ilio Brgy.", "17.00 PHP", "13.00 PHP", "13.00 PHP");
            dgv.Rows.Add("", "Pook (Dulo St.)", "16.00 PHP", "12.00 PHP", "12.00 PHP");

            dgv.Rows.Add("MATUNGAO", "Tibig, London Subd., T.P. Industrial", "20.00 PHP", "16.00 PHP", "16.00 PHP");
            dgv.Rows.Add("", "National Road (Bungad–Batis), Ulingan, Tia Maria, Balatong", "18.00 PHP", "14.40 PHP", "14.40 PHP");

            dgv.Rows.Add("STA. ANA", "Dulo", "18.00 PHP", "14.40 PHP", "14.40 PHP");
            dgv.Rows.Add("", "Establado", "19.00 PHP", "15.20 PHP", "15.20 PHP");
            dgv.Rows.Add("", "San Juan", "21.00 PHP", "16.00 PHP", "16.00 PHP");

            dgv.Rows.Add("BAMBANG", "Bambang Pulo", "16.00 PHP", "12.80 PHP", "12.80 PHP");
            dgv.Rows.Add("", "Purok 3", "16.00 PHP", "12.80 PHP", "12.80 PHP");
            dgv.Rows.Add("", "Pulo (Special)", "19.00 PHP", "15.20 PHP", "15.20 PHP");

            dgv.Rows.Add("BAGUMBAYAN", "Bagumbayan Proper", "16.00 PHP", "12.80 PHP", "12.80 PHP");
            dgv.Rows.Add("", "Bungad (Manggahan)", "16.00 PHP", "12.80 PHP", "12.80 PHP");
            dgv.Rows.Add("", "Panginay", "16.00 PHP", "12.80 PHP", "12.80 PHP");

            dgv.Rows.Add("BALUBAD", " ", "16.00 PHP", "12.80 PHP", "12.80 PHP");

            dgv.Rows.Add("STA. INES", "Min. fare", "16.00 PHP", "12.80 PHP", "12.80 PHP");

            dgv.Rows.Add("TIBIG", "Min. fare", "16.00 PHP", "12.80 PHP", "12.80 PHP");

            dgv.Rows.Add("MAYSANTOL", "Min. fare", "16.00 PHP", "12.80 PHP", "12.80 PHP");

            dgv.Rows.Add("SAN JOSE", "Min. fare", "16.00 PHP", "12.80 PHP", "12.80 PHP");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }
    }
}