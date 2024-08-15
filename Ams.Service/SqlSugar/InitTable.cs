using Ams.Model.Accounting;
using Ams.Model.Logistics;
using SqlSugar.IOC;

namespace Ams.Service.SqlSugar
{
    /// <summary>
    /// 初始化表
    /// </summary>
    public class InitTable
    {
        /// <summary>
        /// 创建db、表
        /// </summary>
        public static void InitDb(bool init)
        {
            var db = DbScoped.SugarScope;
            //可在此处单独更新某个表的结构，无视配置
            //例如：db.CodeFirst.InitTables(typeof(EmailLog));

            if (!init) return;
            //建库：如果不存在创建数据库存在不会重复创建
            db.DbMaintenance.CreateDatabase();// 注意 ：Oracle和个别国产库需不支持该方法，需要手动建库
            db.CodeFirst.InitTables(typeof(GenTable));
            db.CodeFirst.InitTables(typeof(GenTableColumn));

            db.CodeFirst.InitTables(typeof(SysConfig));
            db.CodeFirst.InitTables(typeof(SysUser));
            db.CodeFirst.InitTables(typeof(SysRole));
            db.CodeFirst.InitTables(typeof(SysDept));
            db.CodeFirst.InitTables(typeof(SysPost));
            db.CodeFirst.InitTables(typeof(SysMenu));
            db.CodeFirst.InitTables(typeof(SysLocaleLang));
            db.CodeFirst.InitTables(typeof(SysRoleMenu));
            db.CodeFirst.InitTables(typeof(SysRoleDept));
            db.CodeFirst.InitTables(typeof(SysUserRole));
            db.CodeFirst.InitTables(typeof(SysUserPost));
            db.CodeFirst.InitTables(typeof(SysUserMsg));
            db.CodeFirst.InitTables(typeof(SysDictData));
            db.CodeFirst.InitTables(typeof(SysDictType));
            db.CodeFirst.InitTables(typeof(SysTable));
            db.CodeFirst.InitTables(typeof(SysTableFields));

            db.CodeFirst.InitTables(typeof(DiffLog));
            db.CodeFirst.InitTables(typeof(SmsLog));
            db.CodeFirst.InitTables(typeof(LoginLog));
            db.CodeFirst.InitTables(typeof(TasksQzLog));
            db.CodeFirst.InitTables(typeof(OperLog));

            db.CodeFirst.InitTables(typeof(FileStorage));
            db.CodeFirst.InitTables(typeof(NoticeStorage));
            db.CodeFirst.InitTables(typeof(EmailTpl));
            db.CodeFirst.InitTables(typeof(EmailItems));
            db.CodeFirst.InitTables(typeof(TasksQz));
            db.CodeFirst.InitTables(typeof(Article));
            db.CodeFirst.InitTables(typeof(ArticleCategory));
            db.CodeFirst.InitTables(typeof(ArticleBrowsingLog));
            db.CodeFirst.InitTables(typeof(ArticlePraise));
            db.CodeFirst.InitTables(typeof(ArticleComment));
            db.CodeFirst.InitTables(typeof(ArticleTopic));

            db.CodeFirst.InitTables(typeof(Banner));

            db.CodeFirst.InitTables(typeof(RoutineEhrEmployee));
            db.CodeFirst.InitTables(typeof(RoutineEhrPerformanceMa));
            db.CodeFirst.InitTables(typeof(RoutineEhrPerformanceSlv));
            db.CodeFirst.InitTables(typeof(RoutineEhrBenefits));
            db.CodeFirst.InitTables(typeof(RoutineEhrAttendance));
            db.CodeFirst.InitTables(typeof(RoutineEhrFunds));
            db.CodeFirst.InitTables(typeof(RoutineEhrPayroll));
            db.CodeFirst.InitTables(typeof(RoutineEhrRecruitment));
            db.CodeFirst.InitTables(typeof(RoutineEhrRewardPenalties));
            db.CodeFirst.InitTables(typeof(RoutineEhrSocialSecurity));
            db.CodeFirst.InitTables(typeof(RoutineEhrTrainingMa));
            db.CodeFirst.InitTables(typeof(RoutineEhrTrainingSlv));

            //机构管理
            db.CodeFirst.InitTables(typeof(InstTarget));
            db.CodeFirst.InitTables(typeof(InstFormula));
            db.CodeFirst.InitTables(typeof(InstInfo));

            //源数据
            db.CodeFirst.InitTables(typeof(PpSourceMaterial));
            db.CodeFirst.InitTables(typeof(PpSourceEcMa));
            db.CodeFirst.InitTables(typeof(PpSourceEcSlv));
            db.CodeFirst.InitTables(typeof(PpSourceOrder));
            db.CodeFirst.InitTables(typeof(PpSourceOrderSerial));
            db.CodeFirst.InitTables(typeof(PpSourceManhours));
            db.CodeFirst.InitTables(typeof(PpSourceModelRegion));

            //销售管理
            db.CodeFirst.InitTables(typeof(SdClient));
            db.CodeFirst.InitTables(typeof(SdCustomer));
            db.CodeFirst.InitTables(typeof(SdSellingInvoice));
            db.CodeFirst.InitTables(typeof(SdSellingPrice));

            //财务管理
            db.CodeFirst.InitTables(typeof(FicoAccountingCorp));
            db.CodeFirst.InitTables(typeof(FicoAccountingTitle));
            db.CodeFirst.InitTables(typeof(FicoWageRates));
            db.CodeFirst.InitTables(typeof(FicoExchangeRate));
            db.CodeFirst.InitTables(typeof(FicoProfitCenter));
            db.CodeFirst.InitTables(typeof(FicoFinancialPeriod));

            db.CodeFirst.InitTables(typeof(FicoBudgetActualCont));
            db.CodeFirst.InitTables(typeof(FicoCostingDeptConsuming));
            db.CodeFirst.InitTables(typeof(FicoCostingBom));
            db.CodeFirst.InitTables(typeof(FicoMonthlyAssets));
            db.CodeFirst.InitTables(typeof(FicoMonthlyInventory));

            db.CodeFirst.InitTables(typeof(FicoBudgetAccountingMa));
            db.CodeFirst.InitTables(typeof(FicoBudgetAccountingSlv));
            db.CodeFirst.InitTables(typeof(FicoBudgetAssetsMa));
            db.CodeFirst.InitTables(typeof(FicoBudgetAssetsSlv));
            db.CodeFirst.InitTables(typeof(FicoBudgetOvertimeMa));
            db.CodeFirst.InitTables(typeof(FicoBudgetOvertimeSlv));
            db.CodeFirst.InitTables(typeof(FicoBudgetStaffMa));
            db.CodeFirst.InitTables(typeof(FicoBudgetStaffSlv));
            db.CodeFirst.InitTables(typeof(FicoBudgetExpenseMa));
            db.CodeFirst.InitTables(typeof(FicoBudgetExpenseSlv));

            //物料管理
            db.CodeFirst.InitTables(typeof(MmMara));
            db.CodeFirst.InitTables(typeof(MmMarb));
            db.CodeFirst.InitTables(typeof(MmMarc));
            db.CodeFirst.InitTables(typeof(MmMbew));
            db.CodeFirst.InitTables(typeof(MmPoResidue));
            db.CodeFirst.InitTables(typeof(MmVendor));
            db.CodeFirst.InitTables(typeof(MmSupplier));

            //生产管理
            db.CodeFirst.InitTables(typeof(PpCauseType));
            db.CodeFirst.InitTables(typeof(PpLine));
            db.CodeFirst.InitTables(typeof(PpOrder));
            db.CodeFirst.InitTables(typeof(PpManhours));
            db.CodeFirst.InitTables(typeof(PpEcMaster));
            db.CodeFirst.InitTables(typeof(PpEcSlave));

            db.CodeFirst.InitTables(typeof(PpEcMasterTe));
            db.CodeFirst.InitTables(typeof(PpEcSlaveTe));
            db.CodeFirst.InitTables(typeof(PpEcMasterPmc));
            db.CodeFirst.InitTables(typeof(PpEcSlavePmc));
            db.CodeFirst.InitTables(typeof(PpEcMasterPur));
            db.CodeFirst.InitTables(typeof(PpEcSlavePur));
            db.CodeFirst.InitTables(typeof(PpEcMasterMm));
            db.CodeFirst.InitTables(typeof(PpEcSlaveMm));
            db.CodeFirst.InitTables(typeof(PpEcMasterIqc));
            db.CodeFirst.InitTables(typeof(PpEcSlaveIqc));
            db.CodeFirst.InitTables(typeof(PpEcMasterPcba));
            db.CodeFirst.InitTables(typeof(PpEcSlavePcba));
            db.CodeFirst.InitTables(typeof(PpEcMasterAssy));
            db.CodeFirst.InitTables(typeof(PpEcSlaveAssy));
            db.CodeFirst.InitTables(typeof(PpEcMasterFqc));
            db.CodeFirst.InitTables(typeof(PpEcSlaveFqc));
            db.CodeFirst.InitTables(typeof(PpEcMasterPe));
            db.CodeFirst.InitTables(typeof(PpEcSlavePe));

            db.CodeFirst.InitTables(typeof(PpOutputAssyMaster));
            db.CodeFirst.InitTables(typeof(PpOutputAssySlave));
            db.CodeFirst.InitTables(typeof(PpOutputPcbaMaster));
            db.CodeFirst.InitTables(typeof(PpOutputPcbaSlave));
            db.CodeFirst.InitTables(typeof(PpRepairAssyMa));
            db.CodeFirst.InitTables(typeof(PpRepairAssySlv));
            db.CodeFirst.InitTables(typeof(PpInspPcbaMa));
            db.CodeFirst.InitTables(typeof(PpInspPcbaSlv));
            db.CodeFirst.InitTables(typeof(PpRepairPcbaMa));
            db.CodeFirst.InitTables(typeof(PpRepairPcbaSlv));

            //品质管理
            db.CodeFirst.InitTables(typeof(QmCheckAql));
            db.CodeFirst.InitTables(typeof(QmIncoming));
            db.CodeFirst.InitTables(typeof(QmInspectingItem));
            db.CodeFirst.InitTables(typeof(QmOutgoing));
            db.CodeFirst.InitTables(typeof(QmComplaintsMaster));
            db.CodeFirst.InitTables(typeof(QmComplaintsSlave));
            db.CodeFirst.InitTables(typeof(QmSerial));
            db.CodeFirst.InitTables(typeof(QmImprovementReplyletter));
            db.CodeFirst.InitTables(typeof(QmUnqualifiedContactletter));
            db.CodeFirst.InitTables(typeof(QmCostRework));
            db.CodeFirst.InitTables(typeof(QmCostWaste));
            db.CodeFirst.InitTables(typeof(QmCostOperation));

            //db.CodeFirst.InitTables(typeof(UserOnlineLog));
        }

        public static void InitNewTb()
        {
            var db = DbScoped.SugarScope;
            var t1 = db.DbMaintenance.IsAnyTable(typeof(DurationLog).Name);
            if (!t1)
            {
                db.CodeFirst.InitTables(typeof(DurationLog));
            }
        }
    }
}