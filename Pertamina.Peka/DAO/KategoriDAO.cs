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
    public class KategoriDAO : Kategori
    {
        #region Parameters Declaration
        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @kodeKategori = new SqlParameter("@kodeKategori", SqlDbType.Int);
        protected SqlParameter @deskripsi = new SqlParameter("@deskripsi", SqlDbType.Int);      

        #endregion

        #region Public Method
        public DataSet ListKategori()
        {
            @function.Value = 3;

            return SqlHelper.ExecuteDataset(General.PEKAconnString, CommandType.StoredProcedure, "usp_LembarPeka", @function);

        }
       
        public bool Get(ref Kategori kategories)
        {
            SqlDataReader item_dr;
            @function.Value = 3;
            @kodeKategori.Value = kategories.kodeKategori;

            item_dr = SqlHelper.ExecuteReader(General.PEKAconnString, CommandType.StoredProcedure, "usp_LembarPeka", @function, @kodeKategori);

            if (item_dr.HasRows)
            {
                item_dr.Read();

                if (!(item_dr.IsDBNull(item_dr.GetOrdinal("kodeKAtegori"))))
                {
                    kategories.kodeKategori = int.Parse(item_dr["kodeKategori"].ToString());
                }
                if (!(item_dr.IsDBNull(item_dr.GetOrdinal("deskripsi"))))
                {
                    kategories.deskripsi = item_dr["deskripsi"].ToString();
                }
               
                item_dr.Close();
                item_dr.Dispose();
                return true;
            }
            else
            {
                item_dr.Close();
                item_dr.Dispose();
                return false;
            }
        }
     
        #endregion
    }
}