using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pertamina.Peka.Models;
using Pertamina.Peka.DAO;
using System.IO;

namespace Pertamina.Peka.Controllers
{
    public class LembarPekaController : Controller
    {
        LembarPekaDAO lbp = new LembarPekaDAO();
        BagianDAO BgDAO = new BagianDAO();
        //
        // GET: /LembarPeka/
        public ActionResult Create()
        {
            return View(BgDAO.ListBagian());
        }

        public JsonResult Add(LembarPeka LembarPekas)
        {
            //LembarPekas.dokumenTemuanUrl = Path.Combine(Server.MapPath("~/Images"), LembarPekas.dokumenTemuanName);
            //LembarPekas.dokumenTingkahLakuBaikUrl = Path.Combine(Server.MapPath("~/Images"), LembarPekas.dokumenTingkahLakuBaikName);
            return Json(lbp.AddPeka(LembarPekas), JsonRequestBehavior.AllowGet);
        }


        


      
	}
}