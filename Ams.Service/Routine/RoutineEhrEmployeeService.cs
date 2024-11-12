//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Repository;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 人事
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 17:15:08
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrEmployeeService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrEmployeeService : BaseService<RoutineEhrEmployee>, IRoutineEhrEmployeeService
    {
        /// <summary>
        /// 查询人事列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrEmployeeDto> GetList(RoutineEhrEmployeeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mh034 desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrEmployee, RoutineEhrEmployeeDto>(parm);

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
            int count = Count(it => it.Id.ToString() == enterString);
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
        public RoutineEhrEmployee GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加人事
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrEmployee AddRoutineEhrEmployee(RoutineEhrEmployee model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改人事
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrEmployee(RoutineEhrEmployee model)
        {
            return Update(model, true, "修改人事");
        }

        /// <summary>
        /// 导入人事
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrEmployee(List<RoutineEhrEmployee> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mh002.IsEmpty(), "姓名不能为空")
                .SplitError(x => x.Item.Mh006.IsEmpty(), "性别不能为空")
                .SplitError(x => x.Item.Mh009.IsEmpty(), "婚姻状态不能为空")
                .SplitError(x => x.Item.Mh010.IsEmpty(), "民族不能为空")
                .SplitError(x => x.Item.Mh012.IsEmpty(), "政治面貌不能为空")
                .SplitError(x => x.Item.Mh021.IsEmpty(), "户口性质不能为空")
                .SplitError(x => x.Item.Mh023.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.Mh024.IsEmpty(), "职称不能为空")
                .SplitError(x => x.Item.Mh025.IsEmpty(), "职位不能为空")
                .SplitError(x => x.Item.Mh026.IsEmpty(), "职级不能为空")
                .SplitError(x => x.Item.Mh027.IsEmpty(), "职务不能为空")
                .SplitError(x => x.Item.Mh028.IsEmpty(), "招聘来源不能为空")
                .SplitError(x => x.Item.Mh029.IsEmpty(), "聘用形式不能为空")
                .SplitError(x => x.Item.Mh030.IsEmpty(), "学历不能为空")
                .SplitError(x => x.Item.Mh031.IsEmpty(), "专业不能为空")
                .SplitError(x => x.Item.Mh033.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.Mh035.IsEmpty(), "在职状态不能为空")
                .SplitError(x => x.Item.Mh036.IsEmpty(), "试用期不能为空")
                .SplitError(x => x.Item.Mh037.IsEmpty(), "合同期限不能为空")
                .SplitError(x => x.Item.Mh042.IsEmpty(), "工龄不能为空")
                .SplitError(x => x.Item.Mh044.IsEmpty(), "打卡否不能为空")
                .SplitError(x => x.Item.Mh045.IsEmpty(), "班别不能为空")
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
        /// 导出人事
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrEmployeeDto> ExportList(RoutineEhrEmployeeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrEmployeeDto()
                {
                    //查询字典: <性别>
                    Mh006Label = it.Mh006.GetConfigValue<SysDictData>("sys_gender_type"),
                    //查询字典: <婚姻状态>
                    Mh009Label = it.Mh009.GetConfigValue<SysDictData>("sys_wedlock_state"),
                    //查询字典: <民族>
                    Mh010Label = it.Mh010.GetConfigValue<SysDictData>("sys_nation_list"),
                    //查询字典: <政治面貌>
                    Mh012Label = it.Mh012.GetConfigValue<SysDictData>("sys_politic_list"),
                    //查询字典: <国家/地区>
                    Mh015Label = it.Mh015.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <省区>
                    Mh016Label = it.Mh016.GetConfigValue<SysDictData>("sql_global_state"),
                    //查询字典: <户口性质>
                    Mh021Label = it.Mh021.GetConfigValue<SysDictData>("sys_household_type"),
                    //查询字典: <部门>
                    Mh023Label = it.Mh023.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <职称>
                    Mh024Label = it.Mh024.GetConfigValue<SysDictData>("sys_titles_list"),
                    //查询字典: <职位>
                    Mh025Label = it.Mh025.GetConfigValue<SysDictData>("sql_posts_list"),
                    //查询字典: <职级>
                    Mh026Label = it.Mh026.GetConfigValue<SysDictData>("sys_post_level"),
                    //查询字典: <招聘来源>
                    Mh028Label = it.Mh028.GetConfigValue<SysDictData>("sys_recruited_list"),
                    //查询字典: <聘用形式>
                    Mh029Label = it.Mh029.GetConfigValue<SysDictData>("sys_employ_term"),
                    //查询字典: <学历>
                    Mh030Label = it.Mh030.GetConfigValue<SysDictData>("sys_level_education"),
                    //查询字典: <专业>
                    Mh031Label = it.Mh031.GetConfigValue<SysDictData>("sys_specialty_list"),
                    //查询字典: <在职状态>
                    Mh035Label = it.Mh035.GetConfigValue<SysDictData>("sys_serve_state"),
                    //查询字典: <试用期>
                    Mh036Label = it.Mh036.GetConfigValue<SysDictData>("sys_trialterm_list"),
                    //查询字典: <合同期限>
                    Mh037Label = it.Mh037.GetConfigValue<SysDictData>("sys_contractterm_list"),
                    //查询字典: <打卡否>
                    Mh044Label = it.Mh044.GetConfigValue<SysDictData>("sys_is_status"),
                    //查询字典: <班别>
                    Mh045Label = it.Mh045.GetConfigValue<SysDictData>("sys_shifts_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrEmployee> QueryExp(RoutineEhrEmployeeQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrEmployee>();

            //查询字段: <姓名>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh002), it => it.Mh002.Contains(parm.Mh002));
            //查询字段: <英文名>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh005), it => it.Mh005 == parm.Mh005);
            //查询字段: <性别>
            predicate = predicate.AndIF(parm.Mh006 != null, it => it.Mh006 == parm.Mh006);
            //查询字段: <出生日期>
            //predicate = predicate.AndIF(parm.BeginMh007 == null, it => it.Mh007 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMh007 != null, it => it.Mh007 >= parm.BeginMh007);
            //predicate = predicate.AndIF(parm.EndMh007 != null, it => it.Mh007 <= parm.EndMh007);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMh007 == null, it => it.Mh007 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            //predicate = predicate.AndIF(parm.BeginMh007 == null, it => it.Mh007 >= new DateTime(DateTime.Now.Year, 1, 1));
            //predicate = predicate.AndIF(parm.BeginMh007 != null, it => it.Mh007 >= parm.BeginMh007);
            //predicate = predicate.AndIF(parm.EndMh007 != null, it => it.Mh007 <= parm.EndMh007);
            //查询字段: <婚姻状态>
            predicate = predicate.AndIF(parm.Mh009 != null, it => it.Mh009 == parm.Mh009);
            //查询字段: <民族>
            predicate = predicate.AndIF(parm.Mh010 != null, it => it.Mh010 == parm.Mh010);
            //查询字段: <国家/地区>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh015), it => it.Mh015 == parm.Mh015);
            //查询字段: <省区>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh016), it => it.Mh016 == parm.Mh016);
            //查询字段: <部门>
            predicate = predicate.AndIF(parm.Mh023 != null, it => it.Mh023 == parm.Mh023);
            //查询字段: <职位>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh025), it => it.Mh025 == parm.Mh025);
            //查询字段: <招聘来源>
            predicate = predicate.AndIF(parm.Mh028 != null, it => it.Mh028 == parm.Mh028);
            //查询字段: <聘用形式>
            predicate = predicate.AndIF(parm.Mh029 != null, it => it.Mh029 == parm.Mh029);
            //查询字段: <学历>
            predicate = predicate.AndIF(parm.Mh030 != null, it => it.Mh030 == parm.Mh030);
            //查询字段: <工号>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh033), it => it.Mh033.Contains(parm.Mh033));
            //查询字段: <入职日期>
            //predicate = predicate.AndIF(parm.BeginMh034 == null, it => it.Mh034 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMh034 != null, it => it.Mh034 >= parm.BeginMh034);
            //predicate = predicate.AndIF(parm.EndMh034 != null, it => it.Mh034 <= parm.EndMh034);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMh034 == null, it => it.Mh034 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            //predicate = predicate.AndIF(parm.BeginMh034 == null, it => it.Mh034 >= new DateTime(DateTime.Now.Year, 1, 1));
            //predicate = predicate.AndIF(parm.BeginMh034 != null, it => it.Mh034 >= parm.BeginMh034);
            //predicate = predicate.AndIF(parm.EndMh034 != null, it => it.Mh034 <= parm.EndMh034);
            //查询字段: <在职状态>
            predicate = predicate.AndIF(parm.Mh035 != null, it => it.Mh035 == parm.Mh035);
            //查询字段: <打卡否>
            predicate = predicate.AndIF(parm.Mh044 != -1, it => it.Mh044 == parm.Mh044);
            return predicate;
        }
    }
}