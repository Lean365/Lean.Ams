//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 会计科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:53:13
    /// </summary>
    [AppService(ServiceType = typeof(IFicoAccountingTitleService), ServiceLifetime = LifeTime.Transient)]
    public class FicoAccountingTitleService : BaseService<FicoAccountingTitle>, IFicoAccountingTitleService
    {
        /// <summary>
        /// 查询会计科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoAccountingTitleDto> GetList(FicoAccountingTitleQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mb003 asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoAccountingTitle, FicoAccountingTitleDto>(parm);

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
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FicoAccountingTitle GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加会计科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoAccountingTitle AddFicoAccountingTitle(FicoAccountingTitle model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改会计科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoAccountingTitle(FicoAccountingTitle model)
        {
            return Update(model, true, "修改会计科目");
        }

        /// <summary>
        /// 导入会计科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoAccountingTitle(List<FicoAccountingTitle> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mb002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Mb003.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.Mb004.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.Mb006.IsEmpty(), "科目编号不能为空")
                .SplitError(x => x.Item.Mb015.IsEmpty(), "冻结不能为空")
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
        /// 导出会计科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoAccountingTitleDto> ExportList(FicoAccountingTitleQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoAccountingTitleDto()
                {
                    //查询字典: <公司代码> 
                    Mb003Label = it.Mb003.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <币种> 
                    Mb004Label = it.Mb004.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <BS类别> 
                    Mb008Label = it.Mb008.GetConfigValue<SysDictData>("sys_bs_type"),
                    //查询字典: <PL类别> 
                    Mb009Label = it.Mb009.GetConfigValue<SysDictData>("sys_pl_type"),
                    //查询字典: <统驭类别> 
                    Mb010Label = it.Mb010.GetConfigValue<SysDictData>("sys_conrol_title"),
                    //查询字典: <冻结> 
                    Mb015Label = it.Mb015.GetConfigValue<SysDictData>("sys_freeze_flag"),
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
        private static Expressionable<FicoAccountingTitle> QueryExp(FicoAccountingTitleQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoAccountingTitle>();

            //查询字段: <公司代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb003), it => it.Mb003 == parm.Mb003);
            //查询字段: <币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb004), it => it.Mb004 == parm.Mb004);
            //查询字段: <科目编号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb006), it => it.Mb006.Contains(parm.Mb006));
            //查询字段: <短文本> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb011), it => it.Mb011.Contains(parm.Mb011));
            return predicate;
        }
    }
}