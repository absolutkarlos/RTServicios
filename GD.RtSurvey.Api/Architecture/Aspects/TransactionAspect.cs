using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;
using etc_bl.Common;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace VirtualPayment.Architecture.Aspects
{
	/// <summary>
	///     Wraps the invocation of an ApiController in a single transaction during a web request, so all changes can be
	///     commited atomically or rolled back if an exception is thrown by the controller.
	/// </summary>
	public class TransactionAspect : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			if (ApiControllerPointCut.IsAdvisable(invocation))
			{
				LogEntry logEntry = etc_bl.Utilities.Utils.BuildLoggerObject(invocation.TargetType.FullName, PROJECT_ENUM.ETC_BL);

				logEntry.Message = "Beginning transaction";
				Logger.Write(logEntry);

				var transactionOptions = new TransactionOptions
				{
					IsolationLevel = IsolationLevel.ReadCommitted,
					Timeout = TransactionManager.MaximumTimeout
				};
				try
				{
					using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
					{
						//Since the invocation of an ApiController is done asyncronously, we should wait for it to complete 
						//before we can know if the transaction should be commited or rolled back
						invocation.Proceed();
						((Task<HttpResponseMessage>)invocation.ReturnValue).Wait();

						logEntry.Message = "Commiting transaction";
						Logger.Write(logEntry);
						scope.Complete();
					}
				}
				catch
				{
					logEntry.Severity = TraceEventType.Critical;
					logEntry.Message = "An exception was thown. Transaction was rolled back";
					Logger.Write(logEntry);
				}
			}
			else
			{
				invocation.Proceed();
			}
		}
	}
}