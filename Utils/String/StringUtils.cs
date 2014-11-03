using System;

namespace Common.Lib.Utils.String
{
  public static class StringUtils
  {
    /// <summary>
    /// Use this function (tunc kiral -> Tunc Kiral)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string ToTitleCase(this string data)
    {
      return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(data.ToLower());
    }

    public static int WordCount(this string str)
    {
      return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string GenPasword(int lenght)
    {
      return System.Web.Security.Membership.GeneratePassword(lenght, 3);
    }

  }
}
