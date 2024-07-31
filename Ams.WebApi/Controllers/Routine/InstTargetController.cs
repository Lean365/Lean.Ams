using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 机构目标
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 10:30:14
    /// </summary>
    [Verify]
    [Route("Routine/InstTarget")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class InstTargetController : BaseController
    {
        /// <summary>
        /// 机构目标接口
        /// </summary>
        private readonly IInstTargetService _InstTargetService;

        public InstTargetController(IInstTargetService InstTargetService)
        {
            _InstTargetService = InstTargetService;
        }

        /// <summary>
        /// 查询机构目标列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:target:list")]
        public IActionResult QueryInstTarget([FromQuery] InstTargetQueryDto parm)
        {
            var response = _InstTargetService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询机构目标详情
        /// </summary>
        /// <param name="IkSfId"></param>
        /// <returns></returns>
        [HttpGet("{IkSfId}")]
        [ActionPermissionFilter(Permission = "inst:target:query")]
        public IActionResult GetInstTarget(long IkSfId)
        {
            var response = _InstTargetService.GetInfo(IkSfId);
            
            var info = response.Adapt<InstTargetDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加机构目标
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:target:add")]
        [Log(Title = "机构目标", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInstTarget([FromBody] InstTargetDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstTargetService.CheckInputUnique(parm.IkSfId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增机构目标 '{parm.IkSfId}'失败(Add failed)，输入的机构目标已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<InstTarget>().ToCreate(HttpContext);

            var response = _InstTargetService.AddInstTarget(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新机构目标
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:target:edit")]
        [Log(Title = "机构目标", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInstTarget([FromBody] InstTargetDto parm)
        {
            var modal = parm.Adapt<InstTarget>().ToUpdate(HttpContext);
            var response = _InstTargetService.UpdateInstTarget(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除机构目标
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inst:target:delete")]
        [Log(Title = "机构目标", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstTarget([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_InstTargetService.Delete(idArr, "删除机构目标"));
        }

        /// <summary>
        /// 导出机构目标
        /// </summary>
        /// <returns></returns>
        [Log(Title = "机构目标", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:target:export")]
        public IActionResult Export([FromQuery] InstTargetQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstTargetService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "机构目标", "机构目标");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "机构目标导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inst:target:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<InstTargetDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstTargetDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstTargetService.ImportInstTarget(list.Adapt<List<InstTarget>>()));
        }

        /// <summary>
        /// 机构目标导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "机构目标模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstTargetImportTpl>() { }, "InstTarget_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}