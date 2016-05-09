using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;
using GD.Core.Business.Interfaces;
using GD.RtSurvey.Api.Filters;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

namespace GD.RtSurvey.Api.Providers
{
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		private readonly string _publicClientId = @"self";
		private readonly IAuthenticationBl _authenticationBl;

		public ApplicationOAuthProvider(IAuthenticationBl authenticationBl)
		{
			_authenticationBl = authenticationBl;
		}

		public ClaimsIdentity GenerateClaimsIdentity(long userId, string authenticationType)
		{
			return new ClaimsIdentity(new List<Claim> {
				new Claim(ClaimTypes.PrimarySid, userId.ToString())
			}, authenticationType);
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			try
			{
				var userId = _authenticationBl.ValidateAutentication(new User { UserName = context.UserName, Password = (new Utility()).Encrypt(context.Password) });

				if (!userId.IsGreaterThanZero())
				{
					context.SetError(HttpStatusCode.Unauthorized.ToString(), @"Nombre de usuario o contraseña incorrectos.");
					return;
				}

				ClaimsIdentity oAuthIdentity = GenerateClaimsIdentity(userId, OAuthDefaults.AuthenticationType);
				ClaimsIdentity cookiesIdentity = GenerateClaimsIdentity(userId, CookieAuthenticationDefaults.AuthenticationType);
				AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties(new Dictionary<string, string> { { @"userid", userId.ToString() } }));
				context.Validated(ticket);
				context.Request.Context.Authentication.SignIn(cookiesIdentity);
			}
			catch (Exception exception)
			{
				context.SetError(HttpStatusCode.Unauthorized.ToString(), exception.Message);
			}
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			// Resource owner password credentials does not provide a client ID.
			if (context.ClientId == null)
			{
				context.Validated();
			}

			return Task.FromResult<object>(null);
		}

		public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
		{
			if (context.ClientId == _publicClientId)
			{
				Uri expectedRootUri = new Uri(context.Request.Uri, @"/");

				if (expectedRootUri.AbsoluteUri == context.RedirectUri)
				{
					context.Validated();
				}
			}

			return Task.FromResult<object>(null);
		}

		public static AuthenticationProperties CreateProperties(string userName)
		{
			IDictionary<string, string> data = new Dictionary<string, string>
			{
				{ @"userName", userName }
			};
			return new AuthenticationProperties(data);
		}
	}
}