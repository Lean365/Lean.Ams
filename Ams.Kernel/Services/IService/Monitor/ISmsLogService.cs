using Ams.Kernel.Model.Dto.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 验证码
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ISmsLogService : IBaseService<SmsLog>
    {
        PagedInfo<SmsLogDto> GetList(SmsLogQueryDto parm);

        SmsLog GetInfo(long Id);

        SmsLog AddSmsLog(SmsLog parm);
    }
}