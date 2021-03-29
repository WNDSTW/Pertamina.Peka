using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Pertamina.Peka.DAO
{
    public class General
    {
        public static string connString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["HRDconstring"].ToString();
            }
        }

        public string AppconnString
        {
            get
            {
                string conn = @"data source=Jhon\sqlexpress;initial catalog=Peka;user id=sa;password=kpmproject;Connect Timeout=0;";
                return conn;
            }
        }

        public static string PEKAconnString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["PEKAconstring"].ToString();
            }
        }
    }
}