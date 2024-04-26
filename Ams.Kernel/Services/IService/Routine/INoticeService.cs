using Ams.Model.System.Dto;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 公告通知
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface INoticeService : IBaseService<Notice>
    {
        List<Notice> GetNotices();

        PagedInfo<Notice> GetPageList(NoticeQueryDto parm);

        PagedInfo<NoticeDto> ExportList(NoticeQueryDto parm);
    }
}