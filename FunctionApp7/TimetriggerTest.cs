using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;

namespace FunctionApp7
{
    public static class TimetriggerTest
    {
        [FunctionName("TimetriggerTest")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, IQueryable<Task> inputTable,TraceWriter log)
        {
            foreach (var task in inputTable)
            {
                log.Info($"Processing task '{task.Name}' at: {DateTime.Now}");
            }
            log.Info($"Timer trigger executed at: {DateTime.Now}");
        }
        public class Task:TableEntity
        {
            public string Name { get; set; }
        }

    }
}
