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
    public partial class DaysUForm : UserControl
    {

        public DateTime CurrentDate { get; set; }
        private static int day;
        


        public DaysUForm()
        {
            InitializeComponent();
            this.Click += DaysUForm_Click;
            this.DoubleClick += DaysUForm_DoubleClick;
        }

        private void DaysUForm_Load(object sender, EventArgs e)
        {
           
        }

        public void days(int daysCount, int customMonth = 0, int customYear = 0)
        {
            lbDays.Text = daysCount.ToString();
            day = daysCount;


            int displayMonth = (customMonth != 0) ? customMonth : CalendarUForm.month;
            int displayYear = (customYear != 0) ? customYear : CalendarUForm.year;

            if (day < 1 || day > DateTime.DaysInMonth(displayYear, displayMonth))
                return;
            DateTime thisDate = new DateTime(displayYear, displayMonth, day);
            if ((thisDate.DayOfWeek == DayOfWeek.Saturday || thisDate.DayOfWeek == DayOfWeek.Sunday) &&
                displayMonth == CalendarUForm.month && displayYear == CalendarUForm.year)
            {
                lbDays.ForeColor = Color.Red;
            }
            else
            {
                lbDays.ForeColor = Color.Black;
            }


            // Highlight today's date
            if (thisDate.Date == DateTime.Today)
            {
                this.Paint += (s, e) =>
                {
                    using (Pen pen = new Pen(Color.Red, 3))
                    {
                        Rectangle rect = this.ClientRectangle;
                        rect.Inflate(-1, -1);
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                };
                this.Invalidate();
            }
        }

        private void DaysUForm_Click(object sender, EventArgs e)
        {
           

        }

        private void DaysUForm_DoubleClick(object sender, EventArgs e)
        {
            Control parent = this.Parent;

            while (parent != null && !(parent is CalendarUForm))
            {
                parent = parent.Parent;
            }

            if (parent is CalendarUForm calendar)
            {
                calendar.   AddEventPanel.Visible = true;
                calendar.AddEventPanel.BringToFront();
            }
        }
    }
}
