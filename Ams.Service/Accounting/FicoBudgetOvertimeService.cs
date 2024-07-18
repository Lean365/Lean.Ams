using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 加班预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:59
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetOvertimeService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetOvertimeService : BaseService<FicoBudgetOvertime>, IFicoBudgetOvertimeService
    {
        /// <summary>
        /// 查询加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetOvertimeDto> GetList(FicoBudgetOvertimeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetOvertime, FicoBudgetOvertimeDto>(parm);

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
            int count = Count(it => it. FboSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FboSFID"></param>
        /// <returns></returns>
        public FicoBudgetOvertime GetInfo(long FboSFID)
        {
            var response = Queryable()
                .Where(x => x.FboSFID == FboSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 添加加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetOvertime AddFicoBudgetOvertime(FicoBudgetOvertime model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetOvertime(FicoBudgetOvertime model)
        {
            return Update(model, true, "修改加班预算");
        }

        /// <summary>
        /// 导入加班预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetOvertime(List<FicoBudgetOvertime> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FboSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FboCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FboDept.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.FboFy.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FboFm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FboTitle.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.FboClass.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.FboRequiredst.IsEmpty(), "必要工数不能为空")
                .SplitError(x => x.Item.FboDirectEmployee.IsEmpty(), "保有人数不能为空")
                .SplitError(x => x.Item.FboIndirectEmployee.IsEmpty(), "间接人数不能为空")
                .SplitError(x => x.Item.FboDays.IsEmpty(), "上班天数不能为空")
                .SplitError(x => x.Item.FboContent.IsEmpty(), "加班事由不能为空")
                .SplitError(x => x.Item.FboRetainst.IsEmpty(), "保有工数不能为空")
                .SplitError(x => x.Item.FboRetainstdiff.IsEmpty(), "工数差异不能为空")
                .SplitError(x => x.Item.FboOvertime.IsEmpty(), "投入加班不能为空")
                .SplitError(x => x.Item.FboDirectovertime.IsEmpty(), "平均投入加班不能为空")
                .SplitError(x => x.Item.FboIndirectovertime.IsEmpty(), "间接加班不能为空")
                .SplitError(x => x.Item.FboOvertimetotal.IsEmpty(), "投入总加班不能为空")
                .SplitError(x => x.Item.FboFlag.IsEmpty(), "启用标记不能为空")
                .SplitError(x => x.Item.FboAudit.IsEmpty(), "审核不能为空")
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
        /// 导出加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetOvertimeDto> ExportList(FicoBudgetOvertimeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetOvertimeDto()
                {
                    FboCorpLabel = it.FboCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FboDeptLabel = it.FboDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FboFmLabel = it.FboFm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FboTitleLabel = it.FboTitle.GetConfigValue<SysDictData>("sql_recon_account"),
                    FboFlagLabel = it.FboFlag.GetConfigValue<SysDictData>("sys_normal_whether"),
                    FboAuditLabel = it.FboAudit.GetConfigValue<SysDictData>("sys_audit_flag"),
                    FboAuditNameLabel = it.FboAuditName.GetConfigValue<SysDictData>("sql_ec_group"),
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
        private static Expressionable<FicoBudgetOvertime> QueryExp(FicoBudgetOvertimeQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetOvertime>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboCorp), it => it.FboCorp == parm.FboCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboDept), it => it.FboDept == parm.FboDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboFm), it => it.FboFm == parm.FboFm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboTitle), it => it.FboTitle == parm.FboTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboContent), it => it.FboContent == parm.FboContent);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFboAuditDate == null, it => it.FboAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFboAuditDate == null, it => it.FboAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFboAuditDate != null, it => it.FboAuditDate >= parm.BeginFboAuditDate);
            predicate = predicate.AndIF(parm.EndFboAuditDate != null, it => it.FboAuditDate <= parm.EndFboAuditDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFboUndoDate == null, it => it.FboUndoDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFboUndoDate == null, it => it.FboUndoDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFboUndoDate != null, it => it.FboUndoDate >= parm.BeginFboUndoDate);
            predicate = predicate.AndIF(parm.EndFboUndoDate != null, it => it.FboUndoDate <= parm.EndFboUndoDate);
            return predicate;
        }
    }
}