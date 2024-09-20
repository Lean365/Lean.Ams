using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using SqlSugar;

namespace Ams.Statistics.Accounting
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IContStatiService), ServiceLifetime = LifeTime.Transient)]
    public class ContStatiService : BaseService<FicoBudgetActualCont>, IContStatiService
    {
        /// <summary>
        /// 查询月度生产成本
        /// </summary>
        /// <returns></returns>
        public decimal GetMonthlyProductionCost(FicoBudgetActualContQueryDto parm)
        {
            decimal Me011;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => x.Me003)
                .Select((x) => new
                {
                    Me011 = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Me011 > 0, x.Me011 / 10000, 0)), //求和,
                    //SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.SsiLocalamount > 0, x.SsiLocalamount, 0)), //求和,
                }).ToList();
            if (response.Count == 0)
            {
                Me011 = 0;
            }
            else
            {
                Me011 = response[0].Me011;
            }

            return Me011;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetActualCont> QueryExp(FicoBudgetActualContQueryDto parm)
        {
            string currentMonth = DateTime.Now.ToString("yyyyMM");
            var predicate = Expressionable.Create<FicoBudgetActualCont>();
            predicate = predicate.AndIF(string.IsNullOrEmpty(parm.Me004), it => it.Me007 == "F");
            if (parm.Me003 == null)
            {
                predicate = predicate.AndIF(true, it => it.Me003 == "202201");
            }
            else
            {
                predicate = predicate.AndIF(parm.Me003 != null, it => it.Me003 == parm.Me003);
            }
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            //var predicate = Expressionable.Create<FicoMonthlyInventory>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem == parm.MmMatItem);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mp003), it => it.Mp003.Substring(0, 2).Contains(parm.Mp003));
            return predicate;
        }
    }
}