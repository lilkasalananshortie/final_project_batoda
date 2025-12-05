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
using BATODA.Modules.FareMatrix_Classes;


namespace BATODA.User_Control_Forms
{
    public partial class FareMatrixUForm : UserControl
    {

        public FareMatrixUForm()
        {
            InitializeComponent();
        }

        private readonly List<string> routeNames = new List<string>
        {
            "Dulo, San Sebastian",
            "Bihunan",
            "Kaitaasan",
            "Bagong Daan",
            "Eskwelahan",
            "Dulo",
            "Aksaho",
            "Tapahan",
            "Bungad",
            "Tulay",
            "Umbuyan",
            "Purok 5 (Ibayo)",
            "Masagana",
            "Purok 3, 4, Daang Look \n(San Francisco - Pitpitan vice versa)",
            "Purok 1, 2",
            "Dulo",
            "Libis",
            "Bon Bon Resort",
            "Dulo/Tulay",
            "Tabing Ilog I & II, Libo",
            "(Libo (Dulo)), Libo",
            "Triple Junction Subd.\n(TJS) – Loob",
            "TJS – Harap,Allswell Bukid Dulo, Camella,\nDulong Barrio,Villa Sofia Subd.(paposok)",
            "Hangga, Bayanihan,St., Martires Vill.,Bisita,\nTulay, CenterBisita, (Masikap St.),Fatima, Pulo",
            "Dulo",
            "Estanqillo,\nSadsaran, DJS",
            "Malusak, Subd.,\nGardenia",
            "Bambang Pulo,\nPurok 1,2,3,4",
            "Purok 5\nPulo (papasok)",
            "Purok 7",
            "Bagumbayan Pangulang(Dulo),\nBagulo,Pangulang(Bungad)",
            "Makapatan (Dulo),\nGitna, Subd., Makapatan, Hulo",
            "Min. fare",
            "Min. fare",
            "Min. fare",
            "Min. fare"
        };

        private void FareMatrixUForm_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            FareMatrixRepository repo = new FareMatrixRepository();
            List<FareInfo> fares = repo.GetAllFares();

            foreach (var fare in fares)
            {
                FareMatrixPanelUForm panel = new FareMatrixPanelUForm();
                panel.RouteID = fare.RouteID;
                panel.Route = routeNames[fare.RouteID - 1];  
                panel.BaseFare = fare.BaseFare;
                panel.Discounted = fare.SeniorFare;
                panel.Student = fare.StudentFare;

                flowLayoutPanel1.Controls.Add(panel);
            }

        }
    }
}