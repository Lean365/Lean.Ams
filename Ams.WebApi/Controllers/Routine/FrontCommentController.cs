﻿namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 评论
    /// </summary>
    [Route("routine/article/comment")]
    [ApiExplorerSettings(GroupName = "routine")]
    [ApiController]
    public class FrontCommentController : BaseController
    {
        private readonly IArticleCommentService messageService;
        private readonly IArticleService articleService;

        /// <summary>
        ///
        /// </summary>
        /// <param name="messageService"></param>
        /// <param name="articleService"></param>
        public FrontCommentController(
            IArticleCommentService messageService, IArticleService articleService)
        {
            this.messageService = messageService;
            this.articleService = articleService;
        }

        /// <summary>
        /// 查询评论列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult QueryList([FromQuery] MessageQueryDto parm)
        {
            parm.PageSize = 10;
            PagedInfo<ArticleCommentDto>? response;
            //查询二级评论
            if (parm.CommentId > 0)
            {
                response = messageService.GetReplyComments(parm.CommentId, parm);
            }
            else
            {
                response = messageService.GetMessageList(parm);
            }

            return SUCCESS(response);
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        [Verify]
        [ActionPermissionFilter(Permission = "article:comment:add")]
        public IActionResult Create([FromBody] ArticleCommentDto parm)
        {
            var uid = HttpContext.GetUId();
            if (uid <= 0) { return ToResponse(ResultCode.DENY); }

            var addModel = parm.Adapt<ArticleComment>().ToCreate(context: HttpContext);
            addModel.UserIP = HttpContext.GetClientUserIp();
            addModel.UserId = uid;
            return SUCCESS(messageService.AddMessage(addModel).Adapt<ArticleCommentDto>());
        }

        /// <summary>
        /// 评论点赞
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("praise")]
        [ActionPermissionFilter(Permission = "article:comment:add")]
        [Verify]
        public IActionResult Praise([FromBody] ArticleCommentDto dto)
        {
            if (dto == null || dto.CommentId <= 0) return ToResponse(ResultCode.PARAM_ERROR);
            //var uid = HttpContextExtension.GetUId(HttpContext);

            return SUCCESS(messageService.PraiseMessage(dto.CommentId));
        }

        /// <summary>
        /// 评论删除
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpDelete("delete/{mid}")]
        [ActionPermissionFilter(Permission = "article:comment:delete")]
        [Verify]
        public IActionResult Delete(long mid)
        {
            var uid = HttpContext.GetUId();
            if (uid <= 0) { return ToResponse(ResultCode.DENY); }
            return SUCCESS(messageService.DeleteMessage(mid.ParseToLong(), uid));
        }

        /// <summary>
        /// 查询我的评论列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("mylist")]
        [Verify]
        public IActionResult QueryMyCommentList([FromQuery] MessageQueryDto parm)
        {
            PagedInfo<ArticleCommentDto> response = messageService.GetMyMessageList(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 评论置顶
        /// </summary>
        /// <returns></returns>
        [HttpPut("top")]
        [Verify]
        [ActionPermissionFilter(Permission = "article:comment:update")]
        public IActionResult Top([FromBody] ArticleCommentDto parm)
        {
            var uid = HttpContext.GetUId();
            if (uid <= 0) { return ToResponse(ResultCode.DENY); }
            var contentInfo = articleService.GetArticle(parm.TargetId, uid);
            if (contentInfo == null) { return ToResponse(ResultCode.CUSTOM_ERROR, "操作失败"); }
            return SUCCESS(messageService.TopMessage(parm.CommentId, parm.Top));
        }
    }
}