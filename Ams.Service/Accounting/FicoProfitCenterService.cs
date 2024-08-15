using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 利润中心
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 14:40:21
    /// </summary>
    [AppService(ServiceType = typeof(IFicoProfitCenterService), ServiceLifetime = LifeTime.Transient)]
    public class FicoProfitCenterService : BaseService<FicoProfitCenter>, IFicoProfitCenterService
    {
        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoProfitCenterDto> GetList(FicoProfitCenterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoProfitCenter, FicoProfitCenterDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="Prctr"></param>
        /// <param name="Kokrs"></param>
        /// <returns></returns>
        public string CheckInputUnique(string Prctr, string Kokrs)
        {
            int count = Count(it => it.Prctr.ToString() == Prctr && it.Kokrs.ToString() == Kokrs);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FpSfId"></param>
        /// <returns></returns>
        public FicoProfitCenter GetInfo(long FpSfId)
        {
            var response = Queryable()
                .Where(x => x.FpSfId == FpSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoProfitCenter AddFicoProfitCenter(FicoProfitCenter model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改利润中心
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoProfitCenter(FicoProfitCenter model)
        {
            return Update(model, true, "修改利润中心");
        }

        /// <summary>
        /// 导入利润中心
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoProfitCenter(List<FicoProfitCenter> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FpSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Prctr.IsEmpty(), "利润中心  不能为空")
                .SplitError(x => x.Item.Kokrs.IsEmpty(), "控制范围  不能为空")
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
        /// 导出利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoProfitCenterDto> ExportList(FicoProfitCenterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoProfitCenterDto()
                {
                    KokrsLabel = it.Kokrs.GetConfigValue<SysDictData>("sys_crop_list"),
                    AbteiLabel = it.Abtei.GetConfigValue<SysDictData>("sql_dept_list"),
                    WaersLabel = it.Waers.GetConfigValue<SysDictData>("sys_ccy_type"),
                    EtypeLabel = it.Etype.GetConfigValue<SysDictData>("sys_costs_type"),
                    LockIndLabel = it.LockInd.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoProfitCenter> QueryExp(FicoProfitCenterQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoProfitCenter>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Prctr), it => it.Prctr.Contains(parm.Prctr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Kokrs), it => it.Kokrs == parm.Kokrs);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginDatbi == null, it => it.Datbi >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginDatbi == null, it => it.Datbi >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginDatbi != null, it => it.Datbi >= parm.BeginDatbi);
            predicate = predicate.AndIF(parm.EndDatbi != null, it => it.Datbi <= parm.EndDatbi);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ltext), it => it.Ltext.Contains(parm.Ltext));
            predicate = predicate.AndIF(parm.LockInd != null, it => it.LockInd == parm.LockInd);
            predicate = predicate.AndIF(parm.Tstate != null, it => it.Tstate == parm.Tstate);
            return predicate;
        }
    }
}