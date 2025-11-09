using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Assistance_Request_Module.Assistance_Classes
{
    public class ActionLogModel
    {
        public string RequestAction { get; set; }
        public string ActionDescription { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string DateDisplay { get; set; }
    }

}
