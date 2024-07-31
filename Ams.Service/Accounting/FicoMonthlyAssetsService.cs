using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 固定资产
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:56:51
    /// </summary>
    [AppService(ServiceType = typeof(IFicoMonthlyAssetsService), ServiceLifetime = LifeTime.Transient)]
    public class FicoMonthlyAssetsService : BaseService<FicoMonthlyAssets>, IFicoMonthlyAssetsService
    {
        /// <summary>
        /// 查询固定资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyAssetsDto> GetList(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("FaCheckedDate asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoMonthlyAssets, FicoMonthlyAssetsDto>(parm);

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
            int count = Count(it => it. FaSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FaSfId"></param>
        /// <returns></returns>
        public FicoMonthlyAssets GetInfo(long FaSfId)
        {
            var response = Queryable()
                .Where(x => x.FaSfId == FaSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加固定资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoMonthlyAssets AddFicoMonthlyAssets(FicoMonthlyAssets model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改固定资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoMonthlyAssets(FicoMonthlyAssets model)
        {
            return Update(model, true, "修改固定资产");
        }

        /// <summary>
        /// 导入固定资产
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoMonthlyAssets(List<FicoMonthlyAssets> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FaSfId.IsEmpty(), "SfId不能为空")
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
        public PagedInfo<FicoMonthlyAssetsDto> ExportList(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoMonthlyAssetsDto()
                {
                    FaCorpLabel = it.FaCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FaDeptLabel = it.FaDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FaClassCodeLabel = it.FaClassCode.GetConfigValue<SysDictData>("sys_assets_type"),
                    FaCostCenterLabel = it.FaCostCenter.GetConfigValue<SysDictData>("sql_cost_center"),
                    FaAssetUnitLabel = it.FaAssetUnit.GetConfigValue<SysDictData>("sys_unit_list"),
                    FaAssetManaLabel = it.FaAssetMana.GetConfigValue<SysDictData>("sys_assets_dist"),
                    FaAssetCcyLabel = it.FaAssetCcy.GetConfigValue<SysDictData>("sys_ccy_type"),
                    FaAssetStopLabel = it.FaAssetStop.GetConfigValue<SysDictData>("sys_flag_list"),
                    FaEntityLabel = it.FaEntity.GetConfigValue<SysDictData>("sys_assets_pattern"),
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
        private static Expressionable<FicoMonthlyAssets> QueryExp(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoMonthlyAssets>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaCorp), it => it.FaCorp == parm.FaCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaDept), it => it.FaDept == parm.FaDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaClassCode), it => it.FaClassCode == parm.FaClassCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetNo), it => it.FaAssetNo.Contains(parm.FaAssetNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaCostCenter), it => it.FaCostCenter == parm.FaCostCenter);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetShortName), it => it.FaAssetShortName.Contains(parm.FaAssetShortName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAssetFullName), it => it.FaAssetFullName.Contains(parm.FaAssetFullName));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFaCapitalizedDate == null, it => it.FaCapitalizedDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFaCapitalizedDate == null, it => it.FaCapitalizedDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFaCapitalizedDate != null, it => it.FaCapitalizedDate >= parm.BeginFaCapitalizedDate);
            predicate = predicate.AndIF(parm.EndFaCapitalizedDate != null, it => it.FaCapitalizedDate <= parm.EndFaCapitalizedDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFaScrapDate == null, it => it.FaScrapDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFaScrapDate == null, it => it.FaScrapDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFaScrapDate != null, it => it.FaScrapDate >= parm.BeginFaScrapDate);
            predicate = predicate.AndIF(parm.EndFaScrapDate != null, it => it.FaScrapDate <= parm.EndFaScrapDate);
            predicate = predicate.AndIF(parm.FaAssetStop != null, it => it.FaAssetStop == parm.FaAssetStop);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFaCheckedDate == null, it => it.FaCheckedDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFaCheckedDate == null, it => it.FaCheckedDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFaCheckedDate != null, it => it.FaCheckedDate >= parm.BeginFaCheckedDate);
            predicate = predicate.AndIF(parm.EndFaCheckedDate != null, it => it.FaCheckedDate <= parm.EndFaCheckedDate);
            return predicate;
        }
    }
}