using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 资产预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:59:42
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAssetsSlvService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAssetsSlvService : BaseService<FicoBudgetAssetsSlv>, IFicoBudgetAssetsSlvService
    {
        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAssetsSlvDto> GetList(FicoBudgetAssetsSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetAssetsSlv, FicoBudgetAssetsSlvDto>(parm);

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
            int count = Count(it => it. FbasSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        public FicoBudgetAssetsSlv GetInfo(long FbasSfId)
        {
            var response = Queryable()
                .Where(x => x.FbasSfId == FbasSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAssetsSlv AddFicoBudgetAssetsSlv(FicoBudgetAssetsSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAssetsSlv(FicoBudgetAssetsSlv model)
        {
            return Update(model, true, "修改资产预算");
        }

        /// <summary>
        /// 导入资产预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAssetsSlv(List<FicoBudgetAssetsSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbasSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.FbasParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.FbasTitle.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.FbasClass.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.FbasName.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.FbasDesc.IsEmpty(), "说明不能为空")
                .SplitError(x => x.Item.FbasServiceLife.IsEmpty(), "年限不能为空")
                .SplitError(x => x.Item.FbasBudgetAmount.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.FbasActualAmount.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.FbasDifferenceAmount.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.FbasDepreciation.IsEmpty(), "折旧不能为空")
                .SplitError(x => x.Item.FbasFlag.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.FbasAudit.IsEmpty(), "审核标志不能为空")
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
        /// 导出资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAssetsSlvDto> ExportList(FicoBudgetAssetsSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetAssetsSlvDto()
                {
                    FbasTitleLabel = it.FbasTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    FbasClassLabel = it.FbasClass.GetConfigValue<SysDictData>("sys_exp_type"),
                    FbasFlagLabel = it.FbasFlag.GetConfigValue<SysDictData>("sys_flag_list"),
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
        private static Expressionable<FicoBudgetAssetsSlv> QueryExp(FicoBudgetAssetsSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAssetsSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasTitle), it => it.FbasTitle == parm.FbasTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasClass), it => it.FbasClass == parm.FbasClass);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasName), it => it.FbasName.Contains(parm.FbasName));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbasAuditDate == null, it => it.FbasAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbasAuditDate == null, it => it.FbasAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbasAuditDate != null, it => it.FbasAuditDate >= parm.BeginFbasAuditDate);
            predicate = predicate.AndIF(parm.EndFbasAuditDate != null, it => it.FbasAuditDate <= parm.EndFbasAuditDate);
            return predicate;
        }
    }
}