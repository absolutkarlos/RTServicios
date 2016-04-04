using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GD.Core.Business.Interfaces;

namespace GD.RtSurvey.Api.Architecture.Installers
{
	/// <summary>
	///     Registers in the container all business classes (with their interfaces) found on the BL namespace, no clases in
	///     sub-namespaces are included. Logging and Exception aspects are applied.
	/// </summary>
	public class BusinessLayerInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromAssemblyNamed(@"GD.Core.Business")
					.InNamespace(@"GD.Core.Business", false)
					.WithServiceAllInterfaces()
					.LifestylePerWebRequest());

			//container.Register(
			//	Classes.FromAssemblyNamed("GD.Core.Business")
			//		.InNamespace("GD.Core.Business.Interfaces", false)
			//		.WithServiceDefaultInterfaces()
			//		.LifestylePerWebRequest());

			//container.Register(
			//	Classes.FromAssemblyNamed(@"GD.Core.Business")
			//		.IncludeNonPublicTypes()
			//		.BasedOn(typeof(IBusinessLayer<>))
			//		.WithServiceDefaultInterfaces()
			//		.LifestylePerWebRequest());
		}
	}
}