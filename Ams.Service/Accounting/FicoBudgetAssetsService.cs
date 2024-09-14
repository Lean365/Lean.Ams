//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Collections.Generic;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 资产预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 15:46:44
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
                //.OrderBy("Mg004 desc")
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
            int count = Count(it => it. Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 查询资产预算树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<FicoBudgetAssets> GetTreeList(FicoBudgetAssetsQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAssets>();

            predicate = predicate.AndIF(parm.DeptId != -1, it => it.DeptId == parm.DeptId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg004), it => it.Mg004 == parm.Mg004);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg005), it => it.Mg005 == parm.Mg005);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg006), it => it.Mg006 == parm.Mg006);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToTree(it => it.Children, it => it.ParentId, 0);

            return response;
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
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.DeptId.IsEmpty(), "部门ID不能为空")
                .SplitError(x => x.Item.Mg004.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mg005.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mg006.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mg011.IsEmpty(), "年限不能为空")
                .SplitError(x => x.Item.Mg012.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.Mg013.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.Mg014.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.Mg015.IsEmpty(), "折旧不能为空")
                .SplitError(x => x.Item.Mg016.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.Mg017.IsEmpty(), "审核标志不能为空")
                .SplitError(x => x.Item.Ref04.IsEmpty(), "预留1不能为空")
                .SplitError(x => x.Item.Ref05.IsEmpty(), "预留2不能为空")
                .SplitError(x => x.Item.Ref06.IsEmpty(), "预留3不能为空")
                .SplitError(x => x.Item.Udf51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.Udf52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.Udf53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.Udf54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.Udf55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.Udf56.IsEmpty(), "自定义6不能为空")
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
                    //查询字典: <部门ID> 
                    DeptIdLabel = it.DeptId.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <期间> 
                    Mg004Label = it.Mg004.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mg005Label = it.Mg005.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司> 
                    Mg006Label = it.Mg006.GetConfigValue<SysDictData>("sql_corp_list"),
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

            //查询字段: <部门ID> 
            predicate = predicate.AndIF(parm.DeptId != -1, it => it.DeptId == parm.DeptId);
            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg004), it => it.Mg004 == parm.Mg004);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg005), it => it.Mg005 == parm.Mg005);
            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg006), it => it.Mg006 == parm.Mg006);
            return predicate;
        }
    }
}