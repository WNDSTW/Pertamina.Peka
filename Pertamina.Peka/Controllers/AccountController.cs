using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pertamina.Peka.Models;
using Pertamina.Peka.DAO;


namespace Pertamina.Peka.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //AccountDAO acDAO = new AccountDAO();
        //[AllowAnonymous]
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //public ActionResult goTO(string usn, string pass)
        //{
           
        //    if (acDAO.LDAP(usn,pass))
        //    {
        //        return View("LembarPeka");
        //    }
        //    return View();
        //}
        
    }
}