using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 财务期间
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:53
    /// </summary>
    [AppService(ServiceType = typeof(IFicoPeriodService), ServiceLifetime = LifeTime.Transient)]
    public class FicoPeriodService : BaseService<FicoPeriod>, IFicoPeriodService
    {
        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoPeriodDto> GetList(FicoPeriodQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoPeriod, FicoPeriodDto>(parm);

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
            int count = Count(it => it. FpSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        public FicoPeriod GetInfo(long FpSFID)
        {
            var response = Queryable()
                .Where(x => x.FpSFID == FpSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 添加财务期间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoPeriod AddFicoPeriod(FicoPeriod model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改财务期间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoPeriod(FicoPeriod model)
        {
            return Update(model, true, "修改财务期间");
        }

        /// <summary>
        /// 导入财务期间
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoPeriod(List<FicoPeriod> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FpSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FpFy.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FpYm.IsEmpty(), "年月不能为空")
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
        public PagedInfo<FicoPeriodDto> ExportList(FicoPeriodQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoPeriodDto()
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
        private static Expressionable<FicoPeriod> QueryExp(FicoPeriodQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoPeriod>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpFy), it => it.FpFy == parm.FpFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpYm), it => it.FpYm == parm.FpYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpYear), it => it.FpYear == parm.FpYear);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpMonth), it => it.FpMonth == parm.FpMonth);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpQuarter), it => it.FpQuarter == parm.FpQuarter);
            return predicate;
        }
    }
}