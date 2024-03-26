using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Linq;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 固定资产
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/3/18 16:31:28)
    /// </summary>
    [AppService(ServiceType = typeof(IAssetService), ServiceLifetime = LifeTime.Transient)]
    public class AssetService : BaseService<Asset>, IAssetService
    {
        /// <summary>
        /// 查询固定资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<AssetDto> GetList(AssetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Asset, AssetDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. FaSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FaSFID"></param>
        /// <returns></returns>
        public Asset GetInfo(long FaSFID)
        {
            var response = Queryable()
                .Where(x => x.FaSFID == FaSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加固定资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Asset AddAsset(Asset model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改固定资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAsset(Asset model)
        {
            return Update(model, true, "修改固定资产");
        }

        /// <summary>
        /// 导入固定资产
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportAsset(List<Asset> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FaSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FaCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FaDept.IsEmpty(), "使用部门不能为空")
                .SplitError(x => x.Item.FaClassCode.IsEmpty(), "资产类别不能为空")
                .SplitError(x => x.Item.FaAssetNo.IsEmpty(), "资产编码不能为空")
                .SplitError(x => x.Item.FaCostCenter.IsEmpty(), "成本中心不能为空")
                .SplitError(x => x.Item.FaAssetShortName.IsEmpty(), "资产简称不能为空")
                .SplitError(x => x.Item.FaAssetFullName.IsEmpty(), "资产全称不能为空")
                .SplitError(x => x.Item.FaAssetUnit.IsEmpty(), "单位不能为空")
                .SplitError(x => x.Item.FaAssetQty.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.FaAssetMana.IsEmpty(), "管理区分不能为空")
                .SplitError(x => x.Item.FaAssetCcy.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.FaAcquisitionPrice.IsEmpty(), "购买价格不能为空")
                .SplitError(x => x.Item.FaCapitalizedDate.IsEmpty(), "资本化日期不能为空")
                .SplitError(x => x.Item.FaDepreciationValue.IsEmpty(), "折旧价值不能为空")
                .SplitError(x => x.Item.FaLocale.IsEmpty(), "存放位置不能为空")
                .SplitError(x => x.Item.FaAssetUsed.IsEmpty(), "使用年限不能为空")
                .SplitError(x => x.Item.FaAssetStop.IsEmpty(), "是否停用不能为空")
                .SplitError(x => x.Item.FaEntity.IsEmpty(), "资产形态不能为空")
                .SplitError(x => x.Item.FaHaveorNot.IsEmpty(), "资产存在否不能为空")
                .SplitError(x => x.Item.FaCheckedby.IsEmpty(), "盘点人员不能为空")
                .SplitError(x => x.Item.FaCheckedDate.IsEmpty(), "盘点日期不能为空")
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
        /// 导出固定资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<AssetDto> ExportList(AssetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new AssetDto()
                {
                    FaCorpLabel = it.FaCorp.GetConfigValue<Kernel.Model.System.SysDictData>("sys_crop_list"),
                    FaDeptLabel = it.FaDept.GetConfigValue<Kernel.Model.System.SysDictData>("sql_dept_list"),
                    FaClassCodeLabel = it.FaClassCode.GetConfigValue<Kernel.Model.System.SysDictData>("app_assets_type"),
                    FaCostCenterLabel = it.FaCostCenter.GetConfigValue<Kernel.Model.System.SysDictData>("sql_prctr_list"),
                    FaAssetUnitLabel = it.FaAssetUnit.GetConfigValue<Kernel.Model.System.SysDictData>("sys_unit_list"),
                    FaAssetManaLabel = it.FaAssetMana.GetConfigValue<Kernel.Model.System.SysDictData>("app_assets_dist"),
                    FaAssetCcyLabel = it.FaAssetCcy.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ccy_type"),
                    FaAssetStopLabel = it.FaAssetStop.GetConfigValue<Kernel.Model.System.SysDictData>("sys_is_status"),
                    FaEntityLabel = it.FaEntity.GetConfigValue<Kernel.Model.System.SysDictData>("app_assets_pattern"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Asset> QueryExp(AssetQueryDto parm)
        {
            var predicate = Expressionable.Create<Asset>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaCorp), it => it.FaCorp == parm.FaCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaDept), it => it.FaDept == parm.FaDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaClassCode), it => it.FaClassCode == parm.FaClassCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetNo), it => it.FaAssetNo.Contains(parm.FaAssetNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaCostCenter), it => it.FaCostCenter == parm.FaCostCenter);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetShortName), it => it.FaAssetShortName.Contains(parm.FaAssetShortName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetFullName), it => it.FaAssetFullName.Contains(parm.FaAssetFullName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetUnit), it => it.FaAssetUnit == parm.FaAssetUnit);
            predicate = predicate.AndIF(parm.FaAssetMana != null, it => it.FaAssetMana == parm.FaAssetMana);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetCcy), it => it.FaAssetCcy == parm.FaAssetCcy);
            predicate = predicate.AndIF(parm.BeginFaCapitalizedDate == null, it => it.FaCapitalizedDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginFaCapitalizedDate != null, it => it.FaCapitalizedDate >= parm.BeginFaCapitalizedDate);
            predicate = predicate.AndIF(parm.EndFaCapitalizedDate != null, it => it.FaCapitalizedDate <= parm.EndFaCapitalizedDate);
            predicate = predicate.AndIF(parm.BeginFaScrapDate == null, it => it.FaScrapDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginFaScrapDate != null, it => it.FaScrapDate >= parm.BeginFaScrapDate);
            predicate = predicate.AndIF(parm.EndFaScrapDate != null, it => it.FaScrapDate <= parm.EndFaScrapDate);
            predicate = predicate.AndIF(parm.FaAssetStop != null, it => it.FaAssetStop == parm.FaAssetStop);
            predicate = predicate.AndIF(parm.FaEntity != null, it => it.FaEntity == parm.FaEntity);
            predicate = predicate.AndIF(parm.FaHaveorNot != null, it => it.FaHaveorNot == parm.FaHaveorNot);
            predicate = predicate.AndIF(parm.BeginFaCheckedDate == null, it => it.FaCheckedDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginFaCheckedDate != null, it => it.FaCheckedDate >= parm.BeginFaCheckedDate);
            predicate = predicate.AndIF(parm.EndFaCheckedDate != null, it => it.FaCheckedDate <= parm.EndFaCheckedDate);
            return predicate;
        }
    }
}