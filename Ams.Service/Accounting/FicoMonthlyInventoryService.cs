using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 月度存货
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:45:33
    /// </summary>
    [AppService(ServiceType = typeof(IFicoMonthlyInventoryService), ServiceLifetime = LifeTime.Transient)]
    public class FicoMonthlyInventoryService : BaseService<FicoMonthlyInventory>, IFicoMonthlyInventoryService
    {
        /// <summary>
        /// 查询月度存货列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyInventoryDto> GetList(FicoMonthlyInventoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoMonthlyInventory, FicoMonthlyInventoryDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MiSFID"></param>
        /// <returns></returns>
        public FicoMonthlyInventory GetInfo(long MiSFID)
        {
            var response = Queryable()
                .Where(x => x.MiSFID == MiSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 导入月度存货
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoMonthlyInventory(List<FicoMonthlyInventory> list)
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
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
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
        public PagedInfo<FicoMonthlyInventoryDto> ExportList(FicoMonthlyInventoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoMonthlyInventoryDto()
                {
                    MiPlantLabel = it.MiPlant.GetConfigValue<SysDictData>("sys_plant_list"),
                    MiYmLabel = it.MiYm.GetConfigValue<SysDictData>("sql_ficoym_list"),
                    MiValTypeLabel = it.MiValType.GetConfigValue<SysDictData>("sys_val_type"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoMonthlyInventory> QueryExp(FicoMonthlyInventoryQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoMonthlyInventory>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiPlant), it => it.MiPlant == parm.MiPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiYm), it => it.MiYm == parm.MiYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiValType), it => it.MiValType == parm.MiValType);
            return predicate;
        }
    }
}