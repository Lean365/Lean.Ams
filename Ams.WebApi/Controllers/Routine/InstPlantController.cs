using Microsoft.AspNetCore.Mvc;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 工厂代码
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:16:10
    /// </summary>
    [Verify]
    [Route("Routine/InstPlant")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class InstPlantController : BaseController
    {
        /// <summary>
        /// 工厂代码接口
        /// </summary>
        private readonly IInstPlantService _InstPlantService;

        public InstPlantController(IInstPlantService InstPlantService)
        {
            _InstPlantService = InstPlantService;
        }

        /// <summary>
        /// 查询工厂代码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:plant:list")]
        public IActionResult QueryInstPlant([FromQuery] InstPlantQueryDto parm)
        {
            var response = _InstPlantService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工厂代码详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "inst:plant:query")]
        public IActionResult GetInstPlant(long Id)
        {
            var response = _InstPlantService.GetInfo(Id);
            
            var info = response.Adapt<InstPlantDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加工厂代码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:plant:add")]
        [Log(Title = "工厂代码", BusinessType = BusinessType.ADD)]
        public IActionResult AddInstPlant([FromBody] InstPlantDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_InstPlantService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工厂代码 '{parm.Id}'失败(Add failed)，输入的工厂代码已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<InstPlant>().ToCreate(HttpContext);

            var response = _InstPlantService.AddInstPlant(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新工厂代码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:plant:edit")]
        [Log(Title = "工厂代码", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateInstPlant([FromBody] InstPlantDto parm)
        {
            var modal = parm.Adapt<InstPlant>().ToUpdate(HttpContext);
            var response = _InstPlantService.UpdateInstPlant(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工厂代码
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inst:plant:delete")]
        [Log(Title = "工厂代码", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstPlant([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_InstPlantService.Delete(idArr, "删除工厂代码"));
        }

        /// <summary>
        /// 导出工厂代码
        /// </summary>
        /// <returns></returns>
        [Log(Title = "工厂代码导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:plant:export")]
        public IActionResult Export([FromQuery] InstPlantQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstPlantService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "工厂代码", "工厂代码");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入工厂代码
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
      [HttpPost("importData")]
        [Log(Title = "工厂代码导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inst:plant:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<InstPlantDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InstPlantDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InstPlantService.ImportInstPlant(list.Adapt<List<InstPlant>>()));
        }

        /// <summary>
        /// 工厂代码
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "工厂代码模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InstPlantImportTpl>() { }, "InstPlant_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}