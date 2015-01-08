using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Lib.Log
{
  public class Logger
  {
      public static string LogFolder;
    public static void Log(string log)
    {
      string fileName = string.Format("{0}-{1}-{2}-Error.txt", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
      using (StreamWriter sw = new StreamWriter(fileName, true))
      {
        sw.WriteLine(DateTime.Now.ToString("g") + " : " + log);
        sw.Flush();
      }
    }
  }
}
