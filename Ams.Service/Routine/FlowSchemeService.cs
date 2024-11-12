//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 流程
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 11:32:52
    /// </summary>
    [AppService(ServiceType = typeof(IFlowSchemeService), ServiceLifetime = LifeTime.Transient)]
    public class FlowSchemeService : BaseService<FlowScheme>, IFlowSchemeService
    {
        /// <summary>
        /// 查询流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FlowSchemeDto> GetList(FlowSchemeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FlowScheme, FlowSchemeDto>(parm);

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
        public FlowScheme GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加流程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FlowScheme AddFlowScheme(FlowScheme model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改流程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFlowScheme(FlowScheme model)
        {
            return Update(model, true, "修改流程");
        }

        /// <summary>
        /// 导入流程
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFlowScheme(List<FlowScheme> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FrmType.IsEmpty(), "表单类型不能为空")
                .SplitError(x => x.Item.IsStatus.IsEmpty(), "状态标识不能为空")
                .SplitError(x => x.Item.SortingNum.IsEmpty(), "排序不能为空")
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
        /// 导出流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FlowSchemeDto> ExportList(FlowSchemeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FlowSchemeDto()
                {
                    //查询字典: <流程类型> 
                    SchemeTypeLabel = it.SchemeType.GetConfigValue<SysDictData>("sys_flow_state"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FlowScheme> QueryExp(FlowSchemeQueryDto parm)
        {
            var predicate = Expressionable.Create<FlowScheme>();

            //查询字段: <流程编号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SchemeCode), it => it.SchemeCode.Contains(parm.SchemeCode));
            //查询字段: <流程名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SchemeName), it => it.SchemeName.Contains(parm.SchemeName));
            //查询字段: <流程类型> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SchemeType), it => it.SchemeType == parm.SchemeType);
            //查询字段: <表单类型> 
            predicate = predicate.AndIF(parm.FrmType != -1, it => it.FrmType == parm.FrmType);
            return predicate;
        }
    }
}