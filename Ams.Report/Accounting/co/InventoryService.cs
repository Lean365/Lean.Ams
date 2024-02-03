using Ams.Infrastructure.Attribute;
using Ams.Kernel;
using Ams.Model.Accounting;
using Ams.Model.Dto;
using SqlSugar;
namespace Ams.Report.Accounting.co
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IInventoryService), ServiceLifetime = LifeTime.Transient)]
    public class InventoryService : BaseService<MonthlyInventory>, IInventoryService
    {
        /// <summary>
        /// 上月库存
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic QueryInventoryAmount(MonthlyInventoryQueryDto parm)
        {
            string? MonthlyInventoryQty;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var response = queryableLeft
            .GroupBy(x1 => new { x1.MiPlant, x1.MiYm })
            .Select((x1) => new
            {
                MiInventoryQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.MiInventoryQty > 0, x1.MiInventoryQty, 0)),
                MiInventoryAmount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.MiInventoryAmount > 0, x1.MiInventoryAmount, 0)),
            }).ToList();
            if (response.Count == 0)
            {
                MonthlyInventoryQty = "0,0";

            }
            else
            {
                MonthlyInventoryQty = response[0].MiInventoryQty.ToString() + "," + response[0].MiInventoryAmount.ToString();
            }

            return MonthlyInventoryQty;



        }
        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MonthlyInventory> QueryExp(MonthlyInventoryQueryDto parm)
        {
            var predicate = Expressionable.Create<MonthlyInventory>();
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiYm), it => it.MiYm == parm.MiYm);
            return predicate;
        }
    }
}
