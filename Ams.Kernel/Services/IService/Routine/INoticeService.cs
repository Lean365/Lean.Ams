using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Model;

namespace Ams.Kernel.Services
{
    /// <summary>
    /// 通知公告service接口
    ///
    /// @author zr
    /// @date 2021-12-15
    /// </summary>
    public interface INoticeService : IBaseService<Notice>
    {
        List<Notice> GetNotices();

        PagedInfo<Notice> GetPageList(NoticeQueryDto parm);
        PagedInfo<NoticeDto> ExportList(NoticeQueryDto parm);
    }
}
