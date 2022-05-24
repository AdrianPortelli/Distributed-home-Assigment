using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.Models
{
    [FirestoreData]
    public class ExchangeRateModel
    {
        [FirestoreProperty]
        public double AED { get; set; }
        [FirestoreProperty]
        public double TRY { get; set; }
        [FirestoreProperty]
        public double AFN { get; set; }
        [FirestoreProperty]
        public double ALL { get; set; }
        [FirestoreProperty]
        public double AMD { get; set; }
        [FirestoreProperty]
        public double ANG { get; set; }
        [FirestoreProperty]
        public double AOA { get; set; }
        [FirestoreProperty]
        public double ARS { get; set; }
        [FirestoreProperty]
        public double AUD { get; set; }
        [FirestoreProperty]
        public double AWG { get; set; }
        [FirestoreProperty]
        public double AZN { get; set; }
        [FirestoreProperty]
        public double BAM { get; set; }
        [FirestoreProperty]
        public double BBD { get; set; }
        [FirestoreProperty]
        public double BDT { get; set; }
        [FirestoreProperty]
        public double BGN { get; set; }
        [FirestoreProperty]
        public double BHD { get; set; }
        [FirestoreProperty]
        public double BIF { get; set; }
        [FirestoreProperty]
        public double BMD { get; set; }
        [FirestoreProperty]
        public double BND { get; set; }
        [FirestoreProperty]
        public double BOB { get; set; }
        [FirestoreProperty]
        public double BRL { get; set; }
        [FirestoreProperty]
        public double BSD { get; set; }
        [FirestoreProperty]
        public double BTC { get; set; }
        [FirestoreProperty]
        public double BTN { get; set; }
        [FirestoreProperty]
        public double BWP { get; set; }
        [FirestoreProperty]
        public double BYN { get; set; }
        [FirestoreProperty]
        public double BYR { get; set; }
        [FirestoreProperty]
        public double BZD { get; set; }
        [FirestoreProperty]
        public double CAD { get; set; }
        [FirestoreProperty]
        public double CDF { get; set; }
        [FirestoreProperty]
        public double CHF { get; set; }
        [FirestoreProperty]
        public double CLF { get; set; }
        [FirestoreProperty]
        public double CLP { get; set; }
        [FirestoreProperty]
        public double CNY { get; set; }
        [FirestoreProperty]
        public double COP { get; set; }
        [FirestoreProperty]
        public double CRC { get; set; }
        [FirestoreProperty]
        public double CUC { get; set; }
        [FirestoreProperty]
        public double CUP { get; set; }
        [FirestoreProperty]
        public double CVE { get; set; }
        [FirestoreProperty]
        public double CZK { get; set; }
        [FirestoreProperty]
        public double DJF { get; set; }
        [FirestoreProperty]
        public double DKK { get; set; }
        [FirestoreProperty]
        public double DOP { get; set; }
        [FirestoreProperty]
        public double DZD { get; set; }
        [FirestoreProperty]
        public double EGP { get; set; }
        [FirestoreProperty]
        public double ERN { get; set; }
        [FirestoreProperty]
        public double ETB { get; set; }
        [FirestoreProperty]
        public double EUR { get; set; }
        [FirestoreProperty]
        public double FJD { get; set; }
        [FirestoreProperty]
        public double FKP { get; set; }
        [FirestoreProperty]
        public double GBP { get; set; }
        [FirestoreProperty]
        public double GEL { get; set; }
        [FirestoreProperty]
        public double GGP { get; set; }
        [FirestoreProperty]
        public double GHS { get; set; }
        [FirestoreProperty]
        public double GIP { get; set; }
        [FirestoreProperty]
        public double GMD { get; set; }
        [FirestoreProperty]
        public double GNF { get; set; }
        [FirestoreProperty]
        public double GTQ { get; set; }
        [FirestoreProperty]
        public double GYD { get; set; }
        [FirestoreProperty]
        public double HKD { get; set; }
        [FirestoreProperty]
        public double HNL { get; set; }
        [FirestoreProperty]
        public double HRK { get; set; }
        [FirestoreProperty]
        public double HTG { get; set; }
        [FirestoreProperty]
        public double HUF { get; set; }
        [FirestoreProperty]
        public double IDR { get; set; }
        [FirestoreProperty]
        public double ILS { get; set; }
        [FirestoreProperty]
        public double IMP { get; set; }
        [FirestoreProperty]
        public double INR { get; set; }
        [FirestoreProperty]
        public double IQD { get; set; }
        [FirestoreProperty]
        public double IRR { get; set; }
        [FirestoreProperty]
        public double ISK { get; set; }
        [FirestoreProperty]
        public double JEP { get; set; }
        [FirestoreProperty]
        public double JMD { get; set; }
        [FirestoreProperty]
        public double JOD { get; set; }
        [FirestoreProperty]
        public double JPY { get; set; }
        [FirestoreProperty]
        public double KES { get; set; }
        [FirestoreProperty]
        public double KGS { get; set; }
        [FirestoreProperty]
        public double KHR { get; set; }
        [FirestoreProperty]
        public double KMF { get; set; }
        [FirestoreProperty]
        public double KPW { get; set; }
        [FirestoreProperty]
        public double KRW { get; set; }
        [FirestoreProperty]
        public double KWD { get; set; }
        [FirestoreProperty]
        public double KYD { get; set; }
        [FirestoreProperty]
        public double KZT { get; set; }
        [FirestoreProperty]
        public double LAK { get; set; }
        [FirestoreProperty]
        public double LBP { get; set; }
        [FirestoreProperty]
        public double LKR { get; set; }
        [FirestoreProperty]
        public double LRD { get; set; }
        [FirestoreProperty]
        public double LSL { get; set; }
        [FirestoreProperty]
        public double LTL { get; set; }
        [FirestoreProperty]
        public double LVL { get; set; }
        [FirestoreProperty]
        public double LYD { get; set; }
        [FirestoreProperty]
        public double MAD { get; set; }
        [FirestoreProperty]
        public double MDL { get; set; }
        [FirestoreProperty]
        public double MGA { get; set; }
        [FirestoreProperty]
        public double MKD { get; set; }
        [FirestoreProperty]
        public double MMK { get; set; }
        [FirestoreProperty]
        public double MNT { get; set; }
        [FirestoreProperty]
        public double MOP { get; set; }
        [FirestoreProperty]
        public double MRO { get; set; }
        [FirestoreProperty]
        public double MUR { get; set; }
        [FirestoreProperty]
        public double MVR { get; set; }
        [FirestoreProperty]
        public double MWK { get; set; }
        [FirestoreProperty]
        public double MXN { get; set; }
        [FirestoreProperty]
        public double MYR { get; set; }
        [FirestoreProperty]
        public double MZN { get; set; }
        [FirestoreProperty]
        public double NAD { get; set; }
        [FirestoreProperty]
        public double NGN { get; set; }
        [FirestoreProperty]
        public double NIO { get; set; }
        [FirestoreProperty]
        public double NOK { get; set; }
        [FirestoreProperty]
        public double NPR { get; set; }
        [FirestoreProperty]
        public double NZD { get; set; }
        [FirestoreProperty]
        public double OMR { get; set; }
        [FirestoreProperty]
        public double PAB { get; set; }
        [FirestoreProperty]
        public double PEN { get; set; }
        [FirestoreProperty]
        public double PGK { get; set; }
        [FirestoreProperty]
        public double PHP { get; set; }
        [FirestoreProperty]
        public double PKR { get; set; }
        [FirestoreProperty]
        public double PLN { get; set; }
        [FirestoreProperty]
        public double PYG { get; set; }
        [FirestoreProperty]
        public double QAR { get; set; }
        [FirestoreProperty]
        public double RON { get; set; }
        [FirestoreProperty]
        public double RSD { get; set; }
        [FirestoreProperty]
        public double RUB { get; set; }
        [FirestoreProperty]
        public double RWF { get; set; }
        [FirestoreProperty]
        public double SAR { get; set; }
        [FirestoreProperty]
        public double SBD { get; set; }
        [FirestoreProperty]
        public double SCR { get; set; }
        [FirestoreProperty]
        public double SDG { get; set; }
        [FirestoreProperty]
        public double SEK { get; set; }
        [FirestoreProperty]
        public double SGD { get; set; }
        [FirestoreProperty]
        public double SHP { get; set; }
        [FirestoreProperty]
        public double SLL { get; set; }
        [FirestoreProperty]
        public double SOS { get; set; }
        [FirestoreProperty]
        public double SRD { get; set; }
        [FirestoreProperty]
        public double STD { get; set; }
        [FirestoreProperty]
        public double SVC { get; set; }
        [FirestoreProperty]
        public double SYP { get; set; }
        [FirestoreProperty]
        public double SZL { get; set; }
        [FirestoreProperty]
        public double THB { get; set; }
        [FirestoreProperty]
        public double TJS { get; set; }
        [FirestoreProperty]
        public double TMT { get; set; }
        [FirestoreProperty]
        public double TND { get; set; }
        [FirestoreProperty]
        public double TOP { get; set; }
        [FirestoreProperty]
        public double TTD { get; set; }
        [FirestoreProperty]
        public double TWD { get; set; }
        [FirestoreProperty]
        public double TZS { get; set; }
        [FirestoreProperty]
        public double UAH { get; set; }
        [FirestoreProperty]
        public double UGX { get; set; }
        [FirestoreProperty]
        public double USD { get; set; }
        [FirestoreProperty]
        public double UYU { get; set; }
        [FirestoreProperty]
        public double UZS { get; set; }
        [FirestoreProperty]
        public double VEF { get; set; }
        [FirestoreProperty]
        public double VND { get; set; }
        [FirestoreProperty]
        public double VUV { get; set; }
        [FirestoreProperty]
        public double WST { get; set; }
        [FirestoreProperty]
        public double XAF { get; set; }
        [FirestoreProperty]
        public double XAG { get; set; }
        [FirestoreProperty]
        public double XAU { get; set; }
        [FirestoreProperty]
        public double XCD { get; set; }
        [FirestoreProperty]
        public double XDR { get; set; }
        [FirestoreProperty]
        public double XOF { get; set; }
        [FirestoreProperty]
        public double XPF { get; set; }
        [FirestoreProperty]
        public double YER { get; set; }
        [FirestoreProperty]
        public double ZAR { get; set; }
        [FirestoreProperty]
        public double ZMK { get; set; }
        [FirestoreProperty]
        public double ZMW { get; set; }
        [FirestoreProperty]
        public double ZWL { get; set; }
    }
}
