using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace okko.uzapi.Contracts
{
    public interface ISeedDataService
    {
        Task<bool> SeedRoles(RoleManager<IdentityRole> roleManager);
        Task<bool> SeedUsers(UserManager<IdentityUser> userManager);
        Task<bool> isExistsRole(string id);
        Task<bool> isExistsUser(string id);
    }
}
