using EURIS.Entities.Models;
using System.Data.Entity;

namespace EURIS.Data
{
  public class EurisDbContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }

    public EurisDbContext(string nameOrConnectionString) : base(nameOrConnectionString) {}

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {      
      Database.SetInitializer(new EurisDbInitializer());
    }
  }
}