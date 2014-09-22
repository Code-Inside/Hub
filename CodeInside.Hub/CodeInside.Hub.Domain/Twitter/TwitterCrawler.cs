﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CodeInside.Hub.Domain.Twitter
{
    public class TwitterCrawler : ICrawler<List<TwitterCrawlerResult>>
    {
        public TwitterCrawler()
        {
            Config = new TwitterCrawlerConfig();
        }

        public TwitterCrawlerConfig Config { get; set; }
        public List<TwitterCrawlerResult> DoWork()
        {
            var results = new List<TwitterCrawlerResult>();

            
            var oauth = GetTwitterAccessToken(Config.ConsumerKey, Config.ConsumerSecret).Result;


            foreach (var handle in Config.Handles.Split(';'))
            {
                var result = new TwitterCrawlerResult();

                result.Key = handle;
                result.Type = KnownCrawler.Twitter;
                result.Tweets = new List<TwitterCrawlerResult.Tweet>();

                var twitterResult = GetTwitterTimeline(oauth, handle).Result;
                result.Tweets.AddRange(new List<TwitterCrawlerResult.Tweet>(twitterResult));

                results.Add(result);
            }

            return results;
        }

        public Task<List<TwitterCrawlerResult>> DoWorkAsync()
        {
            throw new NotImplementedException();
        }

        private static async Task<string> GetTwitterAccessToken(string consumerKey, string consumerSecret)
        {
            var client = new HttpClient();

            var authHeaderParameter = Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(consumerKey) + ":" +
                                                             Uri.EscapeDataString((consumerSecret))));

            var postBody = "grant_type=client_credentials";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderParameter);

            var response = await client.PostAsync("https://api.twitter.com/oauth2/token", new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded"));

            response.EnsureSuccessStatusCode();

            string oauthtoken = await response.Content.ReadAsStringAsync();
            var jToken = JToken.Parse(oauthtoken);
            var accessToken = jToken.SelectToken("access_token");

            return accessToken.Value<string>();
        }

        private static async Task<List<TwitterCrawlerResult.Tweet>> GetTwitterTimeline(string oauthToken, string screenname)
        {
            Trace.TraceInformation("GetTwitterTimeline invoked with screenname:" + screenname);

            var client = new HttpClient();

            var timelineFormat = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&include_rts=1&exclude_replies=1&count=5";
            var timelineUrl = string.Format(timelineFormat, screenname);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oauthToken);
            var response = await client.GetAsync(timelineUrl);

            response.EnsureSuccessStatusCode();

            string timeline = await response.Content.ReadAsStringAsync();

            var jTimeline = JArray.Parse(timeline);
            var textNodes = jTimeline.Children()["text"];

            var textValues = textNodes.Values<string>();

            var resultForThisHandle = new List<TwitterCrawlerResult.Tweet>();

            foreach (var value in textValues)
            {
                resultForThisHandle.Add(new TwitterCrawlerResult.Tweet { Content = value });
            }


            return resultForThisHandle;
        }
    }
}