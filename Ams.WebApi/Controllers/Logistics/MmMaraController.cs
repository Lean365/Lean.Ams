using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 常规物料
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 10:59:57
    /// </summary>
    [Verify]
    [Route("Logistics/MmMara")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class MmMaraController : BaseController
    {
        /// <summary>
        /// 常规物料接口
        /// </summary>
        private readonly IMmMaraService _MmMaraService;

        public MmMaraController(IMmMaraService MmMaraService)
        {
            _MmMaraService = MmMaraService;
        }

        /// <summary>
        /// 查询常规物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:mara:list")]
        public IActionResult QueryMmMara([FromQuery] MmMaraQueryDto parm)
        {
            var response = _MmMaraService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询常规物料详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "mm:mara:query")]
        public IActionResult GetMmMara(long Id)
        {
            var response = _MmMaraService.GetInfo(Id);
            
            var info = response.Adapt<MmMaraDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加常规物料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:mara:add")]
        [Log(Title = "常规物料", BusinessType = BusinessType.ADD)]
        public IActionResult AddMmMara([FromBody] MmMaraDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_MmMaraService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增常规物料 '{parm.Id}'失败(Add failed)，输入的常规物料已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<MmMara>().ToCreate(HttpContext);

            var response = _MmMaraService.AddMmMara(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新常规物料
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:mara:edit")]
        [Log(Title = "常规物料", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateMmMara([FromBody] MmMaraDto parm)
        {
            var modal = parm.Adapt<MmMara>().ToUpdate(HttpContext);
            var response = _MmMaraService.UpdateMmMara(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除常规物料
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "mm:mara:delete")]
        [Log(Title = "常规物料", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMara([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_MmMaraService.Delete(idArr, "删除常规物料"));
        }

        /// <summary>
        /// 导出常规物料
        /// </summary>
        /// <returns></returns>
        [Log(Title = "常规物料导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:mara:export")]
        public IActionResult Export([FromQuery] MmMaraQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MmMaraService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "常规物料", "常规物料");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入常规物料
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "常规物料导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "mm:mara:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<MmMaraDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MmMaraDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MmMaraService.ImportMmMara(list.Adapt<List<MmMara>>()));
        }

        /// <summary>
        /// 常规物料
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "常规物料模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MmMaraImportTpl>() { }, "MmMara_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}