using EURIS.Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EURIS.Data
{
  public class EurisDbInitializer : DropCreateDatabaseAlways<EurisDbContext>
  {
    protected override void Seed(EurisDbContext context)
    {
      new List<Product>
      {
          new Product { Code = "PRODUCT-1" , Description = "Product 1" },
          new Product { Code = "PRODUCT-2" , Description = "Product 2" },
          new Product { Code = "PRODUCT-3" , Description = "Product 3" }
      }
      .ToList()
      .ForEach(x => context.Products.Add(x));
      context.SaveChanges();

      var products = context.Products.ToArray();
      new[]
      {
         new Catalog { Code = "CATALOG-1", Description = "Catalog 1", Products = products.Take(1).ToList() },
         new Catalog { Code = "CATALOG-2", Description = "Catalog 2", Products = products.Take(2).ToList() },
         new Catalog { Code = "CATALOG-3", Description = "Catalog 3", Products = products.Take(3).ToList() },
         new Catalog { Code = "CATALOG-4", Description = "Catalog 4" }
      }
      .ToList()
      .ForEach(x => context.Catalogs.Add(x));
      context.SaveChanges();
    }    
  }
}


