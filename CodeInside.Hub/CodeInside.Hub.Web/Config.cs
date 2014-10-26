using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeInside.Hub.Web.Models;

namespace CodeInside.Hub.Web
{
    public class Config
    {
        public static Models.Hub GetCodeInsideHubStaticData()
        {
            var hub = new Models.Hub();

            hub.Name = "Code Inside Hub";
            hub.Description = "Code-Inside is a development project focused on the Microsoft Dev Platform.";

            hub.LinksOfInterest = new List<LinkOfInterest>();
            hub.LinksOfInterest.Add(new LinkOfInterest { Href = new Uri("https://github.com/Code-Inside/"), Name = "GitHub" });
            hub.LinksOfInterest.Add(new LinkOfInterest { Href = new Uri("http://blog.codeinside.eu/"), Name = "Blog" });
            hub.LinksOfInterest.Add(new LinkOfInterest { Href = new Uri("http://twitter.com/codeinsideblog"), Name = "Twitter" });
            hub.LinksOfInterest.Add(new LinkOfInterest { Href = new Uri("https://www.facebook.com/CodeInsideBlog"), Name = "Facebook" });

            hub.PersonsOfInterest = new List<PersonOfInterest>();
            hub.PersonsOfInterest.Add(new PersonOfInterest
            {
                Name = "Robert Muehsig",
                Description = "Software Developer - from Dresden, Germany, now living in Switzerland. ASP.NET MVP & Web Geek.",
                Image = "~/Content/Images/rmuehsig.png",
                Links = new List<LinkOfInterest>
                    {
                        new LinkOfInterest { Href = new Uri("http://twitter.com/robert0muehsig"), Name = "Twitter"},
                        new LinkOfInterest { Href = new Uri("https://github.com/robertmuehsig"), Name = "GitHub"},
                        new LinkOfInterest { Href = new Uri("http://mvp.microsoft.com/en-us/mvp/Robert%20Muehsig-4020675"), Name = "ASP.NET MVP"},
                        new LinkOfInterest { Href = new Uri("http://www.xing.com/profile/Robert_Muehsig"), Name = "XING"},
                        new LinkOfInterest { Href = new Uri("https://speakerdeck.com/robertmuehsig"), Name = "SpeakerDeck"},
                        new LinkOfInterest { Href = new Uri("http://stackoverflow.com/users/602449/robert-muehsig"), Name = "Stack Overflow"},
                    }
            });
            hub.PersonsOfInterest.Add(new PersonOfInterest
            {
                Name = "Oliver Guhr",
                Description = "Software Developer - from Dresden, Germany. Co-Blog-Author.",
                Image = "~/Content/Images/oguhr.png",
                Links = new List<LinkOfInterest>
                    {
                        new LinkOfInterest { Href = new Uri("http://twitter.com/oliverguhr"), Name = "Twitter"},
                        new LinkOfInterest { Href = new Uri("https://github.com/oliverguhr"), Name = "GitHub"},
                        new LinkOfInterest { Href = new Uri("http://www.xing.com/profile/Oliver_Guhr"), Name = "XING"},
                    }
            });
            hub.PersonsOfInterest.Add(new PersonOfInterest
            {
                Name = "Antje Kilian",
                Description = "Geek Girl - from Dresden, Germany.",
                Image = "~/Content/Images/akilian.png",
                Links = new List<LinkOfInterest>
                    {
                        new LinkOfInterest { Href = new Uri("http://www.xing.com/profile/Antje_Kilian5"), Name = "XING"},
                    }
            });
            
            return hub;
        } 
    }
}