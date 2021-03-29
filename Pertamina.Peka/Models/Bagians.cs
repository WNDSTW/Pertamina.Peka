using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Bagians : Default
    {
        public string Bagian { get; set; }
        public int NoBagian { get; set; }       
        public Nullable<int> NoFungsi { get; set; }
        public Nullable<int> CostCenterID { get; set; }
    }
}