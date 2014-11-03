using System.Collections.Generic;

namespace Common.Lib
{
  public static class Constants
  {
    public static List<string> PhotoFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
    public static List<string> VideoFileExtensions = new List<string> { ".avi", ".mov", ".dat", ".wmv", ".mpeg", ".xvid", ".mpeg4", ".mpg", ".mp4" };

    public static string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
    public static string[] mevsimler = { "İlkbahar", "Yaz", "Sonbahar", "Kış" };

    public static string[] months = { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december" };
    public static string[] aylar = { "ocak", "şubat", "mart", "nisan", "mayıs", "haziran", "temmuz", "ağustos", "eylül", "ekim", "kasım", "aralık" };

  }
}
