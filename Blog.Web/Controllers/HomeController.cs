using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.DTOs.Email;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Blog.Web.Models;
using Blog.Web.ResultMessages;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService articleService;
        private readonly IMailService mailService;
        private readonly IToastNotification _toastNotification;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork,IMailService mailService)
        {
            _logger = logger;
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
            this.mailService = mailService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var articeVisitors = await unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == id);

            var result = await articleService.GetArticleWithCategoryNonDeletedAsync(id);

            var visitor = await unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            var addArticleVisitors = new ArticleVisitor(article.Id, visitor.Id);

            if (articeVisitors.Any(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId))
                return View(result);
            else
            {
                await unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors);
                article.Views += 1;
                await unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await unitOfWork.SaveAsync();
            }

            return View(result);
        }

		[HttpGet]
		//[Route("~/hakkimizda")]
		public IActionResult About()
        {
            return View();
        }

		[HttpGet]
		//[Route("~/iletisim")]
		public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = await mailService.SendContactEmail(emailSendDto);
                _toastNotification.AddSuccessToastMessage(Messages.Mail.Send(emailSendDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                return View();
            }

            return View(emailSendDto);
        }

        [HttpGet]
		public async Task<IActionResult> BlogOne(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
			var articles = await articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
			return View(articles);
		}

		[HttpGet]
		public async Task<IActionResult> BlogTwo(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }
    }
}