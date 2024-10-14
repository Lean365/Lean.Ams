using Microsoft.AspNetCore.Mvc;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Logistics
{
    /// <summary>
    /// 技联
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/11 16:21:09
    /// </summary>
    [Verify]
    [Route("Logistics/PpEcLiaison")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class PpEcLiaisonController : BaseController
    {
        /// <summary>
        /// 技联接口
        /// </summary>
        private readonly IPpEcLiaisonService _PpEcLiaisonService;

        public PpEcLiaisonController(IPpEcLiaisonService PpEcLiaisonService)
        {
            _PpEcLiaisonService = PpEcLiaisonService;
        }

        /// <summary>
        /// 查询技联列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecliaison:list")]
        public IActionResult QueryPpEcLiaison([FromQuery] PpEcLiaisonQueryDto parm)
        {
            var response = _PpEcLiaisonService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询技联详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pp:ecliaison:query")]
        public IActionResult GetPpEcLiaison(long Id)
        {
            var response = _PpEcLiaisonService.GetInfo(Id);
            
            var info = response.Adapt<PpEcLiaisonDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加技联
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecliaison:add")]
        [Log(Title = "技联", BusinessType = BusinessType.ADD)]
        public IActionResult AddPpEcLiaison([FromBody] PpEcLiaisonDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcLiaisonService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增技联 '{parm.Id}'失败(Add failed)，输入的技联已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<PpEcLiaison>().ToCreate(HttpContext);

            var response = _PpEcLiaisonService.AddPpEcLiaison(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新技联
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecliaison:edit")]
        [Log(Title = "技联", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdatePpEcLiaison([FromBody] PpEcLiaisonDto parm)
        {
            var modal = parm.Adapt<PpEcLiaison>().ToUpdate(HttpContext);
            var response = _PpEcLiaisonService.UpdatePpEcLiaison(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除技联
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecliaison:delete")]
        [Log(Title = "技联", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcLiaison([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_PpEcLiaisonService.Delete(idArr, "删除技联"));
        }

        /// <summary>
        /// 导出技联
        /// </summary>
        /// <returns></returns>
        [Log(Title = "技联导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecliaison:export")]
        public IActionResult Export([FromQuery] PpEcLiaisonQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PpEcLiaisonService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "技联", "技联");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入技联
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "技联导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pp:ecliaison:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<PpEcLiaisonDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PpEcLiaisonDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PpEcLiaisonService.ImportPpEcLiaison(list.Adapt<List<PpEcLiaison>>()));
        }

        /// <summary>
        /// 技联
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "技联模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PpEcLiaisonImportTpl>() { }, "PpEcLiaison_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}