namespace Ams.Service.IService.Routine
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author zr
    /// @date 2021-12-15
    /// </summary>
    public interface INoticeStorageService : IBaseService<NoticeStorage>
    {
        List<NoticeStorage> GetSysNotices();

        PagedInfo<NoticeStorage> GetPageList(NoticeStorageQueryDto parm);

        PagedInfo<NoticeStorageDto> ExportList(NoticeStorageQueryDto parm);
    }
}