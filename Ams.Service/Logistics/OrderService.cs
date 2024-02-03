using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using System.Linq;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 生产工单
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 9:49:40)
    /// </summary>
    [AppService(ServiceType = typeof(IOrderService), ServiceLifetime = LifeTime.Transient)]
    public class OrderService : BaseService<Order>, IOrderService
    {
        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OrderDto> GetList(OrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Order, OrderDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it.MoOrderNo.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MoSFID"></param>
        /// <returns></returns>
        public Order GetInfo(long MoSFID)
        {
            var response = Queryable()
                .Where(x => x.MoSFID == MoSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Order AddOrder(Order model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改生产工单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateOrder(Order model)
        {
            return Update(model, true, "修改生产工单");
        }

        /// <summary>
        /// 导入生产工单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportOrder(List<Order> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MoSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.MoPlant.IsEmpty(), "生产工厂不能为空")
                .SplitError(x => x.Item.MoOrderType.IsEmpty(), "订单类型不能为空")
                .SplitError(x => x.Item.MoOrderNo.IsEmpty(), "生产订单不能为空")
                .SplitError(x => x.Item.MoOrderItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.MoOrderQty.IsEmpty(), "工单数量不能为空")
                .SplitError(x => x.Item.MoOrderProQty.IsEmpty(), "生产数量不能为空")
                .SplitError(x => x.Item.MoOrderDate.IsEmpty(), "订单日期不能为空")
                .SplitError(x => x.Item.IsState.IsEmpty(), "状态不能为空")
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
        /// 导出生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OrderDto> ExportList(OrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new OrderDto()
                {
                    MoPlantLabel = it.MoPlant.GetConfigValue<Kernel.Model.System.SysDictData>("app_plant_list"),
                    MoOrderTypeLabel = it.MoOrderType.GetConfigValue<Kernel.Model.System.SysDictData>("app_mo_type"),
                    MoOrderItemLabel = it.MoOrderItem.GetConfigValue<Kernel.Model.System.SysDictData>("sql_moc_item"),
                    IsStateLabel = it.IsState.GetConfigValue<Kernel.Model.System.SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Order> QueryExp(OrderQueryDto parm)
        {
            var predicate = Expressionable.Create<Order>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoPlant), it => it.MoPlant == parm.MoPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderType), it => it.MoOrderType == parm.MoOrderType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderItem), it => it.MoOrderItem.Contains(parm.MoOrderItem));
            predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.MoOrderDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginMoOrderDate != null, it => it.MoOrderDate >= parm.BeginMoOrderDate);
            predicate = predicate.AndIF(parm.EndMoOrderDate != null, it => it.MoOrderDate <= parm.EndMoOrderDate);
            predicate = predicate.AndIF(parm.IsState != null, it => it.IsState == parm.IsState);
            return predicate;
        }
    }
}