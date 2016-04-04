using System.Web.Mvc;
using Castle.Windsor;

namespace GD.RtSurvey.Api.Architecture.Injection
{
	public class WindsorMvcDependencyResolver : WindsorDependencyScope, IDependencyResolver
	{
		public WindsorMvcDependencyResolver(IWindsorContainer container) : base(container)
		{

		}
	}
}