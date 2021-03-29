using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Admin : Default
    {
        public Nullable<decimal> Total { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public string Bagian { get; set; }
        public string namapegawai { get; set; }
        public string nopek { get; set; }
        public string tanggal { get; set; }
        public string typePegawai { get; set; }
        public string lokasi { get; set; }
        public int jenisTemuan { get; set; }
        public string Kategori { get; set; }
        public string subKategori { get; set; }
        public string deskripsi { get; set; }
        public string tindakanPerbaikan { get; set; }
        public string uraianIntervensi { get; set; }
        public string saran { get; set; }
        public string resiko { get; set; }
        public Nullable<int> kategoriTingkahLakuBaik { get; set; }
        public string deskripsiTingkahLakuBaik { get; set; }
        public int idPeka { get; set; }
        public string PemilikArea { get; set; }
        public string dokumenTemuan { get; set; }
        public string dokumenTingkahLakuBaik { get; set; }

        public int id { get; set; }
        public Nullable<decimal> locationScore { get; set; }
        public Nullable<decimal> resikoScore { get; set; }
        public Nullable<decimal> temuanScore { get; set; }
        public Nullable<decimal> IntervensiScore { get; set; }
        public Nullable<decimal> saranScore { get; set; }
        public Nullable<decimal> tingkahLakuBaikScore { get; set; }
        public Nullable<decimal> ScoreDetail { get; set; }
       
    }
}