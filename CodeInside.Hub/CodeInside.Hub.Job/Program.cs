﻿using System.Configuration;
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

namespace CodeInside.Hub.Job
{
    class Program
    {
        static void Main()
        {
            Trace.TraceInformation("Crawler Console App started.");

            var crawlerResult = InvokeCrawler().Result;
            Trace.TraceInformation("Crawler succeeded - now convert and write to BlobStorage!");

            var json = JsonConvert.SerializeObject(crawlerResult, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });

            var host = new JobHost();
            host.Call(typeof(Program).GetMethod("SaveToAzure"), new { json });
        }

        public static void SaveToAzure([Blob("crawler/result.json")]TextWriter writer, string json)
        {
            writer.Write(json);

            Trace.TraceInformation("And... done.");
        }

        public static Task<CrawlerRun> InvokeCrawler()
        {
            var config = new MasterCrawlerConfig();
            config.Feeds = "http://blogin.codeinside.eu/feed;http://blog.codeinside.eu/feed;https://github.com/robertmuehsig.atom;https://github.com/oliverguhr.atom";
            config.TwitterHandles = "codeinsideblog;robert0muehsig;oliverguhr";
            config.TwitterConsumerKey = ConfigurationManager.AppSettings["TwitteroAuthConsumerKey"];
            config.TwitterConsumerSecret = ConfigurationManager.AppSettings["TwitteroAuthConsumerSecret"];
            var crawler = new MasterCrawler(config);

            return crawler.RunAllCrawlers();
        }
    }
}
