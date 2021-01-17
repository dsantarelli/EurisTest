using System.ComponentModel.DataAnnotations;

namespace EURISTest.Models.Product
{
  public class ProductCreateViewModel
  {
    [Required]
    public string Code { get; set; }

    [Required]
    public string Description { get; set; }
  }
}