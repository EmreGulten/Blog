using Blog.Entity.DTOs.Products;

namespace Blog.Service.Services.Abstractions
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductNonDeleted();
        Task<List<ProductDto>> GetAllProductDeleted();
        Task CreateProductAsync(ProductAddDto productAdd);
        Task<string> UpdateProductAsync(ProductUpdateDto productUpdate);
        Task<string> SafeDeleteProductAsync(Guid productId);
        Task<string> UndoDeleteProductAsync(Guid productId);
    }
}
