using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Common.Lib
{
  public static class BaseExtension
  {
    public static DataTable ToDataTable<T>(this List<T> varlist)
    {
      DataTable dtReturn = new DataTable();

      // column names 
      PropertyInfo[] oProps = null;

      if (varlist == null) return dtReturn;

      foreach (T rec in varlist)
      {
        // Use reflection to get property names, to create table, Only first time, others will follow 
        if (oProps == null)
        {
          oProps = ((Type)rec.GetType()).GetProperties();
          foreach (PropertyInfo pi in oProps)
          {
            Type colType = pi.PropertyType;

            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
              colType = colType.GetGenericArguments()[0];
            }

            dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
          }
        }

        DataRow dr = dtReturn.NewRow();

        foreach (PropertyInfo pi in oProps)
        {
          dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
        }

        dtReturn.Rows.Add(dr);
      }
      return dtReturn;
    }

    public static bool IsNull(this object source)
    {
      return source == null;
    }

  }
}
