using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 公司科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/3 15:41:55
    /// </summary>
    [AppService(ServiceType = typeof(IFicoCorpTitleService), ServiceLifetime = LifeTime.Transient)]
    public class FicoCorpTitleService : BaseService<FicoCorpTitle>, IFicoCorpTitleService
    {
        /// <summary>
        /// 查询公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCorpTitleDto> GetList(FicoCorpTitleQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoCorpTitle, FicoCorpTitleDto>(parm);

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
            int count = Count(it => it.FctCorp.ToString() + it.FctCode.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FctSFID"></param>
        /// <returns></returns>
        public FicoCorpTitle GetInfo(long FctSFID)
        {
            var response = Queryable()
                .Where(x => x.FctSFID == FctSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加公司科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoCorpTitle AddFicoCorpTitle(FicoCorpTitle model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改公司科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoCorpTitle(FicoCorpTitle model)
        {
            return Update(model, true, "修改公司科目");
        }

        /// <summary>
        /// 导入公司科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoCorpTitle(List<FicoCorpTitle> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FctSFID.IsEmpty(), "FSID不能为空")
                .SplitError(x => x.Item.FctCorp.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.FctCode.IsEmpty(), "科目代码不能为空")
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
        /// 导出公司科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCorpTitleDto> ExportList(FicoCorpTitleQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoCorpTitleDto()
                {
                    FctCorpLabel = it.FctCorp.GetConfigValue<SysDictData>("sys_crop_list"),
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
        private static Expressionable<FicoCorpTitle> QueryExp(FicoCorpTitleQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoCorpTitle>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FctCorp), it => it.FctCorp == parm.FctCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FctCode), it => it.FctCode.Contains(parm.FctCode));
            return predicate;
        }
    }
}