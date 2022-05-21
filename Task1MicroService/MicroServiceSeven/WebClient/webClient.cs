using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MicroServiceSeven.WebClient
{
    public class webClient
    {


        private static webClient webClientInstance = null;

        private webClient() { }

        public static webClient WebClientInstance
        {
            get
            {
                if (webClientInstance == null)
                {
                    webClientInstance = new webClient();
                }

                return webClientInstance;
            }
        }

        public async Task<JsonDocument> Request(HttpRequestMessage requestMessage)
        {
            string responseValue;

            var client = new HttpClient();

            using (var response = await client.SendAsync(requestMessage))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                responseValue = body;
            }

            return JsonDocument.Parse(responseValue);
        }
    }
}
