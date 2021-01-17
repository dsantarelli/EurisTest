using System;
using System.Collections.Generic;

namespace EURIS.Domain.Models
{
  public class Catalog
  {    
    public string Code { get; }
    
    public string Description { get; }

    public IEnumerable<LinkedProduct> Products { get; }

    public Catalog(string code, string description, IEnumerable<LinkedProduct> products)
    {
      if (string.IsNullOrWhiteSpace(code))
        throw new ArgumentException("code can't be null or empty", "code");

      if (string.IsNullOrWhiteSpace(description))
        throw new ArgumentException("description can't be null or empty", "description");

      if (products == null)
        throw new ArgumentException("products can't be null", "products");

      Code = code;
      Description = description;
      Products = products;
    }
  }
}
