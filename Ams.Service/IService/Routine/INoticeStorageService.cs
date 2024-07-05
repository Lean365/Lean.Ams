namespace Ams.Service.IService.Routine
{
    /// <summary>
    /// 通知公告表service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface INoticeStorageService : IBaseService<NoticeStorage>
    {
        List<NoticeStorage> GetSysNotices();

        PagedInfo<NoticeStorage> GetPageList(NoticeStorageQueryDto parm);

        PagedInfo<NoticeStorageDto> ExportList(NoticeStorageQueryDto parm);
    }
}