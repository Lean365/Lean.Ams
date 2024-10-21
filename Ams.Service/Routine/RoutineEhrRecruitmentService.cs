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
    /// @Date: 2024/10/18 15:46:34
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
                //.OrderBy("Mn003 desc")
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
                .SplitError(x => x.Item.Mn002.IsEmpty(), "招聘起始日不能为空")
                .SplitError(x => x.Item.Mn003.IsEmpty(), "招聘截止日不能为空")
                .SplitError(x => x.Item.Mn004.IsEmpty(), "招聘部门不能为空")
                .SplitError(x => x.Item.Mn006.IsEmpty(), "薪资范围不能为空")
                .SplitError(x => x.Item.Mn007.IsEmpty(), "紧急程度不能为空")
                .SplitError(x => x.Item.Mn008.IsEmpty(), "工作城市不能为空")
                .SplitError(x => x.Item.Mn009.IsEmpty(), "工作经验不能为空")
                .SplitError(x => x.Item.Mn010.IsEmpty(), "学历要求不能为空")
                .SplitError(x => x.Item.Mn011.IsEmpty(), "聘用形式不能为空")
                .SplitError(x => x.Item.Mn012.IsEmpty(), "到岗日期不能为空")
                .SplitError(x => x.Item.Mn013.IsEmpty(), "年龄要求不能为空")
                .SplitError(x => x.Item.Mn014.IsEmpty(), "面试否不能为空")
                .SplitError(x => x.Item.Mn015.IsEmpty(), "招聘人数不能为空")
                .SplitError(x => x.Item.Mn016.IsEmpty(), "招聘原因不能为空")
                .SplitError(x => x.Item.Mn017.IsEmpty(), "试用期限不能为空")
                .SplitError(x => x.Item.Mn018.IsEmpty(), "招聘状态不能为空")
                .SplitError(x => x.Item.Mn019.IsEmpty(), "相关资格证书不能为空")
                .SplitError(x => x.Item.Mn020.IsEmpty(), "岗位描述不能为空")
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
                    //查询字典: <招聘部门> 
                    Mn004Label = it.Mn004.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <招聘职位> 
                    Mn005Label = it.Mn005.GetConfigValue<SysDictData>("sql_posts_list"),
                    //查询字典: <薪资范围> 
                    Mn006Label = it.Mn006.GetConfigValue<SysDictData>("sys_salary_range"),
                    //查询字典: <紧急程度> 
                    Mn007Label = it.Mn007.GetConfigValue<SysDictData>("sys_urgently_state"),
                    //查询字典: <工作城市> 
                    Mn008Label = it.Mn008.GetConfigValue<SysDictData>("sql_global_city"),
                    //查询字典: <工作经验> 
                    Mn009Label = it.Mn009.GetConfigValue<SysDictData>("sys_work_expe"),
                    //查询字典: <学历要求> 
                    Mn010Label = it.Mn010.GetConfigValue<SysDictData>("sys_recru_qual"),
                    //查询字典: <聘用形式> 
                    Mn011Label = it.Mn011.GetConfigValue<SysDictData>("sys_employ_term"),
                    //查询字典: <年龄要求> 
                    Mn013Label = it.Mn013.GetConfigValue<SysDictData>("sys_recru_age"),
                    //查询字典: <面试否> 
                    Mn014Label = it.Mn014.GetConfigValue<SysDictData>("sys_is_status"),
                    //查询字典: <招聘原因> 
                    Mn016Label = it.Mn016.GetConfigValue<SysDictData>("sys_recru_reason"),
                    //查询字典: <招聘状态> 
                    Mn018Label = it.Mn018.GetConfigValue<SysDictData>("sys_recru_state"),
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

            //查询字段: <招聘部门> 
            predicate = predicate.AndIF(parm.Mn004 != -1, it => it.Mn004 == parm.Mn004);
            //查询字段: <招聘职位> 
            predicate = predicate.AndIF(parm.Mn005 != -1, it => it.Mn005 == parm.Mn005);
            //查询字段: <薪资范围> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mn006), it => it.Mn006 == parm.Mn006);
            //查询字段: <紧急程度> 
            predicate = predicate.AndIF(parm.Mn007 != -1, it => it.Mn007 == parm.Mn007);
            //查询字段: <工作城市> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mn008), it => it.Mn008 == parm.Mn008);
            return predicate;
        }
    }
}