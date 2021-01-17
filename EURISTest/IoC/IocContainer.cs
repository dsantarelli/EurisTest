using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace EURISTest.IoC
{
	public static class IocContainer
	{		
		public static void Setup()
		{
			var container = new WindsorContainer().Install(FromAssembly.This());			
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
		}
	}
}