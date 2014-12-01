using System.Collections.Generic;

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