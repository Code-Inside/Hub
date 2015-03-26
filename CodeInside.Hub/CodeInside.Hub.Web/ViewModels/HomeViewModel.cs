using System;
using System.Collections.Generic;
using CodeInside.Hub.Web.Models;
using Sloader.Results;

namespace CodeInside.Hub.Web.ViewModels
{
    public class HubViewModel
    {
        public HubViewModel()
        {
            Blog = new List<FeedCrawlerResult.FeedItem>();
            GitHub = new List<FeedCrawlerResult.FeedItem>();
            Twitter = new List<TwitterTimelineCrawlerResult.Tweet>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<LinkOfInterest> LinksOfInterest { get; set; }
        public IList<PersonOfInterest> PersonsOfInterest { get; set; }
        public DateTime CrawlerRunOn { get; set; }
        public List<FeedCrawlerResult.FeedItem> Blog { get; set; }
        public List<FeedCrawlerResult.FeedItem> GitHub { get; set; }
        public List<TwitterTimelineCrawlerResult.Tweet> Twitter { get; set; }
    }


}