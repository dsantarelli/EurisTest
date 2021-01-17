using System.Collections.Generic;

namespace EURISTest.Models.Catalog
{
  public class CatalogViewModel
  {
    public string Code { get; set; }

    public string Description { get; set; }

    public List<CatalogLinkedProductViewModel> Products { get; set; }

    public CatalogViewModel()
    {
      Products = new List<CatalogLinkedProductViewModel>();
    }
  }
}