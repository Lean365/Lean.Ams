using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 机构目标
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 10:30:14
    /// </summary>
    [AppService(ServiceType = typeof(IInstTargetService), ServiceLifetime = LifeTime.Transient)]
    public class InstTargetService : BaseService<InstTarget>, IInstTargetService
    {
        /// <summary>
        /// 查询机构目标列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstTargetDto> GetList(InstTargetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("IkAnnual desc")
                .Where(predicate.ToExpression())
                .ToPage<InstTarget, InstTargetDto>(parm);

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
            int count = Count(it => it. IkSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="IkSfId"></param>
        /// <returns></returns>
        public InstTarget GetInfo(long IkSfId)
        {
            var response = Queryable()
                .Where(x => x.IkSfId == IkSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加机构目标
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InstTarget AddInstTarget(InstTarget model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改机构目标
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstTarget(InstTarget model)
        {
            return Update(model, true, "修改机构目标");
        }

        /// <summary>
        /// 导入机构目标
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportInstTarget(List<InstTarget> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.IkSfId.IsEmpty(), "SfId不能为空")
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
        public PagedInfo<InstTargetDto> ExportList(InstTargetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InstTargetDto()
                {
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
        private static Expressionable<InstTarget> QueryExp(InstTargetQueryDto parm)
        {
            var predicate = Expressionable.Create<InstTarget>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IkAbbrName), it => it.IkAbbrName.Contains(parm.IkAbbrName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IkAnnual), it => it.IkAnnual == parm.IkAnnual);
            return predicate;
        }
    }
}