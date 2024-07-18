using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 生产工单
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:49
    /// </summary>
    [AppService(ServiceType = typeof(IPpOrderService), ServiceLifetime = LifeTime.Transient)]
    public class PpOrderService : BaseService<PpOrder>, IPpOrderService
    {
        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOrderDto> GetList(PpOrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpOrder, PpOrderDto>(parm);

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
            int count = Count(it => it. MoSFID.ToString() == enterString);
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
        public PpOrder GetInfo(long MoSFID)
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
        public PpOrder AddPpOrder(PpOrder model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改生产工单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOrder(PpOrder model)
        {
            return Update(model, true, "修改生产工单");
        }

        /// <summary>
        /// 导入生产工单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOrder(List<PpOrder> list)
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
                .SplitError(x => x.Item.IsStatus.IsEmpty(), "状态不能为空")
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
        /// 导出生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOrderDto> ExportList(PpOrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpOrderDto()
                {
                    MoOrderTypeLabel = it.MoOrderType.GetConfigValue<SysDictData>("sys_mo_type"),
                    IsStatusLabel = it.IsStatus.GetConfigValue<SysDictData>("sys_mo_state"),
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
        private static Expressionable<PpOrder> QueryExp(PpOrderQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOrder>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderType), it => it.MoOrderType == parm.MoOrderType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderNo), it => it.MoOrderNo.Contains(parm.MoOrderNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderItem), it => it.MoOrderItem.Contains(parm.MoOrderItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoOrderlot), it => it.MoOrderlot.Contains(parm.MoOrderlot));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.MoOrderDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.MoOrderDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMoOrderDate != null, it => it.MoOrderDate >= parm.BeginMoOrderDate);
            predicate = predicate.AndIF(parm.EndMoOrderDate != null, it => it.MoOrderDate <= parm.EndMoOrderDate);
            return predicate;
        }
    }
}