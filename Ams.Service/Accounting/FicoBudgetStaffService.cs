using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 人员预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:54
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetStaffService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetStaffService : BaseService<FicoBudgetStaff>, IFicoBudgetStaffService
    {
        /// <summary>
        /// 查询人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetStaffDto> GetList(FicoBudgetStaffQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetStaff, FicoBudgetStaffDto>(parm);

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
            int count = Count(it => it. FbsSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbsSFID"></param>
        /// <returns></returns>
        public FicoBudgetStaff GetInfo(long FbsSFID)
        {
            var response = Queryable()
                .Where(x => x.FbsSFID == FbsSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 添加人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetStaff AddFicoBudgetStaff(FicoBudgetStaff model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetStaff(FicoBudgetStaff model)
        {
            return Update(model, true, "修改人员预算");
        }

        /// <summary>
        /// 导入人员预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetStaff(List<FicoBudgetStaff> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbsSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FbsCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FbsDept.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.FbsFy.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FbsFm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FbsTitle.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.FbsClass.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.FbsCategory.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.FbsKeepPersonnel.IsEmpty(), "保有不能为空")
                .SplitError(x => x.Item.FbsNowPersonnel.IsEmpty(), "现有不能为空")
                .SplitError(x => x.Item.FbsPersonnel.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.FbsFlag.IsEmpty(), "启用不能为空")
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
        /// 导出人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetStaffDto> ExportList(FicoBudgetStaffQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetStaffDto()
                {
                    FbsCorpLabel = it.FbsCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbsDeptLabel = it.FbsDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FbsFmLabel = it.FbsFm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbsTitleLabel = it.FbsTitle.GetConfigValue<SysDictData>("sql_recon_account"),
                    FbsCategoryLabel = it.FbsCategory.GetConfigValue<SysDictData>("sys_assets_type"),
                    FbsFlagLabel = it.FbsFlag.GetConfigValue<SysDictData>("sys_normal_whether"),
                    FbsAuditLabel = it.FbsAudit.GetConfigValue<SysDictData>("sys_audit_flag"),
                    FbsAuditNameLabel = it.FbsAuditName.GetConfigValue<SysDictData>("sql_ec_group"),
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
        private static Expressionable<FicoBudgetStaff> QueryExp(FicoBudgetStaffQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetStaff>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsCorp), it => it.FbsCorp == parm.FbsCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsDept), it => it.FbsDept == parm.FbsDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsFm), it => it.FbsFm == parm.FbsFm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsTitle), it => it.FbsTitle == parm.FbsTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsCategory), it => it.FbsCategory == parm.FbsCategory);
            predicate = predicate.AndIF(parm.FbsFlag != null, it => it.FbsFlag == parm.FbsFlag);
            predicate = predicate.AndIF(parm.FbsAudit != null, it => it.FbsAudit == parm.FbsAudit);
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