namespace Ams.WebApi.Controllers.System
{
    /// <summary>
    /// 系统参数Controller
    /// </summary>
    [Verify]
    [Route("system/config")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysConfigController : BaseController
    {
        /// <summary>
        /// 系统参数接口
        /// </summary>
        private readonly ISysConfigService _SysConfigService;

        public SysConfigController(ISysConfigService SysConfigService)
        {
            _SysConfigService = SysConfigService;
        }

        /// <summary>
        /// 查询系统参数列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "system:config:list")]
        public IActionResult QuerySysConfig([FromQuery] SysConfigQueryDto parm)
        {
            var predicate = Expressionable.Create<SysConfig>();

            predicate = predicate.AndIF(!parm.ConfigType.IsEmpty(), m => m.ConfigType == parm.ConfigType);
            predicate = predicate.AndIF(!parm.ConfigName.IsEmpty(), m => m.ConfigName.Contains(parm.ConfigType));
            predicate = predicate.AndIF(!parm.ConfigKey.IsEmpty(), m => m.ConfigKey.Contains(parm.ConfigKey));
            predicate = predicate.AndIF(!parm.BeginTime.IsEmpty(), m => m.Create_time >= parm.BeginTime);
            predicate = predicate.AndIF(!parm.BeginTime.IsEmpty(), m => m.Create_time <= parm.EndTime);

            var response = _SysConfigService.GetPages(predicate.ToExpression(), parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 查询系统参数详情
        /// </summary>
        /// <param name="ConfigId"></param>
        /// <returns></returns>
        [HttpGet("{ConfigId}")]
        [ActionPermissionFilter(Permission = "system:config:query")]
        public IActionResult GetSysConfig(int ConfigId)
        {
            var response = _SysConfigService.GetId(ConfigId);

            return SUCCESS(response);
        }

        /// <summary>
        /// 根据参数键名查询参数值
        /// </summary>
        /// <param name="configKey"></param>
        /// <returns></returns>
        [HttpGet("configKey/{configKey}")]
        [AllowAnonymous]
        public IActionResult GetConfigKey(string configKey)
        {
            var response = _SysConfigService.Queryable().First(f => f.ConfigKey == configKey);

            return SUCCESS(response?.ConfigValue);
        }

        /// <summary>
        /// 添加系统参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "system:config:add")]
        [Log(Title = "系统参数添加", BusinessType = BusinessType.ADD)]
        public IActionResult AddSysConfig([FromBody] SysConfigDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var model = parm.Adapt<SysConfig>().ToCreate(HttpContext);

            return SUCCESS(_SysConfigService.Insert(model, it => new
            {
                it.ConfigName,
                it.ConfigKey,
                it.ConfigValue,
                it.ConfigType,
                it.Create_by,
                it.Create_time,
                it.Remark,
            }));
        }

        /// <summary>
        /// 更新系统参数
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "system:config:edit")]
        [Log(Title = "系统参数修改", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateSysConfig([FromBody] SysConfigDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var model = parm.Adapt<SysConfig>().ToUpdate(HttpContext);

            var response = _SysConfigService.Update(w => w.ConfigId == model.ConfigId, it => new SysConfig()
            {
                ConfigName = model.ConfigName,
                ConfigKey = model.ConfigKey,
                ConfigValue = model.ConfigValue,
                ConfigType = model.ConfigType,
                Update_by = model.Update_by,
                Update_time = model.Update_time,
                Remark = model.Remark
            });

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除系统参数
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "system:config:remove")]
        [Log(Title = "系统参数删除", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysConfig(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }
            int sysCount = _SysConfigService.Count(s => s.ConfigType == "Y" && idsArr.Contains(s.ConfigId));
            if (sysCount > 0) { return ToResponse(ApiResult.Error($"删除失败Id： 系统内置参数不能删除！")); }
            var response = _SysConfigService.Delete(idsArr);

            return SUCCESS(response);
        }
    }
}