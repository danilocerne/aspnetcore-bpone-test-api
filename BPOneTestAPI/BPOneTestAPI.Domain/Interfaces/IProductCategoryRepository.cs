using BPOneTestAPI.Domain.Entities;

namespace BPOneTestAPI.Domain.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync();
        Task<ProductCategory> GetByIdAsync(int? id);
        Task<ProductCategory> CreateAsync(ProductCategory productCategory);
        Task<ProductCategory> UpdateAsync(ProductCategory productCategory);
        Task<ProductCategory> RemoveAsync(ProductCategory productCategory);
    }
}