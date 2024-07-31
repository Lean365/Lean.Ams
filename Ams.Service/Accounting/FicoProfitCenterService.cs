using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 利润中心
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:41:52
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
                //.OrderBy("Datab asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoProfitCenter, FicoProfitCenterDto>(parm);

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
            int count = Count(it => it. FpSfId.ToString() == enterString);
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
                .SplitError(x => x.Item.Mandt.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Prctr.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.Kokrs.IsEmpty(), "控制范围不能为空")
                .SplitError(x => x.Item.Datbi.IsEmpty(), "有效截至日期不能为空")
                .SplitError(x => x.Item.Ktext.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.Ltext.IsEmpty(), "长文本不能为空")
                .SplitError(x => x.Item.LockInd.IsEmpty(), "锁定标记不能为空")
                .SplitError(x => x.Item.Tstate.IsEmpty(), "状态不能为空")
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
                    EtypeLabel = it.Etype.GetConfigValue<SysDictData>("sys_exp_type"),
                    LockIndLabel = it.LockInd.GetConfigValue<SysDictData>("sys_locked_flag"),
                    TstateLabel = it.Tstate.GetConfigValue<SysDictData>("sys_activate_flag"),
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
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ktext), it => it.Ktext.Contains(parm.Ktext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ltext), it => it.Ltext.Contains(parm.Ltext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Etype), it => it.Etype == parm.Etype);
            predicate = predicate.AndIF(parm.LockInd != null, it => it.LockInd == parm.LockInd);
            predicate = predicate.AndIF(parm.Tstate != null, it => it.Tstate == parm.Tstate);
            return predicate;
        }
    }
}