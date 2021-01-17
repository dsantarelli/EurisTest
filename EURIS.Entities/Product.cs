using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EURIS.Entities.Models
{
  public class Product
  {
    [Key]
    public string Code { get; set; }

    [Required]
    public string Description { get; set; }

    public virtual ICollection<Catalog> Catalogs { get; set; }

    public Product()
    {
      Catalogs = new HashSet<Catalog>();
    }
  }
}
