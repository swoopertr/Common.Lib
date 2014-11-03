using System.Security.Cryptography;
using System.Text;

namespace Common.Lib.Utils.Crypto
{
  public class CryptoUtils
  {

    public static string MD5(string _strDeger)
    {
      MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
      byte[] data = Encoding.ASCII.GetBytes(_strDeger);
      data = md5.ComputeHash(data);

      StringBuilder strReturn = new StringBuilder();

      for (int i = 0; i < data.Length; i++)
        strReturn.Append(data[i].ToString("x2").ToLower());

      return strReturn.ToString();
    }

    public static string HMACMD5(string value, string key)
    {
      ASCIIEncoding encoding = new ASCIIEncoding();
      byte[] keyByte = encoding.GetBytes(key);

      HMACMD5 hmacmd5 = new HMACMD5(keyByte);

      byte[] hashmessage = hmacmd5.ComputeHash(encoding.GetBytes(value));

      return ByteToString(hashmessage);
    }

    public static string Sha256(string password)
    {
      SHA256Managed crypt = new SHA256Managed();
      StringBuilder hash = new StringBuilder();
      byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
      for (int index = 0; index < crypto.Length; index++)
      {
        hash.Append(crypto[index].ToString("x2"));
      }
      return hash.ToString();
    }

    public static string ByteToString(byte[] buff)
    {
      StringBuilder sbinary = new StringBuilder();

      for (int i = 0; i < buff.Length; i++)
        sbinary.Append(buff[i].ToString("x2")); // hex format

      return (sbinary.ToString());
    }
  }
}
