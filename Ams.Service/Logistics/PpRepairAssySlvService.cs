using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 组立不良slv
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 11:58:58
    /// </summary>
    [AppService(ServiceType = typeof(IPpRepairAssySlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpRepairAssySlvService : BaseService<PpRepairAssySlv>, IPpRepairAssySlvService
    {
        /// <summary>
        /// 查询组立不良slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairAssySlvDto> GetList(PpRepairAssySlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpRepairAssySlv, PpRepairAssySlvDto>(parm);

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
            int count = Count(it => it. PpdSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PpdSfId"></param>
        /// <returns></returns>
        public PpRepairAssySlv GetInfo(long PpdSfId)
        {
            var response = Queryable()
                .Where(x => x.PpdSfId == PpdSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加组立不良slv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpRepairAssySlv AddPpRepairAssySlv(PpRepairAssySlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改组立不良slv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpRepairAssySlv(PpRepairAssySlv model)
        {
            return Update(model, true, "修改组立不良slv");
        }

        /// <summary>
        /// 导入组立不良slv
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpRepairAssySlv(List<PpRepairAssySlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PpdSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.PpdParentSfId.IsEmpty(), "PpdParentSfId不能为空")
                .SplitError(x => x.Item.PpdBadQty.IsEmpty(), "不良数量不能为空")
                .SplitError(x => x.Item.PpdBadTotal.IsEmpty(), "不良总数不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
        /// 导出组立不良slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairAssySlvDto> ExportList(PpRepairAssySlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpRepairAssySlvDto()
                {
                    PpdBadTypeLabel = it.PpdBadType.GetConfigValue<SysDictData>("sql_bad_dist"),
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
        private static Expressionable<PpRepairAssySlv> QueryExp(PpRepairAssySlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpRepairAssySlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdBadType), it => it.PpdBadType == parm.PpdBadType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdBadSymptom), it => it.PpdBadSymptom.Contains(parm.PpdBadSymptom));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdBadPosition), it => it.PpdBadPosition.Contains(parm.PpdBadPosition));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdBadReason), it => it.PpdBadReason.Contains(parm.PpdBadReason));
            return predicate;
        }
    }
}