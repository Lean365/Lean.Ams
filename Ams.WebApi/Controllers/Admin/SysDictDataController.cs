using Newtonsoft.Json;

namespace Ams.WebApi.Controllers.System
{
    /// <summary>
    /// 数据字典信息
    /// </summary>
    [Verify]
    [Route("system/dict/data")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysDictDataController : BaseController
    {
        private readonly ISysDictDataService SysDictDataService;
        private readonly ISysDictTypeService SysDictService;

        public SysDictDataController(ISysDictTypeService sysDictService, ISysDictDataService sysDictDataService)
        {
            SysDictService = sysDictService;
            SysDictDataService = sysDictDataService;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="dictData"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:list")]
        [HttpGet("list")]
        public IActionResult List([FromQuery] SysDictData dictData, [FromQuery] PagerInfo pagerInfo)
        {
            var list = SysDictDataService.SelectDictDataList(dictData, pagerInfo);

            if (dictData.DictType.StartsWith("sql_"))
            {
                var result = SysDictService.SelectDictDataByCustomSql(dictData.DictType);

                list.Result.AddRange(result.Adapt<List<SysDictData>>());
                list.TotalNum += result.Count;
            }
            return SUCCESS(list);
        }

        /// <summary>
        /// 根据字典类型查询字典数据信息
        /// </summary>
        /// <param name="dictType"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("type/{dictType}")]
        public IActionResult DictType(string dictType)
        {
            return SUCCESS(SysDictDataService.SelectDictDataByType(dictType));
        }

        /// <summary>
        /// 根据字典类型查询字典数据信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("types")]
        public IActionResult DictTypes([FromBody] List<SysDictDataParamDto> dto)
        {
            var list = SysDictDataService.SelectDictDataByTypes(dto.Select(f => f.DictType).ToArray());
            var dataVos = GetDicts(dto.Select(f => f.DictType).ToArray());

            return SUCCESS(dataVos);
        }

        /// <summary>
        /// 移动端使用uniapp
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("dicts")]
        public IActionResult GetDictTypes()
        {
            var data = HttpContext.GetBody();
            return SUCCESS(GetDicts(JsonConvert.DeserializeObject<string[]>(data)));
        }

        private List<SysDictDataParamDto> GetDicts([FromBody] string[] dicts)
        {
            List<SysDictDataParamDto> dataVos = new();
            var list = SysDictDataService.SelectDictDataByTypes(dicts);

            foreach (var dic in dicts)
            {
                SysDictDataParamDto vo = new()
                {
                    DictType = dic,
                    List = list.FindAll(f => f.DictType == dic)
                };
                if (dic.StartsWith("cus_") || dic.StartsWith("sql_"))
                {
                    vo.List.AddRange(SysDictService.SelectDictDataByCustomSql(dic));
                }
                dataVos.Add(vo);
            }
            return dataVos;
        }

        /// <summary>
        /// 查询字典数据详细
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        [HttpGet("info/{dictCode}")]
        public IActionResult GetInfo(long dictCode)
        {
            return SUCCESS(SysDictDataService.SelectDictDataById(dictCode));
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:add")]
        [Log(Title = "字典数据", BusinessType = BusinessType.ADD)]
        [HttpPost()]
        public IActionResult Add([FromBody] SysDictData dict)
        {
            dict.Create_by = HttpContext.GetName();
            dict.Create_time = DateTime.Now;
            return SUCCESS(SysDictDataService.InsertDictData(dict));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:edit")]
        [Log(Title = "字典数据", BusinessType = BusinessType.EDIT)]
        [HttpPut()]
        public IActionResult Edit([FromBody] SysDictData dict)
        {
            dict.Update_by = HttpContext.GetName();
            return SUCCESS(SysDictDataService.UpdateDictData(dict));
        }

        /// <summary>
        /// 删除字典类型
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:delete")]
        [Log(Title = "字典类型", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{dictCode}")]
        public IActionResult Remove(string dictCode)
        {
            long[] dictCodes = Common.Tools.SpitLongArrary(dictCode);

            return SUCCESS(SysDictDataService.DeleteDictDataByIds(dictCodes));
        }
    }
}