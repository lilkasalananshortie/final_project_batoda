using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Dashboard_Module.Dashboard_Classes
{
    public class SystemActivityLog
    {
        public int SystemLogID { get; set; }
        public string ModuleName { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public DateTime DateRecorded { get; set; }
    }

}
