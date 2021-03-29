using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pertamina.Peka.Models;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Pertamina.Peka.DAO
{
    public class BagianDAO
    {
        #region Parameters Declaration
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @noBagian = new SqlParameter("@noBagian", SqlDbType.Int);
        protected SqlParameter @bagian = new SqlParameter("@bagian", SqlDbType.VarChar, 50);
        protected SqlParameter @noFungsi = new SqlParameter("@noFungsi", SqlDbType.Int);        
        #endregion

        public List<Bagians> ListBagian()
        {
            try
            {
                @function.Value = 1;

                DataSet ds = SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_Bagian", @function);
                DataTable dt = ds.Tables[0];
                List<Bagians> listResource = EntityBinder.ToCollection<Bagians>(dt);
                return listResource;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

    }
}