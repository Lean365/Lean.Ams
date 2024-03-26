using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Model.Monitor;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 短信记录
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface ILogSmsService : IBaseService<LogSms>
    {
        PagedInfo<LogSmsDto> GetList(LogSmsQueryDto parm);

        LogSms GetInfo(long Id);

        LogSms AddLogSms(LogSms parm);
    }
}