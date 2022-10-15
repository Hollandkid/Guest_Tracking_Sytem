using Guest_Tracking_System.Data;
using Guest_Tracking_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class GuestController : Controller
    {
        private ApplicationDbContext _dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;   //This is to get the Environment Service


        public GuestController(ApplicationDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;

        }
        public IActionResult Index()
        {
            GuestViewModel modelVM = new GuestViewModel();
            //This is to return the List of the Product from the Database...
            var result = _dbContext.Guests.ToList() ?? new List<GuestDeatils>();
            int noOfGuest = result.Where(d => d.DepartureTime == "").Count();

            modelVM.Guests = result;
            modelVM.totalInHouseGuest = noOfGuest;
            modelVM.totalGuest = result.Count();

            return View(modelVM);
        }

        public IActionResult GuestDeatils(int? Id)
        {
            GuestViewModel modelVM = new GuestViewModel();
            //This is to return the List of the Product from the Database...
            var result = _dbContext.Guests.FirstOrDefault(d=> d.Id == Id) ?? new GuestDeatils();

            return View(result);
        }


        public IActionResult NewGuest()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewGuest(GuestDeatils model,IFormFile image)
        {
            if (image != null)
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                await image.CopyToAsync(new FileStream(filePath, FileMode.Create));
                model.Image = "Images/" + image.FileName;
            }
            else
            {
                model.Image = "Images/profile.png";
            }
            if (ModelState.IsValid)
            {
               
                await _dbContext.Guests.AddAsync(model);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
