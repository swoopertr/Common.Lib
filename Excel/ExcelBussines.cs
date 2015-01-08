using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Common.Lib.Utils;
using GlobalExcel = Microsoft.Office.Interop.Excel;

namespace Common.Lib.Excel
{
  public class ExcelBussines
  {

    public DataTable ReadDataFromExcel(string filePath)
    {

      GlobalExcel.Application aApp = new GlobalExcel.Application();
      System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

      GlobalExcel.Workbook wBook = aApp.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,Type.Missing, Type.Missing, Type.Missing);


      DataTable result = new DataTable();

      GlobalExcel.Sheets TheSheets = wBook.Sheets;

      GlobalExcel.Worksheet theSheet = (GlobalExcel.Worksheet)TheSheets.Item[1];

      GlobalExcel.Range rng = theSheet.Range["A1", Missing.Value];
      rng = rng.End[Microsoft.Office.Interop.Excel.XlDirection.xlToRight];
      rng = rng.End[Microsoft.Office.Interop.Excel.XlDirection.xlDown];

      int theRow = theSheet.Cells.SpecialCells(GlobalExcel.XlCellType.xlCellTypeLastCell, Missing.Value).Row;
      int theCol = theSheet.Cells.SpecialCells(GlobalExcel.XlCellType.xlCellTypeLastCell, Missing.Value).Column;


      for (int i = 0; i <= theCol; i++) //kolonlar oluşturuluyor
      {
        result.Columns.Add(new DataColumn());
      }

      for (int i = 2; i <= theRow; i++) // ilk satır başlıklar var kabul edip okumuyoruz.
      {
        DataRow dataRow = result.NewRow();
        for (int j = 1; j <= theCol; j++) // excel ilk kolon 1 den başlıyor
        {
          dataRow[j - 1] = ((GlobalExcel.Range)theSheet.Cells[i, j]).Value2 ?? string.Empty;
        }
        result.Rows.Add(dataRow);
      }
      wBook.Close(false, Missing.Value, Missing.Value);
      aApp.Quit();

      //return back to the original culture
      System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;

      return result;
    }





    public static void CreateExcel<T>(List<T> entity, string filePath)
    {
      if (entity.Count == 0) { return; }

      var aApp = new GlobalExcel.Application();
      System.Globalization.CultureInfo oldCi = System.Threading.Thread.CurrentThread.CurrentCulture;
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
      aApp.Visible = true;

      GlobalExcel.Workbook workbook = aApp.Workbooks.Add(Missing.Value);
      GlobalExcel.Worksheet worksheet = (GlobalExcel.Worksheet)workbook.Sheets[1];
      worksheet.Name = "Rapor";

      List<string> propertiesStrings = entity[0].GetPropertiesStrings();

      for (int i = 0; i < propertiesStrings.Count; i++)
      {
        worksheet.Cells[1, i + 1] = propertiesStrings[i];
      }

      GlobalExcel.Range rng = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, propertiesStrings.Count]];
      rng.Font.Bold = true;
      rng.Font.Size = 18;

      for (int i = 0; i < entity.Count; i++)
      {
        List<string> propertyValuesInStrings = entity[i].GetPropertyValuesInStrings();
        for (int j = 0; j < propertyValuesInStrings.Count; j++)
        {
          worksheet.Cells[i + 2, j + 1] = propertyValuesInStrings[j];
        }
      }
      try
      {
        workbook.SaveAs(filePath, GlobalExcel.XlFileFormat.xlWorkbookNormal, null, null, true, false, GlobalExcel.XlSaveAsAccessMode.xlNoChange, false, false, null, null, null);
        workbook.Close(false, Type.Missing, Type.Missing);
      }
      catch
      {
        //exception
      }
      finally
      {
        aApp.Quit();
      }
      System.Threading.Thread.CurrentThread.CurrentCulture = oldCi;


    }

  }
}
