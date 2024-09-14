using Ams.Service;

namespace Ams.Service.Monitor.IMonitorService
{
    /// <summary>
    /// 短信验证service接口
    /// </summary>
    public interface ISmsLogService : IBaseService<SmsLog>
    {
        PagedInfo<SmsLogDto> GetList(SmsLogQueryDto parm);

        SmsLog GetInfo(long Id);

        SmsLog AddSmsLog(SmsLog parm);
    }
}