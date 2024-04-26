namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 系统参数
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ISysConfigService : IBaseService<SysConfig>
    {
        SysConfig GetSysConfigByKey(string key);
    }
}