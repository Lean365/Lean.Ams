using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Statistics.Logistics.Controllers
{
    /// <summary>
    /// 物料号码
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/marb")]
    [ApiExplorerSettings(GroupName = "statistics")]
    public class MaterialStatiControllers : BaseController
    {
        private readonly IMaterialStatiService _MaterialStatiService;

        /// <summary>
        /// 物料号码接口
        /// </summary>
        public MaterialStatiControllers(IMaterialStatiService MaterialStatiService)
        {
            _MaterialStatiService = MaterialStatiService;
        }

        /// <summary>
        /// 按类型生成物料号码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("NewMaterialNumber")]
        [ActionPermissionFilter(Permission = "mm:marb:add")]
        public IActionResult QueryMaterialNumber([FromQuery] MmMaraQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _MaterialStatiService.GetNewMaterialNumber(parm);
            return SUCCESS(response);
        }
    }
}