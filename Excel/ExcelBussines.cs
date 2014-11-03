using System;
using System.Data;
using System.Reflection;
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

      GlobalExcel.Workbook wBook = aApp.Workbooks.Open(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
          Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
          Type.Missing, Type.Missing, Type.Missing);


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

  }
}
