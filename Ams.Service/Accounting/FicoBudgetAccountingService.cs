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
    /// 预算科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:59:02
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAccountingService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAccountingService : BaseService<FicoBudgetAccounting>, IFicoBudgetAccountingService
    {
        /// <summary>
        /// 查询预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAccountingDto> GetList(FicoBudgetAccountingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Md004 asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetAccounting, FicoBudgetAccountingDto>(parm);

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
        /// 查询预算科目树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<FicoBudgetAccounting> GetTreeList(FicoBudgetAccountingQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAccounting>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md004), it => it.Md004 == parm.Md004);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md006), it => it.Md006.Contains(parm.Md006));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md007), it => it.Md007 == parm.Md007);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md008), it => it.Md008 == parm.Md008);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md009), it => it.Md009.Contains(parm.Md009));

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
        public FicoBudgetAccounting GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加预算科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAccounting AddFicoBudgetAccounting(FicoBudgetAccounting model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改预算科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAccounting(FicoBudgetAccounting model)
        {
            return Update(model, true, "修改预算科目");
        }

        /// <summary>
        /// 导入预算科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAccounting(List<FicoBudgetAccounting> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.ParentId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.Md003.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Md004.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.Md006.IsEmpty(), "预算科目不能为空")
                .SplitError(x => x.Item.Md007.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.Md008.IsEmpty(), "会计科目不能为空")
                .SplitError(x => x.Item.Md009.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.Md014.IsEmpty(), "冻结不能为空")
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
        /// 导出预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAccountingDto> ExportList(FicoBudgetAccountingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetAccountingDto()
                {
                    //查询字典: <公司代码> 
                    Md004Label = it.Md004.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <币种> 
                    Md007Label = it.Md007.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <冻结> 
                    Md014Label = it.Md014.GetConfigValue<SysDictData>("sys_freeze_flag"),
                    //查询字典: <软删除> 
                    //IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_Is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetAccounting> QueryExp(FicoBudgetAccountingQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAccounting>();

            //查询字段: <公司代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md004), it => it.Md004 == parm.Md004);
            //查询字段: <预算科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md006), it => it.Md006.Contains(parm.Md006));
            //查询字段: <币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md007), it => it.Md007 == parm.Md007);
            //查询字段: <会计科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md008), it => it.Md008 == parm.Md008);
            //查询字段: <名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md009), it => it.Md009.Contains(parm.Md009));
            return predicate;
        }
    }
}