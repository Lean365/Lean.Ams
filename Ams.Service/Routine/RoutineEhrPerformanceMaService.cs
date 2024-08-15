using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 绩效
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:08
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrPerformanceMaService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrPerformanceMaService : BaseService<RoutineEhrPerformanceMa>, IRoutineEhrPerformanceMaService
    {
        /// <summary>
        /// 查询绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPerformanceMaDto> GetList(RoutineEhrPerformanceMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.RoutineEhrPerformanceSlvNav) //填充子对象
                //.OrderBy("EpEvalYear desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrPerformanceMa, RoutineEhrPerformanceMaDto>(parm);

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
            int count = Count(it => it.EpSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EpSfId"></param>
        /// <returns></returns>
        public RoutineEhrPerformanceMa GetInfo(long EpSfId)
        {
            var response = Queryable()
                .Includes(x => x.RoutineEhrPerformanceSlvNav) //填充子对象
                .Where(x => x.EpSfId == EpSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加绩效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrPerformanceMa AddRoutineEhrPerformanceMa(RoutineEhrPerformanceMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.RoutineEhrPerformanceSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改绩效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrPerformanceMa(RoutineEhrPerformanceMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.RoutineEhrPerformanceSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入绩效
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrPerformanceMa(List<RoutineEhrPerformanceMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EpSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.EpName.IsEmpty(), "姓名不能为空")
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
        public PagedInfo<RoutineEhrPerformanceMaDto> ExportList(RoutineEhrPerformanceMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrPerformanceMaDto()
                {
                    EpNameLabel = it.EpName.GetConfigValue<SysDictData>("sql_inspector_list"),
                    EpEvalYearLabel = it.EpEvalYear.GetConfigValue<SysDictData>("sql_ym_list"),
                    EpEvalGradeLabel = it.EpEvalGrade.GetConfigValue<SysDictData>("sys_eval_grade"),
                    //EpEvalItemsLabel = it.EpEvalItems.GetConfigValue<SysDictData>("sys_eval_items"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrPerformanceMa> QueryExp(RoutineEhrPerformanceMaQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrPerformanceMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpEmployeeId), it => it.EpEmployeeId.Contains(parm.EpEmployeeId));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpName), it => it.EpName == parm.EpName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpEvalYear), it => it.EpEvalYear == parm.EpEvalYear);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpEvalGrade), it => it.EpEvalGrade == parm.EpEvalGrade);
            return predicate;
        }
    }
}