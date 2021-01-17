using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EURIS.Entities.Models
{
  public class Catalog
  {
    [Key]
    public string Code { get; set; }

    [Required]
    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public Catalog()
    {
      Products = new HashSet<Product>();
    }
  }
}
