using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace GD.RtSurvey.Api.Architecture.Injection
{
	public class WindsorDependencyScope : IDependencyScope
	{
		private readonly IWindsorContainer _container;
		private readonly IDisposable _scope;

		public WindsorDependencyScope(IWindsorContainer container)
		{
			_container = container;
			_scope = container.BeginScope();
		}

		public void Dispose()
		{
			_scope.Dispose();
		}

		public object GetService(Type serviceType)
		{
			object result = null;

			if (_container.Kernel.HasComponent(serviceType))
			{
				result = _container.Resolve(serviceType);
			}
			return result;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			//return _container.ResolveAll<object>(serviceType);
			return _container.ResolveAll(serviceType).Cast<object>();
		}
	}
}