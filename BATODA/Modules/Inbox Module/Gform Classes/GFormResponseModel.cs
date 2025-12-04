using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Inbox_Module.Gform_Classes
{
    internal class GFormResponseModel
    {
        public DateTime Timestamp { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string question_1 { get; set; }
        public string question_2 { get; set; }
        public string question_3 { get; set; }
        public string question_4 { get; set; }

    }
}
