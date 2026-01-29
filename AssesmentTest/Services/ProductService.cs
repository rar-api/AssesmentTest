using AssesmentTest.Interfaces;
using AssesmentTest.Models;

namespace AssesmentTest.Services
{
    public class ProductService(IHttpClientFactory httpClientFactory) : IProductService
    {
        public async Task<List<Product>> GetProductsAsync()
        {
            var client = httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetFromJsonAsync<List<Product>>("products");
            return response ?? new List<Product>();
        }
    }
}
