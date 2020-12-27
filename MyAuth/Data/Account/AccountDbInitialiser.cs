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
                new AppUser { UserName = "jack@gmail.com" ,Email = "jack@gmail.com", FullName = "Jack Ferguson"},
                new AppUser { UserName = "paul@gmail.com" ,Email = "paul@gmail.com", FullName = "Paul Mitchell"}
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Password1");
                // auto confirm email addresses for test users
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                await userManager.ConfirmEmailAsync(user, token);
            }

            await userManager.AddToRoleAsync(users[0], "Admin");
            await userManager.AddToRoleAsync(users[1], "Staff");
        }
    }
}
