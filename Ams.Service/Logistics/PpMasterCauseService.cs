//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 原因类别
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:44:02
    /// </summary>
    [AppService(ServiceType = typeof(IPpMasterCauseService), ServiceLifetime = LifeTime.Transient)]
    public class PpMasterCauseService : BaseService<PpMasterCause>, IPpMasterCauseService
    {
        /// <summary>
        /// 查询原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMasterCauseDto> GetList(PpMasterCauseQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ma002 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpMasterCause, PpMasterCauseDto>(parm);

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
        public PpMasterCause GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加原因类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpMasterCause AddPpMasterCause(PpMasterCause model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改原因类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpMasterCause(PpMasterCause model)
        {
            return Update(model, true, "修改原因类别");
        }

        /// <summary>
        /// 导入原因类别
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpMasterCause(List<PpMasterCause> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Ma002.IsEmpty(), "原因类别不能为空")
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
        /// 导出原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMasterCauseDto> ExportList(PpMasterCauseQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpMasterCauseDto()
                {
                    //查询字典: <原因类别> 
                    Ma002Label = it.Ma002.GetConfigValue<SysDictData>("sys_cause_category"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpMasterCause> QueryExp(PpMasterCauseQueryDto parm)
        {
            var predicate = Expressionable.Create<PpMasterCause>();

            //查询字段: <原因类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma002), it => it.Ma002.Contains(parm.Ma002));
            //查询字段: <原因名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma004), it => it.Ma004.Contains(parm.Ma004));
            return predicate;
        }
    }
}