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
    public class LaporanController : Controller
    {
        AdminDAO admDAO = new AdminDAO();
        LaporanDAO lapDAO = new LaporanDAO();
        //
        // GET: /Laporan/
        public ActionResult TemuanTLB()
        {
            return View();
        }

        public ActionResult Rekapitulasi()
        {
            return View();
        }

        public ActionResult TemuanSubStandar()
        {
            return View();
        }

        public ActionResult RekapitulasiRealisasiVSTarget()
        {
            return View();
        }

        public JsonResult GetTemuanTLB(AdvancedSearch advancedSearchModel)
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
            var pekaData = lapDAO.ListTingkahLakuBaik();
            
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = pekaData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);


            if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.Bagian)).ToList<Laporans>();
                pekaData = pekaData.Where(x => x.Bagian.ToLower().Equals(advancedSearchModel.Bagian.ToLower())).ToList<Laporans>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.Kategori) && advancedSearchModel.Kategori != "" && advancedSearchModel.Kategori != "null")
            {
                pekaData = pekaData.Where(x => x.Kategori.ToLower().Equals(advancedSearchModel.Kategori.ToLower())).ToList<Laporans>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.Lokasi) && advancedSearchModel.Lokasi != "" && advancedSearchModel.Lokasi != "null")
            {
                pekaData = pekaData.Where(x => x.lokasi.ToLower().Equals(advancedSearchModel.Lokasi.ToLower())).ToList<Laporans>();
            }

          

            if (advancedSearchModel.Tahun != 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();
            }

            if (advancedSearchModel.Tahun == 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.Equals(DateTime.Now.Year)).ToList<Laporans>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.typePegawai) && advancedSearchModel.typePegawai != "" && advancedSearchModel.typePegawai != "null")
            {
                pekaData = pekaData.Where(x => x.typePegawai.ToLower().Equals(advancedSearchModel.typePegawai.ToLower())).ToList<Laporans>();
            }


            if (advancedSearchModel.Bulan != 0)
            {
                //bool Issued = bool.Parse(searchViewModel.Status);
                pekaData = pekaData.Where(x => x.Bulan.ToString().Equals(advancedSearchModel.Bulan.ToString())).ToList<Laporans>();
            }
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                pekaData = pekaData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Laporans>();
            }

            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                pekaData = pekaData.Where(m => m.Bagian.ToLower().Contains(searchValue.ToLower())
                || m.Kategori.ToLower().Contains(searchValue.ToLower()) || m.namapegawai.ToLower().Contains(searchValue.ToLower())).ToList<Laporans>();
            }

            //total number of rows count   
            var recordsFiltered = pekaData.Count();
            //Paging   
            var data = pekaData.Skip(skip).Take(pageSize).ToList();
            if (pageSize == -1)
            {
                data = pekaData.ToList();
            }

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTemuanSubStandar(AdvancedSearch advancedSearchModel)
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
            var pekaData = lapDAO.ListTemuanSubStandar();
            
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = pekaData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);


            if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.Bagian)).ToList<Laporans>();
                pekaData = pekaData.Where(x => x.Bagian.ToLower().Equals(advancedSearchModel.Bagian.ToLower())).ToList<Laporans>();
            }

            if (!string.IsNullOrEmpty(advancedSearchModel.jenisTemuan) && advancedSearchModel.jenisTemuan != "" && advancedSearchModel.jenisTemuan != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.jenisTemuan) && x.jenisTemuan.ToLower().Equals(advancedSearchModel.jenisTemuan.ToLower())).ToList<Laporans>();
            }

            if (!string.IsNullOrEmpty(advancedSearchModel.Kategori) && advancedSearchModel.Kategori != "" && advancedSearchModel.Kategori != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.Kategori) && x.Kategori.ToLower().Equals(advancedSearchModel.Kategori.ToLower())).ToList<Laporans>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.Lokasi) && advancedSearchModel.Lokasi != "" && advancedSearchModel.Lokasi != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.lokasi) && x.lokasi.ToLower().Equals(advancedSearchModel.Lokasi.ToLower())).ToList<Laporans>();
            }

            if (!string.IsNullOrEmpty(advancedSearchModel.Risiko) && advancedSearchModel.Risiko != "" && advancedSearchModel.Risiko != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.resiko) && x.resiko.ToLower().Equals(advancedSearchModel.Risiko.ToLower())).ToList<Laporans>();
            }

            if (advancedSearchModel.Tahun != 0)
            {
                pekaData = pekaData.Where(x => x.Tahun !=null &&  x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();
            }

            if (advancedSearchModel.Tahun == 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.Equals(DateTime.Now.Year)).ToList<Laporans>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.typePegawai) && advancedSearchModel.typePegawai != "" && advancedSearchModel.typePegawai != "null")
            {
                pekaData = pekaData.Where(x => x.typePegawai !=null && x.typePegawai.ToLower().Equals(advancedSearchModel.typePegawai.ToLower())).ToList<Laporans>();
            }


            if (advancedSearchModel.Bulan != 0)
            {
                //bool Issued = bool.Parse(searchViewModel.Status);
                pekaData = pekaData.Where(x => x.Bulan !=null && x.Bulan.ToString().Equals(advancedSearchModel.Bulan.ToString())).ToList<Laporans>();
            }
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                pekaData = pekaData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Laporans>();
            }

            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                pekaData = pekaData.Where(m => 
                (m.deskripsi !=null && m.deskripsi.ToLower().Contains(searchValue.ToLower())) || (m.saran !=null && m.saran.ToLower().Contains(searchValue.ToLower())) || ( m.uraianIntervensi!=null && m.uraianIntervensi.ToLower().Contains(searchValue.ToLower()))).ToList<Laporans>();
            }

            //total number of rows count   
            
            var recordsFiltered = pekaData.Count();
            var datas = pekaData.Skip(skip).Take(pageSize).ToList();
            if (pageSize == -1)
            {
                datas = pekaData.ToList();
            }
            
            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = datas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRekapitulasi(AdvancedSearch advancedSearchModel)
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
            var pekaData = lapDAO.ListPekaSoreTarget();
            pekaData = pekaData.Where(x => x.TotalScore != null && x.TotalScore != 0).ToList<Laporans>();
            
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = pekaData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);

            if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.Bagian)).ToList<Laporans>();
                pekaData = pekaData.Where(x => x.Bagian.ToLower().Equals(advancedSearchModel.Bagian.ToLower())).ToList<Laporans>();
            }


            if (advancedSearchModel.Tahun != 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.typePegawai) && advancedSearchModel.typePegawai != "" && advancedSearchModel.typePegawai != "null")
            {
                pekaData = pekaData.Where(x => x.typePegawai.ToLower().Equals(advancedSearchModel.typePegawai.ToLower())).ToList<Laporans>();
            }
               

            if (advancedSearchModel.Bulan != 0)
            {
                //bool Issued = bool.Parse(searchViewModel.Status);
                pekaData = pekaData.Where(x => x.Bulan.ToString().Equals(advancedSearchModel.Bulan.ToString())).ToList<Laporans>();
            }
            if (sortColumn !="" && !string.IsNullOrEmpty(sortColumnDir))
            {
                pekaData = pekaData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Laporans>();
            }

            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                pekaData = pekaData.Where(m => m.Bagian.ToLower().Contains(searchValue.ToLower())
                || m.namapegawai.ToLower().Contains(searchValue.ToLower())).ToList<Laporans>();
            }

            //total number of rows count   
            var recordsFiltered = pekaData.Count();
            //Paging   
            var data = pekaData.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRekapitulasiDetail(AdvancedSearch advancedSearchModel)
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
            var pekaData = lapDAO.ListPekaSoreTargetAll();
           
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = pekaData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);

            if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
            {
                pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.Bagian)).ToList<Laporans>();
                pekaData = pekaData.Where(x => x.Bagian.ToLower().Equals(advancedSearchModel.Bagian.ToLower())).ToList<Laporans>();
            }
               

            if (advancedSearchModel.Tahun != 0)
                pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();

            if (advancedSearchModel.Tahun == 0)
                pekaData = pekaData.Where(x => x.Tahun.Equals(DateTime.Now.Year)).ToList<Laporans>();

            //if (!string.IsNullOrEmpty(advancedSearchModel.typePegawai) && advancedSearchModel.typePegawai != "" && advancedSearchModel.typePegawai != "null")
            //    pekaData = pekaData.Where(x => x.typePegawai.ToLower().Equals(advancedSearchModel.typePegawai.ToLower())).ToList<Laporans>();

            if (advancedSearchModel.Bulan != 0)
            {
                pekaData = lapDAO.ListPekaSoreTarget().Where(x => x.Bulan.ToString().Equals(advancedSearchModel.Bulan.ToString())).ToList<Laporans>();
                recordsTotal = pekaData.Count();

                if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
                    pekaData = pekaData.Where(x => !string.IsNullOrEmpty(x.Bagian)).ToList<Laporans>();
                    pekaData = pekaData.Where(x => x.Bagian.ToLower().Equals(advancedSearchModel.Bagian.ToLower())).ToList<Laporans>();

                if (advancedSearchModel.Tahun != 0)
                    pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();

                //if (!string.IsNullOrEmpty(advancedSearchModel.typePegawai) && advancedSearchModel.typePegawai != "" && advancedSearchModel.typePegawai != "null")
                //    pekaData = pekaData.Where(x => x.typePegawai.ToLower().Equals(advancedSearchModel.typePegawai.ToLower())).ToList<Laporans>();
            }
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                pekaData = pekaData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Laporans>();
            }

            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                pekaData = pekaData.Where(m => m.Bagian.ToLower().Contains(searchValue.ToLower())
                || m.namapegawai.ToLower().Contains(searchValue.ToLower())).ToList<Laporans>();
            }

            //total number of rows count   
            var recordsFiltered = pekaData.Count();
            //Paging   
            var data = pekaData.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdvancedSearch(Laporans laporan)
        {        

            return PartialView("_AdvanceSearchPartial", lapDAO.ListTemuanSubStandar().Where (x=>x.Bagian !=null));
        }

        public ActionResult AdvancedSearchSubStandar()
        {
            //var laporan = new Laporans();
            //return View("_AdvancedSearchPartial");
            return PartialView("_AdvancedSearchSubStandarPartial", lapDAO.ListTemuanSubStandar().Where(x=> x.Bagian !=null));
        }

        public ActionResult getPhotoTemuan(int? id)
        {
            //return View(admDAO.ListRealisasiVSTarget());
            return PartialView("_PhotoTemuanPartial", lapDAO.ListTemuanSubStandar().Where(x => x.idPeka.ToString().Equals(id.ToString())).ToList<Laporans>());
        }
        public ActionResult getPhotoTemuanBaik(int? id)
        {
            //return View(admDAO.ListRealisasiVSTarget());
            return PartialView("_PhotoTLBPartial", lapDAO.ListTingkahLakuBaik().Where(x => x.idPeka.ToString().Equals(id.ToString())).ToList<Laporans>());
        }

        public ActionResult AdvancedSearchRekap()
        {
            //var laporan = new Laporans();
            //return View("_AdvancedSearchPartial");
            return PartialView("_AdvancedSearchRekap", lapDAO.ListPekaSoreTarget().Where (x=> x.Bagian!=null));
        }

        public ActionResult AdvancedSearchRekapAll()
        {
            //var laporan = new Laporans();
            //return View("_AdvancedSearchPartial");
            return PartialView("_AdvancedSearchRekapAllPartial", lapDAO.ListTargetFungsi().Where(x=> x.Fungsi!=null));
        }

        public JsonResult GetTargetBagian(AdvancedSearch advancedSearchModel)
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
            var pekaData = lapDAO.ListTargetBagianAll();
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = pekaData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);

            //if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
            //{
            //    pekaData = pekaData.Where(x => x.Bagian.ToLower().Contains(advancedSearchModel.Bagian.ToLower())).ToList<Laporans>();
            //}


            //if (!string.IsNullOrEmpty(advancedSearchModel.Fungsi) && advancedSearchModel.Fungsi != "" && advancedSearchModel.Fungsi != "null")
            //{
            //    pekaData = pekaData.Where(x => x.Fungsi.ToLower().Contains(advancedSearchModel.Fungsi.ToLower())).ToList<Laporans>();
            //}

            if (advancedSearchModel.NoFungsi != 0)
            {
                pekaData = pekaData.Where(x => x.NoFungsi.ToString().Equals(advancedSearchModel.NoFungsi.ToString())).ToList<Laporans>();
            }


            if (advancedSearchModel.Tahun != 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();
            }

            if (advancedSearchModel.Tahun == 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.Equals(DateTime.Now.Year)).ToList<Laporans>();
            }



            if (!string.IsNullOrEmpty(advancedSearchModel.Bulans) && advancedSearchModel.Bulans != "" && advancedSearchModel.Bulans != "null")
            {

                pekaData = lapDAO.ListTargetBagian().Where(x => x.Bulans.ToLower().Equals(advancedSearchModel.Bulans.ToLower())).ToList<Laporans>();
                recordsTotal = pekaData.Count();

                if (advancedSearchModel.NoFungsi != 0)
                {
                    pekaData = pekaData.Where(x => x.NoFungsi.ToString().Equals(advancedSearchModel.NoFungsi.ToString())).ToList<Laporans>();
                }


                if (advancedSearchModel.Tahun != 0)
                {
                    pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();
                }
            }
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                pekaData = pekaData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Laporans>();
            }

            //Search  
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    pekaData = pekaData.Where(m => m.subKategori.ToLower().Contains(searchValue.ToLower())
            //    || m.deskripsi.ToLower().Contains(searchValue.ToLower()) || m.saran.ToLower().Contains(searchValue.ToLower()) || m.uraianIntervensi.ToLower().Contains(searchValue.ToLower())).ToList<Laporans>();
            //}

            //total number of rows count   
            var recordsFiltered = pekaData.Count();
            //Paging   
            var data = pekaData.ToList();
            //recordsFiltered = recordsFiltered, recordsTotal = recordsTotal,
            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTargetFungsi(AdvancedSearch advancedSearchModel)
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
            var pekaData = lapDAO.ListTargetFungsiAll().Where (x=> x.NoFungsi !=null).ToList<Laporans>();
            //var pekaData = pekaList.AsQueryable();
            recordsTotal = pekaData.Count();
            //pekaData = AdvanceSearch(sortColumn, sortColumnDir, searchValue, advancedSearchModel, pekaData);

            //if (!string.IsNullOrEmpty(advancedSearchModel.Bagian) && advancedSearchModel.Bagian != "" && advancedSearchModel.Bagian != "null")
            //{
            //    pekaData = pekaData.Where(x => x.Bagian.ToLower().Contains(advancedSearchModel.Bagian.ToLower())).ToList<Laporans>();
            //}


            if (!string.IsNullOrEmpty(advancedSearchModel.Fungsi) && advancedSearchModel.Fungsi != "" && advancedSearchModel.Fungsi != "null")
            {
                pekaData = pekaData.Where(x => x.Fungsi.ToLower().Equals(advancedSearchModel.Fungsi.ToLower())).ToList<Laporans>();
            }


            if (advancedSearchModel.Tahun != 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();
            }

            if (advancedSearchModel.Tahun == 0)
            {
                pekaData = pekaData.Where(x => x.Tahun.Equals(DateTime.Now.Year)).ToList<Laporans>();
            }


            if (!string.IsNullOrEmpty(advancedSearchModel.Bulans) && advancedSearchModel.Bulans != "" && advancedSearchModel.Bulans != "null")
            {
                //bool Issued = bool.Parse(searchViewModel.Status);
                pekaData = lapDAO.ListTargetFungsi().Where(x => x.Bulans.ToLower().Equals(advancedSearchModel.Bulans.ToLower())).ToList<Laporans>();
                recordsTotal = pekaData.Count();

                if (!string.IsNullOrEmpty(advancedSearchModel.Fungsi) && advancedSearchModel.Fungsi != "" && advancedSearchModel.Fungsi != "null")
                {
                    pekaData = pekaData.Where(x => x.Fungsi.ToLower().Equals(advancedSearchModel.Fungsi.ToLower())).ToList<Laporans>();
                }


                if (advancedSearchModel.Tahun != 0)
                {
                    pekaData = pekaData.Where(x => x.Tahun.ToString().Equals(advancedSearchModel.Tahun.ToString())).ToList<Laporans>();
                }
            }
            if (sortColumn != "" && !string.IsNullOrEmpty(sortColumnDir))
            {
                pekaData = pekaData.OrderBy(sortColumn + " " + sortColumnDir).ToList<Laporans>();
            }

            //Search  
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    pekaData = pekaData.Where(m => m.subKategori.ToLower().Contains(searchValue.ToLower())
            //    || m.deskripsi.ToLower().Contains(searchValue.ToLower()) || m.saran.ToLower().Contains(searchValue.ToLower()) || m.uraianIntervensi.ToLower().Contains(searchValue.ToLower())).ToList<Laporans>();
            //}

            //total number of rows count   
            var recordsFiltered = pekaData.Count();
            //Paging   
            var data = pekaData.ToList();

            return Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Laporans lap)
        {
            return Json(lapDAO.Delete(lap), JsonRequestBehavior.AllowGet);
        }
     
	}
}