using Ams.Kernel.Model.Dto.Routine;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 已发邮件
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ISentItemsService : IBaseService<SentItems>
    {
        PagedInfo<SentItemsDto> GetList(SentItemsQueryDto parm);

        SentItems GetInfo(long Id);

        SentItems AddSentItems(SendEmailDto parm, string result);

        int UpdateSentItems(SentItems parm);
    }
}