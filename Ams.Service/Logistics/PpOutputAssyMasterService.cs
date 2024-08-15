using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 制一OPH主表
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:23
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputAssyMasterService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputAssyMasterService : BaseService<PpOutputAssyMaster>, IPpOutputAssyMasterService
    {
        /// <summary>
        /// 查询制一OPH主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputAssyMasterDto> GetList(PpOutputAssyMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<PpOutputAssyMaster, PpOutputAssyMasterDto>(parm);

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
            int count = Count(it => it.PomSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PomSfId"></param>
        /// <returns></returns>
        public PpOutputAssyMaster GetInfo(long PomSfId)
        {
            var response = Queryable()
                .Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(x => x.PomSfId == PomSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加制一OPH主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpOutputAssyMaster AddPpOutputAssyMaster(PpOutputAssyMaster model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpOutputAssySlaveNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改制一OPH主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputAssyMaster(PpOutputAssyMaster model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpOutputAssySlaveNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入制一OPH主表
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOutputAssyMaster(List<PpOutputAssyMaster> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PomSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.PomOrderType.IsEmpty(), "工单类别不能为空")
                .SplitError(x => x.Item.PomOrderNo.IsEmpty(), "工单号码不能为空")
                .SplitError(x => x.Item.PomOrderQty.IsEmpty(), "工单数量不能为空")
                .SplitError(x => x.Item.PomOrderSerial.IsEmpty(), "序列号不能为空")
                .SplitError(x => x.Item.PomLot.IsEmpty(), "生产批次不能为空")
                .SplitError(x => x.Item.PomModel.IsEmpty(), "机种名不能为空")
                .SplitError(x => x.Item.PomItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.PomDate.IsEmpty(), "生产日期不能为空")
                .SplitError(x => x.Item.PomLine.IsEmpty(), "生产班组不能为空")
                .SplitError(x => x.Item.PomDirect.IsEmpty(), "直接人数不能为空")
                .SplitError(x => x.Item.PomIndirect.IsEmpty(), "间接人数不能为空")
                .SplitError(x => x.Item.PomStdTime.IsEmpty(), "标准工时不能为空")
                .SplitError(x => x.Item.PomStdOutput.IsEmpty(), "标准产能不能为空")
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
        /// 导出制一OPH主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputAssyMasterDto> ExportList(PpOutputAssyMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpOutputAssyMasterDto()
                {
                    PomLineLabel = it.PomLine.GetConfigValue<SysDictData>("sql_line_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //PosProductionTimeLabel = it.PosProductionTime.GetConfigValue<SysDictData>("sys_phase_time"),
                    //PosDownTimeReasonsLabel = it.PosDownTimeReasons.GetConfigValue<SysDictData>("sql_line_stop"),
                    //PosMissingReasonsLabel = it.PosMissingReasons.GetConfigValue<SysDictData>("sql_non_conf"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputAssyMaster> QueryExp(PpOutputAssyMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputAssyMaster>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomOrderNo), it => it.PomOrderNo == parm.PomOrderNo);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomLot), it => it.PomLot.Contains(parm.PomLot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomModel), it => it.PomModel.Contains(parm.PomModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomItem), it => it.PomItem.Contains(parm.PomItem));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPomDate == null, it => it.PomDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPomDate == null, it => it.PomDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPomDate != null, it => it.PomDate >= parm.BeginPomDate);
            predicate = predicate.AndIF(parm.EndPomDate != null, it => it.PomDate <= parm.EndPomDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomLine), it => it.PomLine == parm.PomLine);
            return predicate;
        }
    }
}