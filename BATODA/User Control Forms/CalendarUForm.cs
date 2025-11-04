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

        public static int month, year;
        private static DateTime dateTime = DateTime.Now;
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
            lbDate.Text = $"{monthName} {year}";

            DateTime monthStart = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Previous month info
            int prevMonth = (month == 1) ? 12 : month - 1;
            int prevYear = (month == 1) ? year - 1 : year;
            int prevMonthDays = DateTime.DaysInMonth(prevYear, prevMonth);
            int startDayOfWeek = (int)monthStart.DayOfWeek; 
            DayContainer.Controls.Clear();

            
            for (int i = startDayOfWeek - 1; i >= 0; i--)
            {
                DaysUForm prevDay = new DaysUForm();
                prevDay.days(prevMonthDays - i, prevMonth, prevYear);
                prevDay.BackColor = Color.LightGray;
                DayContainer.Controls.Add(prevDay);
            }


            for (int i = 1; i <= daysInMonth; i++)
            {
                DaysUForm currentDay = new DaysUForm();
                currentDay.days(i, month, year);
                DayContainer.Controls.Add(currentDay);
            }

            // fill all remaining cells 
            int totalCells = DayContainer.Controls.Count;
            int nextMonthDaysToAdd = 42 - totalCells;
            int nextMonth = (month == 12) ? 1 : month + 1;
            int nextYear = (month == 12) ? year + 1 : year;

            for (int i = 1; i <= nextMonthDaysToAdd; i++)
            {
                DaysUForm nextDay = new DaysUForm();
                nextDay.days(i, nextMonth, nextYear);
                nextDay.BackColor = Color.LightGray;
                DayContainer.Controls.Add(nextDay);
            
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

        
    }
}
