using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Grafik : Default
    {
        public string TypePegawai { get; set; }
        public int JumlahPeka { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public String Bagian { get; set; }
        public int totalTarget { get; set; }
        public int PegawaiAktif { get; set; }
        public int PegawaiPasif { get; set; }
        public string Kategori { get; set; }
        public int KumulatifTarget { get; set; }
        public int KumulatifRealisasi { get; set; }
    }
}