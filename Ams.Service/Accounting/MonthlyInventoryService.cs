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
    /// 月度存货
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:20:25)
    /// </summary>
    [AppService(ServiceType = typeof(IMonthlyInventoryService), ServiceLifetime = LifeTime.Transient)]
    public class MonthlyInventoryService : BaseService<MonthlyInventory>, IMonthlyInventoryService
    {
        /// <summary>
        /// 查询月度存货列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MonthlyInventoryDto> GetList(MonthlyInventoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MonthlyInventory, MonthlyInventoryDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. MiSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MiSFID"></param>
        /// <returns></returns>
        public MonthlyInventory GetInfo(long MiSFID)
        {
            var response = Queryable()
                .Where(x => x.MiSFID == MiSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加月度存货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MonthlyInventory AddMonthlyInventory(MonthlyInventory model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改月度存货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMonthlyInventory(MonthlyInventory model)
        {
            return Update(model, true, "修改月度存货");
        }

        /// <summary>
        /// 导入月度存货
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMonthlyInventory(List<MonthlyInventory> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MiSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.MiPlant.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.MiFy.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.MiYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.MiItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.MiValType.IsEmpty(), "评估类不能为空")
                .SplitError(x => x.Item.MiPriceControl.IsEmpty(), "价格控制不能为空")
                .SplitError(x => x.Item.MiMovingAverage.IsEmpty(), "移动平均价不能为空")
                .SplitError(x => x.Item.MiPerUnit.IsEmpty(), "Per单位不能为空")
                .SplitError(x => x.Item.MiLocalCcy.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.MiInventoryQty.IsEmpty(), "库存不能为空")
                .SplitError(x => x.Item.MiInventoryAmount.IsEmpty(), "金额不能为空")
                .SplitError(x => x.Item.MiBalancedate.IsEmpty(), "登录日期不能为空")
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
        /// 导出月度存货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MonthlyInventoryDto> ExportList(MonthlyInventoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MonthlyInventoryDto()
                {
                    MiPlantLabel = it.MiPlant.GetConfigValue<Kernel.Model.System.SysDictData>("app_plant_list"),
                    MiFyLabel = it.MiFy.GetConfigValue<Kernel.Model.System.SysDictData>("sql_period_list"),
                    MiYmLabel = it.MiYm.GetConfigValue<Kernel.Model.System.SysDictData>("sql_ficoym_list"),
                    MiItemLabel = it.MiItem.GetConfigValue<Kernel.Model.System.SysDictData>("sql_mats_list"),
                    MiValTypeLabel = it.MiValType.GetConfigValue<Kernel.Model.System.SysDictData>("app_val_type"),
                    MiLocalCcyLabel = it.MiLocalCcy.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ccy_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MonthlyInventory> QueryExp(MonthlyInventoryQueryDto parm)
        {
            var predicate = Expressionable.Create<MonthlyInventory>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiPlant), it => it.MiPlant == parm.MiPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiFy), it => it.MiFy == parm.MiFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiYm), it => it.MiYm == parm.MiYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiItem), it => it.MiItem == parm.MiItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiValType), it => it.MiValType == parm.MiValType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiLocalCcy), it => it.MiLocalCcy == parm.MiLocalCcy);
            return predicate;
        }
    }
}