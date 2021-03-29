using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Pertamina.Peka.DAO;
using Pertamina.Peka.Models;



namespace Pertamina.Peka.Controllers
{
    public class GrafikController : Controller
    {
        GrafikDAO GrafiksDAO = new GrafikDAO();
        //Grafik grf = new Grafik();

        public ActionResult ChartTargetRealisasi(Grafik grf)
        {
            return View(GrafiksDAO.getTahun());
        }
        //public JsonResult ChartTargetRealisasi()
        //{
        //    return Json(GrafiksDAO.ListRealisasiVSTarget(), JsonRequestBehavior.AllowGet);
        //}
        public ActionResult ChartPengirimPeka()
        {
            return View(GrafiksDAO.getTahun());
        }
        public ActionResult ChartTargetPekerja()
        {
            return View(GrafiksDAO.getTahun());
        }
        public ActionResult ChartTemuan()
        {
            return View(GrafiksDAO.getTahun());
        }

        public JsonResult getPengirimPeka(Grafik grafiks)
        {
            return Json(GrafiksDAO.ListPengirimPerBagian(grafiks),JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTargetRealisasi(Grafik grafiks)
        {
            return Json(GrafiksDAO.ListRealisasiVSTarget(grafiks), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getTargetPekerja(Grafik grafiks)
        {
            return Json(GrafiksDAO.getAktifVSNonAktif(grafiks), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getTemuan(AdvancedSearch advancedSearchModel)
        {
            var grafikData = GrafiksDAO.ListPekaPerKategoriAll().Where(x=> x.Tahun.Equals(DateTime.Now.Year));


            if (advancedSearchModel.Tahun != 0 && advancedSearchModel.Bulan == 0)
            {
                grafikData = grafikData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Grafik>();
            }
            if (advancedSearchModel.Bulan != 0 && advancedSearchModel.Tahun == 0)
            {
                grafikData = GrafiksDAO.ListPekaPerKategori().Where(x => x.Bulan.ToString().Equals(advancedSearchModel.Bulan.ToString()) && x.Tahun.ToString().Equals(DateTime.Now.Year)).ToList<Grafik>();
            }

            if (advancedSearchModel.Bulan != 0 && advancedSearchModel.Tahun != 0)
            {
                grafikData = GrafiksDAO.ListPekaPerKategori().Where(x => x.Bulan.ToString().Equals(advancedSearchModel.Bulan.ToString()) && x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Grafik>();

               
            }
          

            return Json(grafikData,JsonRequestBehavior.AllowGet);
        }
	}
}