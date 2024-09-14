using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 生产班组
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:06:17
    /// </summary>
    [Verify]
    [Route("Logistics/PpMasterWorkshop")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpMasterWorkshopController : BaseController
    {
        /// <summary>
        /// 生产班组接口
        /// </summary>
        private readonly IPpMasterWorkshopService _PpMasterWorkshopService;

        public PpMasterWorkshopController(IPpMasterWorkshopService PpMasterWorkshopService)
        {
            _PpMasterWorkshopService = PpMasterWorkshopService;
        }

        /// <summary>
        /// 查询生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:masterworkshop:list")]
        public IActionResult QueryPpMasterWorkshop([FromQuery] PpMasterWorkshopQueryDto parm)
        {
            var response = _PpMasterWorkshopService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生产班组详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:masterworkshop:query")]
        public IActionResult GetPpMasterWorkshop(long Id)
        {
            var response = _PpMasterWorkshopService.GetInfo(Id);
            
            var info = response.Adapt<PpMasterWorkshopDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:masterworkshop:add")]
        [Log(Title = "生产班组", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpMasterWorkshop([FromBody] PpMasterWorkshopDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpMasterWorkshopService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增生产班组 '{parm.Id}'失败(Add failed)，输入的生产班组已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpMasterWorkshop>().ToCreate(HttpContext);

            var response = _PpMasterWorkshopService.AddPpMasterWorkshop(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:masterworkshop:edit")]
        [Log(Title = "生产班组", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpMasterWorkshop([FromBody] PpMasterWorkshopDto parm)
        {
            var modal = parm.Adapt<PpMasterWorkshop>().ToUpdate(HttpContext);
            var response = _PpMasterWorkshopService.UpdatePpMasterWorkshop(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产班组
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:masterworkshop:delete")]
        [Log(Title = "生产班组", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpMasterWorkshop([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpMasterWorkshopService.Delete(idArr, "删除生产班组"));
        }

        /// <summary>
        /// 导出生产班组
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产班组导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:masterworkshop:export")]
        public IActionResult Export([FromQuery] PpMasterWorkshopQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpMasterWorkshopService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产班组", "生产班组");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入生产班组
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "生产班组导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:masterworkshop:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpMasterWorkshopDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpMasterWorkshopDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpMasterWorkshopService.ImportPpMasterWorkshop(list.Adapt<List<PpMasterWorkshop>>()));
        }

        /// <summary>
        /// 生产班组
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生产班组模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpMasterWorkshopImportTpl>() { }, "PpMasterWorkshop_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}