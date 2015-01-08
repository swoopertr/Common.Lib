using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System;
using System.Text;
using System.Windows.Forms;

namespace Common.Lib.Utils
{
  public static class Utils
  {
    public static List<string> GetPropertiesStrings<T>(this T _object)
    {
      return typeof(T).GetProperties().Select(item => item.Name).ToList();
    }


    public static List<string> GetPropertyValuesInStrings<T>(this T _object)
    {
      List<string> result = new List<string>();
      List<string> propNames = typeof(T).GetProperties().Select(item => item.Name).ToList();

      for (int i = 0; i < propNames.Count; i++)
      {
        result.Add(_object.GetType().GetProperty(propNames[i]).GetValue(_object, null) == null
          ? ""
          : _object.GetType().GetProperty(propNames[i]).GetValue(_object, null).ToString());
      }
      return result;
    }

    public static string GetValueFromProperty<T>(this T _object, string propertyName)
    {
      return _object.GetType().GetProperty(propertyName).GetValue(_object, null).ToString();
    }


    /// <summary>
    /// Resim boyutlandırması yapar
    /// </summary>
    /// <param name="FileNameInput">D:\Projects\Luanda\Luanda.Web\assets\document\gallery\26\chrysanthemum.jpg</param>
    /// <param name="OutputPath">D:\Projects\Luanda\Luanda.Web\assets\document\gallery\26\150x120\chrysanthemum.jpg</param>
    /// <param name="FileName">aa.jpg</param>
    /// <param name="ResizeHeight">150</param>
    /// <param name="ResizeWidth">120</param>
    /// <param name="OutputFormat">ImageFormat.Jpeg</param>
    public static void ResizeImage(string FileNameInput, string OutputPath, string FileName, double ResizeWidth, double ResizeHeight, ImageFormat OutputFormat)
    {
      using (var photo = new Bitmap(FileNameInput))
      {
        double aspectRatio = (double)photo.Width / photo.Height;
        double boxRatio = ResizeWidth / ResizeHeight;
        double scaleFactor = 0;

        if (photo.Width < ResizeWidth && photo.Height < ResizeHeight)
        {
          // keep the image the same size since it is already smaller than our max width/height
          scaleFactor = 1.0;
        }
        else
        {
          if (boxRatio > aspectRatio)
            scaleFactor = ResizeHeight / photo.Height;
          else
            scaleFactor = ResizeWidth / photo.Width;
        }

        int newWidth = (int)(photo.Width * scaleFactor);
        int newHeight = (int)(photo.Height * scaleFactor);

        // Ölçeklenen fotoğraf, istenen yükseklikten küçük ise
        if (newHeight < ResizeHeight)
        {
          newWidth = (int)((photo.Width * ResizeHeight) / photo.Height);
          newHeight = (int)ResizeHeight;
        }
        // Ölçeklenen fotoğraf, istenen genişlikten küçük ise
        else if (newWidth < ResizeWidth)
        {
          newWidth = (int)ResizeWidth;
          newHeight = (int)((photo.Height * ResizeWidth) / photo.Width);
        }

        // İstenen ölçüle yeni Bitmap nesnesi oluştur
        using (Bitmap bmp = new Bitmap((int)ResizeWidth, (int)ResizeHeight))
        {
          using (Graphics g = Graphics.FromImage(bmp))
          {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Bitmap'ın içine yeni ölçülere göre resmi çiz
            g.DrawImage(photo, 0, 0, (int)newWidth, (int)newHeight);

            if (ImageFormat.Png.Equals(OutputFormat))
            {
              bmp.Save(OutputPath, OutputFormat);
            }
            else if (ImageFormat.Jpeg.Equals(OutputFormat))
            {
              ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
              EncoderParameters encoderParameters;
              using (encoderParameters = new System.Drawing.Imaging.EncoderParameters(1))
              {
                // use jpeg info[1] and set quality to 90
                encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);

                // eğer istenen dizin yoksa oluştur.
                if (!Directory.Exists(OutputPath))
                  Directory.CreateDirectory(OutputPath);

                bmp.Save(string.Format(@"{0}\{1}", OutputPath, FileName), info[1], encoderParameters);
              }
            }
          }
        }
      }
    }

    public static Image byteArrayToImage(byte[] byteArrayIn)
    {
      if (byteArrayIn == null)
      {
        return null;
      }
      MemoryStream ms = new MemoryStream(byteArrayIn);
      Image returnImage = (byteArrayIn.Length == 0) ? null : Image.FromStream(ms);
      return returnImage;
    }


    public static string GenerateString(int length)
    {
      const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
      StringBuilder res = new StringBuilder();
      Random rnd = new Random();
      while (0 < length--)
      {
        res.Append(valid[rnd.Next(valid.Length)]);
      }
      return res.ToString();
    }


    public static void CloseApplication()
    {
      Environment.Exit(Environment.ExitCode);
      Application.Exit();
    }

  }
}
