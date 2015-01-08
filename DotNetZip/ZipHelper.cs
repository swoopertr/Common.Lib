using System.IO;
using Ionic.Zip;

namespace Common.Lib.DotNetZip
{
  public class ZipHelper
  {
    public ZipHelper()
    {

    }

    public void ZipFile(string[] sourceFile, string targetFile)
    {
      ZipFile(sourceFile, targetFile,string.Empty);
    }


    public void ZipFile(string[] sourceFile, string targetFile, string password)
    {
      using (var zip = new ZipFile())
      {
        if (!string.IsNullOrEmpty(password))
        {
          zip.Password = password;
        }
        for (int i = 0; i < sourceFile.Length; i++)
        {
          zip.AddFile(sourceFile[i]);
        }
        zip.Save(targetFile + ".zip");
      }
    }

    public void ZipFolder(string folderPath, string targetFolderPath)
    {
      ZipFolder(folderPath,targetFolderPath, string.Empty);
    }

    public void ZipFolder(string folderPath, string targetFolderPath, string password)
    {
      using (var zip = new ZipFile())
      {
        if (!string.IsNullOrEmpty(password))
        {
          zip.Password = password;
        }

        string[] files = Directory.GetFiles(folderPath, "", SearchOption.AllDirectories);

        for (int i = 0; i < files.Length; i++)
        {
          zip.AddFile(files[i]);
        }
        zip.Save(targetFolderPath + ".zip");
      }
    }


    public void ReadZip(string sourceFile, string targetFolder, string password)
    {
      using (var zip = Ionic.Zip.ZipFile.Read(sourceFile))
      {
        zip.ExtractAll(targetFolder, ExtractExistingFileAction.OverwriteSilently);
      }
    }


  }
}
