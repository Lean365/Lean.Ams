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
    /// 资产预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    [AppService(ServiceType = typeof(IBudgetAssetService), ServiceLifetime = LifeTime.Transient)]
    public class BudgetAssetService : BaseService<BudgetAsset>, IBudgetAssetService
    {
        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<BudgetAssetDto> GetList(BudgetAssetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<BudgetAsset, BudgetAssetDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
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
        public BudgetAsset GetInfo(long FbaSFID)
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
        public BudgetAsset AddBudgetAsset(BudgetAsset model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateBudgetAsset(BudgetAsset model)
        {
            return Update(model, true, "修改资产预算");
        }

        /// <summary>
        /// 导入资产预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportBudgetAsset(List<BudgetAsset> list)
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
        public PagedInfo<BudgetAssetDto> ExportList(BudgetAssetQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new BudgetAssetDto()
                {
                    FbaCorpLabel = it.FbaCorp.GetConfigValue<Kernel.Model.System.SysDictData>("sys_crop_list"),
                    FbaDeptLabel = it.FbaDept.GetConfigValue<Kernel.Model.System.SysDictData>("sql_dept_list"),
                    FbaFyLabel = it.FbaFy.GetConfigValue<Kernel.Model.System.SysDictData>("sql_period_list"),
                    FbaFmLabel = it.FbaFm.GetConfigValue<Kernel.Model.System.SysDictData>("sql_ficoym_list"),
                    FbaTitleLabel = it.FbaTitle.GetConfigValue<Kernel.Model.System.SysDictData>("sql_recon_account"),
                    FbaClassLabel = it.FbaClass.GetConfigValue<Kernel.Model.System.SysDictData>("app_exp_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<BudgetAsset> QueryExp(BudgetAssetQueryDto parm)
        {
            var predicate = Expressionable.Create<BudgetAsset>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaCorp), it => it.FbaCorp == parm.FbaCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaDept), it => it.FbaDept == parm.FbaDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaFm), it => it.FbaFm == parm.FbaFm);
            predicate = predicate.AndIF(parm.FbaTitle != null, it => it.FbaTitle == parm.FbaTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaClass), it => it.FbaClass == parm.FbaClass);
            predicate = predicate.AndIF(parm.BeginFbaAuditDate == null, it => it.FbaAuditDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginFbaAuditDate != null, it => it.FbaAuditDate >= parm.BeginFbaAuditDate);
            predicate = predicate.AndIF(parm.EndFbaAuditDate != null, it => it.FbaAuditDate <= parm.EndFbaAuditDate);
            predicate = predicate.AndIF(parm.BeginFbaUndoDate == null, it => it.FbaUndoDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginFbaUndoDate != null, it => it.FbaUndoDate >= parm.BeginFbaUndoDate);
            predicate = predicate.AndIF(parm.EndFbaUndoDate != null, it => it.FbaUndoDate <= parm.EndFbaUndoDate);
            return predicate;
        }
    }
}