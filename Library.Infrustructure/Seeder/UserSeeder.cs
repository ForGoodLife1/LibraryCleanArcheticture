using Library.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrustructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<IdUser> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultuser = new IdUser()
                {
                    UserName = "admin",
                    Email = "admin@project.com",
                    FullName="Library",
                    Country="Egypt",
                    PhoneNumber="123456",
                    Address="Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await _userManager.CreateAsync(defaultuser, "M123_m");
                await _userManager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}
