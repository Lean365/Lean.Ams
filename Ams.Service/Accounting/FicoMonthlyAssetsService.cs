using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 月度资产
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:59:43
    /// </summary>
    [AppService(ServiceType = typeof(IFicoMonthlyAssetsService), ServiceLifetime = LifeTime.Transient)]
    public class FicoMonthlyAssetsService : BaseService<FicoMonthlyAssets>, IFicoMonthlyAssetsService
    {
        /// <summary>
        /// 查询月度资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyAssetsDto> GetList(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("FaLfmon desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoMonthlyAssets, FicoMonthlyAssetsDto>(parm);

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
            int count = Count(it => it. FaSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FaSfId"></param>
        /// <returns></returns>
        public FicoMonthlyAssets GetInfo(long FaSfId)
        {
            var response = Queryable()
                .Where(x => x.FaSfId == FaSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加月度资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoMonthlyAssets AddFicoMonthlyAssets(FicoMonthlyAssets model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改月度资产
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoMonthlyAssets(FicoMonthlyAssets model)
        {
            return Update(model, true, "修改月度资产");
        }

        /// <summary>
        /// 导入月度资产
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoMonthlyAssets(List<FicoMonthlyAssets> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FaSfId.IsEmpty(), "ID不能为空")
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
        /// 导出月度资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoMonthlyAssetsDto> ExportList(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoMonthlyAssetsDto()
                {
                    FaLfgjaLabel = it.FaLfgja.GetConfigValue<SysDictData>("sql_fy_list"),
                    FaLfmonLabel = it.FaLfmon.GetConfigValue<SysDictData>("sql_ym_list"),
                    FaBukrsLabel = it.FaBukrs.GetConfigValue<SysDictData>("sys_crop_list"),
                    FaBtabtLabel = it.FaBtabt.GetConfigValue<SysDictData>("sql_dept_name"),
                    FaAnlklLabel = it.FaAnlkl.GetConfigValue<SysDictData>("sys_assets_type"),
                    FaKostlLabel = it.FaKostl.GetConfigValue<SysDictData>("sql_cost_center"),
                    FaBsakzLabel = it.FaBsakz.GetConfigValue<SysDictData>("sys_assets_dist"),
                    FaWaersLabel = it.FaWaers.GetConfigValue<SysDictData>("sys_ccy_type"),
                    FaParkflgLabel = it.FaParkflg.GetConfigValue<SysDictData>("sys_is_status"),
                    FaEntityLabel = it.FaEntity.GetConfigValue<SysDictData>("sys_assets_pattern"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoMonthlyAssets> QueryExp(FicoMonthlyAssetsQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoMonthlyAssets>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaLfgja), it => it.FaLfgja == parm.FaLfgja);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaLfmon), it => it.FaLfmon == parm.FaLfmon);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaBukrs), it => it.FaBukrs == parm.FaBukrs);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaBtabt), it => it.FaBtabt == parm.FaBtabt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAnlkl), it => it.FaAnlkl == parm.FaAnlkl);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaAnln), it => it.FaAnln.Contains(parm.FaAnln));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaKostl), it => it.FaKostl == parm.FaKostl);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FaStext), it => it.FaStext.Contains(parm.FaStext));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFaAktiv == null, it => it.FaAktiv >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFaAktiv == null, it => it.FaAktiv >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFaAktiv != null, it => it.FaAktiv >= parm.BeginFaAktiv);
            predicate = predicate.AndIF(parm.EndFaAktiv != null, it => it.FaAktiv <= parm.EndFaAktiv);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFaDeakt == null, it => it.FaDeakt >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFaDeakt == null, it => it.FaDeakt >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFaDeakt != null, it => it.FaDeakt >= parm.BeginFaDeakt);
            predicate = predicate.AndIF(parm.EndFaDeakt != null, it => it.FaDeakt <= parm.EndFaDeakt);
            predicate = predicate.AndIF(parm.FaParkflg != null, it => it.FaParkflg == parm.FaParkflg);
            return predicate;
        }
    }
}