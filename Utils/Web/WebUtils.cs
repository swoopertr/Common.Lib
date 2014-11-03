using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Lib.Utils.Web
{
  public struct WebHeaderParameter
  {
    public string name;
    public string value;
  }

  public class WebUtils
  {
    public const string MatchEmailPattern =
           @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    public static bool IsEmail(string email)
    {
      return email != null && Regex.IsMatch(email, MatchEmailPattern);
    }

    public static string GetUserIP()
    {
      string LoadBalancer = ConfigurationManager.AppSettings.Get("LoadBalancerIP");
      string VarIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
      string VarClientIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
      string IP = string.Empty;
      if (!string.IsNullOrEmpty(VarIP) && VarIP != LoadBalancer)
        IP = VarIP;
      else if (!string.IsNullOrEmpty(VarClientIP) && VarClientIP != LoadBalancer)
        IP = VarClientIP;
      return IP;
    }


    public static Stream GetStreamFromUrl(string url, WebHeaderParameter[] parameters, string method)
    {
      WebRequest req = WebRequest.Create(url);
      StringBuilder postData = new StringBuilder();
      //req.Headers.Clear();

      for (int i = 0; i < parameters.Length; i++)
      {
        if (i > 0)
        {
          postData.Append("&");
        }
        postData.AppendFormat("{0}={1}", parameters[i].name, parameters[i].value);
      }

      ASCIIEncoding encoding = new ASCIIEncoding();
      byte[] data = encoding.GetBytes(postData.ToString());


      req.Method = method;
      req.ContentType = "application/x-www-form-urlencoded";
      req.ContentLength = data.Length;

      Stream dataStream = req.GetRequestStream();
      dataStream.Write(data, 0, data.Length);
      dataStream.Close();


      WebResponse res = req.GetResponse();
      return res.GetResponseStream();
    }

  }
}
