using Guest_Tracking_System.Data;
using Guest_Tracking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            GuestViewModel modelVM= new GuestViewModel();
            //This is to return the List of the Product from the Database...
            var result = _dbContext.Guests.ToList() ?? new List<GuestDeatils>();
            int noOfGuest = result.Where(d => d.DepartureTime == "").Count();

            modelVM.Guests = result;
            modelVM.totalInHouseGuest = noOfGuest;
            modelVM.totalGuest = result.Count();

            return View(modelVM);
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
