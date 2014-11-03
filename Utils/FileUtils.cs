using System.IO;
using System.Text;

namespace Common.Lib.Utils
{
  public class FileUtils
  {
    /// <summary>
    /// Gönderilen konumdaki dosyayı varsa siler.
    /// </summary>
    /// <param name="_dosya">C:\asd.jpg</param>
    /// <returns>Başarılı Sonuç = 1, Başarısız Sonuç = -1</returns>
    public static int FileDelete(string _dosya)
    {
      int intReturn = -1;
      if (File.Exists(_dosya))
      {
        try
        {
          File.Delete(_dosya);
          intReturn = 1;
        }
        catch (IOException)
        {
          intReturn = -1;
        }
      }
      return intReturn;
    }

    public static string FileRead(string fileName)
    {
      try
      {
        return File.ReadAllText(fileName, Encoding.UTF8);
      }
      catch
      {
        return string.Empty;
      }
    }



  }
}
