//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 费用预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 8:05:21
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
                //.OrderBy("Mh004 desc")
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
            int count = Count(it => it. Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FicoBudgetExpense GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
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
                .SplitError(x => x.Item.Mh003.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mh004.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mh005.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mh006.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.Mh007.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.Mh008.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.Mh010.IsEmpty(), "单价不能为空")
                .SplitError(x => x.Item.Mh011.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Mh012.IsEmpty(), "金额不能为空")
                .SplitError(x => x.Item.Mh013.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.Mh014.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.Mh015.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.Mh016.IsEmpty(), "审核不能为空")
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
                    //查询字典: <期间> 
                    Mh003Label = it.Mh003.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mh004Label = it.Mh004.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司> 
                    Mh005Label = it.Mh005.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <部门> 
                    Mh006Label = it.Mh006.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <科目> 
                    Mh007Label = it.Mh007.GetConfigValue<SysDictData>("sql_budget_details"),
                    //查询字典: <类别> 
                    Mh008Label = it.Mh008.GetConfigValue<SysDictData>("sys_costs_type"),
                    //查询字典: <启用> 
                    Mh015Label = it.Mh015.GetConfigValue<SysDictData>("sys_is_status"),
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

            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh003), it => it.Mh003 == parm.Mh003);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh004), it => it.Mh004 == parm.Mh004);
            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh005), it => it.Mh005 == parm.Mh005);
            //查询字段: <部门> 
            predicate = predicate.AndIF(parm.Mh006 != -1, it => it.Mh006 == parm.Mh006);
            //查询字段: <科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh007), it => it.Mh007 == parm.Mh007);
            //查询字段: <类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh008), it => it.Mh008 == parm.Mh008);
            //查询字段: <用途> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh009), it => it.Mh009.Contains(parm.Mh009));
            //查询字段: <审核> 
            predicate = predicate.AndIF(parm.Mh016 != -1, it => it.Mh016 == parm.Mh016);
            return predicate;
        }
    }
}