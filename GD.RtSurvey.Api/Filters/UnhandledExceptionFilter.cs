using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace GD.RtSurvey.Api.Filters
{
	public class UnhandledExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext filterContext)
		{
			if (filterContext.Exception != null)
			{
				filterContext.Response = filterContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(filterContext.Exception, true));
			}
		}
	}

}