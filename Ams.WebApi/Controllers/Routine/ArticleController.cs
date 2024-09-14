namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 内容管理
    /// </summary>
    [Verify]
    [Route("routine/article")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class ArticleController : BaseController
    {
        /// <summary>
        /// 文章接口
        /// </summary>
        private readonly IArticleService _ArticleService;

        private readonly IArticleCatalogService _ArticleCategoryService;

        public ArticleController(
            IArticleService ArticleService,
            IArticleCatalogService articleCategoryService)
        {
            _ArticleService = ArticleService;
            _ArticleCategoryService = articleCategoryService;
            _ArticleService = ArticleService;
        }

        /// <summary>
        /// 查询文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:article:list")]
        public IActionResult Query([FromQuery] ArticleQueryDto parm)
        {
            var response = _ArticleService.GetList(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 内容批量审核通过
        /// </summary>
        /// <returns></returns>
        [HttpPut("pass/{ids}")]
        [ActionPermissionFilter(Permission = "routine:article:audit")]
        [Log(Title = "内容审核", BusinessType = BusinessType.AUDIT)]
        public IActionResult PassedMonents(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"审核通过失败Id 不能为空")); }

            return ToResponse(_ArticleService.Passed(idsArr));
        }

        /// <summary>
        /// 内容批量审核拒绝
        /// </summary>
        /// <returns></returns>
        [HttpPut("reject/{ids}")]
        [ActionPermissionFilter(Permission = "routine:article:reject")]
        [Log(Title = "内容审核", BusinessType = BusinessType.REJECT)]
        public IActionResult RejectMonents(string ids, string reason = "")
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"審核拒绝失败Id 不能为空")); }

            int result = _ArticleService.Reject(reason, idsArr);
            return ToResponse(result);
        }

        /// <summary>
        /// 查询我的文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("mylist")]
        public IActionResult QueryMyList([FromQuery] ArticleQueryDto parm)
        {
            parm.UserId = HttpContext.GetUId();
            var response = _ArticleService.GetMyList(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 查询文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            long userId = HttpContext.GetUId();
            var model = _ArticleService.GetArticle(id, userId);

            ApiResult apiResult = ApiResult.Success(model);

            return ToResponse(apiResult);
        }

        /// <summary>
        /// 发布文章
        /// </summary>
        /// <returns></returns>
        [HttpPost("add")]
        [ActionPermissionFilter(Permission = "routine:article:puhlish")]
        public IActionResult Create([FromBody] ArticleDto parm)
        {
            var addModel = parm.Adapt<Article>().ToCreate(context: HttpContext);
            addModel.AuthorName = HttpContext.GetName();
            addModel.UserId = HttpContext.GetUId();
            addModel.UserIP = HttpContext.GetClientUserIp();
            addModel.Location = HttpContextExtension.GetIpInfo(addModel.UserIP);
            addModel.AuditStatus = AuditStatusEnum.Passed;

            return SUCCESS(_ArticleService.InsertReturnIdentity(addModel));
        }

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <returns></returns>
        [HttpPut("edit")]
        [ActionPermissionFilter(Permission = "routine:article:update")]
        public IActionResult Update([FromBody] ArticleDto parm)
        {
            parm.AuthorName = HttpContext.GetName();
            var modal = parm.Adapt<Article>().ToUpdate(HttpContext);
            var response = _ArticleService.UpdateArticle(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <returns></returns>
        [HttpPut("top")]
        [ActionPermissionFilter(Permission = "routine:article:update")]
        [Log(Title = "置顶文章", BusinessType = BusinessType.UPDATE)]
        public IActionResult Top([FromBody] Article parm)
        {
            var response = _ArticleService.TopArticle(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 是否公开
        /// </summary>
        /// <returns></returns>
        [HttpPut("changePublic")]
        [ActionPermissionFilter(Permission = "routine:article:update")]
        [Log(Title = "是否公开", BusinessType = BusinessType.UPDATE)]
        public IActionResult ChangePublic([FromBody] Article parm)
        {
            var response = _ArticleService.ChangeArticlePublic(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ActionPermissionFilter(Permission = "routine:article:delete")]
        [Log(Title = "文章删除", BusinessType = BusinessType.DELETE)]
        public IActionResult Delete(int id = 0)
        {
            var response = _ArticleService.Delete(id);
            return SUCCESS(response);
        }
    }
}