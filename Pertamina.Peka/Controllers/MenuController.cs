using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pertamina.Peka.Models;
using Pertamina.Peka.DAO;

namespace Pertamina.Peka.Controllers
{
    public class MenuController : Controller
    {
        MenuDAO menuDAO = new MenuDAO();
        //
        // GET: /Menu/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[Authorize]
        public ActionResult TopNav()
        {

            //return PartialView("_topNav", menuDAO.ListMenu());
            if (Session["idrole"].ToString() != "1")
            {
                return PartialView("_topNav", menuDAO.ListMenuUser());
            }
            else
            {
                return PartialView("_topNav", menuDAO.ListMenu());
            }                   
        }
	}
}