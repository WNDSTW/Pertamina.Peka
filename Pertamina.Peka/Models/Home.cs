using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Home
    {
        public IEnumerable<Pertamina.Peka.Models.Grafik> Grafik { get; set; }
        public IEnumerable<Pertamina.Peka.Models.Gambar> Gambar { get; set; }
    }
}