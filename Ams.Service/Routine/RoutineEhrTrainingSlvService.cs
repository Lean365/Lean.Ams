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
    /// @Date: 2024/9/12 16:38:39
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
        public RoutineEhrTrainingSlv GetInfo(long Id)
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
                .SplitError(x => x.Item.Mr003.IsEmpty(), "项目不能为空")
                .SplitError(x => x.Item.Mr006.IsEmpty(), "分数不能为空")
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
                    //查询字典: <项目> 
                    Mr003Label = it.Mr003.GetConfigValue<SysDictData>("sys_training_items"),
                    //查询字典: <结果> 
                    Mr007Label = it.Mr007.GetConfigValue<SysDictData>("sys_training_results"),
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

            return predicate;
        }
    }
}