using Ams.Service;
using Ams.Service.Admin.IAdminService;

namespace Ams.Service.Admin
{
    /// <summary>
    /// 系统参数Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISysConfigService), ServiceLifetime = LifeTime.Transient)]
    public class SysConfigService : BaseService<SysConfig>, ISysConfigService
    {
        #region 业务逻辑代码

        public SysConfig GetSysConfigByKey(string key)
        {
            return Queryable().First(f => f.ConfigKey == key);
        }

        #endregion 业务逻辑代码
    }
}