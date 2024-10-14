//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 资产预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 9:17:19
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAssetsService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAssetsService : BaseService<FicoBudgetAssets>, IFicoBudgetAssetsService
    {
        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAssetsDto> GetList(FicoBudgetAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mg006 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetAssets, FicoBudgetAssetsDto>(parm);

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
            int count = Count(it => it.Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FicoBudgetAssets GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAssets AddFicoBudgetAssets(FicoBudgetAssets model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAssets(FicoBudgetAssets model)
        {
            return Update(model, true, "修改资产预算");
        }

        /// <summary>
        /// 导入资产预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAssets(List<FicoBudgetAssets> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mg003.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mg004.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.Mg005.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mg006.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mg007.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.Mg008.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.Mg009.IsEmpty(), "资产名称不能为空")
                .SplitError(x => x.Item.Mg011.IsEmpty(), "年限不能为空")
                .SplitError(x => x.Item.Mg012.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Mg013.IsEmpty(), "单价不能为空")
                .SplitError(x => x.Item.Mg014.IsEmpty(), "预算金额不能为空")
                .SplitError(x => x.Item.Mg015.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.Mg016.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.Mg017.IsEmpty(), "折旧不能为空")
                .SplitError(x => x.Item.Mg018.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.Mg019.IsEmpty(), "审核标志不能为空")
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
        public PagedInfo<FicoBudgetAssetsDto> ExportList(FicoBudgetAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetAssetsDto()
                {
                    //查询字典: <公司>
                    Mg003Label = it.Mg003.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <部门>
                    Mg004Label = it.Mg004.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <期间>
                    Mg005Label = it.Mg005.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月>
                    Mg006Label = it.Mg006.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <科目>
                    Mg007Label = it.Mg007.GetConfigValue<SysDictData>("sql_assets_type"),
                    //查询字典: <类别>
                    Mg008Label = it.Mg008.GetConfigValue<SysDictData>("sys_costs_type"),
                    //查询字典: <年限>
                    Mg011Label = it.Mg011.GetConfigValue<SysDictData>("sys_assets_years"),
                    //查询字典: <启用>
                    Mg018Label = it.Mg018.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetAssets> QueryExp(FicoBudgetAssetsQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAssets>();

            //查询字段: <公司>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg003), it => it.Mg003 == parm.Mg003);
            //查询字段: <部门>
            predicate = predicate.AndIF(parm.Mg004 != 0, it => it.Mg004 == parm.Mg004);
            //查询字段: <期间>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg005), it => it.Mg005 == parm.Mg005);
            //查询字段: <年月>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg006), it => it.Mg006 == parm.Mg006);
            //查询字段: <科目>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg007), it => it.Mg007 == parm.Mg007);
            //查询字段: <类别>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg008), it => it.Mg008 == parm.Mg008);
            //查询字段: <资产名称>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg009), it => it.Mg009.Contains(parm.Mg009));
            //查询字段: <审核标志>
            predicate = predicate.AndIF(parm.Mg019 != -1, it => it.Mg019 == parm.Mg019);
            return predicate;
        }
    }
}