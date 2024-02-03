using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel;
using Ams.Model;
using Ams.Model.Accounting;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using SqlSugar;
namespace Ams.Report.Logistics.pp
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IInstructionService), ServiceLifetime = LifeTime.Transient)]
    public class InstructionService : BaseService<Order>, IInstructionService
    {
        /// <summary>
        /// 查询最大ID
        /// </summary>
        /// <returns></returns>
        public dynamic QueryMaxSfid(string Type)
        {
            string? MaxSfid;
            var db = Context;
            long Sfid = db.Queryable<Order>().Where(s => s.MoOrderType == Type).Max(it => it.MoOrderNo).ParseToLong();//异步
            if (!string.IsNullOrEmpty(Sfid.ToString()) && Sfid != 0)
            {
                MaxSfid = (Sfid + 1).ToString();
            }
            else
            {
                MaxSfid = SnowFlakeSingle.instance.NextId().ToString();
            }

            return MaxSfid;
        }
        /// <summary>
        /// 按类型生成订单号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic QueryOrderNum(OrderQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .Max(it => it.MoOrderNo);//最大订单号
            //.ToPage<Order, OrderDto>(parm);
            // .Max(it => it.MoOrderNo)
            if (response == null)
            {
                if (parm.MoOrderType == "ZDTC")
                {
                    response = "640000";
                }
                if (parm.MoOrderType == "ZDTF")
                {
                    response = "670000";
                }
                if (parm.MoOrderType == "ZDTG")
                {
                    response = "740000";
                }
                if (parm.MoOrderType == "ZDTH")
                {
                    response = "770000";
                }

            }

                return response;



        }
        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Order> QueryExp(OrderQueryDto parm)
        {

            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<Order>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderType), it => it.MoOrderType == parm.MoOrderType);

            return predicate;
        }
    }
}
