namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 通知公告
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/29 13:30:50
    /// </summary>
    public interface INoticeStorageService : IBaseService<NoticeStorage>
    {
        List<NoticeStorage> GetNoticeStorages();

        PagedInfo<NoticeStorage> GetPageList(NoticeStorageQueryDto parm);

        PagedInfo<NoticeStorageDto> ExportList(NoticeStorageQueryDto parm);
    }
}