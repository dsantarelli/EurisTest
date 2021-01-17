using EURIS.Domain.Models;
using EURISTest.Models.Catalog;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EURISTest.Mappers
{
  public static class CatalogViewModelMapper
  {
    public static CatalogListViewModel MapListViewModel(IEnumerable<Catalog> catalogs)
    {
      return new CatalogListViewModel
      {
        Catalogs = catalogs.OrderBy(x => x.Description).Select(MapCatalogViewModel).ToList()
      };
    }

    public static CatalogDetailsViewModel MapDetailsViewModel(Catalog catalog)
    {
      return new CatalogDetailsViewModel
      {
        Catalog = MapCatalogViewModel(catalog)
      };
    }

    public static CatalogCreateViewModel MapCreateViewModel(IEnumerable<Product> products)
    {
      return new CatalogCreateViewModel
      {
        Products = products.OrderBy(x => x.Description).Select(x => new SelectListItem { Text = x.Description, Value = x.Code }).ToList()
      };
    }

    public static CatalogEditViewModel MapEditViewModel(Catalog catalog, IEnumerable<Product> products)
    {
      return new CatalogEditViewModel
      {
        Code = catalog.Code,
        Description = catalog.Description,
        Products = products.OrderBy(x => x.Description).Select(x => new SelectListItem() { Text = x.Description, Value = x.Code }).ToList(),
        SelectedProducts = catalog.Products.Select(x => x.Code).ToList()
      };
    }

    public static CatalogDeleteViewModel MapDeleteViewModel(Catalog catalog)
    {
      return new CatalogDeleteViewModel
      { 
        Catalog = MapCatalogViewModel(catalog)
      };
    }

    private static CatalogViewModel MapCatalogViewModel(Catalog catalog)
    {
      return new CatalogViewModel
      {
        Code = catalog.Code,
        Description = catalog.Description,
        Products = catalog.Products.OrderBy(x => x.Description).Select(MapCatalogLinkedProductViewModel).ToList()
      };
    }
   
    private static CatalogLinkedProductViewModel MapCatalogLinkedProductViewModel(LinkedProduct product)
    {
      return new CatalogLinkedProductViewModel
      {
        Code = product.Code,
        Description = product.Description
      };
    }   
  }
}