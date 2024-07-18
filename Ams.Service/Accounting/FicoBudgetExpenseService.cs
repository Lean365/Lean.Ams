using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 费用预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:03
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetExpenseService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetExpenseService : BaseService<FicoBudgetExpense>, IFicoBudgetExpenseService
    {
        /// <summary>
        /// 查询费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetExpenseDto> GetList(FicoBudgetExpenseQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetExpense, FicoBudgetExpenseDto>(parm);

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
            int count = Count(it => it. FbeSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbeSFID"></param>
        /// <returns></returns>
        public FicoBudgetExpense GetInfo(long FbeSFID)
        {
            var response = Queryable()
                .Where(x => x.FbeSFID == FbeSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 添加费用预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetExpense AddFicoBudgetExpense(FicoBudgetExpense model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改费用预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetExpense(FicoBudgetExpense model)
        {
            return Update(model, true, "修改费用预算");
        }

        /// <summary>
        /// 导入费用预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetExpense(List<FicoBudgetExpense> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbeSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FbeCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FbeDept.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.FbeFy.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FbeFm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FbeTitle.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.FbeClass.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.FbeTitlesub.IsEmpty(), "明细科目不能为空")
                .SplitError(x => x.Item.FbeClasssub.IsEmpty(), "明细名称不能为空")
                .SplitError(x => x.Item.FbeClassmemo.IsEmpty(), "说明不能为空")
                .SplitError(x => x.Item.FbeBudgetAmount.IsEmpty(), "预算金额不能为空")
                .SplitError(x => x.Item.FbeActualAmount.IsEmpty(), "实际发生不能为空")
                .SplitError(x => x.Item.FbeDifferenceAmount.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.FbsFlag.IsEmpty(), "启用标记不能为空")
                .SplitError(x => x.Item.FbsAudit.IsEmpty(), "审核不能为空")
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
        public PagedInfo<FicoBudgetExpenseDto> ExportList(FicoBudgetExpenseQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetExpenseDto()
                {
                    FbeCorpLabel = it.FbeCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbeDeptLabel = it.FbeDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FbeFmLabel = it.FbeFm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbeTitleLabel = it.FbeTitle.GetConfigValue<SysDictData>("sql_recon_account"),
                    FbsFlagLabel = it.FbsFlag.GetConfigValue<SysDictData>("sys_normal_whether"),
                    FbsAuditLabel = it.FbsAudit.GetConfigValue<SysDictData>("sys_audit_flag"),
                    FbsAuditNameLabel = it.FbsAuditName.GetConfigValue<SysDictData>("sql_ec_group"),
                    FbsUndoNameLabel = it.FbsUndoName.GetConfigValue<SysDictData>("sql_sop_group"),
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
        private static Expressionable<FicoBudgetExpense> QueryExp(FicoBudgetExpenseQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetExpense>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeCorp), it => it.FbeCorp == parm.FbeCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeDept), it => it.FbeDept == parm.FbeDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeFm), it => it.FbeFm == parm.FbeFm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeTitle), it => it.FbeTitle == parm.FbeTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeTitlesub), it => it.FbeTitlesub == parm.FbeTitlesub);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbsAuditDate == null, it => it.FbsAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbsAuditDate == null, it => it.FbsAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbsAuditDate != null, it => it.FbsAuditDate >= parm.BeginFbsAuditDate);
            predicate = predicate.AndIF(parm.EndFbsAuditDate != null, it => it.FbsAuditDate <= parm.EndFbsAuditDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbsUndoDate == null, it => it.FbsUndoDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbsUndoDate == null, it => it.FbsUndoDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbsUndoDate != null, it => it.FbsUndoDate >= parm.BeginFbsUndoDate);
            predicate = predicate.AndIF(parm.EndFbsUndoDate != null, it => it.FbsUndoDate <= parm.EndFbsUndoDate);
            return predicate;
        }
    }
}