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
    /// oph从表
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [AppService(ServiceType = typeof(IOutputSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class OutputSlaveService : BaseService<OutputSlave>, IOutputSlaveService
    {
        /// <summary>
        /// 查询oph从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OutputSlaveDto> GetList(OutputSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<OutputSlave, OutputSlaveDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. PosSfid.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PosSfid"></param>
        /// <returns></returns>
        public OutputSlave GetInfo(long PosSfid)
        {
            var response = Queryable()
                .Where(x => x.PosSfid == PosSfid)
                .First();

            return response;
        }

        /// <summary>
        /// 添加oph从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public OutputSlave AddOutputSlave(OutputSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改oph从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateOutputSlave(OutputSlave model)
        {
            return Update(model, true, "修改oph从表");
        }

        /// <summary>
        /// 导入oph从表
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportOutputSlave(List<OutputSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PosSfid.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.PosParentSfid.IsEmpty(), "父SFID不能为空")
                .SplitError(x => x.Item.PosRealOutput.IsEmpty(), "实际产能不能为空")
                .SplitError(x => x.Item.PosDownTime.IsEmpty(), "停线时间不能为空")
                .SplitError(x => x.Item.PosRealWorkhours.IsEmpty(), "实际工数不能为空")
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
        /// 导出oph从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OutputSlaveDto> ExportList(OutputSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new OutputSlaveDto()
                {
                    PosProductionTimeLabel = it.PosProductionTime.GetConfigValue<Kernel.Model.System.SysDictData>("app_phase_time"),
                    PosDownTimeReasonsLabel = it.PosDownTimeReasons.GetConfigValue<Kernel.Model.System.SysDictData>("sql_line_stop"),
                    PosUnfinishedReasonsLabel = it.PosUnfinishedReasons.GetConfigValue<Kernel.Model.System.SysDictData>("sql_non_conf"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<OutputSlave> QueryExp(OutputSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<OutputSlave>();

            return predicate;
        }
    }
}