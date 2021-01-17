using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EURISTest.Models.Catalog
{
  public class CatalogCreateViewModel
  {
    [Required]
    public string Code { get; set; }

    [Required]
    public string Description { get; set; }

    public List<SelectListItem> Products { get; set; }

    [Required]
    public List<string> SelectedProducts { get; set; }

    public CatalogCreateViewModel()
    {
      Products = new List<SelectListItem>();
      SelectedProducts = new List<string>();
    }
  }
}