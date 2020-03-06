using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIGroupProject.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace APIGroupProject.Controllers
{
    public class HomeController : Controller
    {


        private readonly string APIKEYVARIABLE;
        public HomeController(IConfiguration configuration)
        {
            APIKEYVARIABLE = configuration.GetSection("APIKeys")["TicketMasterAPI"];
        }
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://app.ticketmaster.com/discovery/v1/");
            var response = await client.GetAsync($"events.json?apikey={APIKEYVARIABLE}");


            var result = await response.Content.ReadAsAsync<Rootobject>();

            return View(result);
        }

        //    public IActionResult Index()
        //{
        //    return View();
        //}

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
