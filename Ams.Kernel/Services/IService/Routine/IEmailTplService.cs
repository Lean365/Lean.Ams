using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 邮件模板
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface IEmailTplService : IBaseService<EmailTpl>
    {
        PagedInfo<EmailTplDto> GetList(EmailTplQueryDto parm);

        EmailTpl GetInfo(int Id);

        EmailTpl AddEmailTpl(EmailTpl parm);

        int UpdateEmailTpl(EmailTpl parm);
    }
}