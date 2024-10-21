//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 培训
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 8:56:48
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrTrainingService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrTrainingService : BaseService<RoutineEhrTraining>, IRoutineEhrTrainingService
    {
        /// <summary>
        /// 查询培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrTrainingDto> GetList(RoutineEhrTrainingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mq010 desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrTraining, RoutineEhrTrainingDto>(parm);

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
        public RoutineEhrTraining GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加培训
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrTraining AddRoutineEhrTraining(RoutineEhrTraining model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改培训
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrTraining(RoutineEhrTraining model)
        {
            return Update(model, true, "修改培训");
        }

        /// <summary>
        /// 导入培训
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrTraining(List<RoutineEhrTraining> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mq002.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.Mq003.IsEmpty(), "姓名不能为空")
                .SplitError(x => x.Item.Mq005.IsEmpty(), "项目不能为空")
                .SplitError(x => x.Item.Mq008.IsEmpty(), "分数不能为空")
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
        public PagedInfo<RoutineEhrTrainingDto> ExportList(RoutineEhrTrainingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrTrainingDto()
                {
                    //查询字典: <年度> 
                    Mq004Label = it.Mq004.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <项目> 
                    Mq005Label = it.Mq005.GetConfigValue<SysDictData>("sys_training_items"),
                    //查询字典: <结果> 
                    Mq009Label = it.Mq009.GetConfigValue<SysDictData>("sys_training_results"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrTraining> QueryExp(RoutineEhrTrainingQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrTraining>();

            //查询字段: <工号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq002), it => it.Mq002.Contains(parm.Mq002));
            //查询字段: <姓名> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq003), it => it.Mq003.Contains(parm.Mq003));
            //查询字段: <年度> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq004), it => it.Mq004 == parm.Mq004);
            //查询字段: <项目> 
            predicate = predicate.AndIF(parm.Mq005 != -1, it => it.Mq005 == parm.Mq005);
            return predicate;
        }
    }
}