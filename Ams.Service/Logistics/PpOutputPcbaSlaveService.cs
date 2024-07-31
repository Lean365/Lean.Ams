using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 制二OPH从表
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:07:20
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputPcbaSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputPcbaSlaveService : BaseService<PpOutputPcbaSlave>, IPpOutputPcbaSlaveService
    {
        /// <summary>
        /// 查询制二OPH从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputPcbaSlaveDto> GetList(PpOutputPcbaSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpOutputPcbaSlave, PpOutputPcbaSlaveDto>(parm);

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
            int count = Count(it => it. PosSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PosSfId"></param>
        /// <returns></returns>
        public PpOutputPcbaSlave GetInfo(long PosSfId)
        {
            var response = Queryable()
                .Where(x => x.PosSfId == PosSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加制二OPH从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpOutputPcbaSlave AddPpOutputPcbaSlave(PpOutputPcbaSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改制二OPH从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputPcbaSlave(PpOutputPcbaSlave model)
        {
            return Update(model, true, "修改制二OPH从表");
        }

        /// <summary>
        /// 导入制二OPH从表
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOutputPcbaSlave(List<PpOutputPcbaSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PosSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.PosParentSfId.IsEmpty(), "父SfId不能为空")
                .SplitError(x => x.Item.PosLineName.IsEmpty(), "班组不能为空")
                .SplitError(x => x.Item.PosPcbaType.IsEmpty(), "板别不能为空")
                .SplitError(x => x.Item.PosPcbaSide.IsEmpty(), "板面不能为空")
                .SplitError(x => x.Item.PosLotQty.IsEmpty(), "Lot数不能为空")
                .SplitError(x => x.Item.PosRealOutput.IsEmpty(), "生产实绩不能为空")
                .SplitError(x => x.Item.PosRealTotal.IsEmpty(), "累计生产数不能为空")
                .SplitError(x => x.Item.PosProTime.IsEmpty(), "生产工数不能为空")
                .SplitError(x => x.Item.PosHandoffNum.IsEmpty(), "切换次数不能为空")
                .SplitError(x => x.Item.PosHandoffTime.IsEmpty(), "切换时间不能为空")
                .SplitError(x => x.Item.PosDownTime.IsEmpty(), "切停机时间不能为空")
                .SplitError(x => x.Item.PosLossTime.IsEmpty(), "损失工数不能为空")
                .SplitError(x => x.Item.PosMakeTime.IsEmpty(), "投入工数不能为空")
                .SplitError(x => x.Item.PosBadQty.IsEmpty(), "不良台数不能为空")
                .SplitError(x => x.Item.PosManualLoss.IsEmpty(), "手插仕损不能为空")
                .SplitError(x => x.Item.PosRepairLoss.IsEmpty(), "修正仕损不能为空")
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
        /// 导出制二OPH从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputPcbaSlaveDto> ExportList(PpOutputPcbaSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpOutputPcbaSlaveDto()
                {
                    PosLineNameLabel = it.PosLineName.GetConfigValue<SysDictData>("sql_line_list"),
                    PosPcbaTypeLabel = it.PosPcbaType.GetConfigValue<SysDictData>("sql_pcb_type"),
                    PosPcbaSideLabel = it.PosPcbaSide.GetConfigValue<SysDictData>("sys_pcb_side"),
                    PosPcbaStatedLabel = it.PosPcbaStated.GetConfigValue<SysDictData>("sql_comp_status"),
                    PosDownTimeReasonsLabel = it.PosDownTimeReasons.GetConfigValue<SysDictData>("sql_line_stop"),
                    PosMissingReasonsLabel = it.PosMissingReasons.GetConfigValue<SysDictData>("sql_non_conf"),
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
        private static Expressionable<PpOutputPcbaSlave> QueryExp(PpOutputPcbaSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputPcbaSlave>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PosLineName), it => it.PosLineName == parm.PosLineName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PosPcbaType), it => it.PosPcbaType == parm.PosPcbaType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PosPcbaSide), it => it.PosPcbaSide == parm.PosPcbaSide);
            return predicate;
        }
    }
}