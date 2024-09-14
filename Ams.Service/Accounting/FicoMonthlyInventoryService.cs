//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 月度存货
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:55:10
    /// </summary>
    [AppService(ServiceType = typeof(IFicoMonthlyInventoryService), ServiceLifetime = LifeTime.Transient)]
    public class FicoMonthlyInventoryService : BaseService<FicoMonthlyInventory>, IFicoMonthlyInventoryService
    {
        /// <summary>
        /// 查询月度存货列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyInventoryDto> GetList(FicoMonthlyInventoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mp003 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoMonthlyInventory, FicoMonthlyInventoryDto>(parm);

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
        public FicoMonthlyInventory GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加月度存货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoMonthlyInventory AddFicoMonthlyInventory(FicoMonthlyInventory model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改月度存货
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoMonthlyInventory(FicoMonthlyInventory model)
        {
            return Update(model, true, "修改月度存货");
        }

        /// <summary>
        /// 导入月度存货
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoMonthlyInventory(List<FicoMonthlyInventory> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mp002.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mp003.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mp004.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mp005.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Mp009.IsEmpty(), "Per单位不能为空")
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
        /// 导出月度存货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyInventoryDto> ExportList(FicoMonthlyInventoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoMonthlyInventoryDto()
                {
                    //查询字典: <期间> 
                    Mp002Label = it.Mp002.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mp003Label = it.Mp003.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <工厂> 
                    Mp004Label = it.Mp004.GetConfigValue<SysDictData>("sql_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoMonthlyInventory> QueryExp(FicoMonthlyInventoryQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoMonthlyInventory>();

            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mp002), it => it.Mp002 == parm.Mp002);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mp003), it => it.Mp003 == parm.Mp003);
            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mp004), it => it.Mp004 == parm.Mp004);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mp005), it => it.Mp005.Contains(parm.Mp005));
            return predicate;
        }
    }
}