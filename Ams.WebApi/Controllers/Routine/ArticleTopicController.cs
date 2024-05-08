using Ams.Model.Content;
using Ams.Model.Dto;
using Ams.Service.Content.IService;
using Microsoft.AspNetCore.Mvc;

//创建时间：2024-04-29
namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 文章话题
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [ApiExplorerSettings(GroupName = "routine")]
    [Route("routine/article/topic")]
    public class ArticleTopicController : BaseController
    {
        /// <summary>
        /// 文章话题接口
        /// </summary>
        private readonly IArticleTopicService _ArticleTopicService;

        public ArticleTopicController(IArticleTopicService ArticleTopicService)
        {
            _ArticleTopicService = ArticleTopicService;
        }

        /// <summary>
        /// 查询文章话题列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:articletopic:list")]
        public IActionResult QueryArticleTopic([FromQuery] ArticleTopicQueryDto parm)
        {
            var response = _ArticleTopicService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询文章话题详情
        /// </summary>
        /// <param name="TopicId"></param>
        /// <returns></returns>
        [HttpGet("{TopicId}")]
        [ActionPermissionFilter(Permission = "routine:articletopic:query")]
        public IActionResult GetArticleTopic(long TopicId)
        {
            var response = _ArticleTopicService.GetInfo(TopicId);

            var info = response.Adapt<ArticleTopicDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加文章话题
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:articletopic:add")]
        [Log(Title = "文章话题", BusinessType = BusinessType.INSERT)]
        public IActionResult AddArticleTopic([FromBody] ArticleTopicDto parm)
        {
            var modal = parm.Adapt<ArticleTopic>().ToCreate(HttpContext);

            var response = _ArticleTopicService.AddArticleTopic(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新文章话题
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:articletopic:update")]
        [Log(Title = "文章话题", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateArticleTopic([FromBody] ArticleTopicDto parm)
        {
            var modal = parm.Adapt<ArticleTopic>().ToUpdate(HttpContext);
            var response = _ArticleTopicService.UpdateArticleTopic(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除文章话题
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "routine:articletopic:delete")]
        [Log(Title = "文章话题", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteArticleTopic([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_ArticleTopicService.Delete(idArr));
        }

        /// <summary>
        /// 导出文章话题
        /// </summary>
        /// <returns></returns>
        [Log(Title = "文章话题", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:articletopic:export")]
        public IActionResult Export([FromQuery] ArticleTopicQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ArticleTopicService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "文章话题", "文章话题");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}