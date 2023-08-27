using AutoMapper;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Products;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstractions;
using Blog.Web.Consts;
using Blog.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IValidator<Product> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public ProductController(IProductService productService, IValidator<Product> validator, IMapper mapper, IToastNotification toast, ICategoryService categoryService)
        {
            this.productService = productService;
            this.validator = validator;
            this.mapper = mapper;
            this.toast = toast;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var product = await productService.GetAllProductNonDeleted();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new ProductAddDto { Categories = categories });
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            var map = mapper.Map<Product>(productAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await productService.CreateProductAsync(productAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(productAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> AddWithAjax([FromBody] ProductAddDto productAddDto)
        {
            var map = mapper.Map<Product>(productAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await productService.CreateProductAsync(productAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(productAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });

                return Json(Messages.Category.Add(productAddDto.Name));
            }
            else
            {
                toast.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(Guid productId)
        {
            var product = await productService.GetProductyByGuid(productId);
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            var map = mapper.Map<Product, ProductUpdateDto>(product);
            map.Category= categories;

            return View(map);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var map = mapper.Map<Product>(productUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await productService.UpdateProductAsync(productUpdateDto);
                toast.AddSuccessToastMessage(Messages.Product.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var name = await productService.SafeDeleteProductAsync(productId);
            toast.AddSuccessToastMessage(Messages.Product.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid productId)
        {
            var name = await productService.UndoDeleteProductAsync(productId);
            toast.AddSuccessToastMessage(Messages.Product.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }

    }
}
