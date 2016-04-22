using System;
using System.Configuration;
using Castle.Windsor;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using GD.RtSurvey.Api.Providers;
using System.Web.Http;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using GD.RtSurvey.Api.Architecture.Injection;

namespace GD.RtSurvey.Api
{
	public partial class Startup
	{
		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

		public static string PublicClientId { get; private set; }

		// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
		public void ConfigureAuth(IAppBuilder app)
		{
			// Configure the db context and user manager to use a single instance per request
			//app.CreatePerOwinContext(ApplicationDbContext.Create);
			//app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

			// Enable the application to use a cookie to store information for the signed in user
			// and to use a cookie to temporarily store information about a user logging in with a third party login provider
			//app.UseCookieAuthentication(new CookieAuthenticationOptions());
			//app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

			// Configure the application for OAuth based flow
			PublicClientId = "self";
			OAuthOptions = new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString(@"/Token"),
				Provider = _container.Resolve<ApplicationOAuthProvider>(),
				RefreshTokenProvider = _container.Resolve<ApplicationRefreshTokenProvider>(),
				//AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
				AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings[@"TimeExpiredToken"])),
				// In production mode set AllowInsecureHttp = false
				AllowInsecureHttp = true
			};

			// Enable the application to use bearer tokens to authenticate users
			app.UseOAuthBearerTokens(OAuthOptions);

			// Uncomment the following lines to enable logging in with third party login providers
			//app.UseMicrosoftAccountAuthentication(
			//    clientId: "",
			//    clientSecret: "");

			//app.UseTwitterAuthentication(
			//    consumerKey: "",
			//    consumerSecret: "");

			//app.UseFacebookAuthentication(
			//    appId: "",
			//    appSecret: "");

			//app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			//{
			//    ClientId = "",
			//    ClientSecret = ""
			//});
		}

		public static void ConfigureWindsor(HttpConfiguration configuration)
		{
			_container = new WindsorContainer();
			_container.Install(Castle.Windsor.Installer.Configuration.FromAppConfig());
			_container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
			var dependencyResolver = new WindsorDependencyResolver(_container);
			configuration.DependencyResolver = dependencyResolver;
		}

		public void Application_End()
		{
			_container.Dispose();
		}
	}
}
