using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using okko.uzapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Data
{
    public static class SeedData
    {
        private static ApplicationDBContext _db;
        public async static Task Seed(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);          
        }
        private async static Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            if(await userManager.FindByEmailAsync("admin@bookstore.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                };
                var result = await userManager.CreateAsync(user, "6dmin");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, SD.AdminRole);
                }
            }
            if (await userManager.FindByEmailAsync("manager@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "manager",
                    Email = "manager@gmail.com"
                };
                var result = await userManager.CreateAsync(user, "m6n6ger");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, SD.ManagerRole);
                }
            }
            if (await userManager.FindByEmailAsync("marketing@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "marketing",
                    Email = "marketing@gmail.com"
                };
                var result = await userManager.CreateAsync(user, "m6rket2ng");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, SD.MarketingRole);
                }
            }
            if (await userManager.FindByEmailAsync("credit@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "credit",
                    Email = "credid@gmail.com"
                };
                var result = await userManager.CreateAsync(user, "credit246");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, SD.CreditRole);
                }
            }
        }

        private async static Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {         
            roleManager.CreateAsync(new IdentityRole(SD.ManagerRole)).GetAwaiter().GetResult();
            if (!await roleManager.RoleExistsAsync(SD.AdminRole))
            {
                var role = new IdentityRole
                {
                    Name = SD.AdminRole
                };
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync(SD.ManagerRole))
            {
                var role = new IdentityRole
                {
                    Name = SD.ManagerRole
                };
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync(SD.MarketingRole))
            {
                var role = new IdentityRole
                {
                    Name = SD.MarketingRole
                };
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync(SD.CreditRole))
            {
                var role = new IdentityRole
                {
                    Name = SD.CreditRole
                };
                await roleManager.CreateAsync(role);
            }
        }
    }
}
