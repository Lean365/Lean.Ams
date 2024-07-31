using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 绩效
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 17:18:14
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrPerformanceService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrPerformanceService : BaseService<RoutineEhrPerformance>, IRoutineEhrPerformanceService
    {
        /// <summary>
        /// 查询绩效列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPerformanceDto> GetList(RoutineEhrPerformanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("EpAssessmentYear asc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrPerformance, RoutineEhrPerformanceDto>(parm);

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
            int count = Count(it => it. EpSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EpSfId"></param>
        /// <returns></returns>
        public RoutineEhrPerformance GetInfo(long EpSfId)
        {
            var response = Queryable()
                .Where(x => x.EpSfId == EpSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加绩效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrPerformance AddRoutineEhrPerformance(RoutineEhrPerformance model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改绩效
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrPerformance(RoutineEhrPerformance model)
        {
            return Update(model, true, "修改绩效");
        }

        /// <summary>
        /// 导入绩效
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrPerformance(List<RoutineEhrPerformance> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EpSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.EpParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.EpWorkID.IsEmpty(), "工号不能为空")
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
        /// 导出绩效
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrPerformanceDto> ExportList(RoutineEhrPerformanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrPerformanceDto()
                {
                    EpAssessmentYearLabel = it.EpAssessmentYear.GetConfigValue<SysDictData>("sql_fy_list"),
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
        private static Expressionable<RoutineEhrPerformance> QueryExp(RoutineEhrPerformanceQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrPerformance>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpWorkID), it => it.EpWorkID == parm.EpWorkID);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpAssessmentYear), it => it.EpAssessmentYear == parm.EpAssessmentYear);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEpAssessmentDate == null, it => it.EpAssessmentDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEpAssessmentDate == null, it => it.EpAssessmentDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEpAssessmentDate != null, it => it.EpAssessmentDate >= parm.BeginEpAssessmentDate);
            predicate = predicate.AndIF(parm.EndEpAssessmentDate != null, it => it.EpAssessmentDate <= parm.EndEpAssessmentDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEpEffectiveDate == null, it => it.EpEffectiveDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEpEffectiveDate == null, it => it.EpEffectiveDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEpEffectiveDate != null, it => it.EpEffectiveDate >= parm.BeginEpEffectiveDate);
            predicate = predicate.AndIF(parm.EndEpEffectiveDate != null, it => it.EpEffectiveDate <= parm.EndEpEffectiveDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEpAuditDate == null, it => it.EpAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEpAuditDate == null, it => it.EpAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEpAuditDate != null, it => it.EpAuditDate >= parm.BeginEpAuditDate);
            predicate = predicate.AndIF(parm.EndEpAuditDate != null, it => it.EpAuditDate <= parm.EndEpAuditDate);
            return predicate;
        }
    }
}