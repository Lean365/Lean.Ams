using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源订单
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:14
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
            int count = Count(it => it. SfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        public PpSourceOrder GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
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
                .SplitError(x => x.Item.SfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.Cooisma001.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Cooisma002.IsEmpty(), "生产订单不能为空")
                .SplitError(x => x.Item.Cooisma003.IsEmpty(), "品号不能为空")
                .SplitError(x => x.Item.Cooisma005.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Cooisma006.IsEmpty(), "已生产不能为空")
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
                    Cooisma001Label = it.Cooisma001.GetConfigValue<SysDictData>("sys_plant_list"),
                    Cooisma009Label = it.Cooisma009.GetConfigValue<SysDictData>("sys_mo_type"),
                    Cooisma003Label = it.Cooisma003.GetConfigValue<SysDictData>("sql_mats_list"),
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
        private static Expressionable<PpSourceOrder> QueryExp(PpSourceOrderQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceOrder>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Cooisma001), it => it.Cooisma001 == parm.Cooisma001);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Cooisma009), it => it.Cooisma009 == parm.Cooisma009);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Cooisma002), it => it.Cooisma002.Contains(parm.Cooisma002));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Cooisma003), it => it.Cooisma003.Contains(parm.Cooisma003));
            return predicate;
        }
    }
}