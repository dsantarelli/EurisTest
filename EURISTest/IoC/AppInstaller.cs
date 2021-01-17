using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EURIS.Data;
using EURIS.Domain.Services;
using EURIS.Service;

namespace EURISTest.IoC
{
  public class AppInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(Component.For<EurisDbContext>().UsingFactoryMethod(x => new EurisDbContext("LocalDb")).LifestylePerWebRequest());
      container.Register(Component.For<IProductService>().ImplementedBy<ProductService>().LifestylePerWebRequest());
      container.Register(Component.For<ICatalogService>().ImplementedBy<CatalogService>().LifestylePerWebRequest());
    }
  }
}