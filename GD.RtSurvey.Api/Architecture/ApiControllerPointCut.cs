using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Controllers;
using Castle.DynamicProxy;

namespace GD.RtSurvey.Api.Architecture
{
	/// <summary>
	///     Custom pointcut implementation for invocation of ApiController classes.
	/// </summary>
	public static class ApiControllerPointCut
	{
		private static readonly string AdvisableMethodsRegex;

		static ApiControllerPointCut()
		{
			AdvisableMethodsRegex =
				ConfigurationManager.AppSettings["Architecture.Aspect.ApiController.PointCutRegex"] ??
				"GET|POST|PUT|DELETE";
		}

		/// <summary>
		///     Checks if a web method is advisable during a web request.
		/// </summary>
		/// <param name="invocation"></param>
		/// <returns>true if the method matches the pointcut expression, false otherwise</returns>
		public static bool IsAdvisable(IInvocation invocation)
		{
			var result = false;
			if (typeof(ApiController).IsAssignableFrom(invocation.TargetType) &&
				invocation.Method.Name == "ExecuteAsync")
			{
				var context =
					(HttpControllerContext)
						invocation.Arguments.FirstOrDefault(
							a => a.GetType().IsAssignableFrom(typeof(HttpControllerContext)));

				result = (context != null &&
						  Regex.IsMatch(context.Request.Method.Method, AdvisableMethodsRegex, RegexOptions.IgnoreCase));
			}

			return result;
		}
	}
}