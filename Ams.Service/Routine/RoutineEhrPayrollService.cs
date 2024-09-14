//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 薪资
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:02
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
                //.OrderBy("Mk003 asc")
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
        public RoutineEhrPayroll GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
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
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mk002.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.Mk005.IsEmpty(), "岗位不能为空")
                .SplitError(x => x.Item.Mk006.IsEmpty(), "等级不能为空")
                .SplitError(x => x.Item.Mk010.IsEmpty(), "税别不能为空")
                .SplitError(x => x.Item.Mk011.IsEmpty(), "基本工资不能为空")
                .SplitError(x => x.Item.Mk019.IsEmpty(), "工龄不能为空")
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
                    //查询字典: <部门> 
                    Mk002Label = it.Mk002.GetConfigValue<SysDictData>("sql_dept_list"),
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

            //查询字段: <部门> 
            predicate = predicate.AndIF(parm.Mk002 != -1, it => it.Mk002 == parm.Mk002);
            //查询字段: <工号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mk003), it => it.Mk003.Contains(parm.Mk003));
            //查询字段: <姓名> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mk004), it => it.Mk004.Contains(parm.Mk004));
            return predicate;
        }
    }
}