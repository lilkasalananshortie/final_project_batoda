using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.User_Control_Forms;

namespace BATODA
{
    public partial class CalendarUForm : UserControl
    {

        static int month, year;
        private DateTime dateTime = DateTime.Now;
        public CalendarUForm()
        {
            InitializeComponent();
        }

        private void CalendarUForm_Load(object sender, EventArgs e)
        {
            calendarDays();
        }

        public void calendarDays()
        {

            month = dateTime.Month;
            year = dateTime.Year;

            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthName + " " + year;

            DateTime monthStart = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int wholeweek = (int)monthStart.DayOfWeek + 1;

            for (int i = 1; i < wholeweek; i++)
            {
                CalendarContainerUForm calendar = new CalendarContainerUForm();
                //  calendar.days(i);
                DayContainer.Controls.Add(calendar);
            }

            for (int i = 1; i <= days; i++)
            {
                DaysUForm daysUForm = new DaysUForm();
                daysUForm.days(i);
                DayContainer.Controls.Add(daysUForm);
            }


        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            DayContainer.Controls.Clear();
            month++;


            if (month > 12)
            {
                month = 1;
                year++;
            }

            dateTime = new DateTime(year, month, 1);
            calendarDays();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            DayContainer.Controls.Clear();
            month--;


            if (month < 1)
            {
                month = 12;
                year--;
            }

            dateTime = new DateTime(year, month, 1);
            calendarDays();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
