using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Assistance_Request_Module.Assistance_Classes
{
    internal class TicketModel
    {
        public int TicketID { get; set; }

        public int BodyNumber { get; set; }
        public string FullName { get; set; }
        public string RequestedBy { get; set; }
        public string TypeOfAid { get; set; }
        public string AssistanceThru { get; set; }
        public decimal RequestedAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public string RequestStatus { get; set; }
        public DateTime DateRequested { get; set; }
        public string ContactNumber { get; set; }
        public string GcashNumber { get; set; }
    }
}
