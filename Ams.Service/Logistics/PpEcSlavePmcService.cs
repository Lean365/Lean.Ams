using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// Pmc设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:45:42
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlavePmcService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlavePmcService : BaseService<PpEcSlavePmc>, IPpEcSlavePmcService
    {
        /// <summary>
        /// 查询Pmc设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePmcDto> GetList(PpEcSlavePmcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlavePmc, PpEcSlavePmcDto>(parm);

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
            int count = Count(it => it. PmcSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PmcSfId"></param>
        /// <returns></returns>
        public PpEcSlavePmc GetInfo(long PmcSfId)
        {
            var response = Queryable()
                .Where(x => x.PmcSfId == PmcSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加Pmc设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlavePmc AddPpEcSlavePmc(PpEcSlavePmc model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改Pmc设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlavePmc(PpEcSlavePmc model)
        {
            return Update(model, true, "修改Pmc设变");
        }

        /// <summary>
        /// 导入Pmc设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlavePmc(List<PpEcSlavePmc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PmcImplStated.IsEmpty(), "实施标记 不能为空")
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
        /// 导出Pmc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePmcDto> ExportList(PpEcSlavePmcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlavePmcDto()
                {
                    PmcImplStatedLabel = it.PmcImplStated.GetConfigValue<SysDictData>("sys_flag_list"),
                    PmcDisposalLabel = it.PmcDisposal.GetConfigValue<SysDictData>("sys_old_disposal"),
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
        private static Expressionable<PpEcSlavePmc> QueryExp(PpEcSlavePmcQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlavePmc>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PmcEcNo), it => it.PmcEcNo.Contains(parm.PmcEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PmcModel), it => it.PmcModel.Contains(parm.PmcModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PmcItem), it => it.PmcItem.Contains(parm.PmcItem));
            predicate = predicate.AndIF(parm.PmcImplStated != null, it => it.PmcImplStated == parm.PmcImplStated);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPmcEnteredDate == null, it => it.PmcEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPmcEnteredDate == null, it => it.PmcEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPmcEnteredDate != null, it => it.PmcEnteredDate >= parm.BeginPmcEnteredDate);
            predicate = predicate.AndIF(parm.EndPmcEnteredDate != null, it => it.PmcEnteredDate <= parm.EndPmcEnteredDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PmcPreLot), it => it.PmcPreLot.Contains(parm.PmcPreLot));
            predicate = predicate.AndIF(parm.PmcDisposal != null, it => it.PmcDisposal == parm.PmcDisposal);
            return predicate;
        }
    }
}