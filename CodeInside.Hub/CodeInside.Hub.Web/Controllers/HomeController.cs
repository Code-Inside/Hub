using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeInside.Hub.Web.ViewModels;
using Newtonsoft.Json;
using Sloader.Crawler.Config;
using Sloader.Results;

namespace CodeInside.Hub.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("https://codeinside.blob.core.windows.net/sloader/data.json");

            JsonConverter[] converters = { new CrawlerResultConverter() };
            var crawlerRun = JsonConvert.DeserializeObject<CrawlerRun>(json, converters);

            var staticContent = Config.GetCodeInsideHubStaticData();

            var viewModel = new HubViewModel();
            viewModel.PersonsOfInterest = staticContent.PersonsOfInterest;
            viewModel.LinksOfInterest = staticContent.LinksOfInterest;
            viewModel.Name = staticContent.Name;
            viewModel.Description = staticContent.Description;
            
            var blog = crawlerRun.Results.SingleOrDefault(x => x.ResultType == KnownCrawlerResultType.Feed && x.ResultIdentifier == "http://blog.codeinside.eu/feed");
            if (blog != null)
            {
                var blogResult = (FeedCrawlerResult)blog;
                viewModel.Blog = blogResult.FeedItems.OrderByDescending(x => x.PublishedOn).Take(5).ToList();
            }

            var teamTwitter = crawlerRun.Results.Where(x => x.ResultType == KnownCrawlerResultType.TwitterTimeline &&
                                                      (x.ResultIdentifier == "robert0muehsig" ||
                                                       x.ResultIdentifier == "oliverguhr") ||
                                                       x.ResultIdentifier == "codeinsideblog").ToList();
            if (teamTwitter.Any())
            {
                viewModel.Twitter = new List<TwitterTimelineCrawlerResult.Tweet>();
                foreach (var baseCrawlerResult in teamTwitter)
                {
                    var twitterResults = (TwitterTimelineCrawlerResult)baseCrawlerResult;
                    viewModel.Twitter.AddRange(twitterResults.Tweets);
                }

                viewModel.Twitter = viewModel.Twitter.Take(5).ToList();
            }

            var github = crawlerRun.Results.Where(x => x.ResultType == KnownCrawlerResultType.Feed && 
                                                       (x.ResultIdentifier == "https://github.com/robertmuehsig.atom" || 
                                                        x.ResultIdentifier == "https://github.com/oliverguhr.atom")).ToList();
            if (github.Any())
            {
                viewModel.GitHub = new List<FeedCrawlerResult.FeedItem>();
                foreach (var baseCrawlerResult in github)
                {
                    var gitHubResults = (FeedCrawlerResult)baseCrawlerResult;
                    viewModel.GitHub.AddRange(gitHubResults.FeedItems);
                }

                viewModel.GitHub = viewModel.GitHub.OrderByDescending(x => x.PublishedOn).Take(5).ToList();
            }


            viewModel.CrawlerRunOn = crawlerRun.RunOn;


            return View(viewModel);
        }

    }
}