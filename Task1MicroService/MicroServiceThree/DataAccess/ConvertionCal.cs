using MicroServiceThree.API;
using MicroServiceThree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceThree.DataAccess
{
    public class ConvertionCal
    {
        private readonly ExchangeRateApi exchangeRateApi = ExchangeRateApi.ExchangeRateAPI;


        private double getExchangeRate(string basecur, string symbol)
        {
            ExchangeRateModel exchangeRateModel = exchangeRateApi.getCurrentRate(basecur, symbol);

            switch (symbol)
            {
                case "AED": return exchangeRateModel.AED;
                case "AFN": return exchangeRateModel.AFN;
                case "ALL": return exchangeRateModel.ALL;
                case "AMD": return exchangeRateModel.AMD;
                case "ANG": return exchangeRateModel.ANG;
                case "AOA": return exchangeRateModel.AOA;
                case "ARS": return exchangeRateModel.ARS;
                case "AUD": return exchangeRateModel.AUD;
                case "AWG": return exchangeRateModel.AWG;
                case "AZN": return exchangeRateModel.AZN;
                case "BAM": return exchangeRateModel.BAM;
                case "BBD": return exchangeRateModel.BBD;
                case "BDT": return exchangeRateModel.BDT;
                case "BGN": return exchangeRateModel.BGN;
                case "BHD": return exchangeRateModel.BHD;
                case "BIF": return exchangeRateModel.BIF;
                case "BMD": return exchangeRateModel.BMD;
                case "BND": return exchangeRateModel.BND;
                case "BOB": return exchangeRateModel.BOB;
                case "BRL": return exchangeRateModel.BRL;
                case "BSD": return exchangeRateModel.BSD;
                case "BTC": return exchangeRateModel.BTC;
                case "BTN": return exchangeRateModel.BTN;
                case "BWP": return exchangeRateModel.BWP;
                case "BYN": return exchangeRateModel.BYN;
                case "BYR": return exchangeRateModel.BYR;
                case "BZD": return exchangeRateModel.BZD;
                case "CAD": return exchangeRateModel.CAD;
                case "CDF": return exchangeRateModel.CDF;
                case "CHF": return exchangeRateModel.CHF;
                case "CLF": return exchangeRateModel.CLF;
                case "CLP": return exchangeRateModel.CLP;
                case "CNY": return exchangeRateModel.CNY;
                case "COP": return exchangeRateModel.COP;
                case "CRC": return exchangeRateModel.CRC;
                case "CUC": return exchangeRateModel.CUC;
                case "CUP": return exchangeRateModel.CUP;
                case "CVE": return exchangeRateModel.CVE;
                case "CZK": return exchangeRateModel.CZK;
                case "DJF": return exchangeRateModel.DJF;
                case "DKK": return exchangeRateModel.DKK;
                case "DOP": return exchangeRateModel.DOP;
                case "DZD": return exchangeRateModel.DZD;
                case "EGP": return exchangeRateModel.EGP;
                case "ERN": return exchangeRateModel.ERN;
                case "ETB": return exchangeRateModel.ETB;
                case "EUR": return exchangeRateModel.EUR;
                case "FJD": return exchangeRateModel.FJD;
                case "FKP": return exchangeRateModel.FKP;
                case "GBP": return exchangeRateModel.GBP;
                case "GEL": return exchangeRateModel.GEL;
                case "GGP": return exchangeRateModel.GGP;
                case "GHS": return exchangeRateModel.GHS;
                case "GIP": return exchangeRateModel.GIP;
                case "GMD": return exchangeRateModel.GMD;
                case "GNF": return exchangeRateModel.GNF;
                case "GTQ": return exchangeRateModel.GTQ;
                case "GYD": return exchangeRateModel.GYD;
                case "HKD": return exchangeRateModel.HKD;
                case "HNL": return exchangeRateModel.HNL;
                case "HRK": return exchangeRateModel.HRK;
                case "HTG": return exchangeRateModel.HTG;
                case "HUF": return exchangeRateModel.HUF;
                case "IDR": return exchangeRateModel.IDR;
                case "ILS": return exchangeRateModel.ILS;
                case "IMP": return exchangeRateModel.IMP;
                case "INR": return exchangeRateModel.INR;
                case "IQD": return exchangeRateModel.IQD;
                case "IRR": return exchangeRateModel.IRR;
                case "ISK": return exchangeRateModel.ISK;
                case "JEP": return exchangeRateModel.JEP;
                case "JMD": return exchangeRateModel.JMD;
                case "JOD": return exchangeRateModel.JOD;
                case "JPY": return exchangeRateModel.JPY;
                case "KES": return exchangeRateModel.KES;
                case "KGS": return exchangeRateModel.KGS;
                case "KHR": return exchangeRateModel.KHR;
                case "KMF": return exchangeRateModel.KMF;
                case "KPW": return exchangeRateModel.KPW;
                case "KRW": return exchangeRateModel.KRW;
                case "KWD": return exchangeRateModel.KWD;
                case "KYD": return exchangeRateModel.KYD;
                case "KZT": return exchangeRateModel.KZT;
                case "LAK": return exchangeRateModel.LAK;
                case "LBP": return exchangeRateModel.LBP;
                case "LKR": return exchangeRateModel.LKR;
                case "LRD": return exchangeRateModel.LRD;
                case "LSL": return exchangeRateModel.LSL;
                case "LTL": return exchangeRateModel.LTL;
                case "LVL": return exchangeRateModel.LVL;
                case "LYD": return exchangeRateModel.LYD;
                case "MAD": return exchangeRateModel.MAD;
                case "MDL": return exchangeRateModel.MDL;
                case "MGA": return exchangeRateModel.MGA;
                case "MKD": return exchangeRateModel.MKD;
                case "MMK": return exchangeRateModel.MMK;
                case "MNT": return exchangeRateModel.MNT;
                case "MOP": return exchangeRateModel.MOP;
                case "MRO": return exchangeRateModel.MRO;
                case "MUR": return exchangeRateModel.MUR;
                case "MVR": return exchangeRateModel.MVR;
                case "MWK": return exchangeRateModel.MWK;
                case "MXN": return exchangeRateModel.MXN;
                case "MYR": return exchangeRateModel.MYR;
                case "MZN": return exchangeRateModel.MZN;
                case "NAD": return exchangeRateModel.NAD;
                case "NGN": return exchangeRateModel.NGN;
                case "NIO": return exchangeRateModel.NIO;
                case "NOK": return exchangeRateModel.NOK;
                case "NPR": return exchangeRateModel.NPR;
                case "NZD": return exchangeRateModel.NZD;
                case "OMR": return exchangeRateModel.OMR;
                case "PAB": return exchangeRateModel.PAB;
                case "PEN": return exchangeRateModel.PEN;
                case "PGK": return exchangeRateModel.PGK;
                case "PHP": return exchangeRateModel.PHP;
                case "PKR": return exchangeRateModel.PKR;
                case "PLN": return exchangeRateModel.PLN;
                case "PYG": return exchangeRateModel.PYG;
                case "QAR": return exchangeRateModel.QAR;
                case "RON": return exchangeRateModel.RON;
                case "RSD": return exchangeRateModel.RSD;
                case "RUB": return exchangeRateModel.RUB;
                case "RWF": return exchangeRateModel.RWF;
                case "SAR": return exchangeRateModel.SAR;
                case "SBD": return exchangeRateModel.SBD;
                case "SCR": return exchangeRateModel.SCR;
                case "SDG": return exchangeRateModel.SDG;
                case "SEK": return exchangeRateModel.SEK;
                case "SGD": return exchangeRateModel.SGD;
                case "SHP": return exchangeRateModel.SHP;
                case "SLL": return exchangeRateModel.SLL;
                case "SOS": return exchangeRateModel.SOS;
                case "SRD": return exchangeRateModel.SRD;
                case "STD": return exchangeRateModel.STD;
                case "SVC": return exchangeRateModel.SVC;
                case "SYP": return exchangeRateModel.SYP;
                case "SZL": return exchangeRateModel.SZL;
                case "THB": return exchangeRateModel.THB;
                case "TJS": return exchangeRateModel.TJS;
                case "TMT": return exchangeRateModel.TMT;
                case "TND": return exchangeRateModel.TND;
                case "TOP": return exchangeRateModel.TOP;
                case "TRY": return exchangeRateModel.TRY;
                case "TTD": return exchangeRateModel.TTD;
                case "TWD": return exchangeRateModel.TWD;
                case "TZS": return exchangeRateModel.TZS;
                case "UAH": return exchangeRateModel.UAH;
                case "UGX": return exchangeRateModel.UGX;
                case "USD": return exchangeRateModel.USD;
                case "UYU": return exchangeRateModel.UYU;
                case "UZS": return exchangeRateModel.UZS;
                case "VEF": return exchangeRateModel.VEF;
                case "VND": return exchangeRateModel.VND;
                case "VUV": return exchangeRateModel.VUV;
                case "WST": return exchangeRateModel.WST;
                case "XAF": return exchangeRateModel.XAF;
                case "XAG": return exchangeRateModel.XAG;
                case "XAU": return exchangeRateModel.XAU;
                case "XCD": return exchangeRateModel.XCD;
                case "XDR": return exchangeRateModel.XDR;
                case "XOF": return exchangeRateModel.XOF;
                case "XPF": return exchangeRateModel.XPF;
                case "YER": return exchangeRateModel.YER;
                case "ZAR": return exchangeRateModel.ZAR;
                case "ZMK": return exchangeRateModel.ZMK;
                case "ZMW": return exchangeRateModel.ZMW;
                case "ZWL": return exchangeRateModel.ZWL;


            }
            return 0;
        }

       public double Convert(double funds,string basecur,string symbol)
        {
            double convert_rate = getExchangeRate(basecur, symbol);

            if (convert_rate > 0)
            {
                return funds * convert_rate;
            }
            return 0;
        }
    }
}
