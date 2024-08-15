using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 主设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:35:09
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcMasterService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcMasterService : BaseService<PpEcMaster>, IPpEcMasterService
    {
        /// <summary>
        /// 查询主设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpEcSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<PpEcMaster, PpEcMasterDto>(parm);

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
            int count = Count(it => it.EcmSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        public PpEcMaster GetInfo(long EcmSfId)
        {
            var response = Queryable()
                .Includes(x => x.PpEcSlaveNav) //填充子对象
                .Where(x => x.EcmSfId == EcmSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加主设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcMaster AddPpEcMaster(PpEcMaster model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpEcSlaveNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改主设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcMaster(PpEcMaster model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpEcSlaveNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入主设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcMaster(List<PpEcMaster> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EcmIssueDate.IsEmpty(), "发行日期不能为空")
                .SplitError(x => x.Item.EcmNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EcmStated.IsEmpty(), "设变状态不能为空")
                .SplitError(x => x.Item.EcmTitle.IsEmpty(), "标题不能为空")
                .SplitError(x => x.Item.EcmContent.IsEmpty(), "内容不能为空")
                .SplitError(x => x.Item.EcmLeader.IsEmpty(), "担当不能为空")
                .SplitError(x => x.Item.EcmLossAmount.IsEmpty(), "损失金额不能为空")
                .SplitError(x => x.Item.EcmManageCategory.IsEmpty(), "管理区分不能为空")
                .SplitError(x => x.Item.EcmEnteredDept.IsEmpty(), "输入部门不能为空")
                .SplitError(x => x.Item.EcmEnteredDate.IsEmpty(), "输入日不能为空")
                .SplitError(x => x.Item.EcmSopStated.IsEmpty(), "SOP更新否不能为空")
                .SplitError(x => x.Item.EcmImplStated.IsEmpty(), "实施标记不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
        /// 导出主设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterDto> ExportList(PpEcMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcMasterDto()
                {
                    EcmStatedLabel = it.EcmStated.GetConfigValue<SysDictData>("sys_ec_status"),
                    EcmLeaderLabel = it.EcmLeader.GetConfigValue<SysDictData>("sql_ec_group"),
                    EcmManageCategoryLabel = it.EcmManageCategory.GetConfigValue<SysDictData>("sys_ec_mgtype"),
                    EcmEnteredDeptLabel = it.EcmEnteredDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    EcmSopStatedLabel = it.EcmSopStated.GetConfigValue<SysDictData>("sys_flag_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //EcsPurTypeLabel = it.EcsPurType.GetConfigValue<SysDictData>("sys_pur_type"),
                    //EcsPurGroupLabel = it.EcsPurGroup.GetConfigValue<SysDictData>("sys_pur_group"),
                    //EcsSlocLabel = it.EcsSloc.GetConfigValue<SysDictData>("sys_sloc_list"),
                    //EcsPlntStatedLabel = it.EcsPlntStated.GetConfigValue<SysDictData>("sys_eol_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcMaster> QueryExp(PpEcMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcMaster>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEcmIssueDate == null, it => it.EcmIssueDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEcmIssueDate == null, it => it.EcmIssueDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEcmIssueDate != null, it => it.EcmIssueDate >= parm.BeginEcmIssueDate);
            predicate = predicate.AndIF(parm.EndEcmIssueDate != null, it => it.EcmIssueDate <= parm.EndEcmIssueDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmNo), it => it.EcmNo.Contains(parm.EcmNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmTitle), it => it.EcmTitle.Contains(parm.EcmTitle));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmContent), it => it.EcmContent.Contains(parm.EcmContent));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmLeader), it => it.EcmLeader == parm.EcmLeader);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmEnteredDept), it => it.EcmEnteredDept == parm.EcmEnteredDept);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEcmEnteredDate == null, it => it.EcmEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEcmEnteredDate == null, it => it.EcmEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEcmEnteredDate != null, it => it.EcmEnteredDate >= parm.BeginEcmEnteredDate);
            predicate = predicate.AndIF(parm.EndEcmEnteredDate != null, it => it.EcmEnteredDate <= parm.EndEcmEnteredDate);
            return predicate;
        }
    }
}