using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pertamina.Peka.Models;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace Pertamina.Peka.DAO
{
    public class ScoreDAO
    {
        #region Parameters Declaration
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @id = new SqlParameter("@id", SqlDbType.Int);
        protected SqlParameter @locationScore = new SqlParameter("@locationScore", SqlDbType.Float);
        protected SqlParameter @temuanScore = new SqlParameter("@TemuanScore", SqlDbType.Float);
        protected SqlParameter @IntervensiScore = new SqlParameter("@IntervensiScore", SqlDbType.Float);
        protected SqlParameter @saranScore = new SqlParameter("@SaranScore", SqlDbType.Float);
        protected SqlParameter @tingkahLakuBaikScore = new SqlParameter("@tingkahLakuBaikScore", SqlDbType.Float);
        protected SqlParameter @total = new SqlParameter("@total", SqlDbType.Float);

        protected SqlParameter @CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        protected SqlParameter @ModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        #endregion

        public List<LembarPeka> listPeka()
        {
            try
            {
                @function.Value = 2;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_LembarPeka", @function);
                DataTable dt = ds.Tables[0];
                List<LembarPeka> listResource = EntityBinder.ToCollection<LembarPeka>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
           
        }

        public bool AddScore(Admin scores)
        {
            try
            {
                @function.Value = 1;
                @id.Value = scores.id;
                @locationScore.Value = scores.locationScore;
                @temuanScore.Value = scores.temuanScore;
                @IntervensiScore.Value = scores.IntervensiScore;
                @saranScore.Value = scores.saranScore;
                @tingkahLakuBaikScore.Value = scores.tingkahLakuBaikScore;
                @total.Value = scores.locationScore + scores.temuanScore + scores.IntervensiScore + scores.saranScore + scores.tingkahLakuBaikScore;
                @CreatedBy.Value = scores.CreatedBy;
                @CreatedOn.Value = DateTime.Now;

                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_score", @function, @CreatedBy, @CreatedOn);
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

        public bool UpdateLembarPeka(LembarPeka lembarPekas)
        {
            try
            {
                @function.Value = 3;
          
                @ModifiedBy.Value = lembarPekas.ModifiedBy;                
                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_lembarPeka", @function,@ModifiedBy);
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