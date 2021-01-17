using System.Collections.Generic;

namespace EURISTest.Models.Product
{
  public class ProductListViewModel
  {
    public List<ProductViewModel> Products { get; set; }

    public ProductListViewModel()
    {
      Products = new List<ProductViewModel>();
    }
  }
}