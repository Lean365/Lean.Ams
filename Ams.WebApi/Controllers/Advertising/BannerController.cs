using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Advertising
{
    /// <summary>
    /// 横幅广告
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [Verify]
    [Route("advertising/banner")]
    [ApiExplorerSettings(GroupName = "advertising")]
    public class BannerController : BaseController
    {
        /// <summary>
        /// 横幅广告接口
        /// </summary>
        private readonly IBannerService _BannerConfigService;

        public BannerController(IBannerService BannerConfigService)
        {
            _BannerConfigService = BannerConfigService;
        }

        /// <summary>
        /// 查询横幅广告列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "advertising:banner:list")]
        public IActionResult QueryBannerConfig([FromQuery] BannerQueryDto parm)
        {
            var response = _BannerConfigService.GetList(parm);
            return SUCCESS(response, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 查询横幅广告详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "advertising:banner:query")]
        public IActionResult GetBannerConfig(int Id)
        {
            var response = _BannerConfigService.GetInfo(Id);

            var info = response.Adapt<BannerDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加横幅广告
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "advertising:banner:add")]
        [Log(Title = "横幅广告", BusinessType = BusinessType.ADD)]
        public IActionResult AddBannerConfig([FromBody] BannerDto parm)
        {
            var modal = parm.Adapt<Banner>().ToCreate(HttpContext);

            var response = _BannerConfigService.AddBannerConfig(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新横幅广告
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "advertising:banner:edit")]
        [Log(Title = "横幅广告", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateBannerConfig([FromBody] BannerDto parm)
        {
            var modal = parm.Adapt<Banner>();
            var response = _BannerConfigService.UpdateBannerConfig(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除横幅广告
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "advertising:banner:delete")]
        [Log(Title = "横幅广告", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteBannerConfig([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_BannerConfigService.Delete(idArr, "删除横幅广告"));
        }

        /// <summary>
        /// 导出横幅广告
        /// </summary>
        /// <returns></returns>
        [Log(Title = "横幅广告", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "advertising:banner:export")]
        public IActionResult Export([FromQuery] BannerQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _BannerConfigService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "横幅广告", "横幅广告");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="value">排序值</param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "advertising:banner:update")]
        [HttpGet("ChangeSort")]
        [Log(Title = "保存排序", BusinessType = BusinessType.UPDATE)]
        public IActionResult ChangeSort(int id = 0, int value = 0)
        {
            if (id <= 0) { return ToResponse(ApiResult.Error(101, "请求参数错误")); }
            var response = _BannerConfigService.Update(w => w.SfId == id, it => new Banner()
            {
                SortingNum = value,
            });

            return ToResponse(response);
        }

        /// <summary>
        /// 查询横幅广告列表
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