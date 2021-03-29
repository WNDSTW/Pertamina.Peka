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
    public class GambarDAO
    {
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @id = new SqlParameter("@id", SqlDbType.NVarChar, 50);
        protected SqlParameter @deskripsi = new SqlParameter("@deskripsi", SqlDbType.NVarChar, 50);
        protected SqlParameter @photo = new SqlParameter("@photo", SqlDbType.NVarChar, 50);

        protected SqlParameter @CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        protected SqlParameter @ModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);

        private string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/ImageUpload"), fileName);
                file.SaveAs(path);
                var pathDoc = "/ImageUpload/" + fileName;
                return pathDoc;
            }
            return string.Empty;
        }


        public List<Gambar> ListGambar()
        {
            try
            {
                @function.Value = 2;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Beranda", @function);
                DataTable dt = ds.Tables[0];
                List<Gambar> listResource = EntityBinder.ToCollection<Gambar>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public bool AddGambar(Gambar gambars)
        {
            try
            {
                @function.Value = 1;
                @deskripsi.Value = gambars.Deskripsi;
                @photo.Value = SaveToPhysicalLocation(gambars.PhotoFile);
                @CreatedOn.Value = DateTime.Now;
                @CreatedBy.Value = gambars.CreatedBy;

                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_Beranda", @function, @deskripsi,@photo, @CreatedBy, @CreatedOn);
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

        public bool hapusGambar(int idi)
        {
            try
            {
                @function.Value = 3;
                @id.Value = idi;

                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_Beranda", @function, @id);
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
    }
}