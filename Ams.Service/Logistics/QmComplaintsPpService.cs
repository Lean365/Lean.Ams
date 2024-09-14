//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// PP客诉
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:14:58
    /// </summary>
    [AppService(ServiceType = typeof(IQmComplaintsPpService), ServiceLifetime = LifeTime.Transient)]
    public class QmComplaintsPpService : BaseService<QmComplaintsPp>, IQmComplaintsPpService
    {
        /// <summary>
        /// 查询PP客诉列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsPpDto> GetList(QmComplaintsPpQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ma005 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmComplaintsPp, QmComplaintsPpDto>(parm);

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
        public QmComplaintsPp GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加PP客诉
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmComplaintsPp AddQmComplaintsPp(QmComplaintsPp model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改PP客诉
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmComplaintsPp(QmComplaintsPp model)
        {
            return Update(model, true, "修改PP客诉");
        }

        /// <summary>
        /// 导入PP客诉
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmComplaintsPp(List<QmComplaintsPp> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Ma002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Ma003.IsEmpty(), "外部客诉No.不能为空")
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
        /// 导出PP客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsPpDto> ExportList(QmComplaintsPpQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmComplaintsPpDto()
                {
                    //查询字典: <工厂> 
                    Ma002Label = it.Ma002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <班组> 
                    Ma004Label = it.Ma004.GetConfigValue<SysDictData>("sql_line_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmComplaintsPp> QueryExp(QmComplaintsPpQueryDto parm)
        {
            var predicate = Expressionable.Create<QmComplaintsPp>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma002), it => it.Ma002 == parm.Ma002);
            //查询字段: <外部客诉No.> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma003), it => it.Ma003.Contains(parm.Ma003));
            //查询字段: <处理日期> 
            //predicate = predicate.AndIF(parm.BeginMa005 == null, it => it.Ma005 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMa005 != null, it => it.Ma005 >= parm.BeginMa005);
            //predicate = predicate.AndIF(parm.EndMa005 != null, it => it.Ma005 <= parm.EndMa005);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMa005 == null, it => it.Ma005 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMa005 == null, it => it.Ma005 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMa005 != null, it => it.Ma005 >= parm.BeginMa005);
            predicate = predicate.AndIF(parm.EndMa005 != null, it => it.Ma005 <= parm.EndMa005);
            return predicate;
        }
    }
}