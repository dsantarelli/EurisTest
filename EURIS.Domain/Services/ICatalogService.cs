using EURIS.Domain.Models;
using System.Collections.Generic;

namespace EURIS.Domain.Services
{
  public interface ICatalogService
  {
    IEnumerable<Catalog> GetCatalogs();

    Catalog GetCatalog(string code);

    void AddCatalog(string code, string description, string[] productIds);

    void DeleteCatalog(string code);

    void UpdateCatalog(string code, string description, string[] productIds);
  }
}