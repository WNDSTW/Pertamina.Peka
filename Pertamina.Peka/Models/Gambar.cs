using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Gambar : Default
    {
        public int id { get; set; }

        public string Deskripsi { get; set; }
        public string Photo { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

    }
}