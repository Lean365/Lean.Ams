//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Repository;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 公积金
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:44
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrFundsService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrFundsService : BaseService<RoutineEhrFunds>, IRoutineEhrFundsService
    {
        /// <summary>
        /// 查询公积金列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrFundsDto> GetList(RoutineEhrFundsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mj003 desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrFunds, RoutineEhrFundsDto>(parm);

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
        public RoutineEhrFunds GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加公积金
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrFunds AddRoutineEhrFunds(RoutineEhrFunds model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改公积金
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrFunds(RoutineEhrFunds model)
        {
            return Update(model, true, "修改公积金");
        }

        /// <summary>
        /// 导入公积金
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrFunds(List<RoutineEhrFunds> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.ParentId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.Mj003.IsEmpty(), "生效日不能为空")
                .SplitError(x => x.Item.Mj004.IsEmpty(), "工号不能为空")
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
        /// 导出公积金
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrFundsDto> ExportList(RoutineEhrFundsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrFundsDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrFunds> QueryExp(RoutineEhrFundsQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrFunds>();

            //查询字段: <生效日>
            //predicate = predicate.AndIF(parm.BeginMj003 == null, it => it.Mj003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMj003 != null, it => it.Mj003 >= parm.BeginMj003);
            //predicate = predicate.AndIF(parm.EndMj003 != null, it => it.Mj003 <= parm.EndMj003);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMj003 == null, it => it.Mj003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMj003 == null, it => it.Mj003 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMj003 != null, it => it.Mj003 >= parm.BeginMj003);
            predicate = predicate.AndIF(parm.EndMj003 != null, it => it.Mj003 <= parm.EndMj003);
            //查询字段: <工号>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj004), it => it.Mj004.Contains(parm.Mj004));
            return predicate;
        }
    }
}