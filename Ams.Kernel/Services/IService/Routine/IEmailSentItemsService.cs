using Ams.Infrastructure.Model;
using Ams.Kernel.Model;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 邮件发送记录service接口
    /// </summary>
    public interface IEmailSentItemsService : IBaseService<EmailSentItems>
    {
        PagedInfo<EmailSentItemsDto> GetList(EmailSentItemsQueryDto parm);

        EmailSentItems GetInfo(long Id);

        EmailSentItems AddEmailSentItems(SendEmail parm, string result);

        int UpdateEmailSentItems(EmailSentItems parm);
    }
}