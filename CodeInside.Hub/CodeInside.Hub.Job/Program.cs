using System.Configuration;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sloader.Crawler.Config;

namespace CodeInside.Hub.Job
{
    public class Program
    {
        public static void Main()
        {
            Trace.TraceInformation("Crawler Console App started.");

            var crawlerResult = InvokeCrawler().Result;
            Trace.TraceInformation("Crawler succeeded - now convert and write to BlobStorage!");

            var json = JsonConvert.SerializeObject(crawlerResult);

            var host = new JobHost();
            host.Call(typeof(Program).GetMethod("SaveToAzure"), new { json });
        }

        [NoAutomaticTrigger]
        public static void SaveToAzure([Blob(Sloader.Crawler.Config.Constants.SloaderAzureBlobContainer + "/" + Sloader.Crawler.Config.Constants.SloaderAzureBlobFileName)]TextWriter writer, string json)
        {
            writer.Write(json);

            Trace.TraceInformation("And... done.");
        }

        public static async Task<Sloader.Results.CrawlerRun> InvokeCrawler()
        {
            var config = await SloaderConfig.Load(
                    "https://raw.githubusercontent.com/Code-Inside/Hub/master/CodeInside.Hub/CodeInside.Hub.Web/App_Data/Sloader.yaml");

            var secrets = new SloaderSecrets();
            secrets.TwitterConsumerKey = ConfigurationManager.AppSettings[ConfigKeys.SecretTwitterConsumerKey];
            secrets.TwitterConsumerSecret = ConfigurationManager.AppSettings[ConfigKeys.SecretTwitterConsumerSecret];
            var runner = new Sloader.Crawler.SloaderRunner(config, secrets);

            return await runner.RunAllCrawlers();
        }
    }
}
