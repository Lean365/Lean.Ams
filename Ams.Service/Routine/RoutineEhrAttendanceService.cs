//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 考勤
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:26:15
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrAttendanceService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrAttendanceService : BaseService<RoutineEhrAttendance>, IRoutineEhrAttendanceService
    {
        /// <summary>
        /// 查询考勤列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrAttendanceDto> GetList(RoutineEhrAttendanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrAttendance, RoutineEhrAttendanceDto>(parm);

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
        public RoutineEhrAttendance GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加考勤
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrAttendance AddRoutineEhrAttendance(RoutineEhrAttendance model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改考勤
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrAttendance(RoutineEhrAttendance model)
        {
            return Update(model, true, "修改考勤");
        }

        /// <summary>
        /// 导入考勤
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrAttendance(List<RoutineEhrAttendance> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.ParentId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.Mg003.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.Mg004.IsEmpty(), "班别不能为空")
                .SplitError(x => x.Item.Mg005.IsEmpty(), "假日别不能为空")
                .SplitError(x => x.Item.Mg011.IsEmpty(), "迟到分钟不能为空")
                .SplitError(x => x.Item.Mg012.IsEmpty(), "迟到否不能为空")
                .SplitError(x => x.Item.Mg013.IsEmpty(), "早退分钟不能为空")
                .SplitError(x => x.Item.Mg014.IsEmpty(), "早退否不能为空")
                .SplitError(x => x.Item.Mg015.IsEmpty(), "假日加班时数不能为空")
                .SplitError(x => x.Item.Mg016.IsEmpty(), "异常不能为空")
                .SplitError(x => x.Item.Mg018.IsEmpty(), "已有请假信息不能为空")
                .SplitError(x => x.Item.Mg019.IsEmpty(), "正常加班不能为空")
                .SplitError(x => x.Item.Mg020.IsEmpty(), "节日加班不能为空")
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
        /// 导出考勤
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrAttendanceDto> ExportList(RoutineEhrAttendanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrAttendanceDto()
                {
                    //查询字典: <班别> 
                    Mg004Label = it.Mg004.GetConfigValue<SysDictData>("sys_shifts_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrAttendance> QueryExp(RoutineEhrAttendanceQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrAttendance>();

            //查询字段: <工号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg003), it => it.Mg003.Contains(parm.Mg003));
            //查询字段: <班别> 
            predicate = predicate.AndIF(parm.Mg004 != -1, it => it.Mg004 == parm.Mg004);
            //查询字段: <日期> 
            //predicate = predicate.AndIF(parm.BeginMg006 == null, it => it.Mg006 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMg006 != null, it => it.Mg006 >= parm.BeginMg006);
            //predicate = predicate.AndIF(parm.EndMg006 != null, it => it.Mg006 <= parm.EndMg006);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMg006 == null, it => it.Mg006 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMg006 == null, it => it.Mg006 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMg006 != null, it => it.Mg006 >= parm.BeginMg006);
            predicate = predicate.AndIF(parm.EndMg006 != null, it => it.Mg006 <= parm.EndMg006);
            return predicate;
        }
    }
}