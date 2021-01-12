using StaffProductNew.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace StaffProductNew.Services.CustomerOrderingService
{
    public class CustomerProductService : ICustomerProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CustomerProductService(IHttpClientFactory clientFactory)
        {
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


            var disco = await client.GetDiscoveryDocumentAsync("https://staffauththamco.azurewebsites.net");
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
