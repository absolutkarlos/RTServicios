using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IOrderFlowBl : IBusinessLayer<OrderFlow>
	{
		void UpdateStatus(OrderFlow orderFlow);
	}
}