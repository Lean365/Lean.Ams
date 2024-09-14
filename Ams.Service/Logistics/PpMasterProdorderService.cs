//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 生产工单
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:05:47
    /// </summary>
    [AppService(ServiceType = typeof(IPpMasterProdorderService), ServiceLifetime = LifeTime.Transient)]
    public class PpMasterProdorderService : BaseService<PpMasterProdorder>, IPpMasterProdorderService
    {
        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMasterProdorderDto> GetList(PpMasterProdorderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mc004 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpMasterProdorder, PpMasterProdorderDto>(parm);

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
        public PpMasterProdorder GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpMasterProdorder AddPpMasterProdorder(PpMasterProdorder model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改生产工单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpMasterProdorder(PpMasterProdorder model)
        {
            return Update(model, true, "修改生产工单");
        }

        /// <summary>
        /// 导入生产工单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpMasterProdorder(List<PpMasterProdorder> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mc002.IsEmpty(), "生产工厂不能为空")
                .SplitError(x => x.Item.Mc003.IsEmpty(), "订单类型不能为空")
                .SplitError(x => x.Item.Mc012.IsEmpty(), "状态不能为空")
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
        public PagedInfo<PpMasterProdorderDto> ExportList(PpMasterProdorderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpMasterProdorderDto()
                {
                    //查询字典: <生产工厂> 
                    Mc002Label = it.Mc002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <订单类型> 
                    Mc003Label = it.Mc003.GetConfigValue<SysDictData>("sys_mo_type"),
                    //查询字典: <物料> 
                    Mc005Label = it.Mc005.GetConfigValue<SysDictData>("sql_moc_marb"),
                    //查询字典: <状态> 
                    Mc012Label = it.Mc012.GetConfigValue<SysDictData>("sql_comp_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpMasterProdorder> QueryExp(PpMasterProdorderQueryDto parm)
        {
            var predicate = Expressionable.Create<PpMasterProdorder>();

            //查询字段: <生产工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc002), it => it.Mc002 == parm.Mc002);
            //查询字段: <订单类型> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc003), it => it.Mc003 == parm.Mc003);
            //查询字段: <订单号码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc004), it => it.Mc004.Contains(parm.Mc004));
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc005), it => it.Mc005 == parm.Mc005);
            //查询字段: <状态> 
            predicate = predicate.AndIF(parm.Mc012 != -1, it => it.Mc012 == parm.Mc012);
            return predicate;
        }
    }
}