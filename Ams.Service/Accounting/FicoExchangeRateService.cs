using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 汇率表
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:18
    /// </summary>
    [AppService(ServiceType = typeof(IFicoExchangeRateService), ServiceLifetime = LifeTime.Transient)]
    public class FicoExchangeRateService : BaseService<FicoExchangeRate>, IFicoExchangeRateService
    {
        /// <summary>
        /// 查询汇率表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoExchangeRateDto> GetList(FicoExchangeRateQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
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
            int count = Count(it => it. FerSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FerSfId"></param>
        /// <returns></returns>
        public FicoExchangeRate GetInfo(long FerSfId)
        {
            var response = Queryable()
                .Where(x => x.FerSfId == FerSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加汇率表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoExchangeRate AddFicoExchangeRate(FicoExchangeRate model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改汇率表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoExchangeRate(FicoExchangeRate model)
        {
            return Update(model, true, "修改汇率表");
        }

        /// <summary>
        /// 导入汇率表
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoExchangeRate(List<FicoExchangeRate> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FerSfId.IsEmpty(), "ID不能为空")
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
        public PagedInfo<FicoExchangeRateDto> ExportList(FicoExchangeRateQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoExchangeRateDto()
                {
                    FerCorpLabel = it.FerCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FerfmCcyLabel = it.FerfmCcy.GetConfigValue<SysDictData>("sys_ccy_type"),
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
        private static Expressionable<FicoExchangeRate> QueryExp(FicoExchangeRateQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoExchangeRate>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FerCorp), it => it.FerCorp == parm.FerCorp);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFerEffDate == null, it => it.FerEffDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFerEffDate == null, it => it.FerEffDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFerEffDate != null, it => it.FerEffDate >= parm.BeginFerEffDate);
            predicate = predicate.AndIF(parm.EndFerEffDate != null, it => it.FerEffDate <= parm.EndFerEffDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FerfmCcy), it => it.FerfmCcy == parm.FerfmCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FertoCcy), it => it.FertoCcy == parm.FertoCcy);
            return predicate;
        }
    }
}