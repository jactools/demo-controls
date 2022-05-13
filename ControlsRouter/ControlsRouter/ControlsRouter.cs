using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventGrid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;

namespace jactools.demos.ControlsRouter
{
    public static class ControlsRouter
    {
        [FunctionName("ControlsRouter")]
        public static void Run([QueueTrigger("pipelinecontrols", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            JObject json = JObject.Parse(myQueueItem);
            foreach (var e in json)
            {
//                log.LogInformation($"{e}");
                if (e.Key == "subject")
                {
                    log.LogInformation($"subject value: {e.Value}");
                    int pFrom = e.Value.ToString().IndexOf("/containers/") + "/containers/".Length;
                    int pTo = e.Value.ToString().LastIndexOf("/blobs/");
                    String provider = e.Value.ToString().Substring(pFrom, pTo - pFrom);
                    //Forward event to the provider topic

                    log.LogInformation($"Provider={provider}");
                }
            }


            //"subject":"/blobServices/default/containers/provider1/blobs/controls/pipeline/expectation/20220513-dataobjectA-expectations.json","eventType":"Microsoft.Storage.BlobCreated","id":"c59d99f8-401f-0015-4200-678a8506f916"

            //log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }

}
