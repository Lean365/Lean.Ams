using Ams.Model;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 短信验证码
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ILogSmsService : IBaseService<LogSms>
    {
        PagedInfo<LogSmsDto> GetList(LogSmsQueryDto parm);

        LogSms GetInfo(long Id);

        LogSms AddLogSms(LogSms parm);
    }
}