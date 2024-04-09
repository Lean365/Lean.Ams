namespace Ams.WebApi.Controllers.System
{
    /// <summary>
    /// 数据字典信息
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("system/dict/data")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysDictDataController : BaseController
    {
        private readonly ISysDictDataService _SysDictDataService;
        private readonly ISysDictTypeService _SysDictTypeService;

        public SysDictDataController(ISysDictTypeService SysDictTypeService, ISysDictDataService SysDictDataService)
        {
            _SysDictTypeService = SysDictTypeService;
            _SysDictDataService = SysDictDataService;
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
            var list = _SysDictDataService.SelectDictDataList(dictData, pagerInfo);

            if (dictData.DictType.StartsWith("sql_"))
            {
                var result = _SysDictTypeService.SelectDictDataByCustomSql(dictData.DictType);

                list.Result.AddRange(result);
                list.TotalNum += result.Count;
            }
            return SUCCESS(list, TIME_FORMAT_YYYMMDD);
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
            return SUCCESS(_SysDictDataService.SelectDictDataByType(dictType));
        }

        /// <summary>
        /// 根据字典类型查询字典数据信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("types")]
        public IActionResult DictTypes([FromBody] List<SysDictDataDto> dto)
        {
            var list = _SysDictDataService.SelectDictDataByTypes(dto.Select(f => f.DictType).ToArray());
            List<SysDictDataDto> dataVos = new();

            foreach (var dic in dto)
            {
                SysDictDataDto vo = new()
                {
                    DictType = dic.DictType,
                    //Remark=dic.Remark,
                    ColumnName = dic.ColumnName,
                    List = list.FindAll(f => f.DictType == dic.DictType)
                };
                if (dic.DictType.StartsWith("cus_") || dic.DictType.StartsWith("sql_"))
                {
                    vo.List.AddRange(_SysDictTypeService.SelectDictDataByCustomSql(dic.DictType));
                }
                dataVos.Add(vo);
            }
            return SUCCESS(dataVos);
        }

        /// <summary>
        /// 查询字典数据详细
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("info/{dictCode}")]
        public IActionResult GetInfo(long dictCode)
        {
            return SUCCESS(_SysDictDataService.SelectDictDataById(dictCode));
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:add")]
        [Log(Title = "字典数据", BusinessType = BusinessType.INSERT)]
        [HttpPost()]
        public IActionResult Add([FromBody] SysDictData dict)
        {
            dict.Create_by = HttpContext.GetName();
            dict.Create_time = DateTime.Now;
            return SUCCESS(_SysDictDataService.InsertDictData(dict));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:dict:edit")]
        [Log(Title = "字典数据", BusinessType = BusinessType.UPDATE)]
        [HttpPut()]
        public IActionResult Edit([FromBody] SysDictData dict)
        {
            dict.Update_by = HttpContext.GetName();
            return SUCCESS(_SysDictDataService.UpdateDictData(dict));
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

            return SUCCESS(_SysDictDataService.DeleteDictDataByIds(dictCodes));
        }
    }
}