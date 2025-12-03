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

        List<FareInfo> fareList = new List<FareInfo>()
        {
            new FareInfo { Baranggay="TALIPTIP", Route="Dulo, San Sebastian", BaseFare="₱35.00" , Discounted = "₱28.00", Student = "₱28.00" },
            new FareInfo { Baranggay="TALIPTIP", Route="Bihunan", BaseFare="₱25.00" , Discounted = "₱20.00", Student = "₱20.00" },
            new FareInfo { Baranggay="TALIPTIP", Route="Kaitaasan", BaseFare="₱25.00" , Discounted = "₱20.00", Student = "₱20.00" },
            new FareInfo { Baranggay="TALIPTIP", Route="Bagong Daan", BaseFare="₱25.00" , Discounted = "₱20.00", Student = "₱20.00" },
            new FareInfo { Baranggay="TALIPTIP", Route="Eskwelahan", BaseFare="₱24.00" , Discounted = "₱19.20", Student = "₱19.20" },
            new FareInfo { Baranggay="PITPITAN", Route="Dulo", BaseFare="₱22.00" , Discounted = "₱17.60", Student = "₱17.60" },
            new FareInfo { Baranggay="PITPITAN", Route="Aksaho", BaseFare="₱20.00" , Discounted = "₱16.00", Student = "₱16.00" },
            new FareInfo { Baranggay="PITPITAN", Route="Tapahan", BaseFare="₱24.00" , Discounted = "₱19.20", Student = "₱19.20" },
            new FareInfo { Baranggay="PITPITAN", Route="Bungad", BaseFare="₱18.00" , Discounted = "₱14.40", Student = "₱14.40" },
            new FareInfo { Baranggay="PEREZ", Route="Tulay", BaseFare="₱22.00" , Discounted = "₱17.60", Student = "₱17.60" },
            new FareInfo { Baranggay="PEREZ", Route="Umbuyan", BaseFare="₱25.00" , Discounted = "₱20.00", Student = "₱20.00" },
            new FareInfo { Baranggay="SAN FRANCISCO", Route="Purok 5 (Ibayo)", BaseFare="₱22.00" , Discounted = "₱17.60", Student = "₱17.60" },
            new FareInfo { Baranggay="SAN FRANCISCO", Route="Masagana", BaseFare="₱22.00" , Discounted = "₱17.60", Student = "₱17.60" },
            new FareInfo { Baranggay="SAN FRANCISCO", Route="Purok 3, 4, Daang Look (San Francisco -- Pitpitan vice versa)", BaseFare="₱22.00" , Discounted = "₱17.60", Student = "₱17.60" },
            new FareInfo { Baranggay="SAN FRANCISCO", Route="Purok 1, 2", BaseFare="₱18.00" , Discounted = "₱14.40", Student = "₱14.40" },
            new FareInfo { Baranggay="SAN NICOLAS", Route="Dulo", BaseFare="₱20.00" , Discounted = "₱16.00", Student = "₱16.00" },
            new FareInfo { Baranggay="SAN NICOLAS", Route="Libis", BaseFare="₱--" , Discounted = "₱--", Student = "₱--" },
            new FareInfo { Baranggay="SAN NICOLAS", Route="Bon Bon Resort", BaseFare="₱18.00" , Discounted = "₱14.40", Student = "₱14.40" },
            new FareInfo { Baranggay="SAN NICOLAS", Route="Dulo/Tulay", BaseFare="₱--" , Discounted = "₱--", Student = "₱--" },
            new FareInfo { Baranggay="SAN NICOLAS", Route="Tabing Ilog I & II, Libo", BaseFare="₱--" , Discounted = "₱--", Student = "₱--" },
            new FareInfo { Baranggay="SAN NICOLAS", Route="(Libo (Dulo)), Libo", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="MATUNGAO", Route="Triple Junction Subd. (TJS) – Loob", BaseFare="₱--" , Discounted = "₱--", Student = "₱--" },
            new FareInfo { Baranggay="MATUNGAO", Route="TJS – Harap, Allswell Bukid Dulo, Camella, Dulong Barrio, \nVilla Sofia Subd. (paposok), Libo", BaseFare="₱20.00" , Discounted = "₱16.00", Student = "₱16.00" },
            new FareInfo { Baranggay="MATUNGAO", Route="Hangga, Bayanihan, St., Martires Vill., Bisita, \nTulay, Center Bisita, (Masikan St.), Fatima, Pulo", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="STA. ANA", Route="Dulo", BaseFare="₱18.00" , Discounted = "₱14.40", Student = "₱14.40" },
            new FareInfo { Baranggay="STA. ANA", Route="Estanqillo, Sadsaran, DJS", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="STA. ANA", Route="Malusak, Subd., Gardenia", BaseFare="₱20.00" , Discounted = "₱16.00", Student = "₱16.00" },
            new FareInfo { Baranggay="BAMBANG", Route="Bambang Pulo, Purok 1,2,3,4", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="BAMBANG", Route="Purok 5 Pulo (paposok)", BaseFare="₱18.00" , Discounted = "₱14.40", Student = "₱14.40" },
            new FareInfo { Baranggay="BAMBANG", Route="Purok 7", BaseFare="₱25.00" , Discounted = "₱20.00", Student = "₱20.00" },
            new FareInfo { Baranggay="BAGUMBAYAN", Route="Bagumbayan Pangulayan (Dulo), Bagulo, Panapung (Bungad)", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="BALUBAD", Route="Makapatan (Dulo), Gitna, Subd., Makapatan, Hulo", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="STA. INES", Route="Min. fare", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="TIBIG", Route="Min. fare", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="MAYSANTOL", Route="Min. fare", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },
            new FareInfo { Baranggay="SAN JOSE", Route="Min. fare", BaseFare="₱16.00" , Discounted = "₱12.80", Student = "₱12.80" },


        };

        private void FareMatrixUForm_Load(object sender, EventArgs e)
        {
            foreach (var fare in fareList)
            {
                var listDesc = new FareMatrixPanelUForm();
                listDesc.Baranggay = fare.Baranggay;
                listDesc.Route = fare.Route;
                listDesc.BaseFare = fare.BaseFare;
                listDesc.Discounted = fare.Discounted;
                listDesc.Student = fare.Student;

                flowLayoutPanel1.Controls.Add(listDesc);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
