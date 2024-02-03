using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Linq;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// bom成本核算
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:37:37)
    /// </summary>
    [AppService(ServiceType = typeof(IBomCostingService), ServiceLifetime = LifeTime.Transient)]
    public class BomCostingService : BaseService<BomCosting>, IBomCostingService
    {
        /// <summary>
        /// 查询bom成本核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<BomCostingDto> GetList(BomCostingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<BomCosting, BomCostingDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. BcSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="BcSFID"></param>
        /// <returns></returns>
        public BomCosting GetInfo(long BcSFID)
        {
            var response = Queryable()
                .Where(x => x.BcSFID == BcSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加bom成本核算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BomCosting AddBomCosting(BomCosting model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改bom成本核算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateBomCosting(BomCosting model)
        {
            return Update(model, true, "修改bom成本核算");
        }

        /// <summary>
        /// 导入bom成本核算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportBomCosting(List<BomCosting> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.BcSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.BcPlant.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.BcFy.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.BcYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.BcBomItem.IsEmpty(), "成品物料不能为空")
                .SplitError(x => x.Item.BcItemText.IsEmpty(), "物料文本不能为空")
                .SplitError(x => x.Item.BcBomCost.IsEmpty(), "成本不能为空")
                .SplitError(x => x.Item.BcCurrency.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.BcBalancedate.IsEmpty(), "核算日期不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 导出bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<BomCostingDto> ExportList(BomCostingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new BomCostingDto()
                {
                    BcPlantLabel = it.BcPlant.GetConfigValue<Kernel.Model.System.SysDictData>("app_plant_list"),
                    BcFyLabel = it.BcFy.GetConfigValue<Kernel.Model.System.SysDictData>("sql_period_list"),
                    BcYmLabel = it.BcYm.GetConfigValue<Kernel.Model.System.SysDictData>("sql_ficoym_list"),
                    BcBomItemLabel = it.BcBomItem.GetConfigValue<Kernel.Model.System.SysDictData>("sql_moc_item"),
                    BcCurrencyLabel = it.BcCurrency.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ccy_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<BomCosting> QueryExp(BomCostingQueryDto parm)
        {
            var predicate = Expressionable.Create<BomCosting>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcPlant), it => it.BcPlant == parm.BcPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcYm), it => it.BcYm == parm.BcYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcBomItem), it => it.BcBomItem == parm.BcBomItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcCurrency), it => it.BcCurrency == parm.BcCurrency);
            return predicate;
        }
    }
}