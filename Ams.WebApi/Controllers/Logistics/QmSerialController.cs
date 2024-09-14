using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 序列号扫描
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:36:33
    /// </summary>
    [Verify]
    [Route("Logistics/QmSerial")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class QmSerialController : BaseController
    {
        /// <summary>
        /// 序列号扫描接口
        /// </summary>
        private readonly IQmSerialService _QmSerialService;

        public QmSerialController(IQmSerialService QmSerialService)
        {
            _QmSerialService = QmSerialService;
        }

        /// <summary>
        /// 查询序列号扫描列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:serial:list")]
        public IActionResult QueryQmSerial([FromQuery] QmSerialQueryDto parm)
        {
            var response = _QmSerialService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询序列号扫描详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "qm:serial:query")]
        public IActionResult GetQmSerial(int Id)
        {
            var response = _QmSerialService.GetInfo(Id);
            
            var info = response.Adapt<QmSerialDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加序列号扫描
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:serial:add")]
        [Log(Title = "序列号扫描", BusinessType = BusinessType.ADD)]
        public IActionResult AddQmSerial([FromBody] QmSerialDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_QmSerialService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增序列号扫描 '{parm.Id}'失败(Add failed)，输入的序列号扫描已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<QmSerial>().ToCreate(HttpContext);

            var response = _QmSerialService.AddQmSerial(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新序列号扫描
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:serial:edit")]
        [Log(Title = "序列号扫描", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateQmSerial([FromBody] QmSerialDto parm)
        {
            var modal = parm.Adapt<QmSerial>().ToUpdate(HttpContext);
            var response = _QmSerialService.UpdateQmSerial(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除序列号扫描
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:serial:delete")]
        [Log(Title = "序列号扫描", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmSerial([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_QmSerialService.Delete(idArr, "删除序列号扫描"));
        }

        /// <summary>
        /// 导出序列号扫描
        /// </summary>
        /// <returns></returns>
        [Log(Title = "序列号扫描导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:serial:export")]
        public IActionResult Export([FromQuery] QmSerialQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _QmSerialService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "序列号扫描", "序列号扫描");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入序列号扫描
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "序列号扫描导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "qm:serial:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<QmSerialDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<QmSerialDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_QmSerialService.ImportQmSerial(list.Adapt<List<QmSerial>>()));
        }

        /// <summary>
        /// 序列号扫描
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "序列号扫描模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<QmSerialImportTpl>() { }, "QmSerial_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}