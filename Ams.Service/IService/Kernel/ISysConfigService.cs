namespace Ams.Service.IService.Kernel
{
    /// <summary>
    /// 参数配置service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface ISysConfigService : IBaseService<SysConfig>
    {
        SysConfig GetSysConfigByKey(string key);
    }
}