using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pertamina.Peka.Models;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;

namespace Pertamina.Peka.DAO
{
    public class LembarPekaDAO
    {
        #region Parameters Declaration
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @idPeka = new SqlParameter("@idPeka", SqlDbType.NVarChar,50);
        protected SqlParameter @tanggal = new SqlParameter("@tanggal", SqlDbType.DateTime);
         protected SqlParameter @typePegawai = new SqlParameter("@typePegawai", SqlDbType.NVarChar,50);
         protected SqlParameter @jenisTemuan = new SqlParameter("@jenisTemuan", SqlDbType.Int);
        protected SqlParameter @nopek = new SqlParameter("@nopek", SqlDbType.NVarChar,50);
        protected SqlParameter @lokasi = new SqlParameter("@lokasi", SqlDbType.NVarChar,50);
        protected SqlParameter @kodeBagian = new SqlParameter("@kodeBagian", SqlDbType.Int);
        protected SqlParameter @kodeKategori = new SqlParameter("@kodeKategori", SqlDbType.Int);
        protected SqlParameter @subKategori = new SqlParameter("@subKategori", SqlDbType.Text);
        protected SqlParameter @deskripsi = new SqlParameter("@deskripsi", SqlDbType.Text);
        protected SqlParameter @dokumenTemuan = new SqlParameter("@dokumenTemuan", SqlDbType.Text);
        protected SqlParameter @tindakanPerbaikan = new SqlParameter("@tindakanPerbaikan", SqlDbType.Bit);
        protected SqlParameter @uraianIntervensi = new SqlParameter("@uraianIntervensi", SqlDbType.Text);
        protected SqlParameter @saran = new SqlParameter("@saran", SqlDbType.Text);
        protected SqlParameter @resiko = new SqlParameter("@resiko", SqlDbType.Int);
        protected SqlParameter @kategoriTingkahLakuBaik = new SqlParameter("@KategoriTingkahLakuBaik", SqlDbType.Int);
        protected SqlParameter @deskripsiTingkahLakuBaik = new SqlParameter("@deskripsiTingkahLakuBaik", SqlDbType.Text);
        protected SqlParameter @dokumenTingkahLakuBaik = new SqlParameter("@dokumenTingkahLakuBaik", SqlDbType.Text);
        protected SqlParameter @namapegawai = new SqlParameter("@namapegawai", SqlDbType.NVarChar, 100);
        protected SqlParameter @idBagianPemilik = new SqlParameter("@idBagianPemilik", SqlDbType.Int);
        protected SqlParameter @Temuan = new SqlParameter("@Temuan", SqlDbType.NVarChar,50);

        protected SqlParameter @CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        protected SqlParameter @ModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);

          #endregion


        public bool AddPeka(LembarPeka lembarPekas)
        {
            try
            {
                @function.Value = 1;
                //string vtanggal = null;
                //DateTime TMTDinas;
                //string[] formats = 
                //        {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", 
                //         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", "MM/dd/yyyy H:mm:ss",
                //         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", "MM/dd/yyyy HH:mm:ss",
                //         "M/d/yyyy h:mm", "M/d/yyyy h:mm", "MM/dd/yy HH:mm", "MM/dd/yy hh:mm:ss tt",
                //         "MM/dd/yyyy hh:mm",  "MM/dd/yyyy HH:mm", "MM/d/yyyy hh:mm", "MM/dd/yyyy"};
                //string tgl = lembarPekas.tanggal.ToString();
                ////if (DateTime.TryParseExact(txTglLahir.Text, formats, CultureInfo.GetCultureInfo("en-GB").DateTimeFormat,
                ////                    DateTimeStyles.None, out TglLahir))
                ////{
                ////    vTglLahir = TglLahir.ToString("yyyy/MM/dd");
                ////}
                //if (DateTime.TryParseExact(tgl, formats, CultureInfo.GetCultureInfo("en-GB").DateTimeFormat,
                //                    DateTimeStyles.None, out TMTDinas))
                //{
                //    vtanggal = TMTDinas.ToString("yyyy/MM/dd");
                //}
                //@tanggal.Value = DateTime.Parse(lembarPekas.tanggal.ToString());
                @typePegawai.Value = lembarPekas.typePegawai;
                @jenisTemuan.Value = lembarPekas.jenisTemuan; 
                @nopek.Value = lembarPekas.nopek; 
                @lokasi.Value = lembarPekas.lokasi; 
                @kodeBagian.Value = lembarPekas.kodeBagian;
                @kodeKategori.Value =lembarPekas.kodeKategori; 
                @subKategori.Value =lembarPekas.subKategori; 
                @deskripsi.Value =lembarPekas.deskripsi;
                @dokumenTemuan.Value = SaveToPhysicalLocation(lembarPekas.dokumenTemuan);
                @tindakanPerbaikan.Value = lembarPekas.tindakanPerbaikan;
                @uraianIntervensi.Value = lembarPekas.uraianIntervensi;
                @saran.Value = lembarPekas.saran;
                @resiko.Value = lembarPekas.resiko;
                @kategoriTingkahLakuBaik.Value = lembarPekas.kategoriTingkahLakuBaik; 
                @deskripsiTingkahLakuBaik.Value = lembarPekas.deskripsiTingkahLakuBaik;
                @dokumenTingkahLakuBaik.Value = SaveToPhysicalLocation(lembarPekas.dokumenTingkahLakuBaik);
                @namapegawai.Value = lembarPekas.namapegawai;
                @idBagianPemilik.Value = lembarPekas.idBagianPemilik;
                @CreatedBy.Value = lembarPekas.CreatedBy;
                @CreatedOn.Value = DateTime.Now;

                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_lembarPeka", @function,@tanggal,@nopek,@lokasi,@kodeBagian,@kodeKategori,
                    @subKategori,@deskripsi,@dokumenTemuan,@tindakanPerbaikan,@uraianIntervensi,@saran,@resiko,@kategoriTingkahLakuBaik,@deskripsiTingkahLakuBaik,@dokumenTingkahLakuBaik,@CreatedBy,@CreatedOn,@typePegawai,@jenisTemuan,@namapegawai,@idBagianPemilik);
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }       

        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file !=null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/ImageUpload"), fileName);
                file.SaveAs(path);
                var pathDoc = "/ImageUpload/" + fileName;
                return pathDoc;
            }
            return string.Empty;
        }  
    }
}