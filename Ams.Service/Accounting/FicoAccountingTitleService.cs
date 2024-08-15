using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 会计科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 12:02:48
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
                //.OrderBy("Saknr asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoAccountingTitle, FicoAccountingTitleDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验
        /// 输入项目唯一性
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
        /// <param name="FatSfId"></param>
        /// <returns></returns>
        public FicoAccountingTitle GetInfo(long FatSfId)
        {
            var response = Queryable()
                .Where(x => x.FatSfId == FatSfId)
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
                .SplitError(x => x.Item.FatSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mandt.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Bukrs.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.Waers.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.Saknr.IsEmpty(), "科目编号不能为空")
                .SplitError(x => x.Item.Xspea.IsEmpty(), "冻结不能为空")
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
                    BukrsLabel = it.Bukrs.GetConfigValue<SysDictData>("sys_crop_list"),
                    WaersLabel = it.Waers.GetConfigValue<SysDictData>("sys_ccy_type"),
                    XbilkLabel = it.Xbilk.GetConfigValue<SysDictData>("sys_flag_list"),
                    GvtypLabel = it.Gvtyp.GetConfigValue<SysDictData>("sys_pl_type"),
                    MitkzLabel = it.Mitkz.GetConfigValue<SysDictData>("sys_conrol_title"),
                    XspeaLabel = it.Xspea.GetConfigValue<SysDictData>("sys_is_status"),
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

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Bukrs), it => it.Bukrs == parm.Bukrs);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Waers), it => it.Waers == parm.Waers);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Saknr), it => it.Saknr.Contains(parm.Saknr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Xbilk), it => it.Xbilk == parm.Xbilk);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Gvtyp), it => it.Gvtyp == parm.Gvtyp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mitkz), it => it.Mitkz == parm.Mitkz);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Stext), it => it.Stext.Contains(parm.Stext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ltext), it => it.Ltext.Contains(parm.Ltext));
            predicate = predicate.AndIF(parm.Xspea != null, it => it.Xspea == parm.Xspea);
            return predicate;
        }
    }
}