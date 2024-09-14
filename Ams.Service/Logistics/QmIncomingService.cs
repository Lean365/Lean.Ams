//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 进料检验
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:45:51
    /// </summary>
    [AppService(ServiceType = typeof(IQmIncomingService), ServiceLifetime = LifeTime.Transient)]
    public class QmIncomingService : BaseService<QmIncoming>, IQmIncomingService
    {
        /// <summary>
        /// 查询进料检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmIncomingDto> GetList(QmIncomingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mf006 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmIncoming, QmIncomingDto>(parm);

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
        public QmIncoming GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加进料检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmIncoming AddQmIncoming(QmIncoming model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改进料检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmIncoming(QmIncoming model)
        {
            return Update(model, true, "修改进料检验");
        }

        /// <summary>
        /// 导入进料检验
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmIncoming(List<QmIncoming> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mf002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mf003.IsEmpty(), "采购订单不能为空")
                .SplitError(x => x.Item.Mf005.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Mf012.IsEmpty(), "抽样数不能为空")
                .SplitError(x => x.Item.Mf015.IsEmpty(), "验退数不能为空")
                .SplitError(x => x.Item.Mf017.IsEmpty(), "验收数量不能为空")
                .SplitError(x => x.Item.Mf018.IsEmpty(), "检验次数不能为空")
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
        /// 导出进料检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmIncomingDto> ExportList(QmIncomingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmIncomingDto()
                {
                    //查询字典: <工厂> 
                    Mf002Label = it.Mf002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <采购订单> 
                    Mf003Label = it.Mf003.GetConfigValue<SysDictData>("sql_marb_pur"),
                    //查询字典: <检验员> 
                    Mf007Label = it.Mf007.GetConfigValue<SysDictData>("sql_insp_list"),
                    //查询字典: <检验项目> 
                    Mf009Label = it.Mf009.GetConfigValue<SysDictData>("sql_insp_item"),
                    //查询字典: <检验水准> 
                    Mf010Label = it.Mf010.GetConfigValue<SysDictData>("sys_insp_level"),
                    //查询字典: <检验方式> 
                    Mf011Label = it.Mf011.GetConfigValue<SysDictData>("sys_insp_method"),
                    //查询字典: <判定> 
                    Mf013Label = it.Mf013.GetConfigValue<SysDictData>("sys_insp_judge"),
                    //查询字典: <不良级别> 
                    Mf014Label = it.Mf014.GetConfigValue<SysDictData>("sys_insp_bad"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmIncoming> QueryExp(QmIncomingQueryDto parm)
        {
            var predicate = Expressionable.Create<QmIncoming>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf002), it => it.Mf002 == parm.Mf002);
            //查询字段: <采购订单> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf003), it => it.Mf003 == parm.Mf003);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf004), it => it.Mf004.Contains(parm.Mf004));
            //查询字段: <检验日期> 
            //predicate = predicate.AndIF(parm.BeginMf008 == null, it => it.Mf008 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMf008 != null, it => it.Mf008 >= parm.BeginMf008);
            //predicate = predicate.AndIF(parm.EndMf008 != null, it => it.Mf008 <= parm.EndMf008);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMf008 == null, it => it.Mf008 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMf008 == null, it => it.Mf008 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMf008 != null, it => it.Mf008 >= parm.BeginMf008);
            predicate = predicate.AndIF(parm.EndMf008 != null, it => it.Mf008 <= parm.EndMf008);
            return predicate;
        }
    }
}