using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 源订单序列号
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:43:48
    /// </summary>
    [Verify]
    [Route("Logistics/PpSourceOrderSerial")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpSourceOrderSerialController : BaseController
    {
        /// <summary>
        /// 源订单序列号接口
        /// </summary>
        private readonly IPpSourceOrderSerialService _PpSourceOrderSerialService;

        public PpSourceOrderSerialController(IPpSourceOrderSerialService PpSourceOrderSerialService)
        {
            _PpSourceOrderSerialService = PpSourceOrderSerialService;
        }

        /// <summary>
        /// 查询源订单序列号列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:sourceorderserial:list")]
        public IActionResult QueryPpSourceOrderSerial([FromQuery] PpSourceOrderSerialQueryDto parm)
        {
            var response = _PpSourceOrderSerialService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询源订单序列号详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:sourceorderserial:query")]
        public IActionResult GetPpSourceOrderSerial(long Id)
        {
            var response = _PpSourceOrderSerialService.GetInfo(Id);
            
            var info = response.Adapt<PpSourceOrderSerialDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加源订单序列号
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:sourceorderserial:add")]
        [Log(Title = "源订单序列号", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpSourceOrderSerial([FromBody] PpSourceOrderSerialDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpSourceOrderSerialService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增源订单序列号 '{parm.Id}'失败(Add failed)，输入的源订单序列号已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpSourceOrderSerial>().ToCreate(HttpContext);

            var response = _PpSourceOrderSerialService.AddPpSourceOrderSerial(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新源订单序列号
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:sourceorderserial:edit")]
        [Log(Title = "源订单序列号", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpSourceOrderSerial([FromBody] PpSourceOrderSerialDto parm)
        {
            var modal = parm.Adapt<PpSourceOrderSerial>().ToUpdate(HttpContext);
            var response = _PpSourceOrderSerialService.UpdatePpSourceOrderSerial(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除源订单序列号
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:sourceorderserial:delete")]
        [Log(Title = "源订单序列号", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpSourceOrderSerial([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpSourceOrderSerialService.Delete(idArr, "删除源订单序列号"));
        }

        /// <summary>
        /// 导出源订单序列号
        /// </summary>
        /// <returns></returns>
        [Log(Title = "源订单序列号导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:sourceorderserial:export")]
        public IActionResult Export([FromQuery] PpSourceOrderSerialQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpSourceOrderSerialService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "源订单序列号", "源订单序列号");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入源订单序列号
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "源订单序列号导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:sourceorderserial:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpSourceOrderSerialDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpSourceOrderSerialDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpSourceOrderSerialService.ImportPpSourceOrderSerial(list.Adapt<List<PpSourceOrderSerial>>()));
        }

        /// <summary>
        /// 源订单序列号
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "源订单序列号模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpSourceOrderSerialImportTpl>() { }, "PpSourceOrderSerial_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}