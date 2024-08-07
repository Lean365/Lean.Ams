using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 人员预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:27:28
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetStaffMaService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetStaffMaService : BaseService<FicoBudgetStaffMa>, IFicoBudgetStaffMaService
    {
        /// <summary>
        /// 查询人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetStaffMaDto> GetList(FicoBudgetStaffMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.FicoBudgetStaffSlvNav) //填充子对象
                //.OrderBy("FbsFm desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetStaffMa, FicoBudgetStaffMaDto>(parm);

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
            int count = Count(it => it.FbsSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbsSfId"></param>
        /// <returns></returns>
        public FicoBudgetStaffMa GetInfo(long FbsSfId)
        {
            var response = Queryable()
                .Includes(x => x.FicoBudgetStaffSlvNav) //填充子对象
                .Where(x => x.FbsSfId == FbsSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetStaffMa AddFicoBudgetStaffMa(FicoBudgetStaffMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.FicoBudgetStaffSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetStaffMa(FicoBudgetStaffMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.FicoBudgetStaffSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入人员预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetStaffMa(List<FicoBudgetStaffMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbsSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.FbsCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FbsDept.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.FbsFy.IsEmpty(), "财年不能为空")
                // .SplitError(x => x.Item.FbsFm.IsEmpty(), "年月不能为空")
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
        /// 导出人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetStaffMaDto> ExportList(FicoBudgetStaffMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetStaffMaDto()
                {
                    FbsDeptLabel = it.FbsDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FbsFyLabel = it.FbsFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    //FbsFmLabel = it.FbsFm.GetConfigValue<SysDictData>("sql_ym_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //FbssTitleLabel = it.FbssTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    //FbssCategoryLabel = it.FbssCategory.GetConfigValue<SysDictData>("sys_exp_type"),
                    //FbssFlagLabel = it.FbssFlag.GetConfigValue<SysDictData>("sys_flag_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetStaffMa> QueryExp(FicoBudgetStaffMaQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetStaffMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsCorp), it => it.FbsCorp == parm.FbsCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsDept), it => it.FbsDept == parm.FbsDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsFy), it => it.FbsFy == parm.FbsFy);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbsFm), it => it.FbsFm == parm.FbsFm);
            return predicate;
        }
    }
}