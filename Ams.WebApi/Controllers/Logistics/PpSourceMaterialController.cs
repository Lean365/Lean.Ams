using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 源物料
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:36:27
    /// </summary>
    [Verify]
    [Route("Logistics/PpSourceMaterial")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpSourceMaterialController : BaseController
    {
        /// <summary>
        /// 源物料接口
        /// </summary>
        private readonly IPpSourceMaterialService _PpSourceMaterialService;

        public PpSourceMaterialController(IPpSourceMaterialService PpSourceMaterialService)
        {
            _PpSourceMaterialService = PpSourceMaterialService;
        }

        /// <summary>
        /// 查询源物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:sourcematerial:list")]
        public IActionResult QueryPpSourceMaterial([FromQuery] PpSourceMaterialQueryDto parm)
        {
            var response = _PpSourceMaterialService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询源物料详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:sourcematerial:query")]
        public IActionResult GetPpSourceMaterial(long Id)
        {
            var response = _PpSourceMaterialService.GetInfo(Id);
            
            var info = response.Adapt<PpSourceMaterialDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加源物料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:sourcematerial:add")]
        [Log(Title = "源物料", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpSourceMaterial([FromBody] PpSourceMaterialDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpSourceMaterialService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增源物料 '{parm.Id}'失败(Add failed)，输入的源物料已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpSourceMaterial>().ToCreate(HttpContext);

            var response = _PpSourceMaterialService.AddPpSourceMaterial(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新源物料
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:sourcematerial:edit")]
        [Log(Title = "源物料", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpSourceMaterial([FromBody] PpSourceMaterialDto parm)
        {
            var modal = parm.Adapt<PpSourceMaterial>().ToUpdate(HttpContext);
            var response = _PpSourceMaterialService.UpdatePpSourceMaterial(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除源物料
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:sourcematerial:delete")]
        [Log(Title = "源物料", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpSourceMaterial([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpSourceMaterialService.Delete(idArr, "删除源物料"));
        }

        /// <summary>
        /// 导出源物料
        /// </summary>
        /// <returns></returns>
        [Log(Title = "源物料导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:sourcematerial:export")]
        public IActionResult Export([FromQuery] PpSourceMaterialQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpSourceMaterialService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "源物料", "源物料");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入源物料
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "源物料导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:sourcematerial:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpSourceMaterialDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpSourceMaterialDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpSourceMaterialService.ImportPpSourceMaterial(list.Adapt<List<PpSourceMaterial>>()));
        }

        /// <summary>
        /// 源物料
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "源物料模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpSourceMaterialImportTpl>() { }, "PpSourceMaterial_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}