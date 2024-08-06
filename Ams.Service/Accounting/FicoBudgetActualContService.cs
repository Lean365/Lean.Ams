using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 实际对比
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 17:07:36
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetActualContService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetActualContService : BaseService<FicoBudgetActualCont>, IFicoBudgetActualContService
    {
        /// <summary>
        /// 查询实际对比列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> GetList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetActualCont, FicoBudgetActualContDto>(parm);

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
            int count = Count(it => it. FbSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbSfId"></param>
        /// <returns></returns>
        public FicoBudgetActualCont GetInfo(long FbSfId)
        {
            var response = Queryable()
                .Where(x => x.FbSfId == FbSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加实际对比
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetActualCont AddFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改实际对比
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            return Update(model, true, "修改实际对比");
        }

        /// <summary>
        /// 导入实际对比
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetActualCont(List<FicoBudgetActualCont> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbSfId.IsEmpty(), "ID不能为空")
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
        /// 导出实际对比
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> ExportList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetActualContDto()
                {
                    FbFyLabel = it.FbFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    FbYmLabel = it.FbYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbCorpCodeLabel = it.FbCorpCode.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbStatCategoryLabel = it.FbStatCategory.GetConfigValue<SysDictData>("sys_stat_type"),
                    FbCostCodeLabel = it.FbCostCode.GetConfigValue<SysDictData>("sql_cost_center"),
                    FbCostTypeLabel = it.FbCostType.GetConfigValue<SysDictData>("sys_costs_type"),
                    FbTitleCodeLabel = it.FbTitleCode.GetConfigValue<SysDictData>("sql_accounting_title"),
                    FbCcyLabel = it.FbCcy.GetConfigValue<SysDictData>("sys_ccy_type"),
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
        private static Expressionable<FicoBudgetActualCont> QueryExp(FicoBudgetActualContQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetActualCont>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbFy), it => it.FbFy == parm.FbFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbYm), it => it.FbYm == parm.FbYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbCorpCode), it => it.FbCorpCode == parm.FbCorpCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbStatCategory), it => it.FbStatCategory == parm.FbStatCategory);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbCostCode), it => it.FbCostCode == parm.FbCostCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbCostType), it => it.FbCostType == parm.FbCostType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbTitleCode), it => it.FbTitleCode == parm.FbTitleCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbCcy), it => it.FbCcy == parm.FbCcy);
            return predicate;
        }
    }
}