using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Products;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Service.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, ClaimsPrincipal user)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateProductAsync(ProductAddDto productAdd)
        {
            var product = mapper.Map<Product>(productAdd);
            await unitOfWork.GetRepository<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ProductDto>> GetAllProductDeleted()
        {
            var product = await unitOfWork.GetRepository<Product>().GetAllAsync(x => x.IsDeleted);
            return mapper.Map<List<ProductDto>>(product);
        }

        public async Task<List<ProductDto>> GetAllProductNonDeleted()
        {
            var product = await unitOfWork.GetRepository<Product>().GetAllAsync(x => !x.IsDeleted);
            return mapper.Map<List<ProductDto>>(product);
        }

        public async Task<string> SafeDeleteProductAsync(Guid productId)
        {
            var userId = _user.GetLoggedInUserId();
            var product = await unitOfWork.GetRepository<Product>().GetByGuidAsync(productId);

            product.IsDeleted= true;
            product.DeletedDate= DateTime.Now;
            product.DeletedBy = userId.ToString();

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return product.Name;
        }

        public async Task<string> UndoDeleteProductAsync(Guid productId)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByGuidAsync(productId);

            product.IsDeleted = false;
            product.DeletedDate = null;
            product.DeletedBy = null;

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return product.Name;
        }

        public async Task<string> UpdateProductAsync(ProductUpdateDto productUpdate)
        {
            var product = await unitOfWork.GetRepository<Product>().GetAsync(x => !x.IsDeleted && x.Id == productUpdate.Id);

            product.Name= productUpdate.Name;
            product.Description= productUpdate.Description;
            product.Price= productUpdate.Price;
            product.CategoryId= productUpdate.CategoryId;
            product.StockQuantity= productUpdate.StockQuantity;
            product.IsFeatured= productUpdate.IsFeatured;

            await unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return product.Name;
        }
    }
}
