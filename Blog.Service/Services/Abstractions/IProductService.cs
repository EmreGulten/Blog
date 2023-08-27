using Blog.Entity.DTOs.Products;
using Blog.Entity.Entities;

namespace Blog.Service.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductNonDeleted();
        Task<List<ProductDto>> GetAllProductDeleted();
        Task<Product> GetProductyByGuid(Guid id);
        Task CreateProductAsync(ProductAddDto productAdd);
        Task<string> UpdateProductAsync(ProductUpdateDto productUpdate);
        Task<string> SafeDeleteProductAsync(Guid productId);
        Task<string> UndoDeleteProductAsync(Guid productId);
    }
}
