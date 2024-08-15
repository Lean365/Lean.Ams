using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 月度存货
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:52:42
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
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString)
        {
            int count = Count(it => it. MiSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MiSfId"></param>
        /// <returns></returns>
        public FicoMonthlyInventory GetInfo(long MiSfId)
        {
            var response = Queryable()
                .Where(x => x.MiSfId == MiSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加月度存货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoMonthlyInventory AddFicoMonthlyInventory(FicoMonthlyInventory model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改月度存货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoMonthlyInventory(FicoMonthlyInventory model)
        {
            return Update(model, true, "修改月度存货");
        }

        /// <summary>
        /// 导入月度存货
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoMonthlyInventory(List<FicoMonthlyInventory> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MiSfId.IsEmpty(), "ID不能为空")
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
                    MiLfgjaLabel = it.MiLfgja.GetConfigValue<SysDictData>("sql_fy_list"),
                    MiLfmonLabel = it.MiLfmon.GetConfigValue<SysDictData>("sql_ym_list"),
                    MiWerksLabel = it.MiWerks.GetConfigValue<SysDictData>("sys_plant_list"),
                    MiBklasLabel = it.MiBklas.GetConfigValue<SysDictData>("sys_val_type"),
                    MiWaersLabel = it.MiWaers.GetConfigValue<SysDictData>("sys_ccy_type"),
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

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiLfgja), it => it.MiLfgja == parm.MiLfgja);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiLfmon), it => it.MiLfmon == parm.MiLfmon);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiWerks), it => it.MiWerks == parm.MiWerks);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiMatnr), it => it.MiMatnr.Contains(parm.MiMatnr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiBklas), it => it.MiBklas == parm.MiBklas);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MiWaers), it => it.MiWaers == parm.MiWaers);
            return predicate;
        }
    }
}