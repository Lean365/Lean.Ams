using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using SqlSugar;

namespace Ams.Statistics.Accounting
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IInventoryStatiService), ServiceLifetime = LifeTime.Transient)]
    public class InventoryStatiService : BaseService<FicoMonthlyInventory>, IInventoryStatiService
    {
        /// <summary>
        /// 查询月度存货
        /// </summary>
        /// <returns></returns>
        public decimal GetMonthlyInventoryAmount(FicoMonthlyInventoryQueryDto parm)
        {
            decimal MonthlyInventoryAmount;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => x.Mp003)
                .Select((x) => new
                {
                    Mp012 = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mp012 > 0, x.Mp012 / 10000, 0)), //求和,
                    //SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.SsiLocalamount > 0, x.SsiLocalamount, 0)), //求和,
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyInventoryAmount = 0;
            }
            else
            {
                MonthlyInventoryAmount = response[0].Mp012;
            }

            return MonthlyInventoryAmount;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoMonthlyInventory> QueryExp(FicoMonthlyInventoryQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            string currentMonth = nowDate.AddDays(1 - nowDate.Day).AddMonths(-1).ToString("yyyyMM");
            var predicate = Expressionable.Create<FicoMonthlyInventory>();
            if (parm.Mp003 == null)
            {
                predicate = predicate.AndIF(true, it => it.Mp003 == currentMonth);
            }
            else
            {
                predicate = predicate.AndIF(parm.Mp003 != null, it => it.Mp003 == parm.Mp003);
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