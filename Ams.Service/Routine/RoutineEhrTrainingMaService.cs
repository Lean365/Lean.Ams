//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Repository;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 培训
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:13:49
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrTrainingMaService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrTrainingMaService : BaseService<RoutineEhrTrainingMa>, IRoutineEhrTrainingMaService
    {
        /// <summary>
        /// 查询培训列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrTrainingMaDto> GetList(RoutineEhrTrainingMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.RoutineEhrTrainingSlvNav) //填充子对象
                //.OrderBy("Mq004 desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrTrainingMa, RoutineEhrTrainingMaDto>(parm);

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
            int count = Count(it => it.Id.ToString() == enterString);
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
        public RoutineEhrTrainingMa GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.RoutineEhrTrainingSlvNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加培训
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrTrainingMa AddRoutineEhrTrainingMa(RoutineEhrTrainingMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.RoutineEhrTrainingSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改培训
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrTrainingMa(RoutineEhrTrainingMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.RoutineEhrTrainingSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入培训
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrTrainingMa(List<RoutineEhrTrainingMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mq002.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.Mq003.IsEmpty(), "姓名不能为空")
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
        public PagedInfo<RoutineEhrTrainingMaDto> ExportList(RoutineEhrTrainingMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrTrainingMaDto()
                {
                    //查询字典: <年度>
                    Mq004Label = it.Mq004.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <项目>
                    //Mr003Label = it.Mr003.GetConfigValue<SysDictData>("sys_training_items"),
                    //查询字典: <结果>
                    //Mr007Label = it.Mr007.GetConfigValue<SysDictData>("sys_training_results"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrTrainingMa> QueryExp(RoutineEhrTrainingMaQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrTrainingMa>();

            //查询字段: <工号>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq002), it => it.Mq002.Contains(parm.Mq002));
            //查询字段: <姓名>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq003), it => it.Mq003.Contains(parm.Mq003));
            //查询字段: <年度>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq004), it => it.Mq004 == parm.Mq004);
            return predicate;
        }
    }
}