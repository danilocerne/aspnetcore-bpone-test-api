using BPOneTestAPI.Domain.Entities;

namespace BPOneTestAPI.Domain.Interfaces
{
	public interface IClientRepository
	{
        Task<Client> GetClientByAssync(int? clientId);

        Task<IEnumerable<OrderItem>> GetOrderByAssync(int? clientId);

        Task<Client> CreateAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<Client> RemoveAsync(Client client);
    }
}

