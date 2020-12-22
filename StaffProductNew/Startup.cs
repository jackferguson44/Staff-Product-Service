using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<StaffProductDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StaffProductConfig")));
            
            
            services.AddMvc();
            if(_env.IsDevelopment())
            {
                services.AddSingleton<IStockService, FakeStockService>();
                services.AddSingleton<IProductRepository, MockProductRespository>();
                //services.AddScoped<IProductRepository, ProductRepository>();
                //services.AddScoped<IProductService, ProductService>();
            }
            else
            {
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
