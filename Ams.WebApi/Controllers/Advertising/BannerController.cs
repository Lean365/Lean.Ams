using Ams.Model.Advertising;
using Ams.Model.Dto.Advertising;
using Ams.Service.Advertising.IAdvertisingService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 广告管理
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/23 9:01:20
    /// </summary>
    [Verify]
    [Route("advertising/banner")]
    [ApiExplorerSettings(GroupName = "advertising")]
    public class BannerController : BaseController
    {
        /// <summary>
        /// 广告管理接口
        /// </summary>
        private readonly IBannerService _BannerService;

        public BannerController(IBannerService BannerService)
        {
            _BannerService = BannerService;
        }

        /// <summary>
        /// 查询广告管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "Banner:list")]
        public IActionResult QueryBanner([FromQuery] BannerQueryDto parm)
        {
            var response = _BannerService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询广告管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "Banner:query")]
        public IActionResult GetBanner(int Id)
        {
            var response = _BannerService.GetInfo(Id);

            var info = response.Adapt<BannerDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加广告管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "Banner:add")]
        [Log(Title = "广告管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddBanner([FromBody] BannerDto parm)
        {
            var modal = parm.Adapt<Banner>().ToCreate(HttpContext);

            var response = _BannerService.AddBanner(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新广告管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "Banner:edit")]
        [Log(Title = "广告管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateBanner([FromBody] BannerDto parm)
        {
            var modal = parm.Adapt<Banner>();
            var response = _BannerService.UpdateBanner(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除广告管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "Banner:delete")]
        [Log(Title = "广告管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteBanner([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_BannerService.Delete(idArr, "删除广告管理"));
        }

        /// <summary>
        /// 导出广告管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "广告管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "Banner:export")]
        public IActionResult Export([FromQuery] BannerQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _BannerService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "Banner:edit")]
        [HttpGet("ChangeSort")]
        [Log(Title = "保存排序", BusinessType = BusinessType.UPDATE)]
        public IActionResult ChangeSort(int id = 0, int value = 0)
        {
            if (id <= 0) { return ToResponse(ApiResult.Error(101, "请求参数错误")); }
            var response = _BannerService.Update(w => w.Id == id, it => new Banner()
            {
                SortId = value,
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
            var response = _BannerService.GetBannerList(parm);
            return SUCCESS(new { list = response });
        }
    }
}