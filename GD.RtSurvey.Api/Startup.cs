using System.Web.Http;
using Castle.Windsor;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GD.RtSurvey.Api.Startup))]

namespace GD.RtSurvey.Api
{
	public partial class Startup
	{
		private static WindsorContainer _container;
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			ConfigureWindsor(config);
			ConfigureAuth(app);

			WebApiConfig.Register(config, _container);
			app.UseWebApi(config);
		}

	}
}
