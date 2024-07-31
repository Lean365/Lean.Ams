using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 销售价格
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 10:59:46
    /// </summary>
    [AppService(ServiceType = typeof(ISdSellingPriceService), ServiceLifetime = LifeTime.Transient)]
    public class SdSellingPriceService : BaseService<SdSellingPrice>, ISdSellingPriceService
    {
        /// <summary>
        /// 查询销售价格列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdSellingPriceDto> GetList(SdSellingPriceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("SspYm desc")
                .Where(predicate.ToExpression())
                .ToPage<SdSellingPrice, SdSellingPriceDto>(parm);

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
            int count = Count(it => it. SspSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SspSfId"></param>
        /// <returns></returns>
        public SdSellingPrice GetInfo(long SspSfId)
        {
            var response = Queryable()
                .Where(x => x.SspSfId == SspSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加销售价格
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SdSellingPrice AddSdSellingPrice(SdSellingPrice model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改销售价格
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSdSellingPrice(SdSellingPrice model)
        {
            return Update(model, true, "修改销售价格");
        }

        /// <summary>
        /// 导入销售价格
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSdSellingPrice(List<SdSellingPrice> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SspSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.SspPlnt.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.SspFy.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.SspYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.SspItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.SspItemtext.IsEmpty(), "物料文本不能为空")
                .SplitError(x => x.Item.SspOriginalfob.IsEmpty(), "原币价格不能为空")
                .SplitError(x => x.Item.SspOriginalccy.IsEmpty(), "原币种不能为空")
                .SplitError(x => x.Item.SspOriginalperunit.IsEmpty(), "原币Per单位不能为空")
                .SplitError(x => x.Item.SspOriginalprctr.IsEmpty(), "原币利润中心不能为空")
                .SplitError(x => x.Item.SspLocalfob.IsEmpty(), "本币价格不能为空")
                .SplitError(x => x.Item.SspLocalccy.IsEmpty(), "本币种不能为空")
                .SplitError(x => x.Item.SspLocalperunit.IsEmpty(), "本币Per单位不能为空")
                .SplitError(x => x.Item.SspLocalprctr.IsEmpty(), "本币利润中心不能为空")
                .SplitError(x => x.Item.SspEffdate.IsEmpty(), "生效日期不能为空")
                .SplitError(x => x.Item.SspExpdate.IsEmpty(), "失效日期不能为空")
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
        /// 导出销售价格
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdSellingPriceDto> ExportList(SdSellingPriceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SdSellingPriceDto()
                {
                    SspPlntLabel = it.SspPlnt.GetConfigValue<SysDictData>("sys_plant_list"),
                    SspFyLabel = it.SspFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    SspYmLabel = it.SspYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    SspOriginalccyLabel = it.SspOriginalccy.GetConfigValue<SysDictData>("sys_ccy_type"),
                    SspOriginalprctrLabel = it.SspOriginalprctr.GetConfigValue<SysDictData>("sql_prctr_list"),
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
        private static Expressionable<SdSellingPrice> QueryExp(SdSellingPriceQueryDto parm)
        {
            var predicate = Expressionable.Create<SdSellingPrice>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SspPlnt), it => it.SspPlnt == parm.SspPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SspFy), it => it.SspFy == parm.SspFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SspYm), it => it.SspYm == parm.SspYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SspItem), it => it.SspItem == parm.SspItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SspOriginalccy), it => it.SspOriginalccy == parm.SspOriginalccy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SspOriginalprctr), it => it.SspOriginalprctr == parm.SspOriginalprctr);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginSspExpdate == null, it => it.SspExpdate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginSspExpdate == null, it => it.SspExpdate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginSspExpdate != null, it => it.SspExpdate >= parm.BeginSspExpdate);
            predicate = predicate.AndIF(parm.EndSspExpdate != null, it => it.SspExpdate <= parm.EndSspExpdate);
            return predicate;
        }
    }
}