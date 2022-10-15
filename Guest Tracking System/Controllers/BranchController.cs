using Guest_Tracking_System.Data;
using Guest_Tracking_System.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Controllers
{
    public class BranchController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public BranchController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        BranchVM modelVM = new BranchVM();
        public IActionResult Index()
        {
            modelVM = new BranchVM();
            //This is to return the List of the Product from the Database...
            var result = _dbContext.Branches.ToList() ?? new List<Branch>();
            var staff = _dbContext.ApplicationUsers.Where(a=> a.Role == "Staff").ToList() ?? new List<ApplicationUser>();
            int noOfGuest = result.Count();

            modelVM.Branches = result;
            modelVM.Staffs = staff;
            modelVM.totalBranch = noOfGuest;

            return View(modelVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Branch model)
        {
            if (ModelState.IsValid)
            {

                await _dbContext.Branches.AddAsync(model);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(Branch model)
        {
            if (ModelState.IsValid)
            {
                var branchDetails = _dbContext.Branches.FirstOrDefault(a => a.BranchId == model.BranchId);
                
                branchDetails.BranchName = model.BranchName;
                branchDetails.BranchEmail = model.BranchEmail;
                branchDetails.BranchContact = model.BranchContact;
                branchDetails.BranchAddress = model.BranchAddress;

                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(int? Id)
        {

            if (Id> 0)
            {
                var branch = _dbContext.Branches.FirstOrDefault(d => d.BranchId == Id);
                _dbContext.Branches.Remove(branch);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AssignBranch(BranchVM model)
        {

            if (!model.staffEmail.Equals("") && model.branchId > 0)
            {
                var branch = _dbContext.Branches.FirstOrDefault(d => d.BranchId == model.branchId);
                var staff = _dbContext.ApplicationUsers.FirstOrDefault(d => d.Email == model.staffEmail.ToString() && d.Role == "Staff");

                if (branch != null && staff != null)
                {
                    branch.StaffEmail = staff.Email;
                    staff.BranchId = branch.BranchId;

                    _dbContext.Branches.Update(branch);
                    _dbContext.ApplicationUsers.Update(staff);
                    await _dbContext.SaveChangesAsync();
                    
                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Index");
        }
    }
}
