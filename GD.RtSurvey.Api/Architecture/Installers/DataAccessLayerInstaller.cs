using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;

namespace GD.RtSurvey.Api.Architecture.Installers
{
	/// <summary>
	///     Registers in the container all classses that implement (directly or indirectly) the IRepository interface. Logging
	///     aspect is applied.
	/// </summary>
	public class DataAccessLayerInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			//container.Register(
			//	Classes.FromAssemblyNamed(@"GD.Data.Access")
			//		.InNamespace(@"GD.Data.Access", false)
			//		.WithServiceDefaultInterfaces()
			//		.LifestylePerWebRequest());

			container.Register(
				Classes.FromAssemblyNamed(@"GD.Data.Access")
					.InNamespace(@"GD.Data.Access.Repositories", false)
					.WithServiceAllInterfaces()
					.LifestylePerWebRequest());

			//container.Register(
			//	Classes.FromAssemblyNamed(@"GD.Data.Access")
			//		.InNamespace(@"GD.Data.Access.DataAccess.Interface", false)
			//		.WithServiceDefaultInterfaces()
			//		.LifestylePerWebRequest());

			container.Register(
				Classes.FromAssemblyNamed(@"GD.Data.Access")
					.InNamespace(@"GD.Data.Access.DataAccess", false)
					.WithServiceAllInterfaces()
					.LifestylePerWebRequest());

			//container.Register(
			//	Classes.FromAssemblyNamed(@"GD.Data.Access")
			//		.IncludeNonPublicTypes()
			//		.BasedOn(typeof(IRepository<>))
			//		.WithServiceDefaultInterfaces()
			//		.LifestylePerWebRequest());
		}
	}
}