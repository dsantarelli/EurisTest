using System.Collections.Generic;

namespace EURISTest.Models.Catalog
{
  public class CatalogListViewModel
  {
    public List<CatalogViewModel> Catalogs { get; set; }

    public CatalogListViewModel()
    {
      Catalogs = new List<CatalogViewModel>();
    }
  }
}