using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 通知公告
    /// 业务服务接口
    /// @author Lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    public interface INoticeService : IBaseService<Notice>
    {
        List<Notice> GetNotices();

        PagedInfo<Notice> GetPageList(NoticeQueryDto parm);

        PagedInfo<NoticeDto> ExportList(NoticeQueryDto parm);
    }
}