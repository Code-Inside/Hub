using System;
using System.Collections.Generic;
using CodeInside.Hub.Domain;
using CodeInside.Hub.Domain.Feed;
using CodeInside.Hub.Domain.Twitter;
using CodeInside.Hub.Web.Models;

namespace CodeInside.Hub.Web.ViewModels
{
    public class HubViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<LinkOfInterest> LinksOfInterest { get; set; }
        public IList<PersonOfInterest> PersonsOfInterest { get; set; }
        public DateTime CrawlerRunOn { get; set; }
        public List<FeedCrawlerResult.FeedItem> Blog { get; set; }
        public List<FeedCrawlerResult.FeedItem> GitHub { get; set; }
        public List<TwitterCrawlerResult.Tweet> Twitter { get; set; }
    }


}