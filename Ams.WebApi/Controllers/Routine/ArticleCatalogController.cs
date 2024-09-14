namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 文章目录Controller
    /// </summary>
    [Route("routine/article/catalog")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class ArticleCatalogController : BaseController
    {
        /// <summary>
        /// 文章目录接口
        /// </summary>
        private readonly IArticleCatalogService _ArticleCategoryService;

        public ArticleCatalogController(IArticleCatalogService ArticleCategoryService)
        {
            _ArticleCategoryService = ArticleCategoryService;
        }

        /// <summary>
        /// 查询文章目录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [AllowAnonymous]
        public IActionResult QueryArticleCategory([FromQuery] ArticleCatalogQueryDto parm)
        {
            var response = _ArticleCategoryService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询文章目录列表树
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("treeList")]
        [AllowAnonymous]
        public IActionResult QueryTreeArticleCategory([FromQuery] ArticleCatalogQueryDto parm)
        {
            var response = _ArticleCategoryService.GetTreeList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询文章目录详情
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpGet("{CategoryId}")]
        [AllowAnonymous]
        public IActionResult GetArticleCategory(int CategoryId)
        {
            var response = _ArticleCategoryService.GetFirst(x => x.CategoryId == CategoryId);

            return SUCCESS(response);
        }

        /// <summary>
        /// 查询目录分类
        /// </summary>
        /// <param name="categoryType"></param>
        /// <returns></returns>
        [HttpGet("type{categoryType}")]
        public IActionResult GetArticleCategoryByType(int categoryType)
        {
            var response = _ArticleCategoryService.GetFirst(x => x.CategoryType == categoryType);

            return SUCCESS(response);
        }

        /// <summary>
        /// 添加文章目录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Verify]
        [ActionPermissionFilter(Permission = "article:catalog:add")]
        [Log(Title = "文章目录", BusinessType = BusinessType.ADD)]
        public IActionResult AddArticleCategory([FromBody] ArticleCatalogDto parm)
        {
            var modal = parm.Adapt<ArticleCatalog>().ToCreate(HttpContext);
            var response = _ArticleCategoryService.AddArticleCategory(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新文章目录
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Verify]
        [ActionPermissionFilter(Permission = "article:catalog:edit")]
        [Log(Title = "文章目录", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateArticleCategory([FromBody] ArticleCatalogDto parm)
        {
            var modal = parm.Adapt<ArticleCatalog>().ToUpdate(HttpContext);
            var response = _ArticleCategoryService.Update(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除文章目录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "article:catalog:delete")]
        [Log(Title = "文章目录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteArticleCategory(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _ArticleCategoryService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出文章目录
        /// </summary>
        /// <returns></returns>
        [Log(Title = "文章目录", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "article:catalog:export")]
        public IActionResult Export([FromQuery] ArticleCatalogQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _ArticleCategoryService.GetList(parm).Result;

            string sFileName = ExportExcel(list, "ArticleCatalog", "文章目录");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 获取文章目录,前端没用到
        /// </summary>
        /// <returns></returns>
        [HttpGet("CategoryList")]
        public IActionResult CategoryList()
        {
            var response = _ArticleCategoryService.GetAll();
            return SUCCESS(response);
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "article:catalog:update")]
        [HttpGet("ChangeSort")]
        [Log(Title = "保存排序", BusinessType = BusinessType.UPDATE)]
        public IActionResult ChangeSort(int id = 0, int value = 0)
        {
            if (id <= 0) { return ToResponse(ApiResult.Error(101, "请求参数错误")); }
            var response = _ArticleCategoryService.Update(w => w.CategoryId == id, it => new ArticleCatalog()
            {
                CategoryId = id,
                SortingNum = value
            });
            return ToResponse(response);
        }
    }
}