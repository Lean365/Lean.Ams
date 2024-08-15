using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 薪资
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:32:33
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrPayrollService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrPayrollService : BaseService<RoutineEhrPayroll>, IRoutineEhrPayrollService
    {
        /// <summary>
        /// 查询薪资列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPayrollDto> GetList(RoutineEhrPayrollQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrPayroll, RoutineEhrPayrollDto>(parm);

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
            int count = Count(it => it. EeSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        public RoutineEhrPayroll GetInfo(long EeSfId)
        {
            var response = Queryable()
                .Where(x => x.EeSfId == EeSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加薪资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrPayroll AddRoutineEhrPayroll(RoutineEhrPayroll model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改薪资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrPayroll(RoutineEhrPayroll model)
        {
            return Update(model, true, "修改薪资");
        }

        /// <summary>
        /// 导入薪资
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrPayroll(List<RoutineEhrPayroll> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EeSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.EeName.IsEmpty(), "姓名不能为空")
                .SplitError(x => x.Item.EeBirthday.IsEmpty(), "工资日期不能为空")
                .SplitError(x => x.Item.EeDepartmentId.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.EeTitlesId.IsEmpty(), "职称不能为空")
                .SplitError(x => x.Item.EePostId.IsEmpty(), "岗位不能为空")
                .SplitError(x => x.Item.EePostLevel.IsEmpty(), "等级不能为空")
                .SplitError(x => x.Item.EeDutyName.IsEmpty(), "职务不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
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
        /// 导出薪资
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPayrollDto> ExportList(RoutineEhrPayrollQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrPayrollDto()
                {
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrPayroll> QueryExp(RoutineEhrPayrollQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrPayroll>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeName), it => it.EeName.Contains(parm.EeName));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeBirthday != null, it => it.EeBirthday >= parm.BeginEeBirthday);
            predicate = predicate.AndIF(parm.EndEeBirthday != null, it => it.EeBirthday <= parm.EndEeBirthday);
            return predicate;
        }
    }
}