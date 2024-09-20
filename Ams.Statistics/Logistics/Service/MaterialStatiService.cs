using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using SqlSugar;

namespace Ams.Statistics.Logistics.Service
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IMaterialStatiService), ServiceLifetime = LifeTime.Transient)]
    public class MaterialStatiService : BaseService<MmMara>, IMaterialStatiService
    {
        /// <summary>
        /// 按物料生成物料号码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic GetNewMaterialNumber(MmMaraQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .Max(it => it.Ma003);//获取最大
            //.ToPage<Order, OrderDto>(parm);
            // .Max(it => it.MoOrderNo)
            if (response == null)
            {
                return "0000000000";
            }

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmMara> QueryExp(MmMaraQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<MmMara>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma003), it => it.Ma003 == parm.Ma003);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcNo), it => it.EmEcNo.Substring(0, 2).Contains(parm.EmEcNo));
            return predicate;
        }
    }
}