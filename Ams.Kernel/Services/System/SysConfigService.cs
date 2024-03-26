using Ams.Infrastructure.Attribute;
using Ams.Kernel.Model.System;
using Ams.Kernel.Services.IService.System;

namespace Ams.Kernel.Services.System
{
    /// <summary>
    /// 参数配置
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
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