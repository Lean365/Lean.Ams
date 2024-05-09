using Ams.Infrastructure.Attribute;
using Ams.Kernel.Services.IService.Routine;
using Ams.Model;
using Ams.Repository;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 通知公告
    /// 业务层处理
    /// Lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(INoticeService), ServiceLifetime = LifeTime.Transient)]
    public class NoticeService : BaseService<Notice>, INoticeService
    {
        /// <summary>
        /// 查询系统通知
        /// </summary>
        /// <returns></returns>
        public List<Notice> GetNotices()
        {
            var predicate = Expressionable.Create<Notice>();

            predicate = predicate.And(m => m.IsStated == 0);
            return Queryable()
                .Where(predicate.ToExpression())
                .OrderByDescending(f => f.Create_time)
                .ToList();
        }

        public PagedInfo<Notice> GetPageList(NoticeQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = GetPages(predicate.ToExpression(), parm);
            return response;
        }

        /// <summary>
        /// 导出通知公告
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<NoticeDto> ExportList(NoticeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new NoticeDto()
                {
                    NoticeTypeLabel = it.NoticeType.GetConfigValue<SysDictData>("sys_notice_type"),
                    StatusLabel = it.IsStated.GetConfigValue<SysDictData>("sys_notice_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Notice> QueryExp(NoticeQueryDto parm)
        {
            var predicate = Expressionable.Create<Notice>();
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.NoticeTitle), m => m.NoticeTitle.Contains(parm.NoticeTitle));
            predicate = predicate.AndIF(parm.NoticeType != null, m => m.NoticeType == parm.NoticeType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CreateBy), m => m.Create_by.Contains(parm.CreateBy) || m.Update_by.Contains(parm.CreateBy));
            predicate = predicate.AndIF(parm.IsStated != null, m => m.IsStated == parm.IsStated);
            return predicate;
        }
    }
}