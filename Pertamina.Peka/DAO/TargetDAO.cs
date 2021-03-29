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
    public class TargetDAO
    {
        #region Parameters Declaration
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @id = new SqlParameter("@id", SqlDbType.Int);
        protected SqlParameter @bulan = new SqlParameter("@bulan", SqlDbType.NVarChar, 20);
        protected SqlParameter @minggu1 = new SqlParameter("@minggu1", SqlDbType.Int);
        protected SqlParameter @minggu2 = new SqlParameter("@minggu2", SqlDbType.Int);
        protected SqlParameter @minggu3 = new SqlParameter("@minggu3", SqlDbType.Int);
        protected SqlParameter @minggu4 = new SqlParameter("@minggu4", SqlDbType.Int);
        protected SqlParameter @tahun = new SqlParameter("@tahun", SqlDbType.Int);
      
        protected SqlParameter @CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        protected SqlParameter @ModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);


        #endregion

        #region Public Method
        public List<Target> ListTarget()
        {
            try
            {
                @function.Value = 2;

                DataSet ds= SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_target", @function);
                DataTable dt = ds.Tables[0];
                List<Target> listResource = EntityBinder.ToCollection<Target>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public bool AddTarget(Target targets)
        {
            try
            {
                @function.Value = 1;
                @tahun.Value = targets.Tahun ;
                @minggu1.Value = targets.minggu1;
                @minggu2.Value = targets.minggu2;
                @minggu3.Value = targets.minggu3;
                @minggu4.Value = targets.minggu4;
                @CreatedBy.Value = targets.CreatedBy;
                @CreatedOn.Value = DateTime.Now;
                @bulan.Value = targets.Bulan;

                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_target", @function, @CreatedBy, @CreatedOn,@bulan,@tahun,@minggu1,@minggu2,@minggu3,@minggu4);
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

        //public bool UpdateTarget(Target targets)
        //{
        //    try
        //    {
        //        @function.Value = 3;
        //        @id.Value = targets.id;
        //        @bulan.Value = targets.bulan;
        //        @tahun.Value = targets.tahun;
              
        //        @ModifiedBy.Value = targets.ModifiedBy;

        //        int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_target", @function, @bulan, @tahun,
        //          @ModifiedBy,@id);
        //        if (result > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
        #endregion
    }
}