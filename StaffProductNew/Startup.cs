using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.EntityFrameworkCore;
using StaffProductNew.Data;
using StaffProductNew.Repository;
using Microsoft.AspNetCore.Http;
using StaffProductNew.Services.ProductService;
using Polly;
using System.IdentityModel.Tokens.Jwt;
using StaffProductNew.Services.CustomerOrderingService;

namespace StaffProductNew
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //[Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // do not use Microsoft claim mapping == stick with JWT names
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            if (_env.IsDevelopment())
            {
                services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://localhost:5099";
                        options.Audience = "StaffProductNew";
                    });

            }
            else
            {
                services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://staffproductservice.azurewebsites.net/";
                        options.Audience = "staff_product_api";
                    });
            }

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<StaffProductDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StaffProductConfig"), optionsBuilder =>
                {
                    optionsBuilder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null);
                }));

            services.AddHttpClient("RetryAndBreak")
                .AddTransientHttpErrorPolicy(p => p.OrResult(r => !r.IsSuccessStatusCode)
                    .WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry))))
                        .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)));


            services.AddRazorPages();
            if(_env.IsDevelopment())
            {
                services.AddScoped<IProductService, ProductService>();
                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<ICustomerProductService, CustomerProductService>();
            }
            else
            {
                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IProductService, ProductService>();
                services.AddScoped<ICustomerProductService, CustomerProductService>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // use auth middleware during HTTP requests
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          

        }
    }
}
