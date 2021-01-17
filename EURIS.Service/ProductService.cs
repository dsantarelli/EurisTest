using EURIS.Data;
using EURIS.Domain.Models;
using EURIS.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace EURIS.Service
{
  public class ProductService : IProductService
  {
    private readonly EurisDbContext _dbContext;

    public ProductService(EurisDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Product> GetProducts()
    {
      foreach (var product in _dbContext.Products.Include("Catalogs"))
        yield return ToDomain(product);      
    }

    public Product GetProduct(string code)
    {
      return ToDomain(GetDbProduct(code));
    }

    public void AddProduct(string code, string description)
    {
      // Domain checks omitted for semplicity...

      var product = new Entities.Models.Product
      { 
        Code = code, 
        Description = description 
      };
      _dbContext.Products.Add(product);
      _dbContext.SaveChanges();
    }

    public void DeleteProduct(string code)
    {
      // Domain checks omitted for semplicity...

      var product = GetDbProduct(code);
      _dbContext.Products.Remove(product);
      _dbContext.SaveChanges();
    }

    public void UpdateProduct(string code, string description)
    {
      // Domain checks omitted for semplicity...

      var product = GetDbProduct(code);
      product.Description = description;
      _dbContext.SaveChanges();
    }

    private Entities.Models.Product GetDbProduct(string code)
    {
      return _dbContext.Products.SingleOrDefault(x => x.Code == code);
    }

    private Product ToDomain(Entities.Models.Product product)
    {
      if (product == null)
        return null;

      return new Product(
        product.Code,
        product.Description,
        product.Catalogs.Select(x => new LinkedCatalog(x.Code, x.Description)).ToArray()
      );
    }
  }
}
