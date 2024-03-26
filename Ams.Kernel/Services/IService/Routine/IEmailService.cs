using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 邮件记录
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface IEmailService : IBaseService<Email>
    {
        PagedInfo<EmailDto> GetList(EmailQueryDto parm);

        Email GetInfo(long Id);

        Email AddEmail(Email parm);

        int UpdateEmail(Email parm);
    }
}