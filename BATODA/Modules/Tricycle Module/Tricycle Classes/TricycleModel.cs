using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Tricycle_Module.Tricycle_Classes
{
    internal class TricycleModel
    {
        public int BodyNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; } 
        public string ContactNumber { get; set; } 
        public string MembershipType { get; set; }
        public string TricycleBrand { get; set; }
        public string TricModel { get; set; }
        public string PlateNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }

        public string Availability
        {
            get
            {
                DayOfWeek today = DateTime.Now.DayOfWeek;

                // ALL ARE AVAILABLE IF WEEKEND
                if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
                    return "Available";

                // LAST DIGIT
                int lastDigit = BodyNumber % 10; 

                switch (today)
                {
                    case DayOfWeek.Monday:
                        if (lastDigit == 1 || lastDigit == 2) return "Unavailable";
                        break;
                    case DayOfWeek.Tuesday:
                        if (lastDigit == 3 || lastDigit == 4) return "Unavailable";
                        break;
                    case DayOfWeek.Wednesday:
                        if (lastDigit == 5 || lastDigit == 6) return "Unavailable";
                        break;
                    case DayOfWeek.Thursday:
                        if (lastDigit == 7 || lastDigit == 8) return "Unavailable";
                        break;
                    case DayOfWeek.Friday:
                        if (lastDigit == 9 || lastDigit == 0) return "Unavailable";
                        break;
                }
                return "Operational";
            }
        }
    }
}
