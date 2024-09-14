//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 月度资产
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:54:31
    /// </summary>
    [AppService(ServiceType = typeof(IFicoMonthlyAssetsService), ServiceLifetime = LifeTime.Transient)]
    public class FicoMonthlyAssetsService : BaseService<FicoMonthlyAssets>, IFicoMonthlyAssetsService
    {
        /// <summary>
        /// 查询月度资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyAssetsDto> GetList(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mo003 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoMonthlyAssets, FicoMonthlyAssetsDto>(parm);

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
        public FicoMonthlyAssets GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加月度资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoMonthlyAssets AddFicoMonthlyAssets(FicoMonthlyAssets model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改月度资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoMonthlyAssets(FicoMonthlyAssets model)
        {
            return Update(model, true, "修改月度资产");
        }

        /// <summary>
        /// 导入月度资产
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoMonthlyAssets(List<FicoMonthlyAssets> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mo002.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mo003.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mo004.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mo012.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Mo013.IsEmpty(), "管理区分不能为空")
                .SplitError(x => x.Item.Mo014.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.Mo015.IsEmpty(), "购买价格不能为空")
                .SplitError(x => x.Item.Mo017.IsEmpty(), "折旧价值不能为空")
                .SplitError(x => x.Item.Mo019.IsEmpty(), "残值不能为空")
                .SplitError(x => x.Item.Mo021.IsEmpty(), "使用年限不能为空")
                .SplitError(x => x.Item.Mo022.IsEmpty(), "是否停用不能为空")
                .SplitError(x => x.Item.Mo027.IsEmpty(), "资产形态不能为空")
                .SplitError(x => x.Item.Mo028.IsEmpty(), "资产存在否不能为空")
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
        /// 导出月度资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyAssetsDto> ExportList(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoMonthlyAssetsDto()
                {
                    //查询字典: <期间> 
                    Mo002Label = it.Mo002.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mo003Label = it.Mo003.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司> 
                    Mo004Label = it.Mo004.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <成本中心> 
                    Mo008Label = it.Mo008.GetConfigValue<SysDictData>("sql_cost_center"),
                    //查询字典: <是否停用> 
                    Mo022Label = it.Mo022.GetConfigValue<SysDictData>("sys_is_flag"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoMonthlyAssets> QueryExp(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoMonthlyAssets>();

            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mo002), it => it.Mo002 == parm.Mo002);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mo003), it => it.Mo003 == parm.Mo003);
            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mo004), it => it.Mo004 == parm.Mo004);
            //查询字段: <成本中心> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mo008), it => it.Mo008 == parm.Mo008);
            //查询字段: <资产简称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mo009), it => it.Mo009.Contains(parm.Mo009));
            //查询字段: <资本化日期> 
            //predicate = predicate.AndIF(parm.BeginMo016 == null, it => it.Mo016 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMo016 != null, it => it.Mo016 >= parm.BeginMo016);
            //predicate = predicate.AndIF(parm.EndMo016 != null, it => it.Mo016 <= parm.EndMo016);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMo016 == null, it => it.Mo016 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMo016 == null, it => it.Mo016 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMo016 != null, it => it.Mo016 >= parm.BeginMo016);
            predicate = predicate.AndIF(parm.EndMo016 != null, it => it.Mo016 <= parm.EndMo016);
            //查询字段: <报废日期> 
            //predicate = predicate.AndIF(parm.BeginMo018 == null, it => it.Mo018 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMo018 != null, it => it.Mo018 >= parm.BeginMo018);
            //predicate = predicate.AndIF(parm.EndMo018 != null, it => it.Mo018 <= parm.EndMo018);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMo018 == null, it => it.Mo018 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMo018 == null, it => it.Mo018 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMo018 != null, it => it.Mo018 >= parm.BeginMo018);
            predicate = predicate.AndIF(parm.EndMo018 != null, it => it.Mo018 <= parm.EndMo018);
            return predicate;
        }
    }
}