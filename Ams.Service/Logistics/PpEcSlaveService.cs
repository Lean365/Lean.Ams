using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using System.Linq;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 从设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/23 8:52:11
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveService : BaseService<PpEcSlave>, IPpEcSlaveService
    {
        /// <summary>
        /// 查询
        /// 从设变列表
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
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString)
        {
            int count = Count(it => it. EsSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EsSFID"></param>
        /// <returns></returns>
        public PpEcSlave GetInfo(long EsSFID)
        {
            var response = Queryable()
                .Where(x => x.EsSFID == EsSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加
        /// 从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlave AddPpEcSlave(PpEcSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改
        /// 从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlave(PpEcSlave model)
        {
            return Update(model, true, "修改从设变");
        }

        /// <summary>
        /// 批量导入
        /// 从设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlave(List<PpEcSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EsSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.EsEntryDate.IsEmpty(), "输入日不能为空")
                .SplitError(x => x.Item.EsEcNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EsModel.IsEmpty(), "机种不能为空")
                .SplitError(x => x.Item.EsItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.EsOldUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EsNewUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EsBomDate.IsEmpty(), "bom日期不能为空")
                .SplitError(x => x.Item.EmEcImpDept.IsEmpty(), "实施部门不能为空")
                .SplitError(x => x.Item.EsPurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.EsSloc.IsEmpty(), "仓库不能为空")
                .SplitError(x => x.Item.EsSopStae.IsEmpty(), "SOP不能为空")
                .SplitError(x => x.Item.EsOldCurrStock.IsEmpty(), "旧品库存不能为空")
                .SplitError(x => x.Item.EsNewCurrStock.IsEmpty(), "新品库存不能为空")
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
        /// 批量导出
        /// 从设变
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
                    EmEcImpDeptLabel = it.EmEcImpDept.GetConfigValue<Kernel.Model.System.SysDictData>("sql_dept_list"),
                    EsPurTypeLabel = it.EsPurType.GetConfigValue<Kernel.Model.System.SysDictData>("app_pur_type"),
                    EsSlocLabel = it.EsSloc.GetConfigValue<Kernel.Model.System.SysDictData>("app_sloc_list"),
                    EsInsmkLabel = it.EsInsmk.GetConfigValue<Kernel.Model.System.SysDictData>("sys_yes_no"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcSlave> QueryExp(PpEcSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlave>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEsEntryDate == null, it => it.EsEntryDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEsEntryDate == null, it => it.EsEntryDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEsEntryDate != null, it => it.EsEntryDate >= parm.BeginEsEntryDate);
            predicate = predicate.AndIF(parm.EndEsEntryDate != null, it => it.EsEntryDate <= parm.EndEsEntryDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsEcNo), it => it.EsEcNo.Contains(parm.EsEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsModel), it => it.EsModel.Contains(parm.EsModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsItem), it => it.EsItem.Contains(parm.EsItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsOldItem), it => it.EsOldItem.Contains(parm.EsOldItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsNewItem), it => it.EsNewItem.Contains(parm.EsNewItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcImpDept), it => it.EmEcImpDept.Contains(parm.EmEcImpDept));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsPurType), it => it.EsPurType.Contains(parm.EsPurType));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsSloc), it => it.EsSloc.Contains(parm.EsSloc));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsInsmk), it => it.EsInsmk.Contains(parm.EsInsmk));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsMstae), it => it.EsMstae.Contains(parm.EsMstae));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EsSopStae), it => it.EsSopStae.Contains(parm.EsSopStae));
            return predicate;
        }
    }
}