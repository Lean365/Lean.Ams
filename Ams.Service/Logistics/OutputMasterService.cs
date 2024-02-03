using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using System.Linq;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// oph主表
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:16:45)
    /// </summary>
    [AppService(ServiceType = typeof(IOutputMasterService), ServiceLifetime = LifeTime.Transient)]
    public class OutputMasterService : BaseService<OutputMaster>, IOutputMasterService
    {
        /// <summary>
        /// 查询oph主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OutputMasterDto> GetList(OutputMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<OutputMaster, OutputMasterDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. PomSfid.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PomSfid"></param>
        /// <returns></returns>
        public OutputMaster GetInfo(long PomSfid)
        {
            var response = Queryable()
                .Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(x => x.PomSfid == PomSfid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加oph主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OutputMaster AddOutputMaster(OutputMaster model)
        {
            return Context.InsertNav(model).Include(s1 => s1.OutputSlaveNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改oph主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateOutputMaster(OutputMaster model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.OutputSlaveNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入oph主表
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportOutputMaster(List<OutputMaster> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PomSfid.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.PomMfgOrder.IsEmpty(), "生产工单不能为空")
                .SplitError(x => x.Item.PomMfgOrderQty.IsEmpty(), "工单数量不能为空")
                .SplitError(x => x.Item.PomMfgOrderSerial.IsEmpty(), "管理序列号不能为空")
                .SplitError(x => x.Item.PomMfgLot.IsEmpty(), "生产批次不能为空")
                .SplitError(x => x.Item.PomMfgModel.IsEmpty(), "机种名不能为空")
                .SplitError(x => x.Item.PomMfgItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.PomMfgDate.IsEmpty(), "生产日期不能为空")
                .SplitError(x => x.Item.PomMfgLine.IsEmpty(), "生产班组不能为空")
                .SplitError(x => x.Item.PomDirect.IsEmpty(), "直接人数不能为空")
                .SplitError(x => x.Item.PomIndirect.IsEmpty(), "间接人数不能为空")
                .SplitError(x => x.Item.PomStdTime.IsEmpty(), "标准工时不能为空")
                .SplitError(x => x.Item.PomStdOutput.IsEmpty(), "标准产能不能为空")
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
        /// 导出oph主表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OutputMasterDto> ExportList(OutputMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new OutputMasterDto()
                {
                    PomMfgOrderLabel = it.PomMfgOrder.GetConfigValue<Kernel.Model.System.SysDictData>("sql_moc_list"),
                    PomMfgLineLabel = it.PomMfgLine.GetConfigValue<Kernel.Model.System.SysDictData>("sql_line_list"),
                    //PosProductionTimeLabel = it.PosProductionTime.GetConfigValue<Kernel.Model.System.SysDictData>("app_phase_time"),
                    //PosDownTimeReasonsLabel = it.PosDownTimeReasons.GetConfigValue<Kernel.Model.System.SysDictData>("sql_line_stop"),
                    //PosUnfinishedReasonsLabel = it.PosUnfinishedReasons.GetConfigValue<Kernel.Model.System.SysDictData>("sql_non_conf"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<OutputMaster> QueryExp(OutputMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<OutputMaster>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgOrder), it => it.PomMfgOrder == parm.PomMfgOrder);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgLot), it => it.PomMfgLot.Contains(parm.PomMfgLot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgModel), it => it.PomMfgModel.Contains(parm.PomMfgModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgItem), it => it.PomMfgItem.Contains(parm.PomMfgItem));
            predicate = predicate.AndIF(parm.BeginPomMfgDate == null, it => it.PomMfgDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginPomMfgDate != null, it => it.PomMfgDate >= parm.BeginPomMfgDate);
            predicate = predicate.AndIF(parm.EndPomMfgDate != null, it => it.PomMfgDate <= parm.EndPomMfgDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgLine), it => it.PomMfgLine == parm.PomMfgLine);
            return predicate;
        }
    }
}