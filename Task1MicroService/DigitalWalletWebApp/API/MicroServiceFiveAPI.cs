using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DigitalWalletWebApp.Models;
using DigitalWalletWebApp.WebClient;
using Newtonsoft.Json;

namespace DigitalWalletWebApp.API
{
    public class MicroServiceFiveAPI
    {
       private readonly webClient webclient = webClient.WebClientInstance;

        private static MicroServiceFiveAPI microServiceFiveAPI = null;

        private MicroServiceFiveAPI() { }


        public static MicroServiceFiveAPI microserviceFiveAPI
        {
            get
            {
                if(microServiceFiveAPI == null)
                {
                    microServiceFiveAPI = new MicroServiceFiveAPI();
                }
                return microServiceFiveAPI;
            }
        }


        private HttpRequestMessage GetRequestMessageThreeParameters(string hostEndpoint, string endpoint, string parameterOne, string parameterTwo, double parameterThree)
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskFiveCal/" + endpoint + "/" + parameterOne + "/" + parameterTwo+"/"+parameterThree),

            };

            return request;
        }

        public double currencyConversion( string hostEndpoint,string baseSymbol,string symbol,double amount)
        {

            var request = GetRequestMessageThreeParameters(hostEndpoint, "currencyConversion", baseSymbol, symbol, amount);


            JsonDocument jsonDocument = webclient.Request(request).Result;

            JsonElement root = jsonDocument.RootElement;


            string test = "";
            using (var stream = new MemoryStream())
            {
                Utf8JsonWriter writer = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true });
                root.WriteTo(writer);
                writer.Flush();
                test = Encoding.UTF8.GetString(stream.ToArray());
            }


            return JsonConvert.DeserializeObject<double>(test);



        }

        // parsing request
    }
}
