using System.Configuration;
using System.Net.Http;
using CodeInside.Hub.Domain;
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
using Constants = CodeInside.Hub.Domain.Constants;
using MasterCrawlerConfig = CodeInside.Hub.Domain.MasterCrawlerConfig;
using MasterCrawlerSecrets = CodeInside.Hub.Domain.MasterCrawlerSecrets;

namespace CodeInside.Hub.Job
{
    public class Program
    {
        public static void Main()
        {
            Trace.TraceInformation("Crawler Console App started.");

            var crawlerResult = InvokeLegacyCrawler().Result;
            Trace.TraceInformation("Crawler succeeded - now convert and write to BlobStorage!");

            var json = JsonConvert.SerializeObject(crawlerResult, Constants.CrawlerJsonSerializerSettings);

            var host = new JobHost();
            host.Call(typeof(Program).GetMethod("SaveToAzureLegacy"), new { json });
        }

        [NoAutomaticTrigger]
        public static void SaveToAzureLegacy([Blob("hub/data.json")]TextWriter writer, string json)
        {
            writer.Write(json);

            Trace.TraceInformation("And... done.");
        }

        [NoAutomaticTrigger]
        public static void SaveToAzure([Blob(Sloader.Crawler.Config.Constants.SloaderAzureBlobContainer + "/" + Sloader.Crawler.Config.Constants.SloaderAzureBlobFileName)]TextWriter writer, string json)
        {
            writer.Write(json);

            Trace.TraceInformation("And... done.");
        }

        public static async Task<Sloader.Results.CrawlerRun> InvokeCrawler()
        {
            var config = await Sloader.Crawler.Config.MasterCrawlerConfig.Load(
                    "https://raw.githubusercontent.com/Code-Inside/Hub/master/CodeInside.Hub/CodeInside.Hub.Web/App_Data/Sloader.yaml");

            var secrets = new Sloader.Crawler.Config.MasterCrawlerSecrets();
            secrets.TwitterConsumerKey = ConfigurationManager.AppSettings[ConfigKeys.SecretTwitterConsumerKey];
            secrets.TwitterConsumerSecret = ConfigurationManager.AppSettings[ConfigKeys.SecretTwitterConsumerSecret];
            var crawler = new Sloader.Crawler.MasterCrawler(config, secrets);

            return await crawler.RunAllCrawlers();
        }

        public static async Task<CrawlerRun> InvokeLegacyCrawler()
        {
            var client = new HttpClient();
#if DEBUG
            var configString = await client.GetStringAsync("https://raw.githubusercontent.com/Code-Inside/Hub/master/CrawlerConfig.json");
#else
            var configString = await client.GetStringAsync(ConfigurationManager.AppSettings["MasterCrawlerJsonConfigPath"]);
#endif
            var config = JsonConvert.DeserializeObject<MasterCrawlerConfig>(configString);

            var secrets = new MasterCrawlerSecrets();
            secrets.TwitterConsumerKey = ConfigurationManager.AppSettings["TwitteroAuthConsumerKey"];
            secrets.TwitterConsumerSecret = ConfigurationManager.AppSettings["TwitteroAuthConsumerSecret"];
            var crawler = new MasterCrawler(config, secrets);

            return await crawler.RunAllCrawlers();
        }
    }
}
