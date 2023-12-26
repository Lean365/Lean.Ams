using System;
using Ams.Kernel.Model.System;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 参数配置service接口
    ///
    /// @author mr.zhao
    /// @date 2021-09-29
    /// </summary>
    public interface ISysConfigService : IBaseService<SysConfig>
    {
        SysConfig GetSysConfigByKey(string key);
    }
}
