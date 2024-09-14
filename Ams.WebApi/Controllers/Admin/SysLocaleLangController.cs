namespace Ams.WebApi.Controllers.System
{
    /// <summary>
    /// 本地语言Controller
    /// 
    /// </summary>
    [Verify]
    [Route("system/locale/lang")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysLocaleLangController : BaseController
    {
        /// <summary>
        /// 本地语言接口
        /// </summary>
        private readonly ISysLocaleLangService _SysLocaleLangService;

        public SysLocaleLangController(ISysLocaleLangService SysLocaleLangService)
        {
            _SysLocaleLangService = SysLocaleLangService;
        }

        /// <summary>
        /// 查询本地语言列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "system:lang:list")]
        public IActionResult QuerySysLocaleLang([FromQuery] SysLocaleLangQueryDto parm)
        {
            if (parm.ShowMode == 2)
            {
                PagedInfo<dynamic> pagedInfo = new()
                {
                    Result = _SysLocaleLangService.GetListToPivot(parm)
                };

                return SUCCESS(pagedInfo);
            }

            return SUCCESS(_SysLocaleLangService.GetList(parm));
        }

        /// <summary>
        /// 查询本地语言列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/{lang}")]
        [AllowAnonymous]
        public IActionResult QuerySysLocaleLangs(string lang)
        {
            var msgList = _SysLocaleLangService.GetLangList(new SysLocaleLangQueryDto() { LangCode = lang });

            return SUCCESS(_SysLocaleLangService.SetLang(msgList));
        }

        /// <summary>
        /// 查询本地语言详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "system:lang:query")]
        public IActionResult GetSysLocaleLang(long Id)
        {
            var response = _SysLocaleLangService.GetFirst(x => x.Id == Id);

            var list = _SysLocaleLangService.GetList(x => x.LangKey == response.LangKey);
            var vo = list.Adapt<List<SysLocaleLangDto>>();
            var modal = new SysLocaleLangDto() { LangKey = response.LangKey, LangList = vo };
            return SUCCESS(modal);
        }

        /// <summary>
        /// 查询本地语言详情
        /// </summary>
        /// <param name="langKey"></param>
        /// <returns></returns>
        [HttpGet("key/{langKey}")]
        [ActionPermissionFilter(Permission = "system:lang:query")]
        public IActionResult GetSysLocaleLangByKey(string langKey)
        {
            var list = _SysLocaleLangService.GetList(x => x.LangKey == langKey);
            var vo = list.Adapt<List<SysLocaleLangDto>>();
            var modal = new SysLocaleLangDto() { LangKey = langKey, LangList = vo };

            return SUCCESS(modal);
        }

        /// <summary>
        /// 更新本地语言
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "system:lang:edit")]
        [Log(Title = "本地语言", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateSysLocaleLang([FromBody] SysLocaleLangDto parm)
        {
            if (parm == null || parm.LangKey.IsEmpty())
            {
                throw new CustomException("请求实体不能为空");
            }

            _SysLocaleLangService.StorageSysLocaleLang(parm);

            return ToResponse(1);
        }

        /// <summary>
        /// 删除本地语言
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "system:lang:delete")]
        [Log(Title = "本地语言", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysLocaleLang(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysLocaleLangService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除本地语言
        /// </summary>
        /// <returns></returns>
        [HttpDelete("ByKey")]
        [ActionPermissionFilter(Permission = "system:lang:delete")]
        [Log(Title = "本地语言", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysLocaleLangByKey(string langkey)
        {
            if (langkey.IsEmpty()) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysLocaleLangService
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
        public IActionResult Export([FromQuery] SysLocaleLangQueryDto parm)
        {
            parm.PageSize = 10000;
            var list = _SysLocaleLangService.GetListToPivot(parm);

            string sFileName = ExportExcel(list, "SysLocaleLang", "本地语言");
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
            List<SysLocaleLang> list = new();
            var nowTime = DateTime.Now;
            using (var stream = formFile.OpenReadStream())
            {
                var rows = stream.Query(startCell: "A2").ToList();

                foreach (var item in rows)
                {
                    list.Add(new SysLocaleLang() { LangCode = "zh-cn", LangKey = item.A, LangName = item.B, Create_time = nowTime });
                    list.Add(new SysLocaleLang() { LangCode = "en", LangKey = item.A, LangName = item.C, Create_time = nowTime });
                    list.Add(new SysLocaleLang() { LangCode = "zh-tw", LangKey = item.A, LangName = item.D, Create_time = nowTime });
                }
            }

            return SUCCESS(_SysLocaleLangService.ImportSysLocaleLang(list));
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
            var result = DownloadImportTemplate(new List<SysLocaleLang>() { }, "lang");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}