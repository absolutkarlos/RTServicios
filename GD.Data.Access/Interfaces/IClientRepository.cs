using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IClientRepository : IRepository<Client>
	{
		Client GetInfo<TId>(TId id);
		int ValidateByRuc(string ruc);
		int ValidateByRuc(Client client);
	}
}