using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 人员预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:59
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetStaffSlvService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetStaffSlvService : BaseService<FicoBudgetStaffSlv>, IFicoBudgetStaffSlvService
    {
        /// <summary>
        /// 查询人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetStaffSlvDto> GetList(FicoBudgetStaffSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("FbssYm desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetStaffSlv, FicoBudgetStaffSlvDto>(parm);

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
            int count = Count(it => it. FbssSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbssSfId"></param>
        /// <returns></returns>
        public FicoBudgetStaffSlv GetInfo(long FbssSfId)
        {
            var response = Queryable()
                .Where(x => x.FbssSfId == FbssSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetStaffSlv AddFicoBudgetStaffSlv(FicoBudgetStaffSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetStaffSlv(FicoBudgetStaffSlv model)
        {
            return Update(model, true, "修改人员预算");
        }

        /// <summary>
        /// 导入人员预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetStaffSlv(List<FicoBudgetStaffSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbssSfId.IsEmpty(), "ID不能为空")
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
        public PagedInfo<FicoBudgetStaffSlvDto> ExportList(FicoBudgetStaffSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetStaffSlvDto()
                {
                    FbssYmLabel = it.FbssYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbssTitleLabel = it.FbssTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    FbssCategoryLabel = it.FbssCategory.GetConfigValue<SysDictData>("sys_exp_type"),
                    FbssFlagLabel = it.FbssFlag.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetStaffSlv> QueryExp(FicoBudgetStaffSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetStaffSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbssYm), it => it.FbssYm == parm.FbssYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbssTitle), it => it.FbssTitle == parm.FbssTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbssClass), it => it.FbssClass.Contains(parm.FbssClass));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbssCategory), it => it.FbssCategory == parm.FbssCategory);
            predicate = predicate.AndIF(parm.FbssFlag != null, it => it.FbssFlag == parm.FbssFlag);
            predicate = predicate.AndIF(parm.FbssAudit != null, it => it.FbssAudit == parm.FbssAudit);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbssAuditDate == null, it => it.FbssAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbssAuditDate == null, it => it.FbssAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbssAuditDate != null, it => it.FbssAuditDate >= parm.BeginFbssAuditDate);
            predicate = predicate.AndIF(parm.EndFbssAuditDate != null, it => it.FbssAuditDate <= parm.EndFbssAuditDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbssUndoDate == null, it => it.FbssUndoDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbssUndoDate == null, it => it.FbssUndoDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbssUndoDate != null, it => it.FbssUndoDate >= parm.BeginFbssUndoDate);
            predicate = predicate.AndIF(parm.EndFbssUndoDate != null, it => it.FbssUndoDate <= parm.EndFbssUndoDate);
            return predicate;
        }
    }
}