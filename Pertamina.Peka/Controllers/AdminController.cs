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
    public class AdminController : Controller
    {
        AdminDAO admDAO = new AdminDAO();
        TargetDAO tgDAO = new TargetDAO();
        GambarDAO gbDAO = new GambarDAO();
        // GET: Admin
        public ActionResult CreateScore()
        {
            return View();
        }

        public ActionResult TambahTarget()
        {
            return View();
        }

        public ActionResult TambahGambar()
        {
            return View();
        }

        public JsonResult AddScore(Admin admins)
        {
            return Json(admDAO.AddPeka(admins),JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPekaScore(AdvancedSearch advancedSearchModel)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            // Getting all Customer data  
            var pekaData = admDAO.ListRealisasiVSTarget();
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = pekaData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);

            if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
            {
                pekaData = pekaData.Where(x => x.Bagian.ToLower().Contains(advancedSearchModel.Bagian.ToLower())).ToList<Admin>();
            }


            if (advancedSearchModel.Tahun != 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.ToString().Contains(advancedSearchModel.Tahun.ToString())).ToList<Admin>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.typePegawai) && advancedSearchModel.typePegawai != "" && advancedSearchModel.typePegawai != "null")
            {
                pekaData = pekaData.Where(x => x.typePegawai.ToLower().Contains(advancedSearchModel.typePegawai.ToLower())).ToList<Admin>();
            }


            if (advancedSearchModel.Bulan != 0)
            {
                //bool Issued = bool.Parse(searchViewModel.Status);
                pekaData = pekaData.Where(x => x.Bulan.ToString().Contains(advancedSearchModel.Bulan.ToString())).ToList<Admin>();
            }
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                pekaData = pekaData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Admin>();
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                pekaData = pekaData.Where(m => m.Bagian.ToLower().Contains(searchValue.ToLower())
                || m.Kategori.ToLower().Contains(searchValue.ToLower()) || m.namapegawai.ToLower().Contains(searchValue.ToLower())).ToList<Admin>();
            }

            //total number of rows count   
            var recordsFiltered = pekaData.Count();
            //Paging   
            var data = pekaData.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getScoreDetail(int? id)
        {
            //return View(admDAO.ListRealisasiVSTarget());
            return PartialView("_updateScorePartial", admDAO.ListRealisasiVSTarget().Where(x=>x.idPeka.ToString().Equals(id.ToString())).ToList<Admin>());
        }

        public JsonResult getTarget(AdvancedSearch advancedSearchModel)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            // Getting all Customer data  
            var targetData = tgDAO.ListTarget();
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = targetData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);

            if (advancedSearchModel.Tahun != 0)
            {
                targetData = targetData.Where(x => x.Tahun.ToString().Contains(advancedSearchModel.Tahun.ToString())).ToList<Target>();
            }


            if (advancedSearchModel.Bulan != 0)
            {
                //bool Issued = bool.Parse(searchViewModel.Status);
                targetData = targetData.Where(x => x.Bulan.ToString().Contains(advancedSearchModel.Bulan.ToString())).ToList<Target>();
            }
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                targetData = targetData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Target>();
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                targetData = targetData.Where(m => m.Bulan.ToString().Contains(advancedSearchModel.Bulan.ToString())
                || m.Tahun.ToString().Contains(advancedSearchModel.Tahun.ToString())).ToList<Target>();
            }

            //total number of rows count   
            var recordsFiltered = targetData.Count();
            //Paging   
            var data = targetData.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddTarget(Target targets)
        {
            return Json(tgDAO.AddTarget(targets), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddsGambar(Gambar gambars)
        {
            return Json(gbDAO.AddGambar(gambars), JsonRequestBehavior.AllowGet);
        }

        public JsonResult HapusGambar(int id)
        {
            return Json(gbDAO.hapusGambar(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getGambar()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            // Getting all Customer data  
            var targetData = gbDAO.ListGambar();
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = targetData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);

            //if (advancedSearchModel.Tahun != 0)
            //{
            //    targetData = targetData.Where(x => x.Tahun.ToString().Contains(advancedSearchModel.Tahun.ToString())).ToList<Gambar>();
            //}


            //if (advancedSearchModel.Bulan != 0)
            //{
            //    //bool Issued = bool.Parse(searchViewModel.Status);
            //    targetData = targetData.Where(x => x.Bulan.ToString().Contains(advancedSearchModel.Bulan.ToString())).ToList<Gambar>();
            //}
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                targetData = targetData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Gambar>();
            }
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    targetData = targetData.Where(m => m.Deskripsi.ToString().Contains(searchValue)).ToList<Gambar>();
            //}

            //total number of rows count   
            var recordsFiltered = targetData.Count();
            //Paging   
            var data = targetData.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }
    }
}