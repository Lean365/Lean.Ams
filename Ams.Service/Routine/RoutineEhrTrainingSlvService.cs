using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 培训
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:22:49
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrTrainingSlvService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrTrainingSlvService : BaseService<RoutineEhrTrainingSlv>, IRoutineEhrTrainingSlvService
    {
        /// <summary>
        /// 查询培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrTrainingSlvDto> GetList(RoutineEhrTrainingSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("EpTrainingDate desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrTrainingSlv, RoutineEhrTrainingSlvDto>(parm);

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
        public RoutineEhrTrainingSlv GetInfo(long EpSfId)
        {
            var response = Queryable()
                .Where(x => x.EpSfId == EpSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加培训
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrTrainingSlv AddRoutineEhrTrainingSlv(RoutineEhrTrainingSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改培训
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrTrainingSlv(RoutineEhrTrainingSlv model)
        {
            return Update(model, true, "修改培训");
        }

        /// <summary>
        /// 导入培训
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrTrainingSlv(List<RoutineEhrTrainingSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EpSfId.IsEmpty(), "ID不能为空")
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
        /// 导出培训
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrTrainingSlvDto> ExportList(RoutineEhrTrainingSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrTrainingSlvDto()
                {
                    EpTrainingItemsLabel = it.EpTrainingItems.GetConfigValue<SysDictData>("sys_training_items"),
                    EpTrainingResultsLabel = it.EpTrainingResults.GetConfigValue<SysDictData>("sys_training_results"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrTrainingSlv> QueryExp(RoutineEhrTrainingSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrTrainingSlv>();

            predicate = predicate.AndIF(parm.EpTrainingItems != null, it => it.EpTrainingItems == parm.EpTrainingItems);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpTrainingContent), it => it.EpTrainingContent.Contains(parm.EpTrainingContent));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EpTrainingResults), it => it.EpTrainingResults == parm.EpTrainingResults);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEpTrainingDate == null, it => it.EpTrainingDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEpTrainingDate == null, it => it.EpTrainingDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEpTrainingDate != null, it => it.EpTrainingDate >= parm.BeginEpTrainingDate);
            predicate = predicate.AndIF(parm.EndEpTrainingDate != null, it => it.EpTrainingDate <= parm.EndEpTrainingDate);
            return predicate;
        }
    }
}