using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Google.Cloud.SecretManager.V1;
using MicroServiceSix.Model;
using MicroServiceSix.WebClient;
using Newtonsoft.Json;

namespace MicroServiceSix.API
{
    public class ExchangeRateApi
    {

        private readonly string hostEndpoint = "https://api.apilayer.com/exchangerates_data";
        private readonly string lastestendpoint = "latest";



        private readonly webClient webclient = webClient.WebClientInstance;

        private static ExchangeRateApi exchangeRateApi = null;

        private ExchangeRateApi() { }


        public static ExchangeRateApi ExchangeRateAPI
        {
            get
            {
                if(exchangeRateApi == null)
                {
                    exchangeRateApi = new ExchangeRateApi();
                }
                return exchangeRateApi;
            }
        }



        private HttpRequestMessage GetRequestMessage(string endpoint, string basecur, string symbols)
        {

            SecretManagerServiceClient client = SecretManagerServiceClient.Create();
            // Build the resource name.
            SecretVersionName secretVersionName = new SecretVersionName("distributedprograming", "secrect-distributed-programing", "2");
            // Call the API.
            AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);
            // Convert the payload to a string. Payloads are bytes by default.
            String payload = result.Payload.Data.ToStringUtf8();
            dynamic jsonData = JsonConvert.DeserializeObject(payload);

            string api_key = Convert.ToString(jsonData["api_key_exchangerate"]);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/" + endpoint + "?" + "symbols=" + symbols + "&base=" + basecur),
                
            };

