using BPOneTestAPI.Domain.Entities;

namespace BPOneTestAPI.Domain.Interfaces
{
	public interface IOrderItemRepository
	{
        Task<OrderItem> GetOrderItemByAssync(int? orderItemId);
        Task<Product> GetProductByAssync(int? productId);
        Task<Product> GetProductByAssync(int? orderId, int? clientId, int? productId);

        Task<IEnumerable<OrderItem>> GetOrderItemsByAssync(int? orderId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByAsync(int? orderId, int? productId);

        Task<OrderItem> CreateAsync(OrderItem orderItem, int? orderId);
        Task<OrderItem> UpdateAsync(OrderItem orderItem, int? orderId);
        Task<OrderItem> RemoveAsync(OrderItem orderItem, int? orderId);
    }
}

