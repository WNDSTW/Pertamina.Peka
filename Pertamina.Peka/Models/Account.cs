using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Account : Default
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string errorMessage { get; set; }

        public bool requested { get; set; }
        public int idRole { get; set; }

        public string section { get; set; }
        public bool isActive { get; set; }
        public bool isBanned { get; set; }
    }
}