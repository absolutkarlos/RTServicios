using System;
using Castle.DynamicProxy;
using etc_bl.Common;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace VirtualPayment.Architecture.Aspects
{
	/// <summary>
	///     Logs the input and output of the intercepted methods
	/// </summary>
	public class LoggingAspect : IInterceptor
	{
		private LogEntry _logEntry;

		public void Intercept(IInvocation invocation)
		{
			if (_logEntry == null)
			{
				_logEntry = etc_bl.Utilities.Utils.BuildLoggerObject(invocation.TargetType.FullName, PROJECT_ENUM.ETC_BL);
			}

			_logEntry.Message = String.Format("Logging method {0}.{1}. Args: [{2}]", invocation.TargetType.FullName,
				invocation.Method.Name, string.Join(", ", invocation.Arguments));
			Logger.Write(_logEntry);

			invocation.Proceed();

			_logEntry.Message = "Logging return " + invocation.ReturnValue;
			Logger.Write(_logEntry);
		}
	}
}