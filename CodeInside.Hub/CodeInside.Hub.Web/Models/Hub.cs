using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeInside.Hub.Web.Models
{
    public class Hub
    {
        public IList<PersonOfInterest> PersonsOfInterest { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<LinkOfInterest> LinksOfInterest { get; set; }
    }
}