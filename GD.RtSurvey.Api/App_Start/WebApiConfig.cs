using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using Castle.Windsor;
using GD.RtSurvey.Api.Architecture.Injection;
using Microsoft.Owin.Security.OAuth;

namespace GD.RtSurvey.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config, IWindsorContainer container)
		{
			// Web API configuration and services
			// Configure Web API to use only bearer token authentication.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			// Web API routes
			config.MapHttpAttributeRoutes();

			//config.Routes.MapHttpRoute(
			//	name: "DefaultApi",
			//	routeTemplate: "api/{controller}/{id}",
			//	defaults: new { id = RouteParameter.Optional }
			//);

			config.Routes.MapHttpRoute(@"DefaultApiGet", @"api/{controller}", new { action = @"Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
			config.Routes.MapHttpRoute(@"DefaultApiPost", @"api/{controller}", new { action = @"Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
			config.Routes.MapHttpRoute(@"DefaultApiPut", @"api/{controller}", new { action = @"Put" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) });
			config.Routes.MapHttpRoute(@"DefaultApiDelete", @"api/{controller}", new { action = @"Delete" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) });

			config.Routes.MapHttpRoute(@"DefaultApiWithId", @"api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
			config.Routes.MapHttpRoute(@"DefaultApiWithAction", @"api/{controller}/{action}");

			config.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
		}
	}
}
