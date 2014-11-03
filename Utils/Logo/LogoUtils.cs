namespace Common.Lib.Utils.Logo
{
  public class LogoUtils
  {
    public static string GetIslemTipName(int moduleNr, int trCode)
    {
      string result = string.Empty;

      /*Alım Faturaları*/
      if (moduleNr == 4 && trCode == 31) { result = "Mal Alım Faturası"; }
      else if (moduleNr == 4 && trCode == 34) { result = "Alınan Hizmet Faturası"; }
      else if (moduleNr == 4 && trCode == 35) { result = "Alınan Proforma Faturası"; }
      else if (moduleNr == 4 && trCode == 36) { result = "Alım İade Faturası"; }
      else if (moduleNr == 4 && trCode == 37) { result = "Perakende Satıs Faturası"; }
      else if (moduleNr == 4 && trCode == 43) { result = "Alınan Fiyat Farkı Faturası"; }
      else if (moduleNr == 4 && trCode == 56) { result = "Müstahsil Makbuzu"; }

      /*Cari Hesap Modülü Faturaları*/
      else if (moduleNr == 4 && trCode == 41) { result = "Verilen Vade Farkı Faturası"; }
      else if (moduleNr == 4 && trCode == 42) { result = "Alınan Vade Farkı Faturası"; }

      /*Satıs Faturaları*/
      else if (moduleNr == 4 && trCode == 32) { result = "Perakende Satıs İade Faturası"; }
      else if (moduleNr == 4 && trCode == 33) { result = "Toptan Satıs İade Faturası"; }
      else if (moduleNr == 4 && trCode == 38) { result = "Toptan Satıs Faturası"; }
      else if (moduleNr == 4 && trCode == 39) { result = "Verilen Hizmet Faturası"; }
      else if (moduleNr == 4 && trCode == 10) { result = "Verilen Promorma Faturası"; }
      else if (moduleNr == 4 && trCode == 44) { result = "Verilen Fiyat Farkı Faturası"; }

      /*Kasa Modülü*/
      else if (moduleNr == 10 && trCode == 1) { result = "Kasadan Cari Hesap Tahsilat"; }
      else if (moduleNr == 10 && trCode == 2) { result = "Kasadan Cari Hesap Ödeme"; }

      /*Fatura Modulu*/
      else if (moduleNr == 5 && trCode == 1) { result = "Cari Hesap Tahsilat"; }
      else if (moduleNr == 5 && trCode == 2) { result = "Cari Hesap Ödeme"; }
      else if (moduleNr == 5 && trCode == 3) { result = "Borç Dekontu"; }
      else if (moduleNr == 5 && trCode == 4) { result = "Alacak Dekontu"; }
      else if (moduleNr == 5 && trCode == 5) { result = "Virman Fisi"; }
      else if (moduleNr == 5 && trCode == 6) { result = "Kur Farkı Fisi"; }
      else if (moduleNr == 5 && trCode == 12) { result = "Özel Fis"; }
      else if (moduleNr == 5 && trCode == 14) { result = "Açılıs Fisi"; }
      else if (moduleNr == 5 && trCode == 45) { result = "Verilen Serbest Meslek Makbuzu"; }
      else if (moduleNr == 5 && trCode == 46) { result = "Alınan Serbest Meslek Makbuzu"; }
      else if (moduleNr == 5 && trCode == 70) { result = "Kredi Kartı Fişi"; }
      else if (moduleNr == 5 && trCode == 71) { result = "Kredi Kartı İade Fişi"; }

      /*Cek Senet Modülü*/
      else if (moduleNr == 6 && trCode == 61) { result = "Çek Grisi"; }
      else if (moduleNr == 6 && trCode == 62) { result = "Senet Girisi"; }
      else if (moduleNr == 6 && trCode == 63) { result = "Kendi Çekimiz"; }
      else if (moduleNr == 6 && trCode == 64) { result = "Borç Senedimiz"; }
      else if (moduleNr == 61 && trCode == 3) { result = "Müşteriye Çek/Senet İadesi"; }

      /*Banka Modülü*/
      else if (moduleNr == 7 && trCode == 20) { result = "Gelen Havale"; }
      else if (moduleNr == 7 && trCode == 21) { result = "Gönderilen Havale"; }
      else if (moduleNr == 7 && trCode == 24) { result = "Döviz Alış Beldesi"; }
      else if (moduleNr == 7 && trCode == 25) { result = "Döviz Satış Beldesi"; }
      else if (moduleNr == 7 && trCode == 28) { result = "Banka Alınan Hizmet Faturası"; }
      else if (moduleNr == 7 && trCode == 29) { result = "Banka Verilen Hizmet Faturası"; }

      return result;
    }


  }
}
