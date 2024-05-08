using Ams.Model;
using Ams.Model.Content;
using Ams.Model.Dto;
using Ams.Service.Content.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 评论
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Route("routine/article/front/comment")]
    [ApiExplorerSettings(GroupName = "article")]
    [ApiController]
    public class FrontCommentController : BaseController
    {
        private readonly IArticleCommentService _ArticleCommentService;

        /// <summary>
        ///
        /// </summary>
        /// <param name="messageService"></param>
        public FrontCommentController(IArticleCommentService ArticleCommentService)
        {
            this._ArticleCommentService = ArticleCommentService;
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
                response = _ArticleCommentService.GetReplyComments(parm.CommentId, parm);
            }
            else
            {
                response = _ArticleCommentService.GetMessageList(parm);
            }

            return SUCCESS(response);
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        [Verify]
        [ActionPermissionFilter(Permission = "common")]
        public IActionResult Create([FromBody] ArticleCommentDto parm)
        {
            var uid = HttpContext.GetUId();
            if (uid <= 0) { return ToResponse(ResultCode.DENY); }

            var addModel = parm.Adapt<ArticleComment>().ToCreate(context: HttpContext);
            addModel.UserIP = HttpContext.GetClientUserIp();
            addModel.UserId = uid;
            return SUCCESS(_ArticleCommentService.AddMessage(addModel).Adapt<ArticleCommentDto>());
        }

        /// <summary>
        /// 评论点赞
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("praise")]
        [ActionPermissionFilter(Permission = "common")]
        [Verify]
        public IActionResult Praise([FromBody] ArticleCommentDto dto)
        {
            if (dto == null || dto.CommentId <= 0) return ToResponse(ResultCode.PARAM_ERROR);
            //var uid = HttpContextExtension.GetUId(HttpContext);

            return SUCCESS(_ArticleCommentService.PraiseMessage(dto.CommentId));
        }

        /// <summary>
        /// 评论删除
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpDelete("delete/{mid}")]
        [ActionPermissionFilter(Permission = "common")]
        [Verify]
        public IActionResult Delete(long mid)
        {
            var uid = HttpContext.GetUId();
            if (uid <= 0) { return ToResponse(ResultCode.DENY); }
            return SUCCESS(_ArticleCommentService.DeleteMessage(mid.ParseToLong(), uid));
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
            PagedInfo<ArticleCommentDto> response = _ArticleCommentService.GetMyMessageList(parm);

            return SUCCESS(response);
        }
    }
}