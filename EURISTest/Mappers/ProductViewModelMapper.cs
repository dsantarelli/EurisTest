using EURIS.Domain.Models;
using EURISTest.Models;
using EURISTest.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EURISTest.Mappers
{
  public static class ProductViewModelMapper
  {
    public static ProductListViewModel MapListViewModel(IEnumerable<Product> products)
    {
      return new ProductListViewModel
      {
        Products = products.OrderBy(x => x.Description).Select(MapProductViewModel).ToList()
      };
    }

    public static ProductDetailsViewModel MapDetailsViewModel(Product product)
    {
      return new ProductDetailsViewModel
      {
        Product = MapProductViewModel(product)
      };
    }

    public static ProductEditViewModel MapEditViewModel(Product product)
    {
      return new ProductEditViewModel
      {
        Code = product.Code,
        Description = product.Description,
        Catalogs = product.Catalogs.OrderBy(x => x.Description).Select(x => new SelectListItem { Text = x.Description, Value = x.Code }).ToList()
      };
    }   

    public static ProductDeleteViewModel MapDeleteViewModel(Product product)
    {
      return new ProductDeleteViewModel
      {
        Product = MapProductViewModel(product)
      };
    }

    public static ProductCreateViewModel MapCreateViewModel()
    {
      return new ProductCreateViewModel();
    }

    private static ProductViewModel MapProductViewModel(Product product)
    {
      return new ProductViewModel
      {
        Code = product.Code,
        Description = product.Description,
        Catalogs = product.Catalogs.OrderBy(x => x.Description).Select(x => MapProductLinkedCatalogViewModel(x)).ToList()
      };
    }

    private static ProductLinkedCatalogViewModel MapProductLinkedCatalogViewModel(LinkedCatalog catalog)
    {
      return new ProductLinkedCatalogViewModel
      {
        Code = catalog.Code,
        Description = catalog.Description
      };
    }
  }

}