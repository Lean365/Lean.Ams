//创建时间：2024-05-11
namespace Ams.WebApi.Controllers.Advert
{
    /// <summary>
    /// 广告管理
    /// </summary>
    [Verify]
    [Route("advert/banner")]
    public class BannerController : BaseController
    {
        /// <summary>
        /// 广告管理接口
        /// </summary>
        private readonly IBannerService _BannerConfigService;

        public BannerController(IBannerService BannerConfigService)
        {
            _BannerConfigService = BannerConfigService;
        }

        /// <summary>
        /// 查询广告管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "advert:banner:list")]
        public IActionResult QueryBannerConfig([FromQuery] BannerQueryDto parm)
        {
            var response = _BannerConfigService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询广告管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "advert:banner:query")]
        public IActionResult GetBannerConfig(int Id)
        {
            var response = _BannerConfigService.GetInfo(Id);

            var info = response.Adapt<BannerDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加广告管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "advert:banner:add")]
        [Log(Title = "广告管理", BusinessType = BusinessType.ADD)]
        public IActionResult AddBannerConfig([FromBody] BannerDto parm)
        {
            var modal = parm.Adapt<Banner>().ToCreate(HttpContext);

            var response = _BannerConfigService.AddBannerConfig(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新广告管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "advert:banner:edit")]
        [Log(Title = "广告管理", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateBannerConfig([FromBody] BannerDto parm)
        {
            var modal = parm.Adapt<Banner>();
            var response = _BannerConfigService.UpdateBannerConfig(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除广告管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "advert:banner:delete")]
        [Log(Title = "广告管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteBannerConfig([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_BannerConfigService.Delete(idArr, "删除广告管理"));
        }

        /// <summary>
        /// 导出广告管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "广告管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "advert:banner:export")]
        public IActionResult Export([FromQuery] BannerQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _BannerConfigService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "广告管理", "广告管理");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="value">排序值</param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "advert:banner:update")]
        [HttpGet("ChangeSort")]
        [Log(Title = "保存排序", BusinessType = BusinessType.UPDATE)]
        public IActionResult ChangeSort(int id = 0, int value = 0)
        {
            if (id <= 0) { return ToResponse(ApiResult.Error(101, "请求参数错误")); }
            var response = _BannerConfigService.Update(w => w.Id == id, it => new Banner()
            {
                Mb012 = value,
            });

            return ToResponse(response);
        }

        /// <summary>
        /// 查询广告管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("bannerList")]
        [AllowAnonymous]
        public IActionResult QueryBannerList([FromQuery] BannerQueryDto parm)
        {
            var response = _BannerConfigService.GetBannerList(parm);
            return SUCCESS(new { list = response });
        }
    }
}