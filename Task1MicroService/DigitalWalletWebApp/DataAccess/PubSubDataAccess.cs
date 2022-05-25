using DigitalWalletWebApp.Models;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWalletWebApp.DataAccess
{
    public class PubSubDataAccess : IPubSubRepo
    {
        public async Task<string> Publish_Info_LastestExchangeRates(PrefExchangeRates prefExchangeRates)
        {
       

            TopicName topic = new TopicName("distributedprograming", "microserivcelastestexchangerates");
            PublisherClient client = PublisherClient.Create(topic);

            string prefExchangeRates_serialized = JsonConvert.SerializeObject(prefExchangeRates);
            PubsubMessage message = new PubsubMessage
            {
                Data = ByteString.CopyFromUtf8(prefExchangeRates_serialized)
            };

            return await client.PublishAsync(message);
        }

        public async Task<string> Publish_Info_LastestTweets(User user)
        {
            TopicName topic = new TopicName("distributedprograming", "microserivcetwitter");
            PublisherClient client = PublisherClient.Create(topic);

            string user_serialized = JsonConvert.SerializeObject(user);
            PubsubMessage message = new PubsubMessage
            {
                Data = ByteString.CopyFromUtf8(user_serialized)
            };

            return await client.PublishAsync(message);
        }
    }
}
