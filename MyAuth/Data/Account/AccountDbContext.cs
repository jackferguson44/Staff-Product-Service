using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyAuth.Data.Account
{
    public class AccountDbContext : IdentityDbContext<AppUser>
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("account");

            builder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Name = "ManageProducts",
                    NormalizedName = "MANAGEPRODUCTS",
                    Descriptor = "manage Products"
                });

        }

    }
}
