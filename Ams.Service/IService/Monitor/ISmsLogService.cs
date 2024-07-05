namespace Ams.Service.IService.Monitor
{
    /// <summary>
    /// 短信验证码记录service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface ISmsLogService : IBaseService<SmsLog>
    {
        PagedInfo<SmsLogDto> GetList(SmsLogQueryDto parm);

        SmsLog GetInfo(long Id);

        SmsLog AddSmscodeLog(SmsLog parm);
    }
}