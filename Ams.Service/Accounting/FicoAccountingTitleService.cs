using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 会计科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/5 11:12:53
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
            int count = Count(it => it. FatSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FatSFID"></param>
        /// <returns></returns>
        public FicoAccountingTitle GetInfo(long FatSFID)
        {
            var response = Queryable()
                .Where(x => x.FatSFID == FatSFID)
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
                .SplitError(x => x.Item.FatSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FatCode.IsEmpty(), "科目代码不能为空")
                .SplitError(x => x.Item.FatShortName.IsEmpty(), "科目简称不能为空")
                .SplitError(x => x.Item.FatFullName.IsEmpty(), "科目全称不能为空")
                .SplitError(x => x.Item.FatLangKey.IsEmpty(), "语言不能为空")
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
        private static Expressionable<FicoAccountingTitle> QueryExp(FicoAccountingTitleQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoAccountingTitle>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FatCode), it => it.FatCode.Contains(parm.FatCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FatShortName), it => it.FatShortName.Contains(parm.FatShortName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FatFullName), it => it.FatFullName.Contains(parm.FatFullName));
            return predicate;
        }
    }
}