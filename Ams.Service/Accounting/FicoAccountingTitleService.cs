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
    /// 会计科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2023/12/26 7:53:53)
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
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. FtSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FtSFID"></param>
        /// <returns></returns>
        public FicoAccountingTitle GetInfo(long FtSFID)
        {
            var response = Queryable()
                .Where(x => x.FtSFID == FtSFID)
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
                .SplitError(x => x.Item.FtCorpCode.IsEmpty(), "公司名称不能为空")
                .SplitError(x => x.Item.FtTitleCode.IsEmpty(), "科目代码不能为空")
                .SplitError(x => x.Item.FtTitleName.IsEmpty(), "科目名称不能为空")
                .SplitError(x => x.Item.FtTitleLang.IsEmpty(), "语言不能为空")
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
                    FtCorpCodeLabel = it.FtCorpCode.GetConfigValue<Kernel.Model.System.SysDictData>("sys_crop_list"),
                    FtTitleLangLabel = it.FtTitleLang.GetConfigValue<Kernel.Model.System.SysDictData>("sys_lang_type"),
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

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FtCorpCode), it => it.FtCorpCode == parm.FtCorpCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FtTitleCode), it => it.FtTitleCode.Contains(parm.FtTitleCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FtTitleName), it => it.FtTitleName.Contains(parm.FtTitleName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FtTitleLang), it => it.FtTitleLang == parm.FtTitleLang);
            return predicate;
        }
    }
}