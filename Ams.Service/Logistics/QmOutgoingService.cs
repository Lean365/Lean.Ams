//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 出货检验
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:38:43
    /// </summary>
    [AppService(ServiceType = typeof(IQmOutgoingService), ServiceLifetime = LifeTime.Transient)]
    public class QmOutgoingService : BaseService<QmOutgoing>, IQmOutgoingService
    {
        /// <summary>
        /// 查询出货检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmOutgoingDto> GetList(QmOutgoingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mj012 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmOutgoing, QmOutgoingDto>(parm);

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
        public QmOutgoing GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加出货检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmOutgoing AddQmOutgoing(QmOutgoing model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改出货检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmOutgoing(QmOutgoing model)
        {
            return Update(model, true, "修改出货检验");
        }

        /// <summary>
        /// 导入出货检验
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmOutgoing(List<QmOutgoing> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mj002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mj003.IsEmpty(), "生产工单不能为空")
                .SplitError(x => x.Item.Mj006.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Mj009.IsEmpty(), "送检数量不能为空")
                .SplitError(x => x.Item.Mj016.IsEmpty(), "抽样数不能为空")
                .SplitError(x => x.Item.Mj019.IsEmpty(), "验退数不能为空")
                .SplitError(x => x.Item.Mj022.IsEmpty(), "验收数量不能为空")
                .SplitError(x => x.Item.Mj023.IsEmpty(), "订单数量不能为空")
                .SplitError(x => x.Item.Mj024.IsEmpty(), "检验次数不能为空")
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
        /// 导出出货检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmOutgoingDto> ExportList(QmOutgoingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmOutgoingDto()
                {
                    //查询字典: <工厂> 
                    Mj002Label = it.Mj002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <生产工单> 
                    Mj003Label = it.Mj003.GetConfigValue<SysDictData>("sql_moc_oph"),
                    //查询字典: <检查员> 
                    Mj011Label = it.Mj011.GetConfigValue<SysDictData>("sql_insp_list"),
                    //查询字典: <检验水准> 
                    Mj014Label = it.Mj014.GetConfigValue<SysDictData>("sys_insp_level"),
                    //查询字典: <检验方式> 
                    Mj015Label = it.Mj015.GetConfigValue<SysDictData>("sys_insp_method"),
                    //查询字典: <判定> 
                    Mj017Label = it.Mj017.GetConfigValue<SysDictData>("sys_insp_judge"),
                    //查询字典: <不良级别> 
                    Mj018Label = it.Mj018.GetConfigValue<SysDictData>("sys_insp_bad"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmOutgoing> QueryExp(QmOutgoingQueryDto parm)
        {
            var predicate = Expressionable.Create<QmOutgoing>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj002), it => it.Mj002 == parm.Mj002);
            //查询字段: <生产工单> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj003), it => it.Mj003 == parm.Mj003);
            //查询字段: <班组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj004), it => it.Mj004.Contains(parm.Mj004));
            //查询字段: <机种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj005), it => it.Mj005.Contains(parm.Mj005));
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj006), it => it.Mj006.Contains(parm.Mj006));
            //查询字段: <批次> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj007), it => it.Mj007.Contains(parm.Mj007));
            //查询字段: <查验日期> 
            //predicate = predicate.AndIF(parm.BeginMj012 == null, it => it.Mj012 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMj012 != null, it => it.Mj012 >= parm.BeginMj012);
            //predicate = predicate.AndIF(parm.EndMj012 != null, it => it.Mj012 <= parm.EndMj012);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMj012 == null, it => it.Mj012 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMj012 == null, it => it.Mj012 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMj012 != null, it => it.Mj012 >= parm.BeginMj012);
            predicate = predicate.AndIF(parm.EndMj012 != null, it => it.Mj012 <= parm.EndMj012);
            return predicate;
        }
    }
}