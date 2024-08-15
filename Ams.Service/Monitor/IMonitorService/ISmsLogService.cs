using Ams.Model.Monitor.Dto;

namespace Ams.Service.Monitor.IMonitorService
{
    /// <summary>
    /// 短信验证码记录service接口
    /// </summary>
    public interface ISmsLogService : IBaseService<SmsLog>
    {
        PagedInfo<SmsLogDto> GetList(SmsLogQueryDto parm);

        SmsLog GetInfo(long Id);

        SmsLog AddSmscodeLog(SmsLog parm);
    }
}