using Ams.Infrastructure.Attribute;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Services.IService.Routine;
using Ams.Model;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 通知公告
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    [AppService(ServiceType = typeof(INoticesService), ServiceLifetime = LifeTime.Transient)]
    public class NoticesService : BaseService<Notices>, INoticesService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询系统通知
        /// </summary>
        /// <returns></returns>
        public List<Notices> GetNoticess()
        {
            var predicate = Expressionable.Create<Notices>();

            predicate = predicate.And(m => m.IsState == 0);
            return Queryable()
                .Where(predicate.ToExpression())
                .OrderByDescending(f => f.Create_time)
                .ToList();
        }

        public PagedInfo<Notices> GetPageList(NoticesQueryDto parm)
        {
            var predicate = Expressionable.Create<Notices>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.NoticeTitle), m => m.NoticeTitle.Contains(parm.NoticeTitle));
            predicate = predicate.AndIF(parm.NoticeType != null, m => m.NoticeType == parm.NoticeType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CreateBy), m => m.Create_by.Contains(parm.CreateBy));
            //predicate = predicate.AndIF(parm.IsState.ToString()!= null, m => m.IsState == parm.IsState);
            var response = GetPages(predicate.ToExpression(), parm);
            return response;
        }

        #endregion 业务逻辑代码
    }
}