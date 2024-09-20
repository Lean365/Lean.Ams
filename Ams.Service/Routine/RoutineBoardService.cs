//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 看板
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/20 9:52:38
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineBoardService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineBoardService : BaseService<RoutineBoard>, IRoutineBoardService
    {
        /// <summary>
        /// 查询看板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineBoardDto> GetList(RoutineBoardQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mb002 desc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineBoard, RoutineBoardDto>(parm);

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
        public RoutineBoard GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加看板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineBoard AddRoutineBoard(RoutineBoard model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改看板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineBoard(RoutineBoard model)
        {
            return Update(model, true, "修改看板");
        }

        /// <summary>
        /// 导入看板
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineBoard(List<RoutineBoard> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mb002.IsEmpty(), "起始日不能为空")
                .SplitError(x => x.Item.Mb003.IsEmpty(), "结束日不能为空")
                .SplitError(x => x.Item.Mb004.IsEmpty(), "公司名称不能为空")
                .SplitError(x => x.Item.Mb005.IsEmpty(), "参访人员不能为空")
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
        /// 导出看板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineBoardDto> ExportList(RoutineBoardQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineBoardDto()
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
        private static Expressionable<RoutineBoard> QueryExp(RoutineBoardQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineBoard>();

            //查询字段: <公司名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb004), it => it.Mb004.Contains(parm.Mb004));
            return predicate;
        }
    }
}