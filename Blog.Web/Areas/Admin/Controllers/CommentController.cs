using AutoMapper;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using Blog.Web.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Data;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IArticleService articleService;
        private readonly IValidator<Comment> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public CommentController(ICommentService commentService, IArticleService articleService, IValidator<Comment> validator, IMapper mapper, IToastNotification toast)
        {
            this.commentService = commentService;
            this.articleService = articleService;
            this.validator = validator;
            this.mapper = mapper;
            this.toast = toast;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var comments = await commentService.GetAllCommentsNonDeleted();
            return View(comments);
        }


    }
}
