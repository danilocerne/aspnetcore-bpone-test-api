using BPOneTestAPI.Domain.Entities;
using BPOneTestAPI.Domain.Interfaces;
using BPOneTestAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BPOneTestAPI.Infra.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        ApplicationDbContext _productCategoryContext;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _productCategoryContext = context;
        }

        public async Task<ProductCategory> CreateAsync(ProductCategory productCategory)
        {
            _productCategoryContext.Add(productCategory);
            await _productCategoryContext.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductCategory> GetByIdAsync(int? id)
        {
            return await _productCategoryContext.ProductCategories.FindAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
        {
            return await _productCategoryContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> RemoveAsync(ProductCategory productCategory)
        {
            _productCategoryContext.Remove(productCategory);
            await _productCategoryContext.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductCategory> UpdateAsync(ProductCategory productCategory)
        {
            _productCategoryContext.Update(productCategory);
            await _productCategoryContext.SaveChangesAsync();
            return productCategory;
        }
    }
}