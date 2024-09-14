//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 奖惩
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:00
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrRewardPenaltiesService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrRewardPenaltiesService : BaseService<RoutineEhrRewardPenalties>, IRoutineEhrRewardPenaltiesService
    {
        /// <summary>
        /// 查询奖惩列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrRewardPenaltiesDto> GetList(RoutineEhrRewardPenaltiesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mo002 asc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrRewardPenalties, RoutineEhrRewardPenaltiesDto>(parm);

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
        public RoutineEhrRewardPenalties GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加奖惩
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrRewardPenalties AddRoutineEhrRewardPenalties(RoutineEhrRewardPenalties model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改奖惩
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrRewardPenalties(RoutineEhrRewardPenalties model)
        {
            return Update(model, true, "修改奖惩");
        }

        /// <summary>
        /// 导入奖惩
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrRewardPenalties(List<RoutineEhrRewardPenalties> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mo002.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.Mo004.IsEmpty(), "奖惩类别不能为空")
                .SplitError(x => x.Item.Mo005.IsEmpty(), "金额不能为空")
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
        /// 导出奖惩
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrRewardPenaltiesDto> ExportList(RoutineEhrRewardPenaltiesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrRewardPenaltiesDto()
                {
                    //查询字典: <奖惩类别> 
                    Mo004Label = it.Mo004.GetConfigValue<SysDictData>("sys_reward_penalties"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrRewardPenalties> QueryExp(RoutineEhrRewardPenaltiesQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrRewardPenalties>();

            //查询字段: <工号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mo002), it => it.Mo002 == parm.Mo002);
            //查询字段: <姓名> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mo003), it => it.Mo003.Contains(parm.Mo003));
            //查询字段: <奖惩类别> 
            predicate = predicate.AndIF(parm.Mo004 != -1, it => it.Mo004 == parm.Mo004);
            return predicate;
        }
    }
}