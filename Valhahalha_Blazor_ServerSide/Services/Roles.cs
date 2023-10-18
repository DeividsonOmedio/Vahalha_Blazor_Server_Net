using Microsoft.AspNetCore.Identity;
using Valhahalha_Blazor_ServerSide.Services.Interfaces;

namespace Valhahalha_Blazor_ServerSide.Services
{
    public class Roles : IRoles
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Roles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
             if(!await _roleManager.RoleExistsAsync("Dono"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Dono";
                role.NormalizedName = "DONO";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }
            
        }

        public async Task SeedUserAsync()
        {
            if(await _userManager.FindByEmailAsync("dono@dono.com") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "dono@dono.com";
                user.Email = "dono@dono.com";
                user.NormalizedUserName = "O DONO DO SITE";
                user.NormalizedEmail = "DONO@DONO.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "Dono@123");

                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Dono");
                }
            }
        }
    }
}
