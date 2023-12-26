using Ams.Model;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Model.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 短信验证码记录service接口
    /// </summary>
    public interface ILogSmsService : IBaseService<LogSms>
    {
        PagedInfo<LogSmsDto> GetList(LogSmsQueryDto parm);

        LogSms GetInfo(long Id);

        LogSms AddLogSms(LogSms parm);

    }
}