            request.Headers.Add("apikey", api_key);
            return request;
        }

        public ExchangeRateModel getCurrentRate(string basecur,string symbols)
        {
            ExchangeRateModel exchangeRateModel = new ExchangeRateModel();

            var request = GetRequestMessage(lastestendpoint, basecur, symbols);

            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement.GetProperty("rates");

            #region jsonparsing

            if (root.TryGetProperty("AED", out JsonElement AED))
            {
                exchangeRateModel.AED = AED.GetDouble();
            }
            if (root.TryGetProperty("TRY", out JsonElement TRY))
            {
                exchangeRateModel.TRY = TRY.GetDouble();
            }
            if (root.TryGetProperty("AFN", out JsonElement AFN))
            {
                exchangeRateModel.AFN = AFN.GetDouble();
            }
            if (root.TryGetProperty("ALL", out JsonElement ALL))
            {
                exchangeRateModel.ALL = ALL.GetDouble();
            }
            if (root.TryGetProperty("AMD", out JsonElement AMD))
            {
                exchangeRateModel.AMD = AMD.GetDouble();
            }
            if (root.TryGetProperty("ANG", out JsonElement ANG))
            {
                exchangeRateModel.ANG = ANG.GetDouble();
            }
            if (root.TryGetProperty("AOA", out JsonElement AOA))
            {
                exchangeRateModel.AOA = AOA.GetDouble();
            }
            if (root.TryGetProperty("ARS", out JsonElement ARS))
            {
                exchangeRateModel.ARS = ARS.GetDouble();
            }
            if (root.TryGetProperty("AUD", out JsonElement AUD))
            {
                exchangeRateModel.AUD = AUD.GetDouble();
            }
            if (root.TryGetProperty("AWG", out JsonElement AWG))
            {
                exchangeRateModel.AWG = AWG.GetDouble();
            }
            if (root.TryGetProperty("AZN", out JsonElement AZN))
            {
                exchangeRateModel.AZN = AZN.GetDouble();
            }
            if (root.TryGetProperty("BAM", out JsonElement BAM))
            {
                exchangeRateModel.BAM = BAM.GetDouble();
            }
            if (root.TryGetProperty("BBD", out JsonElement BBD))
            {
                exchangeRateModel.BBD = BBD.GetDouble();
            }
            if (root.TryGetProperty("BDT", out JsonElement BDT))
            {
                exchangeRateModel.BDT = BDT.GetDouble();
            }
            if (root.TryGetProperty("BGN", out JsonElement BGN))
            {
                exchangeRateModel.BGN = BGN.GetDouble();
            }
            if (root.TryGetProperty("BHD", out JsonElement BHD))
            {
                exchangeRateModel.BHD = BHD.GetDouble();
            }
            if (root.TryGetProperty("BIF", out JsonElement BIF))
            {
                exchangeRateModel.BIF = BIF.GetDouble();
            }
            if (root.TryGetProperty("BMD", out JsonElement BMD))
            {
                exchangeRateModel.BMD = BMD.GetDouble();
            }
            if (root.TryGetProperty("BND", out JsonElement BND))
            {
                exchangeRateModel.BND = BND.GetDouble();
            }
            if (root.TryGetProperty("BOB", out JsonElement BOB))
            {
                exchangeRateModel.BOB = BOB.GetDouble();
            }
            if (root.TryGetProperty("BRL", out JsonElement BRL))
            {
                exchangeRateModel.BRL = BRL.GetDouble();
            }
            if (root.TryGetProperty("BSD", out JsonElement BSD))
            {
                exchangeRateModel.BSD = BSD.GetDouble();
            }
            if (root.TryGetProperty("BTC", out JsonElement BTC))
            {
                exchangeRateModel.BTC = BTC.GetDouble();
            }
            if (root.TryGetProperty("BTN", out JsonElement BTN))
            { 
                exchangeRateModel.BTN = BTN.GetDouble();
            }
            if (root.TryGetProperty("BWP", out JsonElement BWP))
            {
                exchangeRateModel.BWP = BWP.GetDouble();
            }
            if (root.TryGetProperty("BYN", out JsonElement BYN))
            {
                exchangeRateModel.BYN = BYN.GetDouble();
            }
            if (root.TryGetProperty("BYR", out JsonElement BYR))
            {
                exchangeRateModel.BYR = BYR.GetDouble();
            }
            if (root.TryGetProperty("BZD", out JsonElement BZD))
            {
                exchangeRateModel.BZD = BZD.GetDouble();
            }
            if (root.TryGetProperty("CAD", out JsonElement CAD))
            {
                exchangeRateModel.CAD = CAD.GetDouble();
            }
            if (root.TryGetProperty("CDF", out JsonElement CDF))
            {
                exchangeRateModel.CDF = CDF.GetDouble();
            }
            if (root.TryGetProperty("CHF", out JsonElement CHF))
            {
                exchangeRateModel.CHF = CHF.GetDouble();
            }
            if (root.TryGetProperty("CLF", out JsonElement CLF))
            {
                exchangeRateModel.CLF = CLF.GetDouble();
            }
            if (root.TryGetProperty("CLP", out JsonElement CLP))
            {
                exchangeRateModel.CLP = CLP.GetDouble();
            }
            if (root.TryGetProperty("CNY", out JsonElement CNY))
            {
                exchangeRateModel.CNY = CNY.GetDouble();
            }
            if (root.TryGetProperty("COP", out JsonElement COP))
            {
                exchangeRateModel.COP = COP.GetDouble();
            }
            if (root.TryGetProperty("CRC", out JsonElement CRC))
            {
                exchangeRateModel.CRC = CRC.GetDouble();
            }
            if (root.TryGetProperty("CUC", out JsonElement CUC))
            {
                exchangeRateModel.CUC = CUC.GetDouble();
            }
            if (root.TryGetProperty("CUP", out JsonElement CUP))
            {
                exchangeRateModel.CUP = CUP.GetDouble();
            }
            if (root.TryGetProperty("CVE", out JsonElement CVE))
            {
                exchangeRateModel.CVE = CVE.GetDouble();
            }
            if (root.TryGetProperty("CZK", out JsonElement CZK))
            {
                exchangeRateModel.CZK = CZK.GetDouble();
            }
            if (root.TryGetProperty("DJF", out JsonElement DJF))
            {
                exchangeRateModel.DJF = DJF.GetDouble();
            }
            if (root.TryGetProperty("DKK", out JsonElement DKK))
            {
                exchangeRateModel.DKK = DKK.GetDouble();
            }
            if (root.TryGetProperty("DOP", out JsonElement DOP))
            {
                exchangeRateModel.DOP = DOP.GetDouble();
            }
            if (root.TryGetProperty("DZD", out JsonElement DZD))
            {
                exchangeRateModel.DZD = DZD.GetDouble();
            }
            if (root.TryGetProperty("EGP", out JsonElement EGP))
            {
                exchangeRateModel.EGP = AFN.GetDouble();
            }
            if (root.TryGetProperty("ERN", out JsonElement ERN))
            {
                exchangeRateModel.ERN = ERN.GetDouble();
            }
            if (root.TryGetProperty("ETB", out JsonElement ETB))
            {
                exchangeRateModel.ETB = ETB.GetDouble();
            }
            if (root.TryGetProperty("EUR", out JsonElement EUR))
            {
                exchangeRateModel.EUR = EUR.GetDouble();
            }
            if (root.TryGetProperty("FJD", out JsonElement FJD))
            {
                exchangeRateModel.FJD = FJD.GetDouble();
            }
            if (root.TryGetProperty("FKP", out JsonElement FKP))
            {
                exchangeRateModel.FKP = AFN.GetDouble();
            }
            if (root.TryGetProperty("GBP", out JsonElement GBP))
            {
                exchangeRateModel.GBP = GBP.GetDouble();
            }
            if (root.TryGetProperty("GEL", out JsonElement GEL))
            {
                exchangeRateModel.GEL = GEL.GetDouble();
            }
            if (root.TryGetProperty("GGP", out JsonElement GGP))
            {
                exchangeRateModel.GGP = GGP.GetDouble();
            }
            if (root.TryGetProperty("GHS", out JsonElement GHS))
            {
                exchangeRateModel.GHS = GHS.GetDouble();
            }
            if (root.TryGetProperty("GIP", out JsonElement GIP))
            {
                exchangeRateModel.GIP = GIP.GetDouble();
            }
            if (root.TryGetProperty("GMD", out JsonElement GMD))
            {
                exchangeRateModel.GMD = GMD.GetDouble();
            }
            if (root.TryGetProperty("GNF", out JsonElement GNF))
            {
                exchangeRateModel.GNF = GNF.GetDouble();
            }
            if (root.TryGetProperty("GTQ", out JsonElement GTQ))
            {
                exchangeRateModel.GTQ = GTQ.GetDouble();
            }
            if (root.TryGetProperty("GYD", out JsonElement GYD))
            {
                exchangeRateModel.GYD = GYD.GetDouble();
            }
            if (root.TryGetProperty("HKD", out JsonElement HKD))
            {
                exchangeRateModel.HKD = HKD.GetDouble();
            }
            if (root.TryGetProperty("HNL", out JsonElement HNL))
            {
                exchangeRateModel.HNL = HNL.GetDouble();
            }
            if (root.TryGetProperty("HRK", out JsonElement HRK))
            {
                exchangeRateModel.HRK = HRK.GetDouble();
            }
            if (root.TryGetProperty("HTG", out JsonElement HTG))
            {
                exchangeRateModel.HTG = HTG.GetDouble();
            }
            if (root.TryGetProperty("HUF", out JsonElement HUF))
            {
                exchangeRateModel.HUF = HUF.GetDouble();
            }
            if (root.TryGetProperty("IDR", out JsonElement IDR))
            {
                exchangeRateModel.IDR = IDR.GetDouble();
  }
            if (root.TryGetProperty("ILS", out JsonElement ILS))
            {
                exchangeRateModel.ILS = ILS.GetDouble();
            }
            if (root.TryGetProperty("IMP", out JsonElement IMP))
            {
                exchangeRateModel.IMP = IMP.GetDouble();
            }
            if (root.TryGetProperty("INR", out JsonElement INR))
            {
                exchangeRateModel.INR = INR.GetDouble();
            }
            if (root.TryGetProperty("IQD", out JsonElement IQD))
            {
                exchangeRateModel.IQD = IQD.GetDouble();
            }
            if (root.TryGetProperty("IRR", out JsonElement IRR))
            {
                exchangeRateModel.IRR = IRR.GetDouble();
            }
            if (root.TryGetProperty("ISK", out JsonElement ISK))
            {
                exchangeRateModel.ISK = ISK.GetDouble();
            }
            if (root.TryGetProperty("JEP", out JsonElement JEP))
            {
                exchangeRateModel.JEP = JEP.GetDouble();
            }
            if (root.TryGetProperty("JMD", out JsonElement JMD))
            {
                exchangeRateModel.JMD = JMD.GetDouble();
            }
            if (root.TryGetProperty("JOD", out JsonElement JOD))
            {
                exchangeRateModel.JOD = JOD.GetDouble();
            }
            if (root.TryGetProperty("JPY", out JsonElement JPY))
            {
                exchangeRateModel.JPY = JPY.GetDouble();
            }
            if (root.TryGetProperty("KES", out JsonElement KES))
            {
                exchangeRateModel.KES = KES.GetDouble();
            }
            if (root.TryGetProperty("KGS", out JsonElement KGS))
            {
                exchangeRateModel.KGS = KGS.GetDouble();
            }
            if (root.TryGetProperty("KHR", out JsonElement KHR))
            {
                exchangeRateModel.KHR = KHR.GetDouble();
            }
            if (root.TryGetProperty("KMF", out JsonElement KMF))
            {
                exchangeRateModel.KMF = KMF.GetDouble();
            }
            if (root.TryGetProperty("KPW", out JsonElement KPW))
            {
                exchangeRateModel.KPW = KPW.GetDouble();
            }
            if (root.TryGetProperty("KRW", out JsonElement KRW))
            {
                exchangeRateModel.KRW = KRW.GetDouble();
            }
            if (root.TryGetProperty("KWD", out JsonElement KWD))
            {
                exchangeRateModel.KWD = KWD.GetDouble();
            }
            if (root.TryGetProperty("KYD", out JsonElement KYD))
            {
                exchangeRateModel.KYD = KYD.GetDouble();
            }
            if (root.TryGetProperty("KZT", out JsonElement KZT))
            {
                exchangeRateModel.KZT = KZT.GetDouble();
            }
            if (root.TryGetProperty("LAK", out JsonElement LAK))
            {
                exchangeRateModel.LAK = LAK.GetDouble();
            }
            if (root.TryGetProperty("LBP", out JsonElement LBP))
            {
                exchangeRateModel.LBP = LBP.GetDouble();
            }
            if (root.TryGetProperty("LKR", out JsonElement LKR))
            {
                exchangeRateModel.LKR = LKR.GetDouble();
            }
            if (root.TryGetProperty("LRD", out JsonElement LRD))
            {
                exchangeRateModel.LRD = LRD.GetDouble();
            }
            if (root.TryGetProperty("LSL", out JsonElement LSL))
            {
                exchangeRateModel.LSL = LSL.GetDouble();
            }
            if (root.TryGetProperty("LTL", out JsonElement LTL))
            {
                exchangeRateModel.LTL = LTL.GetDouble();
            }
            if (root.TryGetProperty("LVL", out JsonElement LVL))
            {
                exchangeRateModel.LVL = LVL.GetDouble();
            }
            if (root.TryGetProperty("LYD", out JsonElement LYD))
            {
                exchangeRateModel.LYD = LYD.GetDouble();
            }
            if (root.TryGetProperty("MAD", out JsonElement MAD))
            {
                exchangeRateModel.MAD = MAD.GetDouble();
            }
            if (root.TryGetProperty("MDL", out JsonElement MDL))
            {
                exchangeRateModel.MDL = MDL.GetDouble();
            }
            if (root.TryGetProperty("MGA", out JsonElement MGA))
            {
                exchangeRateModel.MGA = MGA.GetDouble();
            }
            if (root.TryGetProperty("MKD", out JsonElement MKD))
            {
                exchangeRateModel.MKD = MKD.GetDouble();
            }
            if (root.TryGetProperty("MMK", out JsonElement MMK))
            {
                exchangeRateModel.MMK = MMK.GetDouble();
            }
            if (root.TryGetProperty("MNT", out JsonElement MNT))
            {
                exchangeRateModel.MNT = MNT.GetDouble();
            }
            if (root.TryGetProperty("MOP", out JsonElement MOP))
            {
                exchangeRateModel.MOP = MOP.GetDouble();
            }
            if (root.TryGetProperty("MRO", out JsonElement MRO))
            {
                exchangeRateModel.MRO = MRO.GetDouble();
            }
            if (root.TryGetProperty("MUR", out JsonElement MUR))
            {
                exchangeRateModel.MUR = MUR.GetDouble();
            }
            if (root.TryGetProperty("MVR", out JsonElement MVR))
            {
                exchangeRateModel.MVR = MVR.GetDouble();
            }
            if (root.TryGetProperty("MWK", out JsonElement MWK))
            {
                exchangeRateModel.MWK = MWK.GetDouble();
            }
            if (root.TryGetProperty("MXN", out JsonElement MXN))
            {
                exchangeRateModel.MXN = MXN.GetDouble();
            }
            if (root.TryGetProperty("MYR", out JsonElement MYR))
            {
                exchangeRateModel.MYR = MYR.GetDouble();
            }
            if (root.TryGetProperty("MZN", out JsonElement MZN))
            {
                exchangeRateModel.MZN = MZN.GetDouble();
            }
            if (root.TryGetProperty("NAD", out JsonElement NAD))
            {
                exchangeRateModel.NAD = NAD.GetDouble();
            }
            if (root.TryGetProperty("NGN", out JsonElement NGN))
            {
                exchangeRateModel.NGN = NGN.GetDouble();
            }
            if (root.TryGetProperty("NIO", out JsonElement NIO))
            {
                exchangeRateModel.NIO = NIO.GetDouble();
            }
            if (root.TryGetProperty("NOK", out JsonElement NOK))
            {
                exchangeRateModel.NOK = NOK.GetDouble();
            }
            if (root.TryGetProperty("NPR", out JsonElement NPR))
            {
                exchangeRateModel.NPR = NPR.GetDouble();
            }
            if (root.TryGetProperty("NZD", out JsonElement NZD))
            {
                exchangeRateModel.NZD = NZD.GetDouble();
            }
            if (root.TryGetProperty("PAB", out JsonElement PAB))
            {
                exchangeRateModel.PAB = PAB.GetDouble();
            }
            if (root.TryGetProperty("PEN", out JsonElement PEN))
            {
                exchangeRateModel.PEN = PEN.GetDouble();
            }
            if (root.TryGetProperty("PGK", out JsonElement PGK))
            {
                exchangeRateModel.PGK = PGK.GetDouble();
            }
            if (root.TryGetProperty("PHP", out JsonElement PHP))
            {
                exchangeRateModel.PHP = PHP.GetDouble();
            }
            if (root.TryGetProperty("PKR", out JsonElement PKR))
            {
                exchangeRateModel.PKR = PKR.GetDouble();
            }
            if (root.TryGetProperty("PLN", out JsonElement PLN))
            {
                exchangeRateModel.PLN = PLN.GetDouble();
            }
            if (root.TryGetProperty("PYG", out JsonElement PYG))
            {
                exchangeRateModel.PYG = PYG.GetDouble();
            }
            if (root.TryGetProperty("QAR", out JsonElement QAR))
            {
                exchangeRateModel.QAR = QAR.GetDouble();
            }
            if (root.TryGetProperty("RON", out JsonElement RON))
            {
                exchangeRateModel.RON = RON.GetDouble();
            }
            if (root.TryGetProperty("RSD", out JsonElement RSD))
            {
                exchangeRateModel.RSD = RSD.GetDouble();
            }
            if (root.TryGetProperty("RUB", out JsonElement RUB))
            {
                exchangeRateModel.RUB = RUB.GetDouble();
            }
            if (root.TryGetProperty("RWF", out JsonElement RWF))
            {
                exchangeRateModel.RWF = RWF.GetDouble();
            }
            if (root.TryGetProperty("SAR", out JsonElement SAR))
            {
                exchangeRateModel.SAR = SAR.GetDouble();
            }
            if (root.TryGetProperty("SBD", out JsonElement SBD))
            {
                exchangeRateModel.SBD = SBD.GetDouble();
            }
            if (root.TryGetProperty("SCR", out JsonElement SCR))
            {
                exchangeRateModel.SCR = SCR.GetDouble();
            }
            if (root.TryGetProperty("SDG", out JsonElement SDG))
            {
                exchangeRateModel.SDG = SDG.GetDouble();
            }
            if (root.TryGetProperty("SEK", out JsonElement SEK))
            {
                exchangeRateModel.SEK = SEK.GetDouble();
            }
            if (root.TryGetProperty("SGD", out JsonElement SGD))
            {
                exchangeRateModel.SGD = SGD.GetDouble();
            }
            if (root.TryGetProperty("SHP", out JsonElement SHP))
            {
                exchangeRateModel.SHP = AFN.GetDouble();
            }
            if (root.TryGetProperty("SLL", out JsonElement SLL))
            {
                exchangeRateModel.SLL = AFN.GetDouble();
            }
            if (root.TryGetProperty("SOS", out JsonElement SOS))
            {
                exchangeRateModel.SOS = AFN.GetDouble();
            }
            if (root.TryGetProperty("SRD", out JsonElement SRD))
            {
                exchangeRateModel.SRD = AFN.GetDouble();
            }
            if (root.TryGetProperty("STD", out JsonElement STD))
            {
                exchangeRateModel.STD = AFN.GetDouble();
            }
            if (root.TryGetProperty("SVC", out JsonElement SVC))
            {
                exchangeRateModel.SVC = AFN.GetDouble();
            }
            if (root.TryGetProperty("SYP", out JsonElement SYP))
            {
                exchangeRateModel.SYP = AFN.GetDouble();
            }
            if (root.TryGetProperty("SZL", out JsonElement SZL))
            {
                exchangeRateModel.SZL = AFN.GetDouble();
            }
            if (root.TryGetProperty("THB", out JsonElement THB))
            {
                exchangeRateModel.THB = AFN.GetDouble();
            }
            if (root.TryGetProperty("TJS", out JsonElement TJS))
            {
                exchangeRateModel.TJS = AFN.GetDouble();
            }
            if (root.TryGetProperty("TMT", out JsonElement TMT))
            {
                exchangeRateModel.TMT = AFN.GetDouble();
            }
            if (root.TryGetProperty("TND", out JsonElement TND))
            {
                exchangeRateModel.TND = AFN.GetDouble();
            }
            if (root.TryGetProperty("TOP", out JsonElement TOP))
            {
                exchangeRateModel.TOP = AFN.GetDouble();
            }
            if (root.TryGetProperty("TTD", out JsonElement TTD))
            {
                exchangeRateModel.TTD = AFN.GetDouble();
            }
            if (root.TryGetProperty("TWD", out JsonElement TWD))
            {
                exchangeRateModel.TWD = AFN.GetDouble();
            }
            if (root.TryGetProperty("TZS", out JsonElement TZS))
            {
                exchangeRateModel.TZS = AFN.GetDouble();
            }
            if (root.TryGetProperty("UAH", out JsonElement UAH))
            {
                exchangeRateModel.UAH = AFN.GetDouble();
            }
            if (root.TryGetProperty("UGX", out JsonElement UGX))
            {
                exchangeRateModel.UGX = AFN.GetDouble();
            }
            if (root.TryGetProperty("USD", out JsonElement USD))
            {
                exchangeRateModel.USD = AFN.GetDouble();
            }
            if (root.TryGetProperty("UYU", out JsonElement UYU))
            {
                exchangeRateModel.UYU = UYU.GetDouble();
            }
            if (root.TryGetProperty("UZS", out JsonElement UZS))
            {
                exchangeRateModel.UZS = UZS.GetDouble();
            }
            if (root.TryGetProperty("VEF", out JsonElement VEF))
            {
                exchangeRateModel.VEF = VEF.GetDouble();
            }
            if (root.TryGetProperty("VND", out JsonElement VND))
            {
                exchangeRateModel.VND = VND.GetDouble();
            }
            if (root.TryGetProperty("VUV", out JsonElement VUV))
            {
                exchangeRateModel.VUV = VUV.GetDouble();
            }
            if (root.TryGetProperty("WST", out JsonElement WST))
            {
                exchangeRateModel.WST = WST.GetDouble();
            }
            if (root.TryGetProperty("XAF", out JsonElement XAF))
            {
                exchangeRateModel.XAF = XAF.GetDouble();
            }
            if (root.TryGetProperty("XAG", out JsonElement XAG))
            {
                exchangeRateModel.XAG = XAG.GetDouble();
            }
            if (root.TryGetProperty("XAU", out JsonElement XAU))
            {
                exchangeRateModel.XAU = XAU.GetDouble();
            }
            if (root.TryGetProperty("XCD", out JsonElement XCD))
            {
                exchangeRateModel.XCD = XCD.GetDouble();
            }
            if (root.TryGetProperty("XDR", out JsonElement XDR))
            {
                exchangeRateModel.XDR = XDR.GetDouble();
            }
            if (root.TryGetProperty("XOF", out JsonElement XOF))
            {
                exchangeRateModel.XOF = XOF.GetDouble();
            }
            if (root.TryGetProperty("XPF", out JsonElement XPF))
            {
                exchangeRateModel.XPF = XPF.GetDouble();
            }
            if (root.TryGetProperty("YER", out JsonElement YER))
            {
                exchangeRateModel.YER = YER.GetDouble();
            }
            if (root.TryGetProperty("ZAR", out JsonElement ZAR))
            {
                exchangeRateModel.ZAR = ZAR.GetDouble();
            }
            if (root.TryGetProperty("ZMK", out JsonElement ZMK))
            {
                exchangeRateModel.ZMK = ZMK.GetDouble();
            }
            if (root.TryGetProperty("ZMW", out JsonElement ZMW))
            {
                exchangeRateModel.ZMW = ZMW.GetDouble();
            }
            if (root.TryGetProperty("ZWL", out JsonElement ZWL))
            {
                exchangeRateModel.ZWL = ZWL.GetDouble();
            }
            #endregion

            return exchangeRateModel;
        }
    }
}
