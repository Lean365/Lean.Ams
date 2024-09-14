//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 公司科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:35:01
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
                //.OrderBy("Ma004 asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoAccountingCorp, FicoAccountingCorpDto>(parm);

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
        public FicoAccountingCorp GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
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
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Ma002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Ma003.IsEmpty(), "帐目表不能为空")
                .SplitError(x => x.Item.Ma004.IsEmpty(), "总帐科目不能为空")
                .SplitError(x => x.Item.Ma014.IsEmpty(), "短文本不能为空")
                .SplitError(x => x.Item.Ma017.IsEmpty(), "冻结不能为空")
                .SplitError(x => x.Item.Ma018.IsEmpty(), "冻结过账不能为空")
                .SplitError(x => x.Item.Ma019.IsEmpty(), "冻结计划不能为空")
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
                    //查询字典: <冻结>
                    Ma017Label = it.Ma017.GetConfigValue<SysDictData>("sys_freeze_flag"),
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
        private static Expressionable<FicoAccountingCorp> QueryExp(FicoAccountingCorpQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoAccountingCorp>();

            //查询字段: <帐目表>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma003), it => it.Ma003.Contains(parm.Ma003));
            //查询字段: <总帐科目>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma004), it => it.Ma004.Contains(parm.Ma004));
            //查询字段: <短文本>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma014), it => it.Ma014.Contains(parm.Ma014));
            //查询字段: <冻结>
            predicate = predicate.AndIF(parm.Ma017 != -1, it => it.Ma017 == parm.Ma017);
            return predicate;
        }
    }
}