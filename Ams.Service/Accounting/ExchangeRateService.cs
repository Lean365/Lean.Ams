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
    /// 汇率表
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:07:17)
    /// </summary>
    [AppService(ServiceType = typeof(IExchangeRateService), ServiceLifetime = LifeTime.Transient)]
    public class ExchangeRateService : BaseService<ExchangeRate>, IExchangeRateService
    {
        /// <summary>
        /// 查询汇率表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ExchangeRateDto> GetList(ExchangeRateQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<ExchangeRate, ExchangeRateDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. FerSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FerSFID"></param>
        /// <returns></returns>
        public ExchangeRate GetInfo(long FerSFID)
        {
            var response = Queryable()
                .Where(x => x.FerSFID == FerSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加汇率表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ExchangeRate AddExchangeRate(ExchangeRate model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改汇率表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateExchangeRate(ExchangeRate model)
        {
            return Update(model, true, "修改汇率表");
        }

        /// <summary>
        /// 导入汇率表
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportExchangeRate(List<ExchangeRate> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FerSFID.IsEmpty(), "FSID不能为空")
                .SplitError(x => x.Item.FerCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FerEffDate.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.FerStd.IsEmpty(), "基数不能为空")
                .SplitError(x => x.Item.FerfmCcy.IsEmpty(), "从币种不能为空")
                .SplitError(x => x.Item.FerRate.IsEmpty(), "汇率不能为空")
                .SplitError(x => x.Item.FertoCcy.IsEmpty(), "到币种不能为空")
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
        /// 导出汇率表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ExchangeRateDto> ExportList(ExchangeRateQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new ExchangeRateDto()
                {
                    FerCorpLabel = it.FerCorp.GetConfigValue<Kernel.Model.System.SysDictData>("sys_crop_list"),
                    FerfmCcyLabel = it.FerfmCcy.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ccy_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<ExchangeRate> QueryExp(ExchangeRateQueryDto parm)
        {
            var predicate = Expressionable.Create<ExchangeRate>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FerCorp), it => it.FerCorp == parm.FerCorp);
            predicate = predicate.AndIF(parm.BeginFerEffDate == null, it => it.FerEffDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginFerEffDate != null, it => it.FerEffDate >= parm.BeginFerEffDate);
            predicate = predicate.AndIF(parm.EndFerEffDate != null, it => it.FerEffDate <= parm.EndFerEffDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FerfmCcy), it => it.FerfmCcy == parm.FerfmCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FertoCcy), it => it.FertoCcy == parm.FertoCcy);
            return predicate;
        }
    }
}