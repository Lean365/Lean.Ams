using Ams.Model;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 验证码记录service接口
    /// </summary>
    public interface ILogSmsService : IBaseService<LogSms>
    {
        PagedInfo<LogSmsDto> GetList(LogSmsQueryDto parm);

        LogSms GetInfo(long Id);

        LogSms AddLogSms(LogSms parm);
    }
}