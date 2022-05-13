using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ControlsRouter
{
    public static class ControlsRouter
    {
        [FunctionName("ControlsRouter")]
        public static void Run([QueueTrigger("pipelinecontrols", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
