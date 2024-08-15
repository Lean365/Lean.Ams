using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 加班预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:06:46
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetOvertimeSlvService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetOvertimeSlvService : BaseService<FicoBudgetOvertimeSlv>, IFicoBudgetOvertimeSlvService
    {
        /// <summary>
        /// 查询加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetOvertimeSlvDto> GetList(FicoBudgetOvertimeSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("FbosYm desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetOvertimeSlv, FicoBudgetOvertimeSlvDto>(parm);

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
            int count = Count(it => it. FbosSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbosSfId"></param>
        /// <returns></returns>
        public FicoBudgetOvertimeSlv GetInfo(long FbosSfId)
        {
            var response = Queryable()
                .Where(x => x.FbosSfId == FbosSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetOvertimeSlv AddFicoBudgetOvertimeSlv(FicoBudgetOvertimeSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetOvertimeSlv(FicoBudgetOvertimeSlv model)
        {
            return Update(model, true, "修改加班预算");
        }

        /// <summary>
        /// 导入加班预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetOvertimeSlv(List<FicoBudgetOvertimeSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbosSfId.IsEmpty(), "ID不能为空")
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
        public PagedInfo<FicoBudgetOvertimeSlvDto> ExportList(FicoBudgetOvertimeSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetOvertimeSlvDto()
                {
                    FbosYmLabel = it.FbosYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbosTitleLabel = it.FbosTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    FbosFlagLabel = it.FbosFlag.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetOvertimeSlv> QueryExp(FicoBudgetOvertimeSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetOvertimeSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbosYm), it => it.FbosYm == parm.FbosYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbosTitle), it => it.FbosTitle == parm.FbosTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbosClass), it => it.FbosClass.Contains(parm.FbosClass));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbosAuditDate == null, it => it.FbosAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbosAuditDate == null, it => it.FbosAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbosAuditDate != null, it => it.FbosAuditDate >= parm.BeginFbosAuditDate);
            predicate = predicate.AndIF(parm.EndFbosAuditDate != null, it => it.FbosAuditDate <= parm.EndFbosAuditDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbosUndoDate == null, it => it.FbosUndoDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbosUndoDate == null, it => it.FbosUndoDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbosUndoDate != null, it => it.FbosUndoDate >= parm.BeginFbosUndoDate);
            predicate = predicate.AndIF(parm.EndFbosUndoDate != null, it => it.FbosUndoDate <= parm.EndFbosUndoDate);
            return predicate;
        }
    }
}