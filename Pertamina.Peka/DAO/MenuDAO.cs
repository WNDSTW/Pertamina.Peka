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
    public class MenuDAO : Menu
    {
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @MenuId = new SqlParameter("@MenuId", SqlDbType.Int);

        public List<Menu> ListMenu()
        {
            try
            {
                @function.Value = 1;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Menu", @function);
                DataTable dt = ds.Tables[0];
                List<Menu> listResource = EntityBinder.ToCollection<Menu>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public List<Menu> ListMenuUser()
        {
            try
            {
                @function.Value = 2;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Menu", @function);
                DataTable dt = ds.Tables[0];
                List<Menu> listResource = EntityBinder.ToCollection<Menu>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}