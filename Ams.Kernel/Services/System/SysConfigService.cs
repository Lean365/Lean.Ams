using Ams.Infrastructure.Attribute;
using Ams.Kernel.Model.System;
using Ams.Kernel.Services.IService.System;

namespace Ams.Kernel.Services.System
{
    /// <summary>
    /// 参数配置Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISysConfigService), ServiceLifetime = LifeTime.Transient)]
    public class SysConfigService : BaseService<SysConfig>, ISysConfigService
    {
        #region 业务逻辑代码

        public SysConfig GetSysConfigByKey(string key)
        {
            return Queryable().First(f => f.ConfigKey == key);
        }

        #endregion
    }
}