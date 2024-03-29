using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Linq;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 财务期间
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:02:36)
    /// </summary>
    [AppService(ServiceType = typeof(IPeriodService), ServiceLifetime = LifeTime.Transient)]
    public class PeriodService : BaseService<Period>, IPeriodService
    {
        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PeriodDto> GetList(PeriodQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Period, PeriodDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
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
        public Period GetInfo(long FpSFID)
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
        public Period AddPeriod(Period model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改财务期间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePeriod(Period model)
        {
            return Update(model, true, "修改财务期间");
        }

        /// <summary>
        /// 导入财务期间
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPeriod(List<Period> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FpSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FpFy.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FpYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FpYear.IsEmpty(), "年不能为空")
                .SplitError(x => x.Item.FpMonth.IsEmpty(), "月不能为空")
                .SplitError(x => x.Item.FpQuarter.IsEmpty(), "季度不能为空")
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
        public PagedInfo<PeriodDto> ExportList(PeriodQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PeriodDto()
                {
                    FpFyLabel = it.FpFy.GetConfigValue<Kernel.Model.System.SysDictData>("sql_period_list"),
                    FpYmLabel = it.FpYm.GetConfigValue<Kernel.Model.System.SysDictData>("sql_ficoym_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Period> QueryExp(PeriodQueryDto parm)
        {
            var predicate = Expressionable.Create<Period>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpYm), it => it.FpYm == parm.FpYm);
            return predicate;
        }
    }
}