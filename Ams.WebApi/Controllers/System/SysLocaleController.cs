using Ams.Model;
using Microsoft.AspNetCore.Mvc;
using MiniExcelLibs;

namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 本地语言
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("system/locale")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysLocaleController : BaseController
    {
        /// <summary>
        /// 本地语言接口
        /// </summary>
        private readonly ISysLocaleService _SysLocaleService;

        public SysLocaleController(ISysLocaleService SysLocaleService)
        {
            _SysLocaleService = SysLocaleService;
        }

        /// <summary>
        /// 查询本地语言列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "system:lang:list")]
        public IActionResult QuerySysLocale([FromQuery] SysLocaleQueryDto parm)
        {
            if (parm.ShowMode == 2)
            {
                PagedInfo<dynamic> pagedInfo = new()
                {
                    Result = _SysLocaleService.GetListToPivot(parm)
                };

                return SUCCESS(pagedInfo);
            }

            return SUCCESS(_SysLocaleService.GetList(parm));
        }

        /// <summary>
        /// 查询本地语言列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/{lang}")]
        [AllowAnonymous]
        public IActionResult QuerySysLocales(string lang)
        {
            var msgList = _SysLocaleService.GetLangList(new SysLocaleQueryDto() { LangCode = lang });

            return SUCCESS(_SysLocaleService.SetLang(msgList));
        }

        /// <summary>
        /// 查询本地语言详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "system:lang:query")]
        public IActionResult GetSysLocale(long Id)
        {
            var response = _SysLocaleService.GetFirst(x => x.Id == Id);

            var list = _SysLocaleService.GetList(x => x.LangKey == response.LangKey);
            var vo = list.Adapt<List<SysLocaleDto>>();
            var modal = new SysLocaleDto() { LangKey = response.LangKey, LangList = vo };
            return SUCCESS(modal);
        }

        /// <summary>
        /// 查询本地语言详情
        /// </summary>
        /// <param name="langKey"></param>
        /// <returns></returns>
        [HttpGet("key/{langKey}")]
        [ActionPermissionFilter(Permission = "system:lang:query")]
        public IActionResult GetSysLocaleByKey(string langKey)
        {
            var list = _SysLocaleService.GetList(x => x.LangKey == langKey);
            var vo = list.Adapt<List<SysLocaleDto>>();
            var modal = new SysLocaleDto() { LangKey = langKey, LangList = vo };

            return SUCCESS(modal);
        }

        /// <summary>
        /// 更新本地语言
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "system:lang:update")]
        [Log(Title = "本地语言", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysLocale([FromBody] SysLocaleDto parm)
        {
            if (parm == null || parm.LangKey.IsEmpty())
            {
                throw new CustomException("请求实体不能为空");
            }

            _SysLocaleService.StorageSysLocale(parm);

            return ToResponse(1);
        }

        /// <summary>
        /// 删除本地语言
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "system:lang:delete")]
        [Log(Title = "本地语言", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysLocale(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysLocaleService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除本地语言
        /// </summary>
        /// <returns></returns>
        [HttpDelete("ByKey")]
        [ActionPermissionFilter(Permission = "system:lang:delete")]
        [Log(Title = "本地语言", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysLocaleByKey(string langkey)
        {
            if (langkey.IsEmpty()) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysLocaleService
                .Deleteable()
                .EnableDiffLogEvent()
                .Where(f => f.LangKey == langkey)
                .ExecuteCommand();
            return ToResponse(response);
        }

        /// <summary>
        /// 导出本地语言
        /// </summary>
        /// <returns></returns>
        [Log(Title = "本地语言", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "system:lang:export")]
        public IActionResult Export([FromQuery] SysLocaleQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _SysLocaleService.GetListToPivot(parm);

            string sFileName = ExportExcel(list, "SysLocale", "本地语言");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "多语言设置导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false, IsSaveResponseData = true)]
        [ActionPermissionFilter(Permission = "system:lang:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SysLocale> list = new();
            var nowTime = DateTime.Now;
            using (var stream = formFile.OpenReadStream())
            {
                var rows = stream.Query(startCell: "A2").ToList();

                foreach (var item in rows)
                {
                    list.Add(new SysLocale() { LangCode = "zh-cn", LangKey = item.A, LangName = item.B, Create_time = nowTime });
                    list.Add(new SysLocale() { LangCode = "zh-tw", LangKey = item.A, LangName = item.C, Create_time = nowTime });
                    list.Add(new SysLocale() { LangCode = "ja", LangKey = item.A, LangName = item.D, Create_time = nowTime });
                    list.Add(new SysLocale() { LangCode = "en", LangKey = item.A, LangName = item.E, Create_time = nowTime });
                }
            }

            return SUCCESS(_SysLocaleService.ImportSysLocale(list));
        }

        /// <summary>
        /// 多语言设置导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "多语言设置模板", BusinessType = BusinessType.EXPORT, IsSaveRequestData = true, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SysLocale>() { }, "lang");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}