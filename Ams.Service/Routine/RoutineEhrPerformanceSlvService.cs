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
    /// @Date: 2024/9/12 16:38:43
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrPerformanceSlvService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrPerformanceSlvService : BaseService<RoutineEhrPerformanceSlv>, IRoutineEhrPerformanceSlvService
    {
        /// <summary>
        /// 查询绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPerformanceSlvDto> GetList(RoutineEhrPerformanceSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mm003 asc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrPerformanceSlv, RoutineEhrPerformanceSlvDto>(parm);

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
        public RoutineEhrPerformanceSlv GetInfo(long Id)
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
        public RoutineEhrPerformanceSlv AddRoutineEhrPerformanceSlv(RoutineEhrPerformanceSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改绩效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrPerformanceSlv(RoutineEhrPerformanceSlv model)
        {
            return Update(model, true, "修改绩效");
        }

        /// <summary>
        /// 导入绩效
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrPerformanceSlv(List<RoutineEhrPerformanceSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mm003.IsEmpty(), "考核项目不能为空")
                .SplitError(x => x.Item.Is_deleted.IsEmpty(), "软删除不能为空")
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
        public PagedInfo<RoutineEhrPerformanceSlvDto> ExportList(RoutineEhrPerformanceSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrPerformanceSlvDto()
                {
                    //查询字典: <考核项目> 
                    Mm003Label = it.Mm003.GetConfigValue<SysDictData>("sys_eval_items"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrPerformanceSlv> QueryExp(RoutineEhrPerformanceSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrPerformanceSlv>();

            //查询字段: <考核项目> 
            predicate = predicate.AndIF(parm.Mm003 != -1, it => it.Mm003 == parm.Mm003);
            return predicate;
        }
    }
}