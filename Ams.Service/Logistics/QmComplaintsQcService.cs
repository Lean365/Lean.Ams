//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// QC客诉
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:13:49
    /// </summary>
    [AppService(ServiceType = typeof(IQmComplaintsQcService), ServiceLifetime = LifeTime.Transient)]
    public class QmComplaintsQcService : BaseService<QmComplaintsQc>, IQmComplaintsQcService
    {
        /// <summary>
        /// 查询QC客诉列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsQcDto> GetList(QmComplaintsQcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mb010 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmComplaintsQc, QmComplaintsQcDto>(parm);

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
        public QmComplaintsQc GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加QC客诉
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmComplaintsQc AddQmComplaintsQc(QmComplaintsQc model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改QC客诉
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmComplaintsQc(QmComplaintsQc model)
        {
            return Update(model, true, "修改QC客诉");
        }

        /// <summary>
        /// 导入QC客诉
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmComplaintsQc(List<QmComplaintsQc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mb002.IsEmpty(), "工厂代码不能为空")
                .SplitError(x => x.Item.Mb003.IsEmpty(), "客诉No.不能为空")
                .SplitError(x => x.Item.Mb004.IsEmpty(), "外部客诉No.不能为空")
                .SplitError(x => x.Item.Mb005.IsEmpty(), "客户不能为空")
                .SplitError(x => x.Item.Mb011.IsEmpty(), "数量不能为空")
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
        /// 导出QC客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsQcDto> ExportList(QmComplaintsQcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmComplaintsQcDto()
                {
                    //查询字典: <工厂代码> 
                    Mb002Label = it.Mb002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <客户> 
                    Mb005Label = it.Mb005.GetConfigValue<SysDictData>("sql_cus_list"),
                    //查询字典: <机种> 
                    Mb006Label = it.Mb006.GetConfigValue<SysDictData>("sql_sap_model"),
                    //查询字典: <物料> 
                    Mb007Label = it.Mb007.GetConfigValue<SysDictData>("sql_mats_list"),
                    //查询字典: <承认部门> 
                    Mb017Label = it.Mb017.GetConfigValue<SysDictData>("sql_dept_name"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmComplaintsQc> QueryExp(QmComplaintsQcQueryDto parm)
        {
            var predicate = Expressionable.Create<QmComplaintsQc>();

            //查询字段: <工厂代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb002), it => it.Mb002 == parm.Mb002);
            //查询字段: <客诉No.> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb003), it => it.Mb003.Contains(parm.Mb003));
            //查询字段: <外部客诉No.> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb004), it => it.Mb004.Contains(parm.Mb004));
            //查询字段: <客户> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb005), it => it.Mb005 == parm.Mb005);
            //查询字段: <机种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb006), it => it.Mb006 == parm.Mb006);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb007), it => it.Mb007 == parm.Mb007);
            //查询字段: <接收日期> 
            //predicate = predicate.AndIF(parm.BeginMb010 == null, it => it.Mb010 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMb010 != null, it => it.Mb010 >= parm.BeginMb010);
            //predicate = predicate.AndIF(parm.EndMb010 != null, it => it.Mb010 <= parm.EndMb010);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMb010 == null, it => it.Mb010 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMb010 == null, it => it.Mb010 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMb010 != null, it => it.Mb010 >= parm.BeginMb010);
            predicate = predicate.AndIF(parm.EndMb010 != null, it => it.Mb010 <= parm.EndMb010);
            return predicate;
        }
    }
}