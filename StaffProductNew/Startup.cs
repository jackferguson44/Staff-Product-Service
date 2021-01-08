using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffProductNew.Data;
using StaffProductNew.Services;
using StaffProductNew.Services.CustomerStockService;
using StaffProductNew.Repository;
using Microsoft.AspNetCore.Http;
using StaffProductNew.Services.ProductService;
using Polly;
using System.IdentityModel.Tokens.Jwt;
//using Jw
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
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IProductRepository, ProductRepository>();

            // do not use Microsoft claim mapping == stick with JWT names
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            //if(_env.IsDevelopment())
            //{
            //    services.AddAuthentication("Bearer")
            //        .AddJwtBearer("Bearer", options =>
            //        {
            //            options.Authority = "https://localhost:5099";
            //            options.Audience = "StaffProductNew";
            //        });

            //}
            //else
            //{
            //    services.AddAuthentication("Bearer")
            //        .AddJwtBearer("Bearer", options =>
            //        {
            //            options.Authority = "https://staffproductservice.azurewebsites.net/";
            //            options.Audience = "staff_product_api";
            //        });
            //}

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
           //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            if(_env.IsDevelopment())
            {
                services.AddScoped<IProductService, ProductService>();
                services.AddScoped<IProductRepository, ProductRepository>();
                //services.AddScoped<IStockService, StockService>();
                services.AddSingleton<IStockService, FakeStockService>();
                //services.AddSingleton<IProductRepository, MockProductRespository>();


                //services.AddScoped<IProductRepository, ProductRepository>();
                //services.AddScoped<IProductService, ProductService>();
            }
            else
            {
                //services.AddScoped<IProductService, MockProductRespository>

                //services.AddScoped<IStockService, FakeStockService>();
                //services.AddScoped<IProductRepository, MockProductRespository>();
                //services.AddScoped<IProductService, ProductService>();
                services.AddHttpClient<IStockService, StockService>();
                services.AddHttpClient<IProductRepository, ProductRepository>();
                services.AddHttpClient<IProductService, ProductService>();
            }


            //services.AddTransient<IProductRepository, ProductRepository>();
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
            //app.UseAuthentication();
            app.UseAuthorization();

            
            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          

        }
    }
}
