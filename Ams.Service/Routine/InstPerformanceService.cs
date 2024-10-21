//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 机构目标
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 10:55:04
    /// </summary>
    [AppService(ServiceType = typeof(IInstPerformanceService), ServiceLifetime = LifeTime.Transient)]
    public class InstPerformanceService : BaseService<InstPerformance>, IInstPerformanceService
    {
        /// <summary>
        /// 查询机构目标列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstPerformanceDto> GetList(InstPerformanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Md002 desc")
                .Where(predicate.ToExpression())
                .ToPage<InstPerformance, InstPerformanceDto>(parm);

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
        public InstPerformance GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加机构目标
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InstPerformance AddInstPerformance(InstPerformance model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改机构目标
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstPerformance(InstPerformance model)
        {
            return Update(model, true, "修改机构目标");
        }

        /// <summary>
        /// 导入机构目标
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportInstPerformance(List<InstPerformance> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
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
        /// 导出机构目标
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstPerformanceDto> ExportList(InstPerformanceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InstPerformanceDto()
                {
                    //查询字典: <期间> 
                    Md002Label = it.Md002.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <公司> 
                    Md003Label = it.Md003.GetConfigValue<SysDictData>("sql_corp_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<InstPerformance> QueryExp(InstPerformanceQueryDto parm)
        {
            var predicate = Expressionable.Create<InstPerformance>();

            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md002), it => it.Md002 == parm.Md002);
            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md003), it => it.Md003 == parm.Md003);
            return predicate;
        }
    }
}