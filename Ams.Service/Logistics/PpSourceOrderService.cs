//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源订单
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:05:57
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceOrderService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceOrderService : BaseService<PpSourceOrder>, IPpSourceOrderService
    {
        /// <summary>
        /// 查询源订单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceOrderDto> GetList(PpSourceOrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Zf009 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpSourceOrder, PpSourceOrderDto>(parm);

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
        public PpSourceOrder GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加源订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceOrder AddPpSourceOrder(PpSourceOrder model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改源订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceOrder(PpSourceOrder model)
        {
            return Update(model, true, "修改源订单");
        }

        /// <summary>
        /// 导入源订单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceOrder(List<PpSourceOrder> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Zf002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Zf003.IsEmpty(), "订单类型不能为空")
                .SplitError(x => x.Item.Zf004.IsEmpty(), "生产订单不能为空")
                .SplitError(x => x.Item.Zf005.IsEmpty(), "品号不能为空")
                .SplitError(x => x.Item.Zf007.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Zf008.IsEmpty(), "已生产不能为空")
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
        /// 导出源订单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceOrderDto> ExportList(PpSourceOrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceOrderDto()
                {
                    //查询字典: <工厂> 
                    Zf002Label = it.Zf002.GetConfigValue<SysDictData>("sql_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpSourceOrder> QueryExp(PpSourceOrderQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceOrder>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zf002), it => it.Zf002 == parm.Zf002);
            //查询字段: <生产订单> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zf004), it => it.Zf004.Contains(parm.Zf004));
            //查询字段: <品号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zf005), it => it.Zf005.Contains(parm.Zf005));
            return predicate;
        }
    }
}