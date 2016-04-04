using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;
using etc_bl.Common;
using etc_bl.Exceptions;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace VirtualPayment.Architecture.Aspects
{
	/// <summary>
	///     Wraps the invocation in a single try catch to log the exception and retrow only instances of EtcExceptions
	/// </summary>
	public class ExceptionHandlerAspect : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			try
			{
				invocation.Proceed();
			}
			catch (SqlException e)
			{
				ETCException etcException = etc_bl.Utilities.Utils.BuildETCException(GetType().Name,
					string.Empty,
					MethodBase.GetCurrentMethod().Name,
					"An error ocurred accessing database",
					PROJECT_ENUM.ETC_BL,
					1,
					e);
				Logger.Write(etc_bl.Utilities.Utils.BuildLoggerObject(etcException, TraceEventType.Error));
				throw etcException;
			}
			catch (Exception e)
			{
				ETCException etcException = etc_bl.Utilities.Utils.BuildETCException(GetType().Name,
					string.Empty,
					MethodBase.GetCurrentMethod().Name,
					string.Format("An unhandled exception has ocurred invoking {0}", invocation.Method.Name),
					PROJECT_ENUM.ETC_BL,
					1,
					e);
				Logger.Write(etc_bl.Utilities.Utils.BuildLoggerObject(etcException, TraceEventType.Error));
				throw etcException;
			}
		}
	}
}