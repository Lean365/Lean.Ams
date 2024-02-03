using Ams.Infrastructure.Controllers;
using Ams.Kernel.Filters;
using Ams.Model.Dto;
using Microsoft.AspNetCore.Mvc;
namespace Ams.Report.Logistics.mm
{
    /// <summary>
    /// 物料号码
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [Verify]
    [Route("stat/marb")]
    [ApiExplorerSettings(GroupName = "stat")]
    public class MaterialNoController : BaseController
    {

        private readonly IMaterialNoService _MaterialNoService;
        /// <summary>
        /// 物料号码接口
        /// </summary>
        public MaterialNoController(IMaterialNoService IMaterialNoService)
        {
            _MaterialNoService = IMaterialNoService;
        }
        /// <summary>
        /// 按类型生成物料号码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("MaterialNo")]
        [ActionPermissionFilter(Permission = "mm:marb:list")]
        public IActionResult GetMaterialNo([FromQuery] MarbQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）

            var response = _MaterialNoService.QueryMaterialNo(parm);
            return SUCCESS(response);
        }
    }
}
