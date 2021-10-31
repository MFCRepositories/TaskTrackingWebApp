﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskTracking.Entities.Concrete;

namespace TaskTracking.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("fatih");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Fatih ",
                    Surname = "Ceylan",
                    UserName = "Admin",
                    Email = "mfatihceylan87@gmail.com"
                };
                await userManager.CreateAsync(user, "123456");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
