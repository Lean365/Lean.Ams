using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 财务期间
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:59:13
    /// </summary>
    [AppService(ServiceType = typeof(IFicoFinancialPeriodService), ServiceLifetime = LifeTime.Transient)]
    public class FicoFinancialPeriodService : BaseService<FicoFinancialPeriod>, IFicoFinancialPeriodService
    {
        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoFinancialPeriodDto> GetList(FicoFinancialPeriodQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
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
            int count = Count(it => it. FpSfid.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FpSfid"></param>
        /// <returns></returns>
        public FicoFinancialPeriod GetInfo(long FpSfid)
        {
            var response = Queryable()
                .Where(x => x.FpSfid == FpSfid)
                .First();

            return response;
        }
        /// <summary>
        /// 添加财务期间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoFinancialPeriod AddFicoFinancialPeriod(FicoFinancialPeriod model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改财务期间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoFinancialPeriod(FicoFinancialPeriod model)
        {
            return Update(model, true, "修改财务期间");
        }

        /// <summary>
        /// 导入财务期间
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoFinancialPeriod(List<FicoFinancialPeriod> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FpSfid.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FpFinancialYear.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FpYearMonth.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FpYear.IsEmpty(), "年不能为空")
                .SplitError(x => x.Item.FpMonth.IsEmpty(), "月不能为空")
                .SplitError(x => x.Item.FpQuarter.IsEmpty(), "季度不能为空")
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
        /// 导出财务期间
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
        private static Expressionable<FicoFinancialPeriod> QueryExp(FicoFinancialPeriodQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoFinancialPeriod>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpFinancialYear), it => it.FpFinancialYear == parm.FpFinancialYear);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpYearMonth), it => it.FpYearMonth == parm.FpYearMonth);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpYear), it => it.FpYear == parm.FpYear);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpMonth), it => it.FpMonth == parm.FpMonth);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpQuarter), it => it.FpQuarter == parm.FpQuarter);
            return predicate;
        }
    }
}