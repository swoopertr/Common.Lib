using System;
using System.Runtime.InteropServices;

namespace Common.Lib.Utils.SystemHelper
{
  public static class SystemUtils
  {
    /// <summary>
    /// use only excel maniplulations
    /// </summary>
    /// <param name="obj"></param>
    public static void ReleaseObject(this object obj)
    {
      try
      {
        Marshal.ReleaseComObject(obj);
        obj = null;
      }
      catch
      {
        obj = null;
      }
      finally
      {
        GC.Collect();
      }
    }
  }

}

