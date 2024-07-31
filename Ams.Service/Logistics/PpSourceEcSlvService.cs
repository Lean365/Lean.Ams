using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 从源设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:04:44
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceEcSlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceEcSlvService : BaseService<PpSourceEcSlv>, IPpSourceEcSlvService
    {
        /// <summary>
        /// 查询从源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcSlvDto> GetList(PpSourceEcSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpSourceEcSlv, PpSourceEcSlvDto>(parm);

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
            int count = Count(it => it. SfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        public PpSourceEcSlv GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加从源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceEcSlv AddPpSourceEcSlv(PpSourceEcSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改从源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceEcSlv(PpSourceEcSlv model)
        {
            return Update(model, true, "修改从源设变");
        }

        /// <summary>
        /// 导入从源设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceEcSlv(List<PpSourceEcSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.ParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.Zpabds006.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Zpabds010.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.IsSolved.IsEmpty(), "处理标记不能为空")
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
        /// 导出从源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcSlvDto> ExportList(PpSourceEcSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceEcSlvDto()
                {
                    IsSolvedLabel = it.IsSolved.GetConfigValue<SysDictData>("sys_normal_whether"),
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
        private static Expressionable<PpSourceEcSlv> QueryExp(PpSourceEcSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceEcSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabds001), it => it.Zpabds001.Contains(parm.Zpabds001));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabds002), it => it.Zpabds002.Contains(parm.Zpabds002));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabds003), it => it.Zpabds003.Contains(parm.Zpabds003));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabds004), it => it.Zpabds004.Contains(parm.Zpabds004));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabds008), it => it.Zpabds008.Contains(parm.Zpabds008));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsSolved), it => it.IsSolved == parm.IsSolved);
            return predicate;
        }
    }
}