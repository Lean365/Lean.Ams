using Aliyun.OSS;
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
    /// 物料信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 11:34:57)
    /// </summary>
    [AppService(ServiceType = typeof(IMarbService), ServiceLifetime = LifeTime.Transient)]
    public class MarbService : BaseService<Marb>, IMarbService
    {
        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MarbDto> GetList(MarbQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Marb, MarbDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it.MmPlnt.ToString() + it.MmMatItem.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MmSFID"></param>
        /// <returns></returns>
        public Marb GetInfo(long MmSFID)
        {
            var response = Queryable()
                .Where(x => x.MmSFID == MmSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Marb AddMarb(Marb model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改物料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMarb(Marb model)
        {
            return Update(model, true, "修改物料信息");
        }

        /// <summary>
        /// 导入物料信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMarb(List<Marb> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MmSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.MmPlnt.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.MmMatItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.MmIndustry.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.MmMatType.IsEmpty(), "物料类型不能为空")
                .SplitError(x => x.Item.MmMatDes.IsEmpty(), "物料文本不能为空")
                .SplitError(x => x.Item.MmBaseUnit.IsEmpty(), "标准单位不能为空")
                .SplitError(x => x.Item.MmMatGroup.IsEmpty(), "物料组不能为空")
                .SplitError(x => x.Item.MmPurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.MmMoq.IsEmpty(), "最小批量不能为空")
                .SplitError(x => x.Item.MmRoundingVal.IsEmpty(), "舍入值不能为空")
                .SplitError(x => x.Item.MmLeadTime.IsEmpty(), "交货时间不能为空")
                .SplitError(x => x.Item.MmProDays.IsEmpty(), "生产天数不能为空")
                .SplitError(x => x.Item.MmProfitCenter.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.MmValType.IsEmpty(), "评估类不能为空")
                .SplitError(x => x.Item.MmMovingAvg.IsEmpty(), "移动平均价不能为空")
                .SplitError(x => x.Item.MmCcy.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.MmPriceControl.IsEmpty(), "价格控制不能为空")
                .SplitError(x => x.Item.MmPriceUnit.IsEmpty(), "价格单位不能为空")
                .SplitError(x => x.Item.MmInventory.IsEmpty(), "库存不能为空")
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
        /// 导出物料信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MarbDto> ExportList(MarbQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MarbDto()
                {
                    MmPlntLabel = it.MmPlnt.GetConfigValue<Kernel.Model.System.SysDictData>("app_plant_list"),
                    MmIndustryLabel = it.MmIndustry.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ind_type"),
                    MmMatTypeLabel = it.MmMatType.GetConfigValue<Kernel.Model.System.SysDictData>("app_mats_type"),
                    MmBaseUnitLabel = it.MmBaseUnit.GetConfigValue<Kernel.Model.System.SysDictData>("sys_unit_list"),
                    MmMatGroupLabel = it.MmMatGroup.GetConfigValue<Kernel.Model.System.SysDictData>("app_mats_group"),
                    MmPurGroupLabel = it.MmPurGroup.GetConfigValue<Kernel.Model.System.SysDictData>("app_pur_group"),
                    MmPurTypeLabel = it.MmPurType.GetConfigValue<Kernel.Model.System.SysDictData>("app_pur_type"),
                    MmSpecTypeLabel = it.MmSpecType.GetConfigValue<Kernel.Model.System.SysDictData>("app_pur_spec"),
                    MmBulkMatLabel = it.MmBulkMat.GetConfigValue<Kernel.Model.System.SysDictData>("sys_is_status"),
                    MmProfitCenterLabel = it.MmProfitCenter.GetConfigValue<Kernel.Model.System.SysDictData>("sql_prctr_list"),
                    MmValTypeLabel = it.MmValType.GetConfigValue<Kernel.Model.System.SysDictData>("app_val_type"),
                    MmCcyLabel = it.MmCcy.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ccy_type"),
                    MmSLocLabel = it.MmSLoc.GetConfigValue<Kernel.Model.System.SysDictData>("app_sloc_list"),
                    MmLocPosnLabel = it.MmLocPosn.GetConfigValue<Kernel.Model.System.SysDictData>("app_whse_location"),
                    MmLocEolLabel = it.MmLocEol.GetConfigValue<Kernel.Model.System.SysDictData>("app_eol_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Marb> QueryExp(MarbQueryDto parm)
        {
            var predicate = Expressionable.Create<Marb>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPlnt), it => it.MmPlnt == parm.MmPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem.Contains(parm.MmMatItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmIndustry), it => it.MmIndustry == parm.MmIndustry);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatType), it => it.MmMatType == parm.MmMatType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatDes), it => it.MmMatDes.Contains(parm.MmMatDes));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmBaseUnit), it => it.MmBaseUnit == parm.MmBaseUnit);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatGroup), it => it.MmMatGroup == parm.MmMatGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPurGroup), it => it.MmPurGroup == parm.MmPurGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmPurType), it => it.MmPurType == parm.MmPurType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmSpecType), it => it.MmSpecType == parm.MmSpecType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmBulkMat), it => it.MmBulkMat == parm.MmBulkMat);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmisChecked), it => it.MmisChecked == parm.MmisChecked);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmProfitCenter), it => it.MmProfitCenter == parm.MmProfitCenter);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmisLot), it => it.MmisLot == parm.MmisLot);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmValType), it => it.MmValType == parm.MmValType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmCcy), it => it.MmCcy == parm.MmCcy);
            predicate = predicate.AndIF(parm.MmPriceUnit != null, it => it.MmPriceUnit == parm.MmPriceUnit);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmSLoc), it => it.MmSLoc == parm.MmSLoc);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmESLoc), it => it.MmESLoc == parm.MmESLoc);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmLocPosn), it => it.MmLocPosn.Contains(parm.MmLocPosn));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmLocEol), it => it.MmLocEol == parm.MmLocEol);
            return predicate;
        }
    }
}