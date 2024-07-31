using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 资产预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:32:50
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAssetsMaService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAssetsMaService : BaseService<FicoBudgetAssetsMa>, IFicoBudgetAssetsMaService
    {
        /// <summary>
        /// 查询资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAssetsMaDto> GetList(FicoBudgetAssetsMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.FicoBudgetAssetsSlvNav) //填充子对象
                //.OrderBy("FbaFm desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetAssetsMa, FicoBudgetAssetsMaDto>(parm);

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
            int count = Count(it => it. FbaSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbaSfId"></param>
        /// <returns></returns>
        public FicoBudgetAssetsMa GetInfo(long FbaSfId)
        {
            var response = Queryable()
                .Includes(x => x.FicoBudgetAssetsSlvNav) //填充子对象
                .Where(x => x.FbaSfId == FbaSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAssetsMa AddFicoBudgetAssetsMa(FicoBudgetAssetsMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.FicoBudgetAssetsSlvNav).ExecuteReturnEntity();
        }
        /// <summary>
        /// 修改资产预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAssetsMa(FicoBudgetAssetsMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.FicoBudgetAssetsSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入资产预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAssetsMa(List<FicoBudgetAssetsMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbaSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.FbaCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FbaDept.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.FbaFy.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.FbaFm.IsEmpty(), "年月不能为空")
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
        public PagedInfo<FicoBudgetAssetsMaDto> ExportList(FicoBudgetAssetsMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetAssetsMaDto()
                {
                    FbaCorpLabel = it.FbaCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbaDeptLabel = it.FbaDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    FbaFyLabel = it.FbaFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    FbaFmLabel = it.FbaFm.GetConfigValue<SysDictData>("sql_ym_list"),
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
        private static Expressionable<FicoBudgetAssetsMa> QueryExp(FicoBudgetAssetsMaQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAssetsMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaCorp), it => it.FbaCorp == parm.FbaCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaDept), it => it.FbaDept == parm.FbaDept);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaFy), it => it.FbaFy == parm.FbaFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbaFm), it => it.FbaFm == parm.FbaFm);
            return predicate;
        }
    }
}