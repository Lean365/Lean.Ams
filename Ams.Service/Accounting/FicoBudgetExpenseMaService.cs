using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 费用预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:31:03
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetExpenseMaService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetExpenseMaService : BaseService<FicoBudgetExpenseMa>, IFicoBudgetExpenseMaService
    {
        /// <summary>
        /// 查询费用预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetExpenseMaDto> GetList(FicoBudgetExpenseMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.FicoBudgetExpenseSlvNav) //填充子对象
                //.OrderBy("FbeFy desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetExpenseMa, FicoBudgetExpenseMaDto>(parm);

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
            int count = Count(it => it.FbeSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbeSfId"></param>
        /// <returns></returns>
        public FicoBudgetExpenseMa GetInfo(long FbeSfId)
        {
            var response = Queryable()
                .Includes(x => x.FicoBudgetExpenseSlvNav) //填充子对象
                .Where(x => x.FbeSfId == FbeSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加费用预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetExpenseMa AddFicoBudgetExpenseMa(FicoBudgetExpenseMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.FicoBudgetExpenseSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改费用预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetExpenseMa(FicoBudgetExpenseMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.FicoBudgetExpenseSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入费用预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetExpenseMa(List<FicoBudgetExpenseMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbeSfId.IsEmpty(), "ID不能为空")
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
        public PagedInfo<FicoBudgetExpenseMaDto> ExportList(FicoBudgetExpenseMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetExpenseMaDto()
                {
                    FbeFyLabel = it.FbeFy.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbeCorpLabel = it.FbeCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbeDeptLabel = it.FbeDept.GetConfigValue<SysDictData>("sql_dept_name"),
                    //FbesTitleLabel = it.FbesTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    //FbesTitlesubLabel = it.FbesTitlesub.GetConfigValue<SysDictData>("sql_budget_details"),
                    // FbssFlagLabel = it.FbssFlag.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetExpenseMa> QueryExp(FicoBudgetExpenseMaQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetExpenseMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeFy), it => it.FbeFy == parm.FbeFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeCorp), it => it.FbeCorp == parm.FbeCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeDept), it => it.FbeDept == parm.FbeDept);
            return predicate;
        }
    }
}