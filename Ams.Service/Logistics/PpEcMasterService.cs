using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 主设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:43
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
            int count = Count(it => it.EmSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EmSFID"></param>
        /// <returns></returns>
        public PpEcMaster GetInfo(long EmSFID)
        {
            var response = Queryable()
                .Includes(x => x.PpEcSlaveNav) //填充子对象
                .Where(x => x.EmSFID == EmSFID)
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
                .SplitError(x => x.Item.EmSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.EmEcIssueDate.IsEmpty(), "发行日不能为空")
                .SplitError(x => x.Item.EmEcNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EmEcStatus.IsEmpty(), "状态不能为空")
                .SplitError(x => x.Item.EmEcTitle.IsEmpty(), "标题不能为空")
                .SplitError(x => x.Item.EmEcContent.IsEmpty(), "内容不能为空")
                .SplitError(x => x.Item.EmEcAssigned.IsEmpty(), "担当不能为空")
                .SplitError(x => x.Item.EmEcLossAmount.IsEmpty(), "损失金额不能为空")
                .SplitError(x => x.Item.EmEcManageCategory.IsEmpty(), "管理区分不能为空")
                .SplitError(x => x.Item.EmEcImpDept.IsEmpty(), "输入部门不能为空")
                .SplitError(x => x.Item.EmEcEntryDate.IsEmpty(), "输入日不能为空")
                .SplitError(x => x.Item.EsSopStae.IsEmpty(), "SOP不能为空")
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
                    EmEcStatusLabel = it.EmEcStatus.GetConfigValue<SysDictData>("sys_ec_status"),
                    EmEcAssignedLabel = it.EmEcAssigned.GetConfigValue<SysDictData>("sql_ec_group"),
                    EmEcManageCategoryLabel = it.EmEcManageCategory.GetConfigValue<SysDictData>("sys_ec_mgtype"),
                    EsSopStaeLabel = it.EsSopStae.GetConfigValue<SysDictData>("sys_sop_yn"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //EsPurTypeLabel = it.EsPurType.GetConfigValue<SysDictData>("sys_pur_type"),
                    //EsInsmkLabel = it.EsInsmk.GetConfigValue<SysDictData>("sys_normal_whether"),
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
            //predicate = predicate.AndIF(parm.BeginEmEcIssueDate == null, it => it.EmEcIssueDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEmEcIssueDate == null, it => it.EmEcIssueDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEmEcIssueDate != null, it => it.EmEcIssueDate >= parm.BeginEmEcIssueDate);
            predicate = predicate.AndIF(parm.EndEmEcIssueDate != null, it => it.EmEcIssueDate <= parm.EndEmEcIssueDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcNo), it => it.EmEcNo.Contains(parm.EmEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcTitle), it => it.EmEcTitle.Contains(parm.EmEcTitle));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcAssigned), it => it.EmEcAssigned == parm.EmEcAssigned);
            predicate = predicate.AndIF(parm.EmEcManageCategory != null, it => it.EmEcManageCategory == parm.EmEcManageCategory);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcLiaisonNo), it => it.EmEcLiaisonNo.Contains(parm.EmEcLiaisonNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcEppLiaisonNo), it => it.EmEcEppLiaisonNo.Contains(parm.EmEcEppLiaisonNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcFppLiaisonNo), it => it.EmEcFppLiaisonNo.Contains(parm.EmEcFppLiaisonNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcExternalNo), it => it.EmEcExternalNo.Contains(parm.EmEcExternalNo));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEmEcEntryDate == null, it => it.EmEcEntryDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEmEcEntryDate == null, it => it.EmEcEntryDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEmEcEntryDate != null, it => it.EmEcEntryDate >= parm.BeginEmEcEntryDate);
            predicate = predicate.AndIF(parm.EndEmEcEntryDate != null, it => it.EmEcEntryDate <= parm.EndEmEcEntryDate);
            predicate = predicate.AndIF(parm.EsSopStae != null, it => it.EsSopStae == parm.EsSopStae);
            return predicate;
        }
    }
}