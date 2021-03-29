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
    public class LaporanDAO :Laporans
    {
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @modifiedBy= new SqlParameter("@modifiedBy", SqlDbType.NVarChar,50);
        protected SqlParameter @idPeka = new SqlParameter("@idPeka", SqlDbType.Int);

        public List<Laporans> ListTemuanSubStandar()
        {
            try
            {
                @function.Value = 1;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Laporans> ListTingkahLakuBaik()
        {
            try
            {
                @function.Value = 2;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Laporans> ListPekaSoreTarget()
        {
            try
            {
                @function.Value = 3;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public List<Laporans> ListPekaSoreTargetAll()
        {
            try
            {
                @function.Value = 31;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Laporans> ListTargetBagian()
        {
            try
            {
                @function.Value = 4;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public List<Laporans> ListTargetBagianAll()
        {
            try
            {
                @function.Value = 41;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Laporans> ListTargetFungsi()
        {
            try
            {
                @function.Value = 5;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        public List<Laporans> ListTargetFungsiAll()
        {
            try
            {
                @function.Value = 51;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function);
                DataTable dt = ds.Tables[0];
                List<Laporans> listResource = EntityBinder.ToCollection<Laporans>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public bool Delete(Laporans lap)
        {
            @function.Value = 6;
            @modifiedBy.Value = lap.ModifiedBy;
            @idPeka.Value = lap.idPeka;
             try
            {
                int result = SqlHelper.ExecuteNonQuery(General.PEKAconnString, CommandType.StoredProcedure, "usp_Laporan", @function, @modifiedBy,@idPeka);
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