using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISampleDate sampleDate;
        private readonly IBinParser binParser;

        public HomeController(ILogger<HomeController> logger, ISampleDate  sampleDate, IBinParser binParser)
        {
            _logger = logger;
            this.sampleDate = sampleDate;
            this.binParser = binParser;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new SamplesViewModel();
            var samplesList = await this.sampleDate.GetSamples();
            viewModel.EventList = samplesList;
            viewModel.SampledList = binParser.GetMeanPerBin(new TimeSpan(0, 5, 0), samplesList);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
