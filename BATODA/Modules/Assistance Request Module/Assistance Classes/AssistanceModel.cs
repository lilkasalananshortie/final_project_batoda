using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Assistance_Request_Module.Assistance_Classes
{
    internal class AssistanceModel
    {
        public int TicketID { get; set; }
        public int BodyNumber { get; set; }
        public string RequestedBy { get; set; }
        public string TypeOfAid { get; set; }
        public string AssistanceThru { get; set; }
        public decimal Amount { get; set; }
        public DateTime TargetDate { get; set; }
        public string RequestStatus { get; set; } = "Pending";
        public DateTime DateRequested { get; set; } = DateTime.Now;
    }
}
