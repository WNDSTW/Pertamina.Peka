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
    public class GrafikDAO : Grafik
    {
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @Bulan = new SqlParameter("@Bulan", SqlDbType.Int);
        protected SqlParameter @Tahun = new SqlParameter("@Tahun", SqlDbType.Int);
        //protected SqlParameter @MenuId = new SqlParameter("@MenuId", SqlDbType.Int);

        public List<Grafik> ListRealisasiVSTarget(Grafik grafiks)
        {
            try
            {
                @function.Value = 2;
                @Bulan.Value = grafiks.Bulan;
                @Tahun.Value = grafiks.Tahun;
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Grafik", @function,@Bulan,@Tahun);
                DataTable dt = ds.Tables[0];
                List<Grafik> listResource = EntityBinder.ToCollection<Grafik>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Grafik> ListPengirimPerBagian(Grafik grafiks)
        {
            try
            {
                @function.Value = 1;
                @Bulan.Value = grafiks.Bulan;
                @Tahun.Value = grafiks.Tahun;
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Grafik", @function,@Bulan,@Tahun);
                DataTable dt = ds.Tables[0];
                List<Grafik> listResource = EntityBinder.ToCollection<Grafik>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Grafik> ListPekaPerKategori()
        {
            try
            {
                @function.Value = 3;
                //@Bulan.Value = grafiks.Bulan;
                //@Tahun.Value = grafiks.Tahun;
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Grafik", @function);
                DataTable dt = ds.Tables[0];
                List<Grafik> listResource = EntityBinder.ToCollection<Grafik>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Grafik> ListPekaPerKategoriAll()
        {
            try
            {
                @function.Value = 31;
                //@Bulan.Value = grafiks.Bulan;
                //@Tahun.Value = grafiks.Tahun;
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Grafik", @function);
                DataTable dt = ds.Tables[0];
                List<Grafik> listResource = EntityBinder.ToCollection<Grafik>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Grafik> getTahun()
        {
            try
            {
                @function.Value =4 ;
                //@Bulan.Value = grafiks.Bulan;
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Grafik", @function);
                DataTable dt = ds.Tables[0];
                List<Grafik> listResource = EntityBinder.ToCollection<Grafik>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Grafik> getAktifVSNonAktif(Grafik grafiks)
        {
            try
            {
                @function.Value = 5;
                @Bulan.Value = grafiks.Bulan;
                @Tahun.Value = grafiks.Tahun;
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Grafik", @function,@Bulan,@Tahun);
                DataTable dt = ds.Tables[0];
                List<Grafik> listResource = EntityBinder.ToCollection<Grafik>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Grafik> ListRealisasiVsTargetPerBagian(Grafik grafiks)
        {
            try
            {
                @function.Value = 6;
                @Bulan.Value = grafiks.Bulan;
                @Tahun.Value = grafiks.Tahun;
                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Grafik", @function, @Bulan, @Tahun);
                DataTable dt = ds.Tables[0];
                List<Grafik> listResource = EntityBinder.ToCollection<Grafik>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}