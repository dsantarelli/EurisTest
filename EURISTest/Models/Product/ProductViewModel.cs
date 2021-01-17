using EURISTest.Models.Product;
using System.Collections.Generic;

namespace EURISTest.Models
{
  public class ProductViewModel
  {
    public string Code { get; set; }

    public string Description { get; set; }

    public List<ProductLinkedCatalogViewModel> Catalogs { get; set; }

    public ProductViewModel()
    {
      Catalogs = new List<ProductLinkedCatalogViewModel>();
    }
  }
}