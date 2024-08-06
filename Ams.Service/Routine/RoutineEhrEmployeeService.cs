using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 人事
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 8:07:34
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
                //.OrderBy("EeBeginDate desc")
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
        public RoutineEhrEmployee GetInfo(long EeSfId)
        {
            var response = Queryable()
                .Where(x => x.EeSfId == EeSfId)
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
                .SplitError(x => x.Item.EeSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.EeWorkID.IsEmpty(), "工号 不能为空")
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
                    EeGenderLabel = it.EeGender.GetConfigValue<SysDictData>("sys_gender_type"),
                    EeWedlockLabel = it.EeWedlock.GetConfigValue<SysDictData>("sys_wedlock_state"),
                    EeNationIdLabel = it.EeNationId.GetConfigValue<SysDictData>("sys_nation_list"),
                    EeNativePlaceLabel = it.EeNativePlace.GetConfigValue<SysDictData>("sql_region_county"),
                    EePoliticIdLabel = it.EePoliticId.GetConfigValue<SysDictData>("sys_politic_list"),
                    EeCountryLabel = it.EeCountry.GetConfigValue<SysDictData>("sys_country_list"),
                    EeProvinceLabel = it.EeProvince.GetConfigValue<SysDictData>("sql_region_province"),
                    EeCityLabel = it.EeCity.GetConfigValue<SysDictData>("sql_region_city"),
                    EeHouseholdTypeLabel = it.EeHouseholdType.GetConfigValue<SysDictData>("sys_household_type"),
                    EeDepartmentIdLabel = it.EeDepartmentId.GetConfigValue<SysDictData>("sql_dept_list"),
                    EeTitlesIdLabel = it.EeTitlesId.GetConfigValue<SysDictData>("sys_titles_list"),
                    EePostIdLabel = it.EePostId.GetConfigValue<SysDictData>("sql_posts_list"),
                    EePostLevelLabel = it.EePostLevel.GetConfigValue<SysDictData>("sys_post_level"),
                    EeRecruitedLabel = it.EeRecruited.GetConfigValue<SysDictData>("sys_recruited_list"),
                    EeEngageFormLabel = it.EeEngageForm.GetConfigValue<SysDictData>("sys_employ_term"),
                    EeTiptopDegrEeLabel = it.EeTiptopDegrEe.GetConfigValue<SysDictData>("sys_level_education"),
                    EeSpecialtyLabel = it.EeSpecialty.GetConfigValue<SysDictData>("sys_specialty_list"),
                    EeWorkStateLabel = it.EeWorkState.GetConfigValue<SysDictData>("sys_serve_state"),
                    EeClockInLabel = it.EeClockIn.GetConfigValue<SysDictData>("sys_flag_list"),
                    EeShiftsTypeLabel = it.EeShiftsType.GetConfigValue<SysDictData>("sys_shifts_list"),
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
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeGender), it => it.EeGender == parm.EeGender);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeBirthday != null, it => it.EeBirthday >= parm.BeginEeBirthday);
            predicate = predicate.AndIF(parm.EndEeBirthday != null, it => it.EeBirthday <= parm.EndEeBirthday);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeIdentityCard), it => it.EeIdentityCard.Contains(parm.EeIdentityCard));
            predicate = predicate.AndIF(parm.EeWedlock != null, it => it.EeWedlock == parm.EeWedlock);
            predicate = predicate.AndIF(parm.EeNationId != null, it => it.EeNationId == parm.EeNationId);
            predicate = predicate.AndIF(parm.EeNativePlace != null, it => it.EeNativePlace == parm.EeNativePlace);
            predicate = predicate.AndIF(parm.EePoliticId != null, it => it.EePoliticId == parm.EePoliticId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeCountry), it => it.EeCountry == parm.EeCountry);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeProvince), it => it.EeProvince == parm.EeProvince);
            predicate = predicate.AndIF(parm.EeHouseholdType != null, it => it.EeHouseholdType == parm.EeHouseholdType);
            predicate = predicate.AndIF(parm.EeDepartmentId != null, it => it.EeDepartmentId == parm.EeDepartmentId);
            predicate = predicate.AndIF(parm.EeTitlesId != null, it => it.EeTitlesId == parm.EeTitlesId);
            predicate = predicate.AndIF(parm.EePostId != null, it => it.EePostId == parm.EePostId);
            predicate = predicate.AndIF(parm.EePostLevel != null, it => it.EePostLevel == parm.EePostLevel);
            predicate = predicate.AndIF(parm.EeDutyName != null, it => it.EeDutyName == parm.EeDutyName);
            predicate = predicate.AndIF(parm.EeRecruited != null, it => it.EeRecruited == parm.EeRecruited);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeEngageForm), it => it.EeEngageForm == parm.EeEngageForm);
            predicate = predicate.AndIF(parm.EeTiptopDegrEe != null, it => it.EeTiptopDegrEe == parm.EeTiptopDegrEe);
            predicate = predicate.AndIF(parm.EeSpecialty != null, it => it.EeSpecialty == parm.EeSpecialty);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWorkID), it => it.EeWorkID.Contains(parm.EeWorkID));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeBeginDate == null, it => it.EeBeginDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeBeginDate == null, it => it.EeBeginDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeBeginDate != null, it => it.EeBeginDate >= parm.BeginEeBeginDate);
            predicate = predicate.AndIF(parm.EndEeBeginDate != null, it => it.EeBeginDate <= parm.EndEeBeginDate);
            predicate = predicate.AndIF(parm.EeWorkState != null, it => it.EeWorkState == parm.EeWorkState);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeConversionTime == null, it => it.EeConversionTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeConversionTime == null, it => it.EeConversionTime >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeConversionTime != null, it => it.EeConversionTime >= parm.BeginEeConversionTime);
            predicate = predicate.AndIF(parm.EndEeConversionTime != null, it => it.EeConversionTime <= parm.EndEeConversionTime);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeLeaveDate == null, it => it.EeLeaveDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeLeaveDate == null, it => it.EeLeaveDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeLeaveDate != null, it => it.EeLeaveDate >= parm.BeginEeLeaveDate);
            predicate = predicate.AndIF(parm.EndEeLeaveDate != null, it => it.EeLeaveDate <= parm.EndEeLeaveDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeEndContract == null, it => it.EeEndContract >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeEndContract == null, it => it.EeEndContract >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeEndContract != null, it => it.EeEndContract >= parm.BeginEeEndContract);
            predicate = predicate.AndIF(parm.EndEeEndContract != null, it => it.EeEndContract <= parm.EndEeEndContract);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeRetireDate == null, it => it.EeRetireDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeRetireDate == null, it => it.EeRetireDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeRetireDate != null, it => it.EeRetireDate >= parm.BeginEeRetireDate);
            predicate = predicate.AndIF(parm.EndEeRetireDate != null, it => it.EeRetireDate <= parm.EndEeRetireDate);
            return predicate;
        }
    }
}