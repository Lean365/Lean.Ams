using Ams.Model.Routine.Dto;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    public interface INoticeStorageService : IBaseService<NoticeStorage>
    {
        List<NoticeStorage> GetSysNotices();

        PagedInfo<NoticeStorage> GetPageList(NoticeStorageQueryDto parm);

        PagedInfo<NoticeStorageDto> ExportList(NoticeStorageQueryDto parm);
    }
}