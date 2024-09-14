//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 销售价格
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:46:00
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
                //.OrderBy("Md003 desc")
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
        public SdSellingPrice GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
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
                .SplitError(x => x.Item.Md007.IsEmpty(), "原币价格不能为空")
                .SplitError(x => x.Item.Md009.IsEmpty(), "原币Per单位不能为空")
                .SplitError(x => x.Item.Md011.IsEmpty(), "本币价格不能为空")
                .SplitError(x => x.Item.Md013.IsEmpty(), "本币Per单位不能为空")
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
                    //查询字典: <工厂> 
                    Md002Label = it.Md002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <期间> 
                    Md003Label = it.Md003.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Md004Label = it.Md004.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <物料> 
                    Md005Label = it.Md005.GetConfigValue<SysDictData>("sql_mats_list"),
                    //查询字典: <原币种> 
                    Md008Label = it.Md008.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <原币利润中心> 
                    Md010Label = it.Md010.GetConfigValue<SysDictData>("sql_prctr_list"),
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

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md002), it => it.Md002 == parm.Md002);
            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md003), it => it.Md003 == parm.Md003);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md004), it => it.Md004 == parm.Md004);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md005), it => it.Md005 == parm.Md005);
            //查询字段: <原币利润中心> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md010), it => it.Md010 == parm.Md010);
            return predicate;
        }
    }
}