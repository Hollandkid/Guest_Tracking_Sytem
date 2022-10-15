using Guest_Tracking_System.Data;
using Guest_Tracking_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Controllers
{
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;  

        public UserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            AdminVM modelVM = new AdminVM();
            var result = _dbContext.ApplicationUsers.Where(d=> d.Role == "Admin" || d.Role == "Staff").ToList() ?? new List<ApplicationUser>();

            int totalStaff = result.Where(d => d.Role == "Staff").Count();
            int totalAdmin = result.Where(d => d.Role == "Admin").Count();

            modelVM.Users = result;
            modelVM.totalAdmin = totalAdmin;
            modelVM.totalStaff = totalStaff;

            return View(modelVM);
        }


        public IActionResult login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginModel model, string returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Content("/Home/Index");

            if (ModelState.IsValid)
            {
                //var Admin = await _userManager.FindByEmailAsync(model.Email);
                //var isAdmin = await _userManager.IsInRoleAsync(Admin, "Admin");
               
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    //TempData["save"] = "You Logged In as an Admin";
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check Login credentials");
                    return View(model);
                }

            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Register(string returnUrl)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model,IFormFile image)
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
               
                //Add to Db
                var newUser = new ApplicationUser()
                {
                    Fullname = model.Fullname,
                    Email = model.Email,
                    UserName = model.Email,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNo,
                    Password = model.Password,
                    DateCreated = DateTime.Now,
                   Role = model.Role,
                   Image=model.Image
                };

                var chkuser = await _userManager.CreateAsync(newUser, model.Password);

                if (chkuser.Succeeded)
                {
                    if(model.Role == "Admin")
                    {
                        var result = await _userManager.AddToRoleAsync(newUser, "Admin");
                        if (result.Succeeded)
                        {
                            //TempData["save"] = "You have successfully Register as an Admin";
                        }
                    }
                    
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                foreach (var error in chkuser.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
