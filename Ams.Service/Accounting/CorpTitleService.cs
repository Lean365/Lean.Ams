using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Linq;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 公司科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:11:12)
    /// </summary>
    [AppService(ServiceType = typeof(ICorpTitleService), ServiceLifetime = LifeTime.Transient)]
    public class CorpTitleService : BaseService<CorpTitle>, ICorpTitleService
    {
        /// <summary>
        /// 查询公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<CorpTitleDto> GetList(CorpTitleQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<CorpTitle, CorpTitleDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. FctSFID.ToString() == enterString);
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
        public CorpTitle GetInfo(long FctSFID)
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
        public CorpTitle AddCorpTitle(CorpTitle model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改公司科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCorpTitle(CorpTitle model)
        {
            return Update(model, true, "修改公司科目");
        }

        /// <summary>
        /// 导入公司科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportCorpTitle(List<CorpTitle> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FctSFID.IsEmpty(), "FSID不能为空")
                .SplitError(x => x.Item.FctCorp.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.FctCode.IsEmpty(), "科目代码不能为空")
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
        public PagedInfo<CorpTitleDto> ExportList(CorpTitleQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new CorpTitleDto()
                {
                    FctCorpLabel = it.FctCorp.GetConfigValue<Kernel.Model.System.SysDictData>("sys_crop_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<CorpTitle> QueryExp(CorpTitleQueryDto parm)
        {
            var predicate = Expressionable.Create<CorpTitle>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FctCorp), it => it.FctCorp == parm.FctCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FctCode), it => it.FctCode.Contains(parm.FctCode));
            return predicate;
        }
    }
}