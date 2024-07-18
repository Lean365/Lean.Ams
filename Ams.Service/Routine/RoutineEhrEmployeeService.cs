using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 人事信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:48:53
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrEmployeeService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrEmployeeService : BaseService<RoutineEhrEmployee>, IRoutineEhrEmployeeService
    {
        /// <summary>
        /// 查询人事信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrEmployeeDto> GetList(RoutineEhrEmployeeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
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
            int count = Count(it => it. EeSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EeSFID"></param>
        /// <returns></returns>
        public RoutineEhrEmployee GetInfo(long EeSFID)
        {
            var response = Queryable()
                .Where(x => x.EeSFID == EeSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 添加人事信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrEmployee AddRoutineEhrEmployee(RoutineEhrEmployee model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改人事信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrEmployee(RoutineEhrEmployee model)
        {
            return Update(model, true, "修改人事信息");
        }

        /// <summary>
        /// 导入人事信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrEmployee(List<RoutineEhrEmployee> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EeSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.EeName.IsEmpty(), "姓名不能为空")
                .SplitError(x => x.Item.EeGender.IsEmpty(), "性别不能为空")
                .SplitError(x => x.Item.EeBirthday.IsEmpty(), "出生日期不能为空")
                .SplitError(x => x.Item.EeIdentityCard.IsEmpty(), "身份证号不能为空")
                .SplitError(x => x.Item.EeWedlock.IsEmpty(), "婚姻状态不能为空")
                .SplitError(x => x.Item.EeNationId.IsEmpty(), "民族不能为空")
                .SplitError(x => x.Item.EeNativePlace.IsEmpty(), "籍贯不能为空")
                .SplitError(x => x.Item.EePoliticId.IsEmpty(), "政治面貌不能为空")
                .SplitError(x => x.Item.EeCountry.IsEmpty(), "国家/地区不能为空")
                .SplitError(x => x.Item.EeProvince.IsEmpty(), "省区不能为空")
                .SplitError(x => x.Item.EeCity.IsEmpty(), "市区不能为空")
                .SplitError(x => x.Item.EeCounty.IsEmpty(), "县区不能为空")
                .SplitError(x => x.Item.EeHomeAddress.IsEmpty(), "家庭住址不能为空")
                .SplitError(x => x.Item.EeDepartmentId.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.EeTitlesId.IsEmpty(), "职称不能为空")
                .SplitError(x => x.Item.EePostId.IsEmpty(), "职位不能为空")
                .SplitError(x => x.Item.EePostLevel.IsEmpty(), "职级不能为空")
                .SplitError(x => x.Item.EeDutyName.IsEmpty(), "职务不能为空")
                .SplitError(x => x.Item.EeRecruited.IsEmpty(), "招聘来源不能为空")
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
        /// 导出人事信息
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
                    EeGenderLabel = it.EeGender.GetConfigValue<SysDictData>("sys_gender_type"),
                    EeWedlockLabel = it.EeWedlock.GetConfigValue<SysDictData>("sys_wedlock_state"),
                    EeNationIdLabel = it.EeNationId.GetConfigValue<SysDictData>("sys_nation_list"),
                    EePoliticIdLabel = it.EePoliticId.GetConfigValue<SysDictData>("sys_politic_list"),
                    EeCountryLabel = it.EeCountry.GetConfigValue<SysDictData>("sys_country_list"),
                    EeHouseholdTypeLabel = it.EeHouseholdType.GetConfigValue<SysDictData>("sys_household_type"),
                    EeTitlesIdLabel = it.EeTitlesId.GetConfigValue<SysDictData>("sys_titles_list"),
                    EePostIdLabel = it.EePostId.GetConfigValue<SysDictData>("sql_posts_list"),
                    EePostLevelLabel = it.EePostLevel.GetConfigValue<SysDictData>("sys_post_level"),
                    EeRecruitedLabel = it.EeRecruited.GetConfigValue<SysDictData>("sys_recruited_list"),
                    EeEngageFormLabel = it.EeEngageForm.GetConfigValue<SysDictData>("sys_employ_term"),
                    EeTiptopDegrEeLabel = it.EeTiptopDegrEe.GetConfigValue<SysDictData>("sys_level_education"),
                    EeSpecialtyLabel = it.EeSpecialty.GetConfigValue<SysDictData>("sys_specialty_list"),
                    EeWorkStateLabel = it.EeWorkState.GetConfigValue<SysDictData>("sys_serve_state"),
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

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeName), it => it.EeName.Contains(parm.EeName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeEnglishName), it => it.EeEnglishName.Contains(parm.EeEnglishName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeGender), it => it.EeGender == parm.EeGender);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeBirthday != null, it => it.EeBirthday >= parm.BeginEeBirthday);
            predicate = predicate.AndIF(parm.EndEeBirthday != null, it => it.EeBirthday <= parm.EndEeBirthday);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeIdentityCard), it => it.EeIdentityCard == parm.EeIdentityCard);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWedlock), it => it.EeWedlock == parm.EeWedlock);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeNationId), it => it.EeNationId == parm.EeNationId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeNativePlace), it => it.EeNativePlace == parm.EeNativePlace);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EePoliticId), it => it.EePoliticId == parm.EePoliticId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeCountry), it => it.EeCountry == parm.EeCountry);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeHouseholdType), it => it.EeHouseholdType == parm.EeHouseholdType);
            predicate = predicate.AndIF(parm.EeDepartmentId != null, it => it.EeDepartmentId == parm.EeDepartmentId);
            predicate = predicate.AndIF(parm.EeTitlesId != null, it => it.EeTitlesId == parm.EeTitlesId);
            predicate = predicate.AndIF(parm.EePostId != null, it => it.EePostId == parm.EePostId);
            predicate = predicate.AndIF(parm.EePostLevel != null, it => it.EePostLevel == parm.EePostLevel);
            predicate = predicate.AndIF(parm.EeDutyName != null, it => it.EeDutyName == parm.EeDutyName);
            predicate = predicate.AndIF(parm.EeRecruited != null, it => it.EeRecruited == parm.EeRecruited);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeEngageForm), it => it.EeEngageForm == parm.EeEngageForm);
            predicate = predicate.AndIF(parm.EeTiptopDegrEe != null, it => it.EeTiptopDegrEe == parm.EeTiptopDegrEe);
            predicate = predicate.AndIF(parm.EeSpecialty != null, it => it.EeSpecialty == parm.EeSpecialty);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWorkID), it => it.EeWorkID == parm.EeWorkID);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeBeginDate == null, it => it.EeBeginDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeBeginDate == null, it => it.EeBeginDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeBeginDate != null, it => it.EeBeginDate >= parm.BeginEeBeginDate);
            predicate = predicate.AndIF(parm.EndEeBeginDate != null, it => it.EeBeginDate <= parm.EndEeBeginDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWorkState), it => it.EeWorkState == parm.EeWorkState);
            return predicate;
        }
    }
}