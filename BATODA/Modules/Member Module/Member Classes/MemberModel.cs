using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.MemberModule
{
    public class MemberModel
    {
        /// <summary>
        /// Member Related Properties
        /// </summary>
        /// 
        public int BodyNumber { get; set; }
        public string MembershipType { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public DateTime Birthdate { get; set; }
        public string TricycleBrand { get; set; }
        public string TricycleModel { get; set; }
        public string ContactNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string PlateNumber { get; set; }
        public decimal TaxBalance { get; set; }
        public string MemberStatus { get; set; }
        public int PenaltyLevel { get; set; }
        public int PenaltyCount { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateJoined { get; set; }
        public int SuspensionDays { get; set; }
        public DateTime? SuspensionStartDate { get; set; }

        public DateTime ExpiryDate { get; set; }      
        public string RenewalStatus { get; set; }

        public int SuspensionHoursRemaining
        {
            get
            {
                if (PenaltyLevel == 3 && SuspensionStartDate.HasValue)
                {
                    double hoursLeft = SuspensionDays - (DateTime.Now - SuspensionStartDate.Value).TotalHours;
                    return hoursLeft <= 0 ? 0 : (int)Math.Ceiling(hoursLeft);
                }
                return 0;
            }
        }

        public void ApplyPenalty()
        {
            if (PenaltyLevel < 3)
            {
                PenaltyLevel += 1;

                if (PenaltyLevel == 3)
                {
                    SuspensionDays = 24; // 24 HOURS
                    SuspensionStartDate = DateTime.Now;
                }
            }
        }

        public void UpdateSuspensionStatus()
        {
            if (PenaltyLevel == 3 && SuspensionStartDate.HasValue)
            {
                double hoursPassed = (DateTime.Now - SuspensionStartDate.Value).TotalHours;
                if (hoursPassed >= SuspensionDays)
                {
                    PenaltyLevel = 0;
                    SuspensionDays = 0;
                    SuspensionStartDate = null;
                }
            }
        }








    }
}
