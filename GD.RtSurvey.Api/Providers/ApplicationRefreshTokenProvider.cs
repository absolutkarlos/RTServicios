using System;
using System.Configuration;
using Microsoft.Owin.Security.Infrastructure;

namespace GD.RtSurvey.Api.Providers
{
	public class ApplicationRefreshTokenProvider : AuthenticationTokenProvider
	{
		public ApplicationRefreshTokenProvider() { }

		public override void Create(AuthenticationTokenCreateContext context)
		{
			context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(int.Parse(ConfigurationManager.AppSettings[@"TimeExpiredToken"])));
			context.SetToken(context.SerializeTicket());
		}

		public override void Receive(AuthenticationTokenReceiveContext context)
		{
			context.DeserializeTicket(context.Token);
		}
	}
}
