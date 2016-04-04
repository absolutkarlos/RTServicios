using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GD.RtSurvey.Api.Architecture.Installers
{
	/// <summary>
	///     Registers in the container all controllers that extends from ApiController base type using a Per-Request lifestyle,
	///     that is, the a new instance is created with each HTTP request and is disposed at the end of it.
	/// </summary>
	public class ApiControllersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Types.FromThisAssembly()
					.BasedOn<ApiController>()
					.WithServiceSelf()
					.LifestylePerWebRequest());

			//container.Register(
			//	Types.FromThisAssembly()
			//		.BasedOn<IController>()
			//		.WithServiceSelf()
			//		.LifestylePerWebRequest()
			//		.Configure(
			//		c => c.Interceptors<TransactionAspect>()));
		}
	}
}