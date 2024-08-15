using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 生产工单
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:07:48
    /// </summary>
    [Verify]
    [Route("Logistics/PpOrder")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpOrderController : BaseController
    {
        /// <summary>
        /// 生产工单接口
        /// </summary>
        private readonly IPpOrderService _PpOrderService;

        public PpOrderController(IPpOrderService PpOrderService)
        {
            _PpOrderService = PpOrderService;
        }

        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:order:list")]
        public IActionResult QueryPpOrder([FromQuery] PpOrderQueryDto parm)
        {
            var response = _PpOrderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生产工单详情
        /// </summary>
        /// <param name="MoSfId"></param>
        /// <returns></returns>
        [HttpGet("{MoSfId}")]
        [ActionPermissionFilter(Permission = "pp:order:query")]
        public IActionResult GetPpOrder(long MoSfId)
        {
            var response = _PpOrderService.GetInfo(MoSfId);
            
            var info = response.Adapt<PpOrderDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:order:add")]
        [Log(Title = "生产工单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOrder([FromBody] PpOrderDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpOrderService.CheckInputUnique(parm.MoSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增生产工单 '{parm.MoSfId}'失败(Add failed)，输入的生产工单已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpOrder>().ToCreate(HttpContext);

            var response = _PpOrderService.AddPpOrder(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:order:edit")]
        [Log(Title = "生产工单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOrder([FromBody] PpOrderDto parm)
        {
            var modal = parm.Adapt<PpOrder>().ToUpdate(HttpContext);
            var response = _PpOrderService.UpdatePpOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产工单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:order:delete")]
        [Log(Title = "生产工单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOrder([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpOrderService.Delete(idArr, "删除生产工单"));
        }

        /// <summary>
        /// 导出生产工单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产工单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:order:export")]
        public IActionResult Export([FromQuery] PpOrderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpOrderService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产工单", "生产工单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生产工单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:order:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PpOrderDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpOrderDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpOrderService.ImportPpOrder(list.Adapt<List<PpOrder>>()));
        }

        /// <summary>
        /// 生产工单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生产工单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpOrderImportTpl>() { }, "PpOrder_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}