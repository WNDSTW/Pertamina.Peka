using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class AdvancedSearch
    {
        public string Bagian { get; set; }
        public Nullable<int> Bulan { get; set; }
        public Nullable<int> Tahun { get; set; }
        public string typePegawai { get; set; }

        public string Lokasi { get; set; }

        public string Kategori { get; set; }

        public string Risiko { get; set; }

        public Nullable<int> NoFungsi { get; set; }

        public string Fungsi { get; set; }

        public string Bulans { get; set; }

        public string jenisTemuan { get; set; }

     
    }
}