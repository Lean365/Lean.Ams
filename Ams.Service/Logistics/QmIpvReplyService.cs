//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 分析对策
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:44:05
    /// </summary>
    [AppService(ServiceType = typeof(IQmIpvReplyService), ServiceLifetime = LifeTime.Transient)]
    public class QmIpvReplyService : BaseService<QmIpvReply>, IQmIpvReplyService
    {
        /// <summary>
        /// 查询分析对策列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmIpvReplyDto> GetList(QmIpvReplyQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mi009 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmIpvReply, QmIpvReplyDto>(parm);

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
        public QmIpvReply GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加分析对策
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmIpvReply AddQmIpvReply(QmIpvReply model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改分析对策
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmIpvReply(QmIpvReply model)
        {
            return Update(model, true, "修改分析对策");
        }

        /// <summary>
        /// 导入分析对策
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmIpvReply(List<QmIpvReply> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mi002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mi005.IsEmpty(), "订单不能为空")
                .SplitError(x => x.Item.Mi007.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Mi012.IsEmpty(), "验退数不能为空")
                .SplitError(x => x.Item.Mi024.IsEmpty(), "实施查证不能为空")
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
        /// 导出分析对策
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmIpvReplyDto> ExportList(QmIpvReplyQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmIpvReplyDto()
                {
                    //查询字典: <工厂> 
                    Mi002Label = it.Mi002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <检查员> 
                    Mi003Label = it.Mi003.GetConfigValue<SysDictData>("sql_insp_list"),
                    //查询字典: <班组> 
                    Mi004Label = it.Mi004.GetConfigValue<SysDictData>("sql_line_list"),
                    //查询字典: <不良级别> 
                    Mi013Label = it.Mi013.GetConfigValue<SysDictData>("sys_insp_bad"),
                    //查询字典: <实施查证> 
                    Mi024Label = it.Mi024.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmIpvReply> QueryExp(QmIpvReplyQueryDto parm)
        {
            var predicate = Expressionable.Create<QmIpvReply>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi002), it => it.Mi002 == parm.Mi002);
            //查询字段: <检查员> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi003), it => it.Mi003 == parm.Mi003);
            //查询字段: <班组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi004), it => it.Mi004 == parm.Mi004);
            //查询字段: <订单> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi005), it => it.Mi005.Contains(parm.Mi005));
            //查询字段: <机种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi006), it => it.Mi006.Contains(parm.Mi006));
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi007), it => it.Mi007.Contains(parm.Mi007));
            //查询字段: <检验日期> 
            //predicate = predicate.AndIF(parm.BeginMi009 == null, it => it.Mi009 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMi009 != null, it => it.Mi009 >= parm.BeginMi009);
            //predicate = predicate.AndIF(parm.EndMi009 != null, it => it.Mi009 <= parm.EndMi009);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMi009 == null, it => it.Mi009 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMi009 == null, it => it.Mi009 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMi009 != null, it => it.Mi009 >= parm.BeginMi009);
            predicate = predicate.AndIF(parm.EndMi009 != null, it => it.Mi009 <= parm.EndMi009);
            //查询字段: <实施日期> 
            //predicate = predicate.AndIF(parm.BeginMi023 == null, it => it.Mi023 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMi023 != null, it => it.Mi023 >= parm.BeginMi023);
            //predicate = predicate.AndIF(parm.EndMi023 != null, it => it.Mi023 <= parm.EndMi023);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMi023 == null, it => it.Mi023 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMi023 == null, it => it.Mi023 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMi023 != null, it => it.Mi023 >= parm.BeginMi023);
            predicate = predicate.AndIF(parm.EndMi023 != null, it => it.Mi023 <= parm.EndMi023);
            //查询字段: <发行号码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi027), it => it.Mi027.Contains(parm.Mi027));
            return predicate;
        }
    }
}