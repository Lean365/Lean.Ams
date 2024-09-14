namespace Ams.Service.Admin.IAdminService
{
    /// <summary>
    /// 系统参数
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/29 13:30:56
    /// </summary>
    public interface ISysConfigService : IBaseService<SysConfig>
    {
        SysConfig GetSysConfigByKey(string key);
    }
}