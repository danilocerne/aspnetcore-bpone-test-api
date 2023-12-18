using BPOneTestAPI.Domain.Entities;

namespace BPOneTestAPI.Domain.Interfaces
{
	public interface IOrderRepository
	{
        Task<Order> GetOrderByAssync(int? orderId);
        Task<Client> GetClientByAssync(int? orderId);
        Task<Client> GetClientByAssync(int? orderId, int? clientId);

        Task<IEnumerable<Order>> GetOrdersByAssync(int? clientId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByAsync(int? orderId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByAsync(int? orderId, int? clientId);

        Task<Order> CreateAsync(Order order);
        Task<Order> UpdateAsync(Order order);
        Task<Order> RemoveAsync(Order order);
    }
}

