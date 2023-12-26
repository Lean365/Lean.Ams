using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 邮件模板service接口
    /// </summary>
    public interface IEmailTplService : IBaseService<EmailTpl>
    {
        PagedInfo<EmailTplDto> GetList(EmailTplQueryDto parm);

        EmailTpl GetInfo(int Id);

        EmailTpl AddEmailTpl(EmailTpl parm);

        int UpdateEmailTpl(EmailTpl parm);

    }
}
