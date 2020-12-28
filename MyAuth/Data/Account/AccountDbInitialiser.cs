using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MyAuth.Data.Account
{
    public class AccountDbInitialiser
    {
        public static async Task SeedTestData(AccountDbContext context, IServiceProvider services)
        {
            // exit early if any existing data is present
            if(context.Users.Any())
            {
                return;
            }

            var userManager = services.GetRequiredService<UserManager<AppUser>>();

            AppUser[] users =
            {
                new AppUser { UserName = "paul@example.com" ,Email = "paul@example.com", FullName = "Jack Ferguson"},
                new AppUser { UserName = "paul@example.com" ,Email = "paul@example.com", FullName = "Paul Mitchell"},
                new AppUser { UserName = "chris@example.com", Email = "chris@example.com", FullName = "Chris Burrell"},
                new AppUser { UserName = "carter@example.com", Email = "carter@example.com", FullName = "Carter Ridgeway"},
                new AppUser { UserName = "karl@example.com", Email = "karl@example.com", FullName = "Karl Hall"}
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Password1!");
                // auto confirm email addresses for test users
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                await userManager.ConfirmEmailAsync(user, token);
            }

            await userManager.AddToRoleAsync(users[0], "Customer");
            await userManager.AddToRoleAsync(users[1], "Customer");
            await userManager.AddToRoleAsync(users[2], "Customer");
            await userManager.AddToRoleAsync(users[3], "Customer");
            await userManager.AddToRoleAsync(users[4], "Customer");
        }
    }
}
