using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.FareMatrix_Classes
{
    internal class FareMatrixModel
    {
      
    }

    public class FareInfo
    {
        public int RouteID { get; set; }
        public string Route { get; set; }
        public decimal BaseFare { get; set; }
        public decimal SeniorFare { get; set; }
        public decimal StudentFare { get; set; }
    }


}
