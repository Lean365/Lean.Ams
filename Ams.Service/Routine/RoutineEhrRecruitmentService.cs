using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 招聘
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:16
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
        public RoutineEhrRecruitment GetInfo(long EeSfId)
        {
            var response = Queryable()
                .Where(x => x.EeSfId == EeSfId)
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
        private static Expressionable<RoutineEhrRecruitment> QueryExp(RoutineEhrRecruitmentQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrRecruitment>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWorkID), it => it.EeWorkID.Contains(parm.EeWorkID));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeName), it => it.EeName.Contains(parm.EeName));
            return predicate;
        }
    }
}