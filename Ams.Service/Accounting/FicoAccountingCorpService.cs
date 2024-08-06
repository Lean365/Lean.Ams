using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 公司科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 11:09:24
    /// </summary>
    [AppService(ServiceType = typeof(IFicoAccountingCorpService), ServiceLifetime = LifeTime.Transient)]
    public class FicoAccountingCorpService : BaseService<FicoAccountingCorp>, IFicoAccountingCorpService
    {
        /// <summary>
        /// 查询公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoAccountingCorpDto> GetList(FicoAccountingCorpQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Saknr asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoAccountingCorp, FicoAccountingCorpDto>(parm);

            return response;
        }

        /// <summary>
        /// 检查
        /// 输入是否唯一
        /// </summary>
        /// <param name="Bukrs"></param>
        /// <param name="Saknr"></param>
        /// <returns></returns>
        public string CheckInputUnique(string Bukrs, string Saknr)
        {
            int count = Count(it => it.Bukrs.ToString() == Bukrs && it.Saknr.ToString() == Saknr);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        public FicoAccountingCorp GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加公司科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoAccountingCorp AddFicoAccountingCorp(FicoAccountingCorp model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改公司科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoAccountingCorp(FicoAccountingCorp model)
        {
            return Update(model, true, "修改公司科目");
        }

        /// <summary>
        /// 导入公司科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoAccountingCorp(List<FicoAccountingCorp> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mandt.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Bukrs.IsEmpty(), "公司代码  不能为空")
                .SplitError(x => x.Item.Saknr.IsEmpty(), "科目代码  不能为空")
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
        public PagedInfo<FicoAccountingCorpDto> ExportList(FicoAccountingCorpQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoAccountingCorpDto()
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
        private static Expressionable<FicoAccountingCorp> QueryExp(FicoAccountingCorpQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoAccountingCorp>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Saknr), it => it.Saknr.Contains(parm.Saknr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Stext), it => it.Stext.Contains(parm.Stext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ltext), it => it.Ltext.Contains(parm.Ltext));
            return predicate;
        }
    }
}