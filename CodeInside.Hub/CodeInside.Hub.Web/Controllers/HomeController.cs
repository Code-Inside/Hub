using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CodeInside.Hub.Domain;
using CodeInside.Hub.Web.ViewModels;
using Newtonsoft.Json;

namespace CodeInside.Hub.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("https://codeinside.blob.core.windows.net/hub/data.json");
            var crawlerRun = JsonConvert.DeserializeObject<CrawlerRun>(json, Constants.CrawlerJsonSerializerSettings);

            var staticContent = Config.GetCodeInsideHubStaticData();

            var viewModel = new HubViewModel();
            viewModel.PersonsOfInterest = staticContent.PersonsOfInterest;
            viewModel.Name = staticContent.Name;
            viewModel.Description = staticContent.Description;
            viewModel.CrawlerRunOn = crawlerRun.RunOn;
            return View(viewModel);
        }

    }
}