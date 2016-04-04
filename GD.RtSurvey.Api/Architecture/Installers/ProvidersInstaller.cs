using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GD.RtSurvey.Api.Architecture.Installers
{
	/// <summary>
	///     Regsters all classes that implement IInterceptor interface so they can be applied to registered components.
	/// </summary>
	public class ProvidersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromAssemblyNamed(@"GD.RtSurvey.Api")
					.InNamespace(@"GD.RtSurvey.Api.Providers", false)
					.WithServiceSelf()
					.LifestylePerWebRequest());
		}
	}
}