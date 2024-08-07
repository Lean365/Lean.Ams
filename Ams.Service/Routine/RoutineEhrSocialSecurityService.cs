using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 社保
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:43
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrSocialSecurityService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrSocialSecurityService : BaseService<RoutineEhrSocialSecurity>, IRoutineEhrSocialSecurityService
    {
        /// <summary>
        /// 查询社保列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrSocialSecurityDto> GetList(RoutineEhrSocialSecurityQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrSocialSecurity, RoutineEhrSocialSecurityDto>(parm);

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
        public RoutineEhrSocialSecurity GetInfo(long EeSfId)
        {
            var response = Queryable()
                .Where(x => x.EeSfId == EeSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加社保
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrSocialSecurity AddRoutineEhrSocialSecurity(RoutineEhrSocialSecurity model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改社保
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrSocialSecurity(RoutineEhrSocialSecurity model)
        {
            return Update(model, true, "修改社保");
        }

        /// <summary>
        /// 导入社保
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrSocialSecurity(List<RoutineEhrSocialSecurity> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EeSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.EeParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.EeWorkID.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.EssEffectiveDate.IsEmpty(), "生效日不能为空")
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
        /// 导出社保
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrSocialSecurityDto> ExportList(RoutineEhrSocialSecurityQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrSocialSecurityDto()
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
        private static Expressionable<RoutineEhrSocialSecurity> QueryExp(RoutineEhrSocialSecurityQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrSocialSecurity>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EeWorkID), it => it.EeWorkID.Contains(parm.EeWorkID));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEssEffectiveDate == null, it => it.EssEffectiveDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEssEffectiveDate == null, it => it.EssEffectiveDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEssEffectiveDate != null, it => it.EssEffectiveDate >= parm.BeginEssEffectiveDate);
            predicate = predicate.AndIF(parm.EndEssEffectiveDate != null, it => it.EssEffectiveDate <= parm.EndEssEffectiveDate);
            return predicate;
        }
    }
}