using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Assistance_Request_Module.Renewal_Classes
{
    public class MemberRenewalModel
    {
        public int BodyNumber { get; set; }
        public string FullName { get; set; }
        public string MembershipType { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? DateRenewed { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public string RenewalStatus { get; set; }
    }

}
