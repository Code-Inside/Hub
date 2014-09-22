using System.Collections.Generic;

namespace CodeInside.Hub.Domain.Twitter
{
    public class TwitterCrawlerResult : BaseCrawlerResult
    {
        public class Tweet
        {
            public string Content { get; set; }
        }

        public List<Tweet> Tweets { get; set; }
    }
}