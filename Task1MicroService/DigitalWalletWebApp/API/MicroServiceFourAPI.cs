using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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




        

        // parsing request
    }
}
