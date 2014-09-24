using System;
using System.Collections.Generic;
using CodeInside.Hub.Web.Models;

namespace CodeInside.Hub.Web.ViewModels
{
    public class HubViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<PersonOfInterest> PersonsOfInterest { get; set; }
        public DateTime CrawlerRunOn { get; set; }
    }


}