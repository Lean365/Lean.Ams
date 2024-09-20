using Ams.Model.Routine;
using Ams.Model.Routine.Dto;
using SqlSugar;

namespace Ams.Statistics.Routine
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IEmployeeStatiService), ServiceLifetime = LifeTime.Transient)]
    public class EmployeeStatiService : BaseService<RoutineEhrEmployee>, IEmployeeStatiService
    {
        /// <summary>
        /// 按性别生成工号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic GetMaxWorkNumber(RoutineEhrEmployeeQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .Max(it => it.Mh033);//获取最大
            //.ToPage<Order, OrderDto>(parm);
            // .Max(it => it.MoOrderNo)
            if (response == null)
            {
                return "00000000";
            }

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrEmployee> QueryExp(RoutineEhrEmployeeQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<RoutineEhrEmployee>();
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh006.ToString()), it => it.Mh006 == parm.Mh006);
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem == parm.MmMatItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh033), it => it.Mh033.Substring(0, 2).Contains(parm.Mh033));
            return predicate;
        }
    }
}