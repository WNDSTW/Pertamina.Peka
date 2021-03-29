using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Pertamina.Peka.DAO;
using Pertamina.Peka.Models;
using System.Web.Security;

namespace Pertamina.Peka.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        GambarDAO gbDAO = new GambarDAO();
        GrafikDAO grDAO = new GrafikDAO();
        AccountDAO accDAO = new AccountDAO();


        [Authorize]
        public ActionResult Index(Grafik gr)
        {

            if (Session["idRole"] != null)
            {
                var TupleModel = new Tuple<List<Gambar>, List<Grafik>>(gbDAO.ListGambar(), grDAO.ListRealisasiVSTarget(gr));
                return View(TupleModel);
            }
            else
            {
                return RedirectToAction("Login");
            }     
        }

     
         [AllowAnonymous]
         [HttpGet]
         public ActionResult Login()
         {

             return View();

         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Login(Account acc)
         {
             //accDAO.coba(acc)
             //accDAO.LDAP(acc)

             if (accDAO.LDAP(acc))
             {
                 FormsAuthentication.SetAuthCookie(acc.Email,false);
                 return RedirectToAction("Index");
             }
             else
             {
                 ModelState.AddModelError("", "Login data is incorrect!");
             }
             return View(acc);

         }

         public ActionResult Logout()
         {

             FormsAuthentication.SignOut();
             Session.Abandon();
             return RedirectToAction("Index");

         }
        
    }
}