using System.IO;
using System.Net;
using fastJSON;

namespace Common.Lib.Json
{
  public class JsonHelper<T> where T : class
  {
    public string Serialize(T entity)
    {
      JSON.Parameters.UseExtensions = false;
      return JSON.ToJSON(entity, JSON.Parameters);
    }

    public T Deserialize(string stringData)
    {
      JSON.Parameters.UseExtensions = false;
      return JSON.ToObject<T>(stringData);
    }

    public static T CallJson<T>(string url)
    {
      HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);

      using (WebResponse webResponse = webRequest.GetResponse())
      {
        using (Stream str = webResponse.GetResponseStream())
        {
          using (StreamReader sr = new StreamReader(str))
          {
            return JSON.ToObject<T>(sr.ReadToEnd());
          }
        }
      }

    }


  }




  public static class JsonExtension
  {
    public static string ToJson(this object v)
    {
      JSON.Parameters.UseExtensions = false;
      return JSON.ToJSON(v, JSON.Parameters);
    }
  }








}

