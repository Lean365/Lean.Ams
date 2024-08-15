using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Kernel
{
    /// <summary>
    /// 通知公告表Service业务层处理
    ///
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [AppService(ServiceType = typeof(INoticeStorageService), ServiceLifetime = LifeTime.Transient)]
    public class NoticeStorageService : BaseService<NoticeStorage>, INoticeStorageService
    {
        /// <summary>
        /// 查询系统通知
        /// </summary>
        /// <returns></returns>
        public List<NoticeStorage> GetSysNotices()
        {
            var predicate = Expressionable.Create<NoticeStorage>();
            var now = DateTime.Now;
            predicate = predicate.And(m => m.IsStatus == 0);
            predicate = predicate.Or(m => m.BeginTime != null && m.BeginTime <= now && m.EndTime >= now && m.IsStatus == 0);

            return Queryable()
                .Where(predicate.ToExpression())
                .OrderByDescending(f => f.Create_time)
                .ToList();
        }

        public PagedInfo<NoticeStorage> GetPageList(NoticeStorageQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = GetPages(predicate.ToExpression(), parm);
            return response;
        }

        /// <summary>
        /// 导出通知公告表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<NoticeStorageDto> ExportList(NoticeStorageQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new NoticeStorageDto()
                {
                    NoticeTypeLabel = it.NoticeType.GetConfigValue<SysDictData>("sys_notice_type"),
                    IsStatusLabel = int.Parse(it.IsStatus.GetConfigValue<SysDictData>("sys_notice_status")),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<NoticeStorage> QueryExp(NoticeStorageQueryDto parm)
        {
            var predicate = Expressionable.Create<NoticeStorage>();
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.NoticeTitle), m => m.NoticeTitle.Contains(parm.NoticeTitle));
            predicate = predicate.AndIF(parm.NoticeType != null, m => m.NoticeType == parm.NoticeType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CreateBy), m => m.Create_by.Contains(parm.CreateBy) || m.Update_by.Contains(parm.CreateBy));
            predicate = predicate.AndIF(parm.IsStatus != null, m => m.IsStatus == parm.IsStatus);
            return predicate;
        }
    }
}