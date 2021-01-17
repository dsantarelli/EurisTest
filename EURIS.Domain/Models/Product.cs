using System;
using System.Collections.Generic;

namespace EURIS.Domain.Models
{
  public class Product
  {
    public string Code { get; }

    public string Description { get; }

    public IEnumerable<LinkedCatalog> Catalogs { get; }

    public Product(string code, string description, IEnumerable<LinkedCatalog> catalogs)
    {
      if (string.IsNullOrWhiteSpace(code))
        throw new ArgumentException("code can't be null or empty", "code");

      if (string.IsNullOrWhiteSpace(description))
        throw new ArgumentException("description can't be null or empty", "description");

      if (catalogs == null)
        throw new ArgumentException("catalogs can't be null", "catalogs");

      Code = code;
      Description = description;
      Catalogs = catalogs;
    }
  }
}
