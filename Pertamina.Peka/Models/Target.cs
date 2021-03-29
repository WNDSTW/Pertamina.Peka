using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Target : Default
    {
        public int id { get; set; }
        public string Bulan { get; set; }
        public string Tahun { get; set; }

        public int minggu1 { get; set; }

        public int minggu2 { get; set; }

        public int minggu3 { get; set; }
        public int minggu4 { get; set; }
        public int totalTarget { get; set; }
    }
}