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
    public class AdminDAO 
    {
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @idPeka = new SqlParameter("@idPeka", SqlDbType.NVarChar, 50);
        protected SqlParameter @locationScore = new SqlParameter("@locationScore", SqlDbType.BigInt);
        protected SqlParameter @resikoScore = new SqlParameter("@resikoScore", SqlDbType.BigInt);
        protected SqlParameter @temuanScore = new SqlParameter("@temuanScore", SqlDbType.BigInt);
        protected SqlParameter @IntervensiScore = new SqlParameter("@IntervensiScore", SqlDbType.BigInt);
        protected SqlParameter @saranScore = new SqlParameter("@saranScore", SqlDbType.BigInt);
        protected SqlParameter @tingkahLakuBaikScore = new SqlParameter("@tingkahLakuBaikScore", SqlDbType.BigInt);

        protected SqlParameter @CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        protected SqlParameter @ModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);

        public bool AddPeka(Admin admins)
        {
            try
            {
                @function.Value = 1;

                @idPeka.Value = admins.idPeka;
                @locationScore.Value = admins.locationScore;
                @resikoScore.Value = admins.resikoScore;
                @temuanScore.Value = admins.temuanScore;
                @IntervensiScore.Value = admins.IntervensiScore;
                @saranScore.Value = admins.saranScore;
                @tingkahLakuBaikScore.Value = admins.tingkahLakuBaikScore; 
                @CreatedOn.Value = DateTime.Now;
                @CreatedBy.Value = admins.CreatedBy;

                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_Admin", @function, @idPeka, @locationScore, @resikoScore, @temuanScore, @IntervensiScore,
                    @saranScore, @tingkahLakuBaikScore, @CreatedBy, @CreatedOn);
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
        public List<Admin> ListRealisasiVSTarget()
        {
            try
            {
                @function.Value =2;
      
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Admin", @function);
                DataTable dt = ds.Tables[0];
                List<Admin> listResource = EntityBinder.ToCollection<Admin>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}