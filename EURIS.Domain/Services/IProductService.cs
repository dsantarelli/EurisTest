using EURIS.Domain.Models;
using System.Collections.Generic;

namespace EURIS.Domain.Services
{
  public interface IProductService
  {
    IEnumerable<Product> GetProducts();

    Product GetProduct(string code);

    void AddProduct(string code, string description);

    void DeleteProduct(string code);

    void UpdateProduct(string code, string description);
  }
}
