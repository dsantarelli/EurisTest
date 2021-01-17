using EURIS.Data;
using EURIS.Domain.Models;
using EURIS.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace EURIS.Service
{
  public class CatalogService : ICatalogService
  {
    private readonly EurisDbContext _dbContext;

    public CatalogService(EurisDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Catalog> GetCatalogs()
    {
      foreach (var catalog in _dbContext.Catalogs.Include("Products"))
        yield return ToDomain(catalog);
    }

    public Catalog GetCatalog(string code)
    {
      return ToDomain(GetDbCatalog(code));
    }

    public void AddCatalog(string code, string description, string[] productIds)
    {
      // Domain checks omitted for semplicity...

      var catalog = new Entities.Models.Catalog
      {
        Code = code,
        Description = description,
        Products = _dbContext.Products.Where(c => productIds.Contains(c.Code)).ToList()
      };
      _dbContext.Catalogs.Add(catalog);
      _dbContext.SaveChanges();
    }

    public void DeleteCatalog(string code)
    {
      // Domain checks omitted for semplicity...

      var catalog = GetDbCatalog(code);
      _dbContext.Catalogs.Remove(catalog);
      _dbContext.SaveChanges();
    }

    public void UpdateCatalog(string code, string description, string[] productIds)
    {
      // Domain checks omitted for semplicity...

      var catalog = GetDbCatalog(code);
      catalog.Description = description;
      _dbContext.Entry(catalog).Collection(x => x.Products).Load(); // This is an update so we need to load the Products     
      catalog.Products = _dbContext.Products.Where(c => productIds.Contains(c.Code)).ToList();
      _dbContext.SaveChanges();
    }

    private Entities.Models.Catalog GetDbCatalog(string code)
    {
      return _dbContext.Catalogs.SingleOrDefault(x => x.Code == code);
    }

    private Catalog ToDomain(Entities.Models.Catalog catalog)
    {
      if (catalog == null)
        return null;

      return new Catalog(
        catalog.Code,
        catalog.Description,
        catalog.Products.Select(x => new LinkedProduct(x.Code, x.Description)).ToArray()
      );
    }
  }
}
