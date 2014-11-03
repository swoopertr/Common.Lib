using System.Web;

namespace Common.Lib.Utils.Web
{
  public static class HttpRequestExtensions
  {
    private static readonly string[] _ipHeaderOrder = new[] { "HTTP_X_FORWARDED_FOR", "HTTP_X_CLUSTER_CLIENT_IP", "REMOTE_ADDR" };

    public static string ClientAddress(this HttpRequest request)
    {
      foreach (string header in _ipHeaderOrder)
      {
        string ipAddress = request.ServerVariables[header];
        if (ipAddress != null)
        {
          return ipAddress;
        }
      }
      return string.Empty;
    }
  }
}
