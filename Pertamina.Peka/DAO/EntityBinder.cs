using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;
using Pertamina.Peka.Models;

namespace Pertamina.Peka.DAO
{
    public static class EntityBinder
    {
        public static List<T> ToCollection<T>(this DataTable dt)
        {
            List<T> lst = new System.Collections.Generic.List<T>();
            Type tClass = typeof(T);
            PropertyInfo[] pClass = tClass.GetProperties();
            List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
            T cn;
            foreach (DataRow item in dt.Rows)
            {
                cn = (T)Activator.CreateInstance(tClass);
                foreach (PropertyInfo pc in pClass)
                {

                    DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                    if (d != null)
                    {
                        if (item[pc.Name] != DBNull.Value)
                        {
                            pc.SetValue(cn, (item[pc.Name]), null);
                        }
                    }
                }
                lst.Add(cn);
            }
            return lst;
        }
    }
}