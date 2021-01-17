using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EURISTest.Models.Product
{
  public class ProductEditViewModel
  {
    [Required]
    public string Code { get; set; }

    [Required]
    public string Description { get; set; }

    public List<SelectListItem> Catalogs { get; set; }

    public ProductEditViewModel()
    {
      Catalogs = new List<SelectListItem>();
    }
  }
}