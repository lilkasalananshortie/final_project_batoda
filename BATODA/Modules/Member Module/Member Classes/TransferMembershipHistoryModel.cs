using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Member_Module.Member_Classes
{
    public class TransferMembershipHistoryModel
    {
        public int TransferID { get; set; }
        public int BodyNumber { get; set; }
        public string PastOwnerFullName { get; set; }
        public string NewOwnerFullName { get; set; }
        public string ReasonForTransfer { get; set; }
        public DateTime DateOfTransfer { get; set; }

    }
}
