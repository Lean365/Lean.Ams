using Ams.Infrastructure.Attribute;
using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Services.IService.Routine;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 通知公告表Service业务层处理
    ///
    /// @author zr
    /// @date 2021-12-15
    /// </summary>
    [AppService(ServiceType = typeof(INoticesService), ServiceLifetime = LifeTime.Transient)]
    public class NoticesService : BaseService<RoutineNotices>, INoticesService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询系统通知
        /// </summary>
        /// <returns></returns>
        public List<RoutineNotices> GetNoticess()
        {
            var predicate = Expressionable.Create<RoutineNotices>();

            predicate = predicate.And(m => m.IsState == 0);
            return Queryable()
                .Where(predicate.ToExpression())
                .OrderByDescending(f => f.Create_time)
                .ToList();
        }

        public PagedInfo<RoutineNotices> GetPageList(NoticesQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineNotices>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.NoticeTitle), m => m.NoticeTitle.Contains(parm.NoticeTitle));
            predicate = predicate.AndIF(parm.NoticeType != null, m => m.NoticeType == parm.NoticeType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CreateBy), m => m.Create_by.Contains(parm.CreateBy) || m.Update_by.Contains(parm.CreateBy));
            predicate = predicate.AndIF(parm.IsState.ToString()!= null, m => m.IsState == parm.IsState);
            var response = GetPages(predicate.ToExpression(), parm);
            return response;
        }

        #endregion
    }
}