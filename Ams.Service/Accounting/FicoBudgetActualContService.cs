//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 实际对比
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 14:38:54
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetActualContService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetActualContService : BaseService<FicoBudgetActualCont>, IFicoBudgetActualContService
    {
        /// <summary>
        /// 查询实际对比列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> GetList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Me003 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetActualCont, FicoBudgetActualContDto>(parm);

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
        public FicoBudgetActualCont GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加实际对比
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetActualCont AddFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改实际对比
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            return Update(model, true, "修改实际对比");
        }

        /// <summary>
        /// 导入实际对比
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetActualCont(List<FicoBudgetActualCont> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Me002.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Me003.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Me004.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.Me009.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.Me010.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.Me011.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.Me012.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.Ref04.IsEmpty(), "预留1不能为空")
                .SplitError(x => x.Item.Ref05.IsEmpty(), "预留2不能为空")
                .SplitError(x => x.Item.Ref06.IsEmpty(), "预留3不能为空")
                .SplitError(x => x.Item.Udf51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.Udf52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.Udf53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.Udf54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.Udf55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.Udf56.IsEmpty(), "自定义6不能为空")
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
        /// 导出实际对比
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> ExportList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetActualContDto()
                {
                    //查询字典: <期间> 
                    Me002Label = it.Me002.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Me003Label = it.Me003.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司代码> 
                    Me004Label = it.Me004.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <币种> 
                    Me009Label = it.Me009.GetConfigValue<SysDictData>("sql_global_currency"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetActualCont> QueryExp(FicoBudgetActualContQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetActualCont>();

            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me002), it => it.Me002 == parm.Me002);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me003), it => it.Me003 == parm.Me003);
            //查询字段: <公司代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me004), it => it.Me004 == parm.Me004);
            //查询字段: <币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me009), it => it.Me009 == parm.Me009);
            return predicate;
        }
    }
}