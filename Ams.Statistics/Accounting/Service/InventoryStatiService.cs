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
            decimal MiSalk;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => x.MiLfmon)
                .Select((x) => new
                {
                    MiSalk = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.MiSalk > 0, x.MiSalk / 10000, 0)), //求和,
                    //SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.SsiLocalamount > 0, x.SsiLocalamount, 0)), //求和,
                }).ToList();
            if (response.Count == 0)
            {
                MiSalk = 0;
            }
            else
            {
                MiSalk = response[0].MiSalk;
            }

            return MiSalk;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoMonthlyInventory> QueryExp(FicoMonthlyInventoryQueryDto parm)
        {
            string currentMonth = DateTime.Now.ToString("yyyyMM");
            var predicate = Expressionable.Create<FicoMonthlyInventory>();
            if (parm.MiLfmon == null)
            {
                predicate = predicate.AndIF(true, it => it.MiLfmon == "202312");
            }
            else
            {
                predicate = predicate.AndIF(parm.MiLfmon != null, it => it.MiLfmon == parm.MiLfmon);
            }
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            //var predicate = Expressionable.Create<FicoMonthlyInventory>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem == parm.MmMatItem);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiLfmon), it => it.MiLfmon.Substring(0, 2).Contains(parm.MiLfmon));
            return predicate;
        }
    }
}