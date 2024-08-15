using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 人事
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 8:47:39
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
            int count = Count(it => it.EeSfId.ToString() == enterString);
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
                .SplitError(x => x.Item.EeName.IsEmpty(), "姓名不能为空")
                .SplitError(x => x.Item.EeGenderId.IsEmpty(), "性别不能为空")
                .SplitError(x => x.Item.EeBirthday.IsEmpty(), "出生日期不能为空")
                .SplitError(x => x.Item.EeIdentityCard.IsEmpty(), "身份证号不能为空")
                .SplitError(x => x.Item.EeWedlockId.IsEmpty(), "婚姻状态不能为空")
                .SplitError(x => x.Item.EeNationId.IsEmpty(), "民族不能为空")
                .SplitError(x => x.Item.EeNativePlace.IsEmpty(), "籍贯不能为空")
                .SplitError(x => x.Item.EePoliticId.IsEmpty(), "政治面貌不能为空")
                .SplitError(x => x.Item.EeCountry.IsEmpty(), "国家/地区不能为空")
                .SplitError(x => x.Item.EeProvince.IsEmpty(), "省区不能为空")
                .SplitError(x => x.Item.EeCity.IsEmpty(), "市区不能为空")
                .SplitError(x => x.Item.EeCounty.IsEmpty(), "县区不能为空")
                .SplitError(x => x.Item.EeHouseholdTypeId.IsEmpty(), "户口性质不能为空")
                .SplitError(x => x.Item.EeDepartmentId.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.EeEmployeeId.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.EeJoinedDate.IsEmpty(), "入职日期不能为空")
                .SplitError(x => x.Item.EeClockInId.IsEmpty(), "打卡否不能为空")
                .SplitError(x => x.Item.EeShiftsTypeId.IsEmpty(), "班别不能为空")
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
                    EeGenderIdLabel = it.EeGenderId.GetConfigValue<SysDictData>("sys_gender_type"),
                    EeWedlockIdLabel = it.EeWedlockId.GetConfigValue<SysDictData>("sys_wedlock_state"),
                    EeNationIdLabel = it.EeNationId.GetConfigValue<SysDictData>("sys_nation_list"),
                    EePoliticIdLabel = it.EePoliticId.GetConfigValue<SysDictData>("sys_politic_list"),
                    EeCountryLabel = it.EeCountry.GetConfigValue<SysDictData>("sys_country_list"),
                    EeProvinceLabel = it.EeProvince.GetConfigValue<SysDictData>("sql_region_province"),
                    EeHouseholdTypeIdLabel = it.EeHouseholdTypeId.GetConfigValue<SysDictData>("sys_household_type"),
                    EeDepartmentIdLabel = it.EeDepartmentId.GetConfigValue<SysDictData>("sql_dept_list"),
                    EeTitlesIdLabel = it.EeTitlesId.GetConfigValue<SysDictData>("sys_titles_list"),
                    EePostIdLabel = it.EePostId.GetConfigValue<SysDictData>("sql_posts_list"),
                    EePostLevelLabel = it.EePostLevel.GetConfigValue<SysDictData>("sys_post_level"),
                    EeRecruitedLabel = it.EeRecruited.GetConfigValue<SysDictData>("sys_recruited_list"),
                    EeEngageFormIdLabel = it.EeEngageFormId.GetConfigValue<SysDictData>("sys_employ_term"),
                    EeEducationalBackgroundIdLabel = it.EeEducationalBackgroundId.GetConfigValue<SysDictData>("sys_level_education"),
                    EeSpecialtyIdLabel = it.EeSpecialtyId.GetConfigValue<SysDictData>("sys_specialty_list"),
                    EeEmployedStatusLabel = it.EeEmployedStatus.GetConfigValue<SysDictData>("sys_serve_state"),
                    EeClockInIdLabel = it.EeClockInId.GetConfigValue<SysDictData>("sys_is_status"),
                    EeShiftsTypeIdLabel = it.EeShiftsTypeId.GetConfigValue<SysDictData>("sys_shifts_list"),
                    //IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
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
            predicate = predicate.AndIF(parm.EeGenderId != null, it => it.EeGenderId == parm.EeGenderId);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeBirthday == null, it => it.EeBirthday >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeBirthday != null, it => it.EeBirthday >= parm.BeginEeBirthday);
            predicate = predicate.AndIF(parm.EndEeBirthday != null, it => it.EeBirthday <= parm.EndEeBirthday);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeIdentityCard), it => it.EeIdentityCard.Contains(parm.EeIdentityCard));
            predicate = predicate.AndIF(parm.EeWedlockId != null, it => it.EeWedlockId == parm.EeWedlockId);
            predicate = predicate.AndIF(parm.EeNationId != null, it => it.EeNationId == parm.EeNationId);
            predicate = predicate.AndIF(parm.EePoliticId != null, it => it.EePoliticId == parm.EePoliticId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeCountry), it => it.EeCountry == parm.EeCountry);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeProvince), it => it.EeProvince == parm.EeProvince);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeCity), it => it.EeCity == parm.EeCity);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeCounty), it => it.EeCounty == parm.EeCounty);
            predicate = predicate.AndIF(parm.EeHouseholdTypeId != null, it => it.EeHouseholdTypeId == parm.EeHouseholdTypeId);
            predicate = predicate.AndIF(parm.EeDepartmentId != null, it => it.EeDepartmentId == parm.EeDepartmentId);
            predicate = predicate.AndIF(parm.EeTitlesId != null, it => it.EeTitlesId == parm.EeTitlesId);
            predicate = predicate.AndIF(parm.EePostId != null, it => it.EePostId == parm.EePostId);
            predicate = predicate.AndIF(parm.EePostLevel != null, it => it.EePostLevel == parm.EePostLevel);
            predicate = predicate.AndIF(parm.EeRecruited != null, it => it.EeRecruited == parm.EeRecruited);
            predicate = predicate.AndIF(parm.EeEngageFormId != null, it => it.EeEngageFormId == parm.EeEngageFormId);
            predicate = predicate.AndIF(parm.EeEducationalBackgroundId != null, it => it.EeEducationalBackgroundId == parm.EeEducationalBackgroundId);
            predicate = predicate.AndIF(parm.EeSpecialtyId != null, it => it.EeSpecialtyId == parm.EeSpecialtyId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeEmployeeId), it => it.EeEmployeeId.Contains(parm.EeEmployeeId));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeJoinedDate == null, it => it.EeJoinedDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeJoinedDate == null, it => it.EeJoinedDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeJoinedDate != null, it => it.EeJoinedDate >= parm.BeginEeJoinedDate);
            predicate = predicate.AndIF(parm.EndEeJoinedDate != null, it => it.EeJoinedDate <= parm.EndEeJoinedDate);
            predicate = predicate.AndIF(parm.EeEmployedStatus != null, it => it.EeEmployedStatus == parm.EeEmployedStatus);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeLeaveDate == null, it => it.EeLeaveDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeLeaveDate == null, it => it.EeLeaveDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeLeaveDate != null, it => it.EeLeaveDate >= parm.BeginEeLeaveDate);
            predicate = predicate.AndIF(parm.EndEeLeaveDate != null, it => it.EeLeaveDate <= parm.EndEeLeaveDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeContractEndDate == null, it => it.EeContractEndDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeContractEndDate == null, it => it.EeContractEndDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeContractEndDate != null, it => it.EeContractEndDate >= parm.BeginEeContractEndDate);
            predicate = predicate.AndIF(parm.EndEeContractEndDate != null, it => it.EeContractEndDate <= parm.EndEeContractEndDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEeRetirementDate == null, it => it.EeRetirementDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEeRetirementDate == null, it => it.EeRetirementDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEeRetirementDate != null, it => it.EeRetirementDate >= parm.BeginEeRetirementDate);
            predicate = predicate.AndIF(parm.EndEeRetirementDate != null, it => it.EeRetirementDate <= parm.EndEeRetirementDate);
            predicate = predicate.AndIF(parm.EeClockInId != null, it => it.EeClockInId == parm.EeClockInId);
            predicate = predicate.AndIF(parm.EeShiftsTypeId != null, it => it.EeShiftsTypeId == parm.EeShiftsTypeId);
            return predicate;
        }
    }
}