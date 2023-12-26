using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 邮件发送记录service接口
    /// </summary>
    public interface IEmailService : IBaseService<Email>
    {
        PagedInfo<EmailDto> GetList(EmailQueryDto parm);

        Email GetInfo(long Id);

        Email AddEmail(Email parm);

        int UpdateEmail(Email parm);
    }
}
