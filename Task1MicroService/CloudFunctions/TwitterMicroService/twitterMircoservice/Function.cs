using CloudNative.CloudEvents;
using Google.Cloud.Functions.Framework;
using Google.Events.Protobuf.Cloud.PubSub.V1;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace twitterMircoservice
{
    [FirestoreData]
    public class twitterModel {
        [FirestoreProperty]
        public string tweet1 {get;set;}
        [FirestoreProperty]
        public string tweet2 {get;set;}
        [FirestoreProperty]
        public string tweet3 {get;set;}
        [FirestoreProperty]
        public string tweet4 {get;set;}
        [FirestoreProperty]
        public string tweet5 {get;set;}
        [FirestoreProperty]
        public string tweet6 {get;set;}
        [FirestoreProperty]
        public string tweet7 {get;set;}
        [FirestoreProperty]
        public string tweet8 {get;set;}

        [FirestoreProperty]
        public string tweet9 {get;set;}
        [FirestoreProperty]
        public string tweet10 {get;set;}
        [FirestoreProperty]
        public string tweet11 {get;set;}

        [FirestoreProperty]
        public string tweet12 {get;set;}

        [FirestoreProperty]
        public string tweet13 {get;set;}
        [FirestoreProperty]
        public string tweet14 {get;set;}
        [FirestoreProperty]
        public string tweet15 {get;set;}
    }

    
    public class jsonTwitterModel{
        
        public string text {get;set;}
    }
    /// <summary>
    /// A function that can be triggered in responses to changes in Google Cloud Storage.
    /// The type argument (StorageObjectData in this case) determines how the event payload is deserialized.
    /// The function must be deployed so that the trigger matches the expected payload type. (For example,
    /// deploying a function expecting a StorageObject payload will not work for a trigger that provides
    /// a FirestoreEvent.)
    /// </summary>
    public class Function : ICloudEventFunction<MessagePublishedData>
    {
        private readonly ILogger _logger;

        public Function(ILogger<Function> logger) =>
            _logger = logger;

        public  Task HandleAsync(CloudEvent cloudEvent, MessagePublishedData data, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Accessed Twitter MicroService Cloud function");
            string nameFromMessage = data.Message?.TextData;
          
            dynamic Obj = JsonConvert.DeserializeObject(nameFromMessage);

            string email = Obj.Email.ToString();


            RestClient client = new RestClient("http://microserviceseven-rlz3wkvhza-uc.a.run.app/api/v1/TaskSeven/getalltweets");//add twitter microservice here
            RestRequest request = new RestRequest();

            request.Method = Method.Get;
            var response = client.ExecuteAsync(request);
            _logger.LogInformation("Request to Twitter MicroService Has been Sent");

            response.Wait();

            _logger.LogInformation("Obtained Response : "+response.Result.Content);

            //List<string> parsedReponse = JsonConvert.DeserializeObject<List<string>>(response.Result.Content);
            dynamic jsonString =  JsonConvert.DeserializeObject(response.Result.Content);

            List<jsonTwitterModel> parsedReponse = JsonConvert.DeserializeObject<List<jsonTwitterModel>>(jsonString);
            
            _logger.LogInformation("Parsed Json");

            twitterModel twittermodel = new twitterModel();
            _logger.LogInformation("Instance of twitter model created");
            int count = 1;
            foreach(var item in parsedReponse){
                switch(count){
                    case 1:   twittermodel.tweet1 = item.text; break;
                    case 2:   twittermodel.tweet2 = item.text; break;
                    case 3:   twittermodel.tweet3 = item.text; break;
                    case 4:   twittermodel.tweet4 = item.text; break;
                    case 5:   twittermodel.tweet5 = item.text; break;
                    case 6:   twittermodel.tweet6 = item.text; break;
                    case 7:   twittermodel.tweet7 = item.text; break;
                    case 8:   twittermodel.tweet8 = item.text; break;
                    case 9: twittermodel.tweet9 = item.text; break;
                    case 10: twittermodel.tweet10 = item.text; break;
                    case 11:   twittermodel.tweet11 = item.text; break;
                    case 12:   twittermodel.tweet12 = item.text; break;
                    case 13:   twittermodel.tweet13 = item.text; break;
                    case 14:   twittermodel.tweet14 = item.text; break;
                    case 15:   twittermodel.tweet15 = item.text; break;
                
                }
                count++;

            }
             _logger.LogInformation("Twitter model populated");
            FirestoreDb db = FirestoreDb.Create("distributedprograming");
            DocumentReference docRef = db.Collection("users").Document(email).Collection("latestnews").Document("currentnews");
            docRef.SetAsync(twittermodel).Wait();
             _logger.LogInformation("Json Saved to Database");
            
            


            return Task.CompletedTask;
        }
    }
}
