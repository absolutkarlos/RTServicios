using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IClientBl : IBusinessLayer<Client>
	{
		Client GetInfo<TId>(TId id);
		int ValidateByRuc(string ruc);
		int ValidateByRuc(Client client);
	} 
}