using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// PO残清单
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:59:13
    /// </summary>
    [AppService(ServiceType = typeof(IMmPoResidueService), ServiceLifetime = LifeTime.Transient)]
    public class MmPoResidueService : BaseService<MmPoResidue>, IMmPoResidueService
    {
        /// <summary>
        /// 查询PO残清单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmPoResidueDto> GetList(MmPoResidueQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmPoResidue, MmPoResidueDto>(parm);

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
            int count = Count(it => it. PrSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PrSfId"></param>
        /// <returns></returns>
        public MmPoResidue GetInfo(long PrSfId)
        {
            var response = Queryable()
                .Where(x => x.PrSfId == PrSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加PO残清单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmPoResidue AddMmPoResidue(MmPoResidue model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改PO残清单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmPoResidue(MmPoResidue model)
        {
            return Update(model, true, "修改PO残清单");
        }

        /// <summary>
        /// 导入PO残清单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmPoResidue(List<MmPoResidue> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PrSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.PrPlant.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.PrSupplierCode.IsEmpty(), "供应商ID不能为空")
                .SplitError(x => x.Item.PrSupplierName.IsEmpty(), "供应商名称不能为空")
                .SplitError(x => x.Item.PrPurItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.PrPurItemText.IsEmpty(), "物料文本不能为空")
                .SplitError(x => x.Item.PrLocation.IsEmpty(), "仓库不能为空")
                .SplitError(x => x.Item.PrDelivDate.IsEmpty(), "交货日期不能为空")
                .SplitError(x => x.Item.PrUnpaidQty.IsEmpty(), "未交不能为空")
                .SplitError(x => x.Item.PrAlreadyQty.IsEmpty(), "已交不能为空")
                .SplitError(x => x.Item.PrPurOrder.IsEmpty(), "订单号不能为空")
                .SplitError(x => x.Item.PrPurOrderDetails.IsEmpty(), "订单明细不能为空")
                .SplitError(x => x.Item.PrPlannedQty.IsEmpty(), "订单数量不能为空")
                .SplitError(x => x.Item.PrPurGroup.IsEmpty(), "采购组不能为空")
                .SplitError(x => x.Item.PrPurDate.IsEmpty(), "采购日期不能为空")
                .SplitError(x => x.Item.PrPurUnit.IsEmpty(), "单位不能为空")
                .SplitError(x => x.Item.PrUnitPrice.IsEmpty(), "价格单位不能为空")
                .SplitError(x => x.Item.PrPurCcy.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.PrPurTaxType.IsEmpty(), "税别不能为空")
                .SplitError(x => x.Item.PrPrctr.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.PrBalancedate.IsEmpty(), "PO残发行日期不能为空")
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
        /// 导出PO残清单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmPoResidueDto> ExportList(MmPoResidueQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmPoResidueDto()
                {
                    PrPlantLabel = it.PrPlant.GetConfigValue<SysDictData>("sys_plant_list"),
                    PrSupplierCodeLabel = it.PrSupplierCode.GetConfigValue<SysDictData>("sql_cus_list"),
                    PrLocationLabel = it.PrLocation.GetConfigValue<SysDictData>("sys_sloc_list"),
                    PrPurGroupLabel = it.PrPurGroup.GetConfigValue<SysDictData>("sys_pur_group"),
                    PrPurUnitLabel = it.PrPurUnit.GetConfigValue<SysDictData>("sys_unit_list"),
                    PrPurCcyLabel = it.PrPurCcy.GetConfigValue<SysDictData>("sys_ccy_type"),
                    PrPurTaxTypeLabel = it.PrPurTaxType.GetConfigValue<SysDictData>("sys_tax_list"),
                    PrPrctrLabel = it.PrPrctr.GetConfigValue<SysDictData>("sql_prctr_list"),
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
        private static Expressionable<MmPoResidue> QueryExp(MmPoResidueQueryDto parm)
        {
            var predicate = Expressionable.Create<MmPoResidue>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrPlant), it => it.PrPlant == parm.PrPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrSupplierCode), it => it.PrSupplierCode == parm.PrSupplierCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrSupplierName), it => it.PrSupplierName.Contains(parm.PrSupplierName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrPurItem), it => it.PrPurItem.Contains(parm.PrPurItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrLocation), it => it.PrLocation == parm.PrLocation);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPrDelivDate == null, it => it.PrDelivDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPrDelivDate == null, it => it.PrDelivDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPrDelivDate != null, it => it.PrDelivDate >= parm.BeginPrDelivDate);
            predicate = predicate.AndIF(parm.EndPrDelivDate != null, it => it.PrDelivDate <= parm.EndPrDelivDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrPurOrder), it => it.PrPurOrder.Contains(parm.PrPurOrder));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrPurGroup), it => it.PrPurGroup == parm.PrPurGroup);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPrPurDate == null, it => it.PrPurDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPrPurDate == null, it => it.PrPurDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPrPurDate != null, it => it.PrPurDate >= parm.BeginPrPurDate);
            predicate = predicate.AndIF(parm.EndPrPurDate != null, it => it.PrPurDate <= parm.EndPrPurDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrPurCcy), it => it.PrPurCcy == parm.PrPurCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrPurTaxType), it => it.PrPurTaxType == parm.PrPurTaxType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PrPrctr), it => it.PrPrctr == parm.PrPrctr);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPrBalancedate == null, it => it.PrBalancedate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPrBalancedate == null, it => it.PrBalancedate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPrBalancedate != null, it => it.PrBalancedate >= parm.BeginPrBalancedate);
            predicate = predicate.AndIF(parm.EndPrBalancedate != null, it => it.PrBalancedate <= parm.EndPrBalancedate);
            return predicate;
        }
    }
}