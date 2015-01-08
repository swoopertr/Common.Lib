using System;
using System.Web;

namespace Common.Lib.Utils.Web
{
  public class CookieHelper
  {
    public static HttpCookie Get(string key)
    {
      HttpCookie httpCookie = HttpContext.Current.Request.Cookies[key];

      return httpCookie ?? null;
    }

    public static bool Add(string key, string value, DateTime expiresDate)
    {
      HttpContext.Current.Request.Cookies.Remove(key);
      HttpCookie httpCookie = new HttpCookie(key)
      {
        Expires = expiresDate, 
        Value = value, 
        HttpOnly = true
      };
      HttpContext.Current.Response.Cookies.Add(httpCookie);
      return true;
    }

    public static void Remove(string key)
    {
      HttpContext.Current.Request.Cookies.Remove(key);
    }
  }
}
