using System.Collections.Generic;

namespace CodeInside.Hub.Web.Models
{
    public class PersonOfInterest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<LinkOfInterest> Links { get; set; }

        public string Image { get; set; }
    }
}