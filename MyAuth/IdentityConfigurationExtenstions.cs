using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace MyAuth
{
    public static class IdentityConfigurationExtenstions
    {
        public static IEnumerable<IdentityResource> GetIdentityResources(this IConfiguration configuration)
        {
            return new[]
            {
                new IdentityResources.OpenId(),

                new IdentityResources.Profile(),

                new IdentityResource(name: "roles",
                                     displayName: "ThAmCo Application Roles",
                                     userClaims: new [] { "role" })

            };
        }

        public static IEnumerable<ApiResource> GetIdentityApis(this IConfiguration configuration)
        {
            return new[]
            {
               // new ApiResource("thamco_account_api", "ThAmCo Account Management"),

                new ApiResource("staff_product_api, Staff Product Service")
                {
                    UserClaims = {"name", "role"}
                }
            };
        }

        public static IEnumerable<Client> GetIdentityClients(this IConfiguration configuration)
        {
            return new[]
            {
                new Client
                {
                    ClientId = "staff_product_api",
                    ClientName = "Staff Product Service",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("Password1!".Sha256())
                    },

                    //AllowedScopes =
                    //{
                    //    "thamco_account_api"
                    //},

                    RequireConsent = false
                }


            };
        }
    }
}
