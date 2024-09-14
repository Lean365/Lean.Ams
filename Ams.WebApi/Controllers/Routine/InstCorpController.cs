using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 公司代码
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:19:56
    /// </summary>
    [Verify]
    [Route("Routine/InstCorp")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class InstCorpController : BaseController
    {
        /// <summary>
        /// 公司代码接口
        /// </summary>
        private readonly IInstCorpService _InstCorpService;

        public InstCorpController(IInstCorpService InstCorpService)
        {
            _InstCorpService = InstCorpService;
        }

        /// <summary>
        /// 查询公司代码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:corp:list")]
        public IActionResult QueryInstCorp([FromQuery] InstCorpQueryDto parm)
        {
            var response = _InstCorpService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询公司代码详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "inst:corp:query")]
        public IActionResult GetInstCorp(long Id)
        {
            var response = _InstCorpService.GetInfo(Id);
            
            var info = response.Adapt<InstCorpDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加公司代码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:corp:add")]
        [Log(Title = "公司代码", BusinessType = BusinessType.ADD)]
        public IActionResult AddInstCorp([FromBody] InstCorpDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstCorpService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增公司代码 '{parm.Id}'失败(Add failed)，输入的公司代码已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<InstCorp>().ToCreate(HttpContext);

            var response = _InstCorpService.AddInstCorp(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新公司代码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:corp:edit")]
        [Log(Title = "公司代码", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateInstCorp([FromBody] InstCorpDto parm)
        {
            var modal = parm.Adapt<InstCorp>().ToUpdate(HttpContext);
            var response = _InstCorpService.UpdateInstCorp(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除公司代码
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inst:corp:delete")]
        [Log(Title = "公司代码", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstCorp([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_InstCorpService.Delete(idArr, "删除公司代码"));
        }

        /// <summary>
        /// 导出公司代码
        /// </summary>
        /// <returns></returns>
        [Log(Title = "公司代码导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:corp:export")]
        public IActionResult Export([FromQuery] InstCorpQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstCorpService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "公司代码", "公司代码");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入公司代码
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "公司代码导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inst:corp:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<InstCorpDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstCorpDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstCorpService.ImportInstCorp(list.Adapt<List<InstCorp>>()));
        }

        /// <summary>
        /// 公司代码
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "公司代码模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstCorpImportTpl>() { }, "InstCorp_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}