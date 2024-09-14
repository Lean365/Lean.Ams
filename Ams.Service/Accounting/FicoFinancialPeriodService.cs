//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 财政年度
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:58
    /// </summary>
    [AppService(ServiceType = typeof(IFicoFinancialPeriodService), ServiceLifetime = LifeTime.Transient)]
    public class FicoFinancialPeriodService : BaseService<FicoFinancialPeriod>, IFicoFinancialPeriodService
    {
        /// <summary>
        /// 查询财政年度列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoFinancialPeriodDto> GetList(FicoFinancialPeriodQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mn002 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoFinancialPeriod, FicoFinancialPeriodDto>(parm);

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
            int count = Count(it => it.Id.ToString() == enterString);
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
        public FicoFinancialPeriod GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加财政年度
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoFinancialPeriod AddFicoFinancialPeriod(FicoFinancialPeriod model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改财政年度
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoFinancialPeriod(FicoFinancialPeriod model)
        {
            return Update(model, true, "修改财政年度");
        }

        /// <summary>
        /// 导入财政年度
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoFinancialPeriod(List<FicoFinancialPeriod> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mn002.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mn003.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mn004.IsEmpty(), "年不能为空")
                .SplitError(x => x.Item.Mn005.IsEmpty(), "月不能为空")
                .SplitError(x => x.Item.Mn006.IsEmpty(), "季度不能为空")
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
        /// 导出财政年度
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoFinancialPeriodDto> ExportList(FicoFinancialPeriodQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoFinancialPeriodDto()
                {
                    //查询字典: <软删除>
                    //IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_Is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoFinancialPeriod> QueryExp(FicoFinancialPeriodQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoFinancialPeriod>();

            //查询字段: <期间>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mn002), it => it.Mn002.Contains(parm.Mn002));
            //查询字段: <年月>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mn003), it => it.Mn003.Contains(parm.Mn003));
            return predicate;
        }
    }
}