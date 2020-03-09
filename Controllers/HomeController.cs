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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace APIGroupProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IdentityFavoriteDbContext _context;

       
        private readonly string APIKEYVARIABLE;
        public HomeController(IConfiguration configuration, IdentityFavoriteDbContext context)
        {
            _context = context;
            APIKEYVARIABLE = configuration.GetSection("APIKeys")["TicketMasterAPI"];
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayEvents()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://app.ticketmaster.com/discovery/v1/");
            var response = await client.GetAsync($"events.json?apikey={APIKEYVARIABLE}");


            var result = await response.Content.ReadAsAsync<Rootobject>();

            return View(result);
        }
        public IActionResult DisplayFavorite()
        {
            return View(_context.Favorite.ToList());
        }

        //    public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult RemoveFavoriteEvent(int id)
        {
            //may need to change the name Event to what Abe creates and sends to the database.
            Favorite findFavorite = _context.Favorite.Find(id);
            if (findFavorite != null)
            {
                _context.Favorite.Remove(findFavorite);
                _context.SaveChanges();
            }

            return RedirectToAction("DisplayFavorite"); //redirect to the view page of favorites. 
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

        public async Task<IActionResult> AddFavoriteEvent(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://app.ticketmaster.com/discovery/v1/");
            var response = await client.GetAsync($"events/{id}.json?apikey={APIKEYVARIABLE}");


            var result = await response.Content.ReadAsAsync<Event>();

            string venueAddress = result._embedded.venue[0].address.line1 + ", " + result._embedded.venue[0].address.line2;

            Favorite favorite = new Favorite(result.name, result.dates.start.dateTime, result._embedded.venue[0].name, venueAddress, result.eventUrl);

            favorite.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _context.Favorite.Add(favorite);
            _context.SaveChanges();


            return RedirectToAction("DisplayEvents");

        }
    }
}
