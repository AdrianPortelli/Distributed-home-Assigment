using Google.Cloud.SecretManager.V1;
using MicroServiceSeven.Model;
using MicroServiceSeven.WebClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroServiceSeven.API
{
    public class twitterAPI
    {

        private readonly webClient webclient = webClient.WebClientInstance;


        private static twitterAPI twitterApi = null;

     
        private twitterAPI() {
            

        }

    

        public static twitterAPI twitterapi
        {
            get
            {
                if(twitterApi == null)
                {
                    twitterApi = new twitterAPI();
                }
                return twitterApi;
            }
        }
    
        private HttpRequestMessage GetRequestMessage()
        {
            SecretManagerServiceClient client = SecretManagerServiceClient.Create();
            // Build the resource name.
            SecretVersionName secretVersionName = new SecretVersionName("distributedprograming", "secrect-distributed-programing", "2");
            // Call the API.
            AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);
            // Convert the payload to a string. Payloads are bytes by default.
            String payload = result.Payload.Data.ToStringUtf8();
            dynamic jsonData = JsonConvert.DeserializeObject(payload);

            string bearerToken = Convert.ToString(jsonData["bearerToken"]);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.twitter.com/1.1/search/tweets.json?q=%23exchangerates&src=typed_query&f=top"),

            };
            request.Headers.Add("Authorization", "Bearer " + bearerToken);
            return request;
        }


        public twitterModel getRecentNews()
        {
            twitterModel twittermodel = new twitterModel();
            twittermodel.text = new List<string>();

            var request = GetRequestMessage();

            JsonDocument jsonDocument = webclient.Request(request).Result;

            //JsonElement root = jsonDocument.RootElement.GetProperty("statuses")[0].GetProperty("text");

            for(int i = 0; i < 15; i++)
            {
                JsonElement root = jsonDocument.RootElement.GetProperty("statuses")[i];

                if (root.TryGetProperty("text", out JsonElement text))
                {
                    twittermodel.text.Add(text.GetString());
                }

            }

            return twittermodel;
        }

    }
}
