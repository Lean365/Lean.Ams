using Ams.Infrastructure.Model;
using Ams.Model;
using Ams.Model.Systems;


namespace Ams.Service.IService
{
    /// <summary>
    /// 邮件发送记录service接口
    /// </summary>
    public interface IEmailItemsService : IBaseService<EmailItems>
    {
        PagedInfo<EmailItemsDto> GetList(EmailLogQueryDto parm);

        EmailItems GetInfo(long Id);

        EmailItems AddEmailLog(SendEmailDto parm, string result);

        int UpdateEmailLog(EmailItems parm);
    }
}
