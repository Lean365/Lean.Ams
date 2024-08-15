using Ams.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.System
{
    /// <summary>
    /// 字典类别
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [Verify]
    [Route("system/dict/type")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysDictTypeController : BaseController
    {
        private readonly ISysDictTypeService SysDictService;

        public SysDictTypeController(ISysDictTypeService sysDictService)
        {
            SysDictService = sysDictService;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:list")]
        [HttpGet("list")]
        public IActionResult List([FromQuery] SysDictType dict, [FromQuery] PagerInfo pagerInfo)
        {
            var list = SysDictService.SelectDictTypeList(dict, pagerInfo);

            return SUCCESS(list, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 查询字典类别详细
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        [HttpGet("{dictId}")]
        [ActionPermissionFilter(Permission = "system:dict:query")]
        public IActionResult GetInfo(long dictId = 0)
        {
            return SUCCESS(SysDictService.GetInfo(dictId));
        }

        /// <summary>
        /// 添加字典类别
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:add")]
        [Log(Title = "字典操作", BusinessType = BusinessType.ADD)]
        [HttpPost("edit")]
        public IActionResult Add([FromBody] SysDictTypeDto dto)
        {
            SysDictType dict = dto.Adapt<SysDictType>();
            if (UserConstants.NOT_UNIQUE.Equals(SysDictService.CheckDictTypeUnique(dict)))
            {
                return ToResponse(ApiResult.Error($"新增字典'{dict.DictName}'失败，字典类别已存在"));
            }
            dict.Create_by = HttpContext.GetName();
            dict.Create_time = DateTime.Now;
            return SUCCESS(SysDictService.InsertDictType(dict));
        }

        /// <summary>
        /// 修改字典类别
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:edit")]
        [Log(Title = "字典操作", BusinessType = BusinessType.EDIT)]
        [Route("edit")]
        [HttpPut]
        public IActionResult Edit([FromBody] SysDictTypeDto dto)
        {
            SysDictType dict = dto.Adapt<SysDictType>();
            if (UserConstants.NOT_UNIQUE.Equals(SysDictService.CheckDictTypeUnique(dict)))
            {
                return ToResponse(ApiResult.Error($"修改字典'{dict.DictName}'失败，字典类别已存在"));
            }
            //设置添加人
            dict.Update_by = HttpContext.GetName();
            return SUCCESS(SysDictService.UpdateDictType(dict));
        }

        /// <summary>
        /// 删除字典类别
        /// </summary>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:delete")]
        [Log(Title = "删除字典类别", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{ids}")]
        public IActionResult Remove(string ids)
        {
            long[] idss = Tools.SpitLongArrary(ids);

            return SUCCESS(SysDictService.DeleteDictTypeByIds(idss));
        }

        /// <summary>
        /// 字典导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "字典导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "system:dict:export")]
        public IActionResult Export()
        {
            var list = SysDictService.GetAll();

            string sFileName = ExportExcel(list, "DictType", "字典");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}