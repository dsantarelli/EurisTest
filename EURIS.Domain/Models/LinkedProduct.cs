using System;

namespace EURIS.Domain.Models
{
  public class LinkedProduct
  {
    public string Code { get; }

    public string Description { get; }

    public LinkedProduct(string code, string description)
    {
      if (string.IsNullOrWhiteSpace(code))
        throw new ArgumentException("code can't be null or empty");

      if (string.IsNullOrWhiteSpace(description))
        throw new ArgumentException("description can't be null or empty");

      Code = code;
      Description = description;
    }
  }
}
