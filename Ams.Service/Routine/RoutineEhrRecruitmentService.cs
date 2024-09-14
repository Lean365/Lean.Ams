//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 招聘
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:55
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrRecruitmentService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrRecruitmentService : BaseService<RoutineEhrRecruitment>, IRoutineEhrRecruitmentService
    {
        /// <summary>
        /// 查询招聘列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrRecruitmentDto> GetList(RoutineEhrRecruitmentQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mn002 desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrRecruitment, RoutineEhrRecruitmentDto>(parm);

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
        public RoutineEhrRecruitment GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加招聘
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrRecruitment AddRoutineEhrRecruitment(RoutineEhrRecruitment model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改招聘
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrRecruitment(RoutineEhrRecruitment model)
        {
            return Update(model, true, "修改招聘");
        }

        /// <summary>
        /// 导入招聘
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrRecruitment(List<RoutineEhrRecruitment> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mn002.IsEmpty(), "招聘日期不能为空")
                .SplitError(x => x.Item.Mn003.IsEmpty(), "姓名不能为空")
                .SplitError(x => x.Item.Mn004.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.Mn005.IsEmpty(), "职称不能为空")
                .SplitError(x => x.Item.Mn006.IsEmpty(), "岗位不能为空")
                .SplitError(x => x.Item.Mn007.IsEmpty(), "等级不能为空")
                .SplitError(x => x.Item.Mn008.IsEmpty(), "职务不能为空")
                .SplitError(x => x.Item.Mn013.IsEmpty(), "试用工资不能为空")
                .SplitError(x => x.Item.Mn015.IsEmpty(), "转正工资不能为空")
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
        /// 导出招聘
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrRecruitmentDto> ExportList(RoutineEhrRecruitmentQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrRecruitmentDto()
                {
                    //查询字典: <部门> 
                    Mn004Label = it.Mn004.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <聘用形式> 
                    Mn009Label = it.Mn009.GetConfigValue<SysDictData>("sys_employ_term"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrRecruitment> QueryExp(RoutineEhrRecruitmentQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrRecruitment>();

            //查询字段: <招聘日期> 
            //predicate = predicate.AndIF(parm.BeginMn002 == null, it => it.Mn002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMn002 != null, it => it.Mn002 >= parm.BeginMn002);
            //predicate = predicate.AndIF(parm.EndMn002 != null, it => it.Mn002 <= parm.EndMn002);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMn002 == null, it => it.Mn002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMn002 == null, it => it.Mn002 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMn002 != null, it => it.Mn002 >= parm.BeginMn002);
            predicate = predicate.AndIF(parm.EndMn002 != null, it => it.Mn002 <= parm.EndMn002);
            //查询字段: <姓名> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mn003), it => it.Mn003.Contains(parm.Mn003));
            //查询字段: <部门> 
            predicate = predicate.AndIF(parm.Mn004 != -1, it => it.Mn004 == parm.Mn004);
            //查询字段: <聘用形式> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mn009), it => it.Mn009 == parm.Mn009);
            return predicate;
        }
    }
}