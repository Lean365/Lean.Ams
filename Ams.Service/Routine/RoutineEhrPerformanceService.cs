//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 绩效
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 9:40:38
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrPerformanceService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrPerformanceService : BaseService<RoutineEhrPerformance>, IRoutineEhrPerformanceService
    {
        /// <summary>
        /// 查询绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPerformanceDto> GetList(RoutineEhrPerformanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ml004 desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrPerformance, RoutineEhrPerformanceDto>(parm);

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
        public RoutineEhrPerformance GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加绩效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrPerformance AddRoutineEhrPerformance(RoutineEhrPerformance model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改绩效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrPerformance(RoutineEhrPerformance model)
        {
            return Update(model, true, "修改绩效");
        }

        /// <summary>
        /// 导入绩效
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrPerformance(List<RoutineEhrPerformance> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Ml002.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.Ml003.IsEmpty(), "姓名不能为空")
                .SplitError(x => x.Item.Ml005.IsEmpty(), "总分不能为空")
                .SplitError(x => x.Item.Ml007.IsEmpty(), "考核项目不能为空")
                .SplitError(x => x.Item.Ml008.IsEmpty(), "初次评分不能为空")
                .SplitError(x => x.Item.Ml011.IsEmpty(), "二次评分不能为空")
                .SplitError(x => x.Item.Ml014.IsEmpty(), "三次评分不能为空")
                .SplitError(x => x.Item.Ml017.IsEmpty(), "四次评分不能为空")
                .SplitError(x => x.Item.Ml020.IsEmpty(), "五次评分不能为空")
                .SplitError(x => x.Item.Ml023.IsEmpty(), "六次评分不能为空")
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
        /// 导出绩效
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPerformanceDto> ExportList(RoutineEhrPerformanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrPerformanceDto()
                {
                    //查询字典: <年度> 
                    Ml004Label = it.Ml004.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <等级> 
                    Ml006Label = it.Ml006.GetConfigValue<SysDictData>("sys_eval_grade"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrPerformance> QueryExp(RoutineEhrPerformanceQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrPerformance>();

            //查询字段: <工号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml002), it => it.Ml002.Contains(parm.Ml002));
            //查询字段: <姓名> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml003), it => it.Ml003.Contains(parm.Ml003));
            //查询字段: <年度> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml004), it => it.Ml004 == parm.Ml004);
            //查询字段: <等级> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml006), it => it.Ml006 == parm.Ml006);
            return predicate;
        }
    }
}