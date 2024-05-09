using Ams.Infrastructure.Model;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 发送记录
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface IEmailSentItemsService : IBaseService<EmailSentItems>
    {
        PagedInfo<EmailSentItemsDto> GetList(EmailSentItemsQueryDto parm);

        EmailSentItems GetInfo(long Id);

        EmailSentItems AddEmailSentItems(SendEmail parm, string result);

        int UpdateEmailSentItems(EmailSentItems parm);
    }
}