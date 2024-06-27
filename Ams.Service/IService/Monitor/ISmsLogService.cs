namespace Ams.Service.IService
{
    /// <summary>
    /// 短信验证码记录service接口
    /// </summary>
    public interface ISmsLogService : IBaseService<SmsLog>
    {
        PagedInfo<SmsLogDto> GetList(SmscodeLogQueryDto parm);

        SmsLog GetInfo(long Id);

        SmsLog AddSmscodeLog(SmsLog parm);
    }
}