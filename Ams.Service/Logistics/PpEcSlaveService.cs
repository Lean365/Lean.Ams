using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 从设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:30:08
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveService : BaseService<PpEcSlave>, IPpEcSlaveService
    {
        /// <summary>
        /// 查询从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlave, PpEcSlaveDto>(parm);

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
            int count = Count(it => it. EcsSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EcsSfId"></param>
        /// <returns></returns>
        public PpEcSlave GetInfo(long EcsSfId)
        {
            var response = Queryable()
                .Where(x => x.EcsSfId == EcsSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlave AddPpEcSlave(PpEcSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlave(PpEcSlave model)
        {
            return Update(model, true, "修改从设变");
        }

        /// <summary>
        /// 导入从设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlave(List<PpEcSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EcsParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.EcsEcNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EcsModel.IsEmpty(), "机种不能为空")
                .SplitError(x => x.Item.EcsItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.EcsItemText.IsEmpty(), "物料文本不能为空")
                .SplitError(x => x.Item.EcsOldCurrStock.IsEmpty(), "旧品库存不能为空")
                .SplitError(x => x.Item.EcsOldUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EcsNewCurrStock.IsEmpty(), "新品库存不能为空")
                .SplitError(x => x.Item.EcsNewUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EcsBomDate.IsEmpty(), "bom日期不能为空")
                .SplitError(x => x.Item.EcsPurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.EcsPurGroup.IsEmpty(), "采购组不能为空")
                .SplitError(x => x.Item.EcsSloc.IsEmpty(), "仓库不能为空")
                .SplitError(x => x.Item.EcsSopStated.IsEmpty(), "SOP不能为空")
                .SplitError(x => x.Item.EcsImplStated.IsEmpty(), "实施标记不能为空")
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
        /// 导出从设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> ExportList(PpEcSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveDto()
                {
                    EcsPurTypeLabel = it.EcsPurType.GetConfigValue<SysDictData>("sys_pur_type"),
                    EcsPurGroupLabel = it.EcsPurGroup.GetConfigValue<SysDictData>("sys_pur_group"),
                    EcsSlocLabel = it.EcsSloc.GetConfigValue<SysDictData>("sys_sloc_list"),
                    EcsInsmkLabel = it.EcsInsmk.GetConfigValue<SysDictData>("sys_flag_list"),
                    EcsPlntStatedLabel = it.EcsPlntStated.GetConfigValue<SysDictData>("sys_eol_list"),
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
        private static Expressionable<PpEcSlave> QueryExp(PpEcSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlave>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsEcNo), it => it.EcsEcNo.Contains(parm.EcsEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsModel), it => it.EcsModel.Contains(parm.EcsModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsItem), it => it.EcsItem.Contains(parm.EcsItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsSubItem), it => it.EcsSubItem.Contains(parm.EcsSubItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsOldItem), it => it.EcsOldItem.Contains(parm.EcsOldItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsPurType), it => it.EcsPurType == parm.EcsPurType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsPurGroup), it => it.EcsPurGroup == parm.EcsPurGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsSloc), it => it.EcsSloc == parm.EcsSloc);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsInsmk), it => it.EcsInsmk == parm.EcsInsmk);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcsPlntStated), it => it.EcsPlntStated == parm.EcsPlntStated);
            predicate = predicate.AndIF(parm.EcsSopStated != null, it => it.EcsSopStated == parm.EcsSopStated);
            predicate = predicate.AndIF(parm.EcsImplStated != null, it => it.EcsImplStated == parm.EcsImplStated);
            return predicate;
        }
    }
}