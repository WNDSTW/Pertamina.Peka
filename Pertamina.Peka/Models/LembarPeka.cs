using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class LembarPeka : Default
    {
        //public string idPeka { get; set; }
        public Nullable<System.DateTime> tanggal { get; set; }
        public string nopek { get; set; }

        public string typePegawai { get; set; }
        public string lokasi { get; set; }
        public string namapegawai { get; set; }
        public Nullable<int> jenisTemuan { get; set; }
        public Nullable<int> kodeBagian { get; set; }
        public Nullable<int> kodeKategori { get; set; }
        public string subKategori { get; set; }
        public string deskripsi { get; set; }
        public HttpPostedFileBase dokumenTemuan { get; set; }
        public string dokumenTemuanName { get; set; }
        public string dokumenTemuanUrl { get; set; }
        public Nullable<bool> tindakanPerbaikan { get; set; }
        public string uraianIntervensi { get; set; }
        public string saran { get; set; }
        public Nullable<int> resiko { get; set; }
        public Nullable<int> kategoriTingkahLakuBaik { get; set; }
        public string deskripsiTingkahLakuBaik { get; set; }
        public HttpPostedFileBase dokumenTingkahLakuBaik { get; set; }
        public string dokumenTingkahLakuBaikName { get; set; }
        public string dokumenTingkahLakuBaikUrl { get; set; }
        public Nullable<int> idBagianPemilik { get; set; }
    }
}