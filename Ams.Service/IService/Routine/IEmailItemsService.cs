using Ams.Infrastructure.Model;

namespace Ams.Service.IService.Routine
{
    /// <summary>
    /// 邮件发送记录service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface IEmailItemsService : IBaseService<EmailItems>
    {
        PagedInfo<EmailItemsDto> GetList(EmailItemsQueryDto parm);

        EmailItems GetInfo(long Id);

        EmailItems AddEmailLog(SendEmailDto parm, string result);

        int UpdateEmailLog(EmailItems parm);
    }
}