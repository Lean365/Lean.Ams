//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 币种汇率
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:52:45
    /// </summary>
    [AppService(ServiceType = typeof(IFicoExchangeRateService), ServiceLifetime = LifeTime.Transient)]
    public class FicoExchangeRateService : BaseService<FicoExchangeRate>, IFicoExchangeRateService
    {
        /// <summary>
        /// 查询币种汇率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoExchangeRateDto> GetList(FicoExchangeRateQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mm003 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoExchangeRate, FicoExchangeRateDto>(parm);

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
        public FicoExchangeRate GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加币种汇率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoExchangeRate AddFicoExchangeRate(FicoExchangeRate model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改币种汇率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoExchangeRate(FicoExchangeRate model)
        {
            return Update(model, true, "修改币种汇率");
        }

        /// <summary>
        /// 导入币种汇率
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoExchangeRate(List<FicoExchangeRate> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mm002.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mm003.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.Mm004.IsEmpty(), "从币种不能为空")
                .SplitError(x => x.Item.Mm005.IsEmpty(), "基数不能为空")
                .SplitError(x => x.Item.Mm006.IsEmpty(), "汇率不能为空")
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
        /// 导出币种汇率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoExchangeRateDto> ExportList(FicoExchangeRateQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoExchangeRateDto()
                {
                    //查询字典: <公司> 
                    Mm002Label = it.Mm002.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <从币种> 
                    Mm004Label = it.Mm004.GetConfigValue<SysDictData>("sql_global_currency"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoExchangeRate> QueryExp(FicoExchangeRateQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoExchangeRate>();

            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mm002), it => it.Mm002 == parm.Mm002);
            //查询字段: <日期> 
            //predicate = predicate.AndIF(parm.BeginMm003 == null, it => it.Mm003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMm003 != null, it => it.Mm003 >= parm.BeginMm003);
            //predicate = predicate.AndIF(parm.EndMm003 != null, it => it.Mm003 <= parm.EndMm003);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMm003 == null, it => it.Mm003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMm003 == null, it => it.Mm003 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMm003 != null, it => it.Mm003 >= parm.BeginMm003);
            predicate = predicate.AndIF(parm.EndMm003 != null, it => it.Mm003 <= parm.EndMm003);
            //查询字段: <从币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mm004), it => it.Mm004 == parm.Mm004);
            return predicate;
        }
    }
}