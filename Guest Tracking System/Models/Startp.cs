using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Guest_Tracking_System.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guest_Tracking_System.Models
{
    public class Startp
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var roleContext = serviceProvider.GetService<RoleManager<IdentityRole>>();

            string[] roles = new string[] { "Admin", "User" };

            foreach (string role in roles)
            {
                var isExist = await roleContext.RoleExistsAsync(role);
                if (!isExist)
                {
                    var crole = new IdentityRole() { Name = role };
                    var result = await roleContext.CreateAsync(crole);
                    if (!result.Succeeded)
                    {
                        Console.WriteLine("Admin Role not created");
                    }
                }

            }


            var user = new ApplicationUser
            {
                Fullname = "Admin Admin",
                Email = "Admin@admin.com",
                NormalizedEmail = "Admin@admin.com",
                UserName = "Admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                Password = "Admin",
                Role = "Admin",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Admin");
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                var result = userStore.CreateAsync(user);
            }

            await AssignRoles(serviceProvider, user.Email, roles);

            await context.SaveChangesAsync();
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
    }
}
