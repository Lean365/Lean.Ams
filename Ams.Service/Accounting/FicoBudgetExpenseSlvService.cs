using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 费用预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:30:56
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetExpenseSlvService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetExpenseSlvService : BaseService<FicoBudgetExpenseSlv>, IFicoBudgetExpenseSlvService
    {
        /// <summary>
        /// 查询费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetExpenseSlvDto> GetList(FicoBudgetExpenseSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetExpenseSlv, FicoBudgetExpenseSlvDto>(parm);

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
            int count = Count(it => it. FbesSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbesSfId"></param>
        /// <returns></returns>
        public FicoBudgetExpenseSlv GetInfo(long FbesSfId)
        {
            var response = Queryable()
                .Where(x => x.FbesSfId == FbesSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加费用预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetExpenseSlv AddFicoBudgetExpenseSlv(FicoBudgetExpenseSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改费用预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetExpenseSlv(FicoBudgetExpenseSlv model)
        {
            return Update(model, true, "修改费用预算");
        }

        /// <summary>
        /// 导入费用预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetExpenseSlv(List<FicoBudgetExpenseSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbesSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.FbesParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.FbesTitle.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.FbesClass.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.FbesTitlesub.IsEmpty(), "明细科目不能为空")
                .SplitError(x => x.Item.FbesClasssub.IsEmpty(), "明细名称不能为空")
                .SplitError(x => x.Item.FbesClassmemo.IsEmpty(), "说明不能为空")
                .SplitError(x => x.Item.FbesBudgetAmount.IsEmpty(), "预算金额不能为空")
                .SplitError(x => x.Item.FbesActualAmount.IsEmpty(), "实际发生不能为空")
                .SplitError(x => x.Item.FbesDifferenceAmount.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.FbssFlag.IsEmpty(), "启用标记不能为空")
                .SplitError(x => x.Item.FbssAudit.IsEmpty(), "审核不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
        /// 导出费用预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetExpenseSlvDto> ExportList(FicoBudgetExpenseSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetExpenseSlvDto()
                {
                    FbesTitleLabel = it.FbesTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    FbesTitlesubLabel = it.FbesTitlesub.GetConfigValue<SysDictData>("sql_budget_details"),
                    FbssFlagLabel = it.FbssFlag.GetConfigValue<SysDictData>("sys_flag_list"),
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
        private static Expressionable<FicoBudgetExpenseSlv> QueryExp(FicoBudgetExpenseSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetExpenseSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbesTitle), it => it.FbesTitle == parm.FbesTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbesClass), it => it.FbesClass.Contains(parm.FbesClass));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbesTitlesub), it => it.FbesTitlesub == parm.FbesTitlesub);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbesClasssub), it => it.FbesClasssub.Contains(parm.FbesClasssub));
            predicate = predicate.AndIF(parm.FbssFlag != null, it => it.FbssFlag == parm.FbssFlag);
            predicate = predicate.AndIF(parm.FbssAudit != null, it => it.FbssAudit == parm.FbssAudit);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbssAuditDate == null, it => it.FbssAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbssAuditDate == null, it => it.FbssAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbssAuditDate != null, it => it.FbssAuditDate >= parm.BeginFbssAuditDate);
            predicate = predicate.AndIF(parm.EndFbssAuditDate != null, it => it.FbssAuditDate <= parm.EndFbssAuditDate);
            return predicate;
        }
    }
}