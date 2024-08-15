using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 资产预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:23:49
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
                //.OrderBy("FbasYm desc")
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
                .SplitError(x => x.Item.FbasSfId.IsEmpty(), "ID不能为空")
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
                    FbasYmLabel = it.FbasYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbasTitleLabel = it.FbasTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    FbasClassLabel = it.FbasClass.GetConfigValue<SysDictData>("sys_exp_type"),
                    FbasFlagLabel = it.FbasFlag.GetConfigValue<SysDictData>("sys_is_status"),
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

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasYm), it => it.FbasYm == parm.FbasYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasTitle), it => it.FbasTitle == parm.FbasTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasClass), it => it.FbasClass == parm.FbasClass);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasName), it => it.FbasName.Contains(parm.FbasName));
            predicate = predicate.AndIF(parm.FbasFlag != null, it => it.FbasFlag == parm.FbasFlag);
            predicate = predicate.AndIF(parm.FbasAudit != null, it => it.FbasAudit == parm.FbasAudit);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbasAuditDate == null, it => it.FbasAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbasAuditDate == null, it => it.FbasAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbasAuditDate != null, it => it.FbasAuditDate >= parm.BeginFbasAuditDate);
            predicate = predicate.AndIF(parm.EndFbasAuditDate != null, it => it.FbasAuditDate <= parm.EndFbasAuditDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbasUndoDate == null, it => it.FbasUndoDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbasUndoDate == null, it => it.FbasUndoDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbasUndoDate != null, it => it.FbasUndoDate >= parm.BeginFbasUndoDate);
            predicate = predicate.AndIF(parm.EndFbasUndoDate != null, it => it.FbasUndoDate <= parm.EndFbasUndoDate);
            return predicate;
        }
    }
}