using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 预算实际明细
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:40:38
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetActualContService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetActualContService : BaseService<FicoBudgetActualCont>, IFicoBudgetActualContService
    {
        /// <summary>
        /// 查询预算实际明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> GetList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("FbYm asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetActualCont, FicoBudgetActualContDto>(parm);

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
            int count = Count(it => it. FbSfid.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbSfid"></param>
        /// <returns></returns>
        public FicoBudgetActualCont GetInfo(long FbSfid)
        {
            var response = Queryable()
                .Where(x => x.FbSfid == FbSfid)
                .First();

            return response;
        }
        /// <summary>
        /// 添加预算实际明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetActualCont AddFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改预算实际明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            return Update(model, true, "修改预算实际明细");
        }

        /// <summary>
        /// 导入预算实际明细
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetActualCont(List<FicoBudgetActualCont> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbSfid.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FbFy.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.FbYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FbCorpCode.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.FbCorpName.IsEmpty(), "公司名称不能为空")
                .SplitError(x => x.Item.FbExpCategory.IsEmpty(), "统计类别不能为空")
                .SplitError(x => x.Item.FbCostCode.IsEmpty(), "成本代码不能为空")
                .SplitError(x => x.Item.FbCostName.IsEmpty(), "成本名称不能为空")
                .SplitError(x => x.Item.FbTitleCode.IsEmpty(), "科目代码不能为空")
                .SplitError(x => x.Item.FbTitleName.IsEmpty(), "科目名称不能为空")
                .SplitError(x => x.Item.FbTitleNote.IsEmpty(), "科目分类不能为空")
                .SplitError(x => x.Item.FbBudgetAmt.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.FbActualAmt.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.FbDiffAmt.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.FbAccountant.IsEmpty(), "会计人员不能为空")
                .SplitError(x => x.Item.FbBalanceDate.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "删除不能为空")
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
        /// 导出预算实际明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> ExportList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetActualContDto()
                {
                    FbFyLabel = it.FbFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    FbYmLabel = it.FbYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbCorpCodeLabel = it.FbCorpCode.GetConfigValue<SysDictData>("sys_crop_list"),
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
        private static Expressionable<FicoBudgetActualCont> QueryExp(FicoBudgetActualContQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetActualCont>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbFy), it => it.FbFy == parm.FbFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbYm), it => it.FbYm == parm.FbYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbCorpCode), it => it.FbCorpCode == parm.FbCorpCode);
            return predicate;
        }
    }
}