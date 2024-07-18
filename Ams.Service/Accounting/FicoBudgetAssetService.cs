using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 资产预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:07
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAssetService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAssetService : BaseService<FicoBudgetAsset>, IFicoBudgetAssetService
    {
        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAssetDto> GetList(FicoBudgetAssetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetAsset, FicoBudgetAssetDto>(parm);

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
            int count = Count(it => it. FbaSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbaSFID"></param>
        /// <returns></returns>
        public FicoBudgetAsset GetInfo(long FbaSFID)
        {
            var response = Queryable()
                .Where(x => x.FbaSFID == FbaSFID)
                .First();

            return response;
        }
        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAsset AddFicoBudgetAsset(FicoBudgetAsset model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAsset(FicoBudgetAsset model)
        {
            return Update(model, true, "修改资产预算");
        }

        /// <summary>
        /// 导入资产预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAsset(List<FicoBudgetAsset> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbaSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FbaCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FbaDept.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.FbaFy.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FbaFm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FbaTitle.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.FbaClass.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.FbaName.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.FbaDesc.IsEmpty(), "说明不能为空")
                .SplitError(x => x.Item.FbaServiceLife.IsEmpty(), "年限不能为空")
                .SplitError(x => x.Item.FbaBudgetAmount.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.FbaActualAmount.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.FbaDifferenceAmount.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.FbaDepreciation.IsEmpty(), "折旧不能为空")
                .SplitError(x => x.Item.FbaFlag.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.FbaAudit.IsEmpty(), "审核标志不能为空")
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
        /// 导出资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAssetDto> ExportList(FicoBudgetAssetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetAssetDto()
                {
                    FbaCorpLabel = it.FbaCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbaDeptLabel = it.FbaDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FbaFyLabel = it.FbaFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    FbaFmLabel = it.FbaFm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbaTitleLabel = it.FbaTitle.GetConfigValue<SysDictData>("sql_recon_account"),
                    FbaClassLabel = it.FbaClass.GetConfigValue<SysDictData>("sys_assets_type"),
                    FbaFlagLabel = it.FbaFlag.GetConfigValue<SysDictData>("sys_normal_whether"),
                    FbaAuditLabel = it.FbaAudit.GetConfigValue<SysDictData>("sys_audit_flag"),
                    FbaAuditNameLabel = it.FbaAuditName.GetConfigValue<SysDictData>("sql_ec_group"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetAsset> QueryExp(FicoBudgetAssetQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAsset>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaCorp), it => it.FbaCorp == parm.FbaCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaDept), it => it.FbaDept == parm.FbaDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaFy), it => it.FbaFy == parm.FbaFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaFm), it => it.FbaFm == parm.FbaFm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaTitle), it => it.FbaTitle == parm.FbaTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaClass), it => it.FbaClass == parm.FbaClass);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaName), it => it.FbaName.Contains(parm.FbaName));
            predicate = predicate.AndIF(parm.FbaFlag != null, it => it.FbaFlag == parm.FbaFlag);
            predicate = predicate.AndIF(parm.FbaAudit != null, it => it.FbaAudit == parm.FbaAudit);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbaAuditDate == null, it => it.FbaAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbaAuditDate == null, it => it.FbaAuditDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbaAuditDate != null, it => it.FbaAuditDate >= parm.BeginFbaAuditDate);
            predicate = predicate.AndIF(parm.EndFbaAuditDate != null, it => it.FbaAuditDate <= parm.EndFbaAuditDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFbaUndoDate == null, it => it.FbaUndoDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFbaUndoDate == null, it => it.FbaUndoDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFbaUndoDate != null, it => it.FbaUndoDate >= parm.BeginFbaUndoDate);
            predicate = predicate.AndIF(parm.EndFbaUndoDate != null, it => it.FbaUndoDate <= parm.EndFbaUndoDate);
            return predicate;
        }
    }
}