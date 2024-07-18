using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// KPI
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:44:18
    /// </summary>
    [AppService(ServiceType = typeof(IInstKpiService), ServiceLifetime = LifeTime.Transient)]
    public class InstKpiService : BaseService<InstKpi>, IInstKpiService
    {
        /// <summary>
        /// 查询KPI列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstKpiDto> GetList(InstKpiQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<InstKpi, InstKpiDto>(parm);

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
            int count = Count(it => it. IkSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="IkSFID"></param>
        /// <returns></returns>
        public InstKpi GetInfo(long IkSFID)
        {
            var response = Queryable()
                .Where(x => x.IkSFID == IkSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 添加KPI
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InstKpi AddInstKpi(InstKpi model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改KPI
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstKpi(InstKpi model)
        {
            return Update(model, true, "修改KPI");
        }

        /// <summary>
        /// 导入KPI
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportInstKpi(List<InstKpi> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.IkSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.IkAbbrName.IsEmpty(), "公司简称不能为空")
                .SplitError(x => x.Item.IkAnnual.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.IkLangKey.IsEmpty(), "语言不能为空")
                .SplitError(x => x.Item.IkTarget.IsEmpty(), "目标不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
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
        /// 导出KPI
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstKpiDto> ExportList(InstKpiQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InstKpiDto()
                {
                    IkAbbrNameLabel = it.IkAbbrName.GetConfigValue<SysDictData>("sys_crop_list"),
                    IkAnnualLabel = it.IkAnnual.GetConfigValue<SysDictData>("sql_fy_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<InstKpi> QueryExp(InstKpiQueryDto parm)
        {
            var predicate = Expressionable.Create<InstKpi>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IkAbbrName), it => it.IkAbbrName == parm.IkAbbrName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IkAnnual), it => it.IkAnnual == parm.IkAnnual);
            return predicate;
        }
    }
}