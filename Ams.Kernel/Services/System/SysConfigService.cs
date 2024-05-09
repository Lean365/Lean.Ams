using Ams.Infrastructure.Attribute;
using Ams.Kernel.Services.IService.System;

namespace Ams.Kernel.Services.System
{
    /// <summary>
    /// 参数配置
    /// 业务层处理
    /// Lean365(Davis.Ching)
    /// @date 2024-01-01
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