using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IUserBl : IBusinessLayer<User>
	{
		void UpdateLastConnect(long userId);
	}
}