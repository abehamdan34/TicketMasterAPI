using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIGroupProject.Models;

namespace APIGroupProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IdentityFavoriteDbContext _context;

        public HomeController(IdentityFavoriteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RemoveFavoriteEvent(int id)
        {
            //may need to change the name Event to what Abe creates and sends to the database.
            Favorite findFavorite = _context.Favorite.Find(id); 
            if(findFavorite != null)
            {
                _context.Favorite.Remove(findFavorite);
                _context.SaveChanges();
            }

            return RedirectToAction("Index"); //redirect to the view page of favorites. 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
