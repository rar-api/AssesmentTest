using AssesmentTest.Models;

namespace AssesmentTest.Interfaces
{
    public interface IProductService
    {
       Task<List<Product>> GetProductsAsync();
    }
}
