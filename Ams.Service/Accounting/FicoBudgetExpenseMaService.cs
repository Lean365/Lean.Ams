using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 费用预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:31:54
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
                //.OrderBy("FbeFm desc")
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
                .SplitError(x => x.Item.FbeSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.FbeCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FbeDept.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.FbeFy.IsEmpty(), "财年不能为空")
                //.SplitError(x => x.Item.FbeFm.IsEmpty(), "年月不能为空")
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
        public PagedInfo<FicoBudgetExpenseMaDto> ExportList(FicoBudgetExpenseMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetExpenseMaDto()
                {
                    FbeCorpLabel = it.FbeCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbeDeptLabel = it.FbeDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FbeFyLabel = it.FbeFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    // FbeFmLabel = it.FbeFm.GetConfigValue<SysDictData>("sql_ym_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //FbesTitleLabel = it.FbesTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    //FbesTitlesubLabel = it.FbesTitlesub.GetConfigValue<SysDictData>("sql_budget_details"),
                    //FbssFlagLabel = it.FbssFlag.GetConfigValue<SysDictData>("sys_flag_list"),
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

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeCorp), it => it.FbeCorp == parm.FbeCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeDept), it => it.FbeDept == parm.FbeDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeFy), it => it.FbeFy == parm.FbeFy);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbeFm), it => it.FbeFm == parm.FbeFm);
            return predicate;
        }
    }
}