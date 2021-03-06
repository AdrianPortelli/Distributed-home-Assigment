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
    public class MicroServiceFourAPI
    {
       private readonly webClient webclient = webClient.WebClientInstance;

        private static MicroServiceFourAPI microServiceFourAPI = null;

        private MicroServiceFourAPI() { }


        public static MicroServiceFourAPI microserviceFourAPI
        {
            get
            {
                if(microServiceFourAPI == null)
                {
                    microServiceFourAPI = new MicroServiceFourAPI();
                }
                return microServiceFourAPI;
            }
        }



        private HttpRequestMessage GetRequestMessageOneParameter(string hostEndpoint, string endpoint, string parameterOne) { 

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskFour/"+ endpoint + "/"+ parameterOne),
                
            };

            return request;
        }

        private HttpRequestMessage GetRequestMessageTwoParameters(string hostEndpoint, string endpoint, string parameterOne,string parameterTwo)
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskFour/" + endpoint + "/" + parameterOne+"/"+parameterTwo),

            };

            return request;
        }

        private HttpRequestMessage GetRequestMessageThreeParameters(string hostEndpoint, string endpoint, string parameterOne, string parameterTwo,string parameterThree)
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(hostEndpoint + "/api/v1/TaskFour/" + endpoint + "/" + parameterOne + "/" + parameterTwo+"/"+parameterThree),

            };

            return request;
        }

        public List<Transactions> getAllTranscations(string hostEndpoint, string email)
        {

            var request = GetRequestMessageOneParameter(hostEndpoint, "getalltranscations", email);

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


            return JsonConvert.DeserializeObject<List<Transactions>>(test);
        }


        public List<Transactions> getTranscationsByAccountno(string hostEndpoint, string email, string accountNo)
        {
            var request = GetRequestMessageTwoParameters(hostEndpoint, "gettranscationsbyaccoutno", email,accountNo);


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


            return JsonConvert.DeserializeObject<List<Transactions>>(test);
        }

        public List<Transactions> getTranscationsByRange(string hostEndpoint, string accountNo,string start,string end)
        {
            var request = GetRequestMessageThreeParameters(hostEndpoint, "gettranscationsbyaccoutno",accountNo,start,end);


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


            return JsonConvert.DeserializeObject<List<Transactions>>(test);
        }


        // parsing request
    }
}
