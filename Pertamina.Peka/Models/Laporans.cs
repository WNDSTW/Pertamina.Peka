using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Laporans : Default
    {
        public string Bagian { get; set; }

        public string PemilikArea { get; set; }

        public string Fungsi { get; set; }
        public string namapegawai { get; set; }
        public string nopek { get; set; }
        public int Realisasi { get; set; }
        public string tanggal { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public string typePegawai { get; set; }
        public string lokasi { get; set; }
        public string jenisTemuan { get; set; }
        public string Kategori { get; set; }
        public string subKategori { get; set; }
        public string deskripsi { get; set; }
        public string dokumenTemuan { get; set; }
        public string uraianIntervensi { get; set; }
        public string tindakanPerbaikan { get; set; }
        public string saran { get; set; }
        public string resiko { get; set; }    
        public int idPeka { get; set; }
        public Nullable<int> kategoriTingkahLakuBaik { get; set; }
        public string deskripsiTingkahLakuBaik { get; set; }
        public string dokumenTingkahLakuBaik { get; set; }

        public Nullable<int> NoBagian { get; set; }

        public Nullable<int> NoFungsi { get; set; }

        public Nullable<int> KumulatifTarget { get; set; }

        public decimal PersentaseBagian { get; set; }

        public decimal PersentaseFungsi { get; set; }

        public Nullable<int> KumulatifRealisasi { get; set; }

        public string Bulans { get; set; }
        public string Tahuns { get; set; }

        public Nullable<int> Target { get; set; }
        public decimal TotalScore { get; set; }
        public int PersonalTarget { get; set; }
        public string Temuan { get; set; }

    }
}