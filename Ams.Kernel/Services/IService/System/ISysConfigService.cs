using Ams.Kernel.Model.System;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 参数配置
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface ISysConfigService : IBaseService<SysConfig>
    {
        SysConfig GetSysConfigByKey(string key);
    }
}