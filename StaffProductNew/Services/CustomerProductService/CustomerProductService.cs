using Newtonsoft.Json;
using StaffProductNew.Data;
using StaffProductNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityModel;
using IdentityModel.Client;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public class CustomerProductService : ICustomerProductService
    {
        //private readonly IProductRepository _productRepository;
        private readonly IHttpClientFactory _clientFactory;

        public CustomerProductService(IHttpClientFactory clientFactory) //IProductRepository productRepository
        {
           // _productRepository = productRepository;
            //client.BaseAddress = new System.Uri("http://localhost:44357");
            //client.Timeout = TimeSpan.FromSeconds(5);
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<CustomerProductDto>> UpdateStock(IEnumerable<Product> productChanges)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.ParseAdd("applications/json");

            var product = productChanges.Select(p => new CustomerProductDto
            {
                ProductId = p.Id,
                Name = p.Name,
                Quantity = p.Stock,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Price = p.Price
            }).ToList();


            var disco = await client.GetDiscoveryDocumentAsync("https://customeroauththamco.azurewebsites.net");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "staff_product_api",
                ClientSecret = "eRRg%sR!231iHZ_Mq&G",
                Scope = "customer_product_api"
            });

            client.SetBearerToken(tokenResponse.AccessToken);
            var postTask = client.PostAsJsonAsync("https://customerproductsthamco.azurewebsites.net/api/product/", product);
            postTask.Wait();

            var result = postTask.Result;
            //
            if (result.IsSuccessStatusCode)
            {
                return product;
            }
            return null;
        }
    }
}
