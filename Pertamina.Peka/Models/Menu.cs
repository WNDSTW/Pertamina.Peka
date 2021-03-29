using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pertamina.Peka.Models
{
    public class Menu
    {
        public int menuId { get; set; }
        public Nullable<int> parentMenuID { get; set; }
        public Nullable<int> NoOrder { get; set; }
        public string Title { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool isParent { get; set; }
    }
}