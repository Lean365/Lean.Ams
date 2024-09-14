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

            //db.CodeFirst.InitTables(typeof(Article));
            //db.CodeFirst.InitTables(typeof(ArticleCatalog));
            //db.CodeFirst.InitTables(typeof(ArticleBrowsingLog));
            //db.CodeFirst.InitTables(typeof(ArticlePraise));
            //db.CodeFirst.InitTables(typeof(ArticleComment));
            //db.CodeFirst.InitTables(typeof(ArticleTopic));
            //db.CodeFirst.InitTables(typeof(EmailItems));
            //db.CodeFirst.InitTables(typeof(EmailTpl));
            //db.CodeFirst.InitTables(typeof(FileStorage));
            //db.CodeFirst.InitTables(typeof(NoticeStorage));
            //db.CodeFirst.InitTables(typeof(RoutineEhrAttendance));
            //db.CodeFirst.InitTables(typeof(RoutineEhrEmployee));
            //db.CodeFirst.InitTables(typeof(RoutineEhrFunds));
            //db.CodeFirst.InitTables(typeof(RoutineEhrPayroll));
            //db.CodeFirst.InitTables(typeof(RoutineEhrPerformanceMa));
            //db.CodeFirst.InitTables(typeof(RoutineEhrPerformanceSlv));
            //db.CodeFirst.InitTables(typeof(RoutineEhrRecruitment));
            //db.CodeFirst.InitTables(typeof(RoutineEhrRewardPenalties));
            //db.CodeFirst.InitTables(typeof(RoutineEhrSocialSecurity));
            //db.CodeFirst.InitTables(typeof(RoutineEhrTrainingMa));
            //db.CodeFirst.InitTables(typeof(RoutineEhrTrainingSlv));

            //db.CodeFirst.InitTables(typeof(Banner));

            //db.CodeFirst.InitTables(typeof(SysConfig));
            //db.CodeFirst.InitTables(typeof(SysDept));
            //db.CodeFirst.InitTables(typeof(SysDictData));
            //db.CodeFirst.InitTables(typeof(SysDictType));
            //db.CodeFirst.InitTables(typeof(SysLocaleLang));
            //db.CodeFirst.InitTables(typeof(SysMenu));
            //db.CodeFirst.InitTables(typeof(SysRole));
            //db.CodeFirst.InitTables(typeof(SysRoleDept));
            //db.CodeFirst.InitTables(typeof(SysRoleMenu));
            //db.CodeFirst.InitTables(typeof(SysUser));
            //db.CodeFirst.InitTables(typeof(SysTable));
            //db.CodeFirst.InitTables(typeof(SysTableFields));
            //db.CodeFirst.InitTables(typeof(SysUserMsg));
            //db.CodeFirst.InitTables(typeof(SysUserRole));
            //db.CodeFirst.InitTables(typeof(SysUserPost));
            //db.CodeFirst.InitTables(typeof(SysPost));

            //db.CodeFirst.InitTables(typeof(DiffLog));
            //db.CodeFirst.InitTables(typeof(LoginLog));
            //db.CodeFirst.InitTables(typeof(OperLog));
            //db.CodeFirst.InitTables(typeof(SmsLog));
            //db.CodeFirst.InitTables(typeof(TasksQz));
            //db.CodeFirst.InitTables(typeof(TasksQzLog));

            //db.CodeFirst.InitTables(typeof(GenTable));
            //db.CodeFirst.InitTables(typeof(GenTableColumn));

            //db.CodeFirst.InitTables(typeof(InstCorp));
            //db.CodeFirst.InitTables(typeof(InstFormula));
            //db.CodeFirst.InitTables(typeof(InstPlant));
            //db.CodeFirst.InitTables(typeof(InstTarget));

            //db.CodeFirst.InitTables(typeof(FicoAccountingCorp));
            //db.CodeFirst.InitTables(typeof(FicoAccountingTitle));
            //db.CodeFirst.InitTables(typeof(FicoBank));
            //db.CodeFirst.InitTables(typeof(FicoBudgetAccounting));
            //db.CodeFirst.InitTables(typeof(FicoBudgetActualCont));
            //db.CodeFirst.InitTables(typeof(FicoBudgetAssets));
            //db.CodeFirst.InitTables(typeof(FicoBudgetExpense));
            //db.CodeFirst.InitTables(typeof(FicoBudgetOvertime));
            //db.CodeFirst.InitTables(typeof(FicoBudgetStaff));
            //db.CodeFirst.InitTables(typeof(FicoCostingBom));
            //db.CodeFirst.InitTables(typeof(FicoCostingDeptConsuming));
            //db.CodeFirst.InitTables(typeof(FicoExchangeRate));
            //db.CodeFirst.InitTables(typeof(FicoFinancialPeriod));
            //db.CodeFirst.InitTables(typeof(FicoMonthlyAssets));
            //db.CodeFirst.InitTables(typeof(FicoMonthlyInventory));
            //db.CodeFirst.InitTables(typeof(FicoProfitCenter));
            //db.CodeFirst.InitTables(typeof(FicoWageRates));

            //db.CodeFirst.InitTables(typeof(MmMara));
            //db.CodeFirst.InitTables(typeof(MmMarb));
            //db.CodeFirst.InitTables(typeof(MmMarc));
            //db.CodeFirst.InitTables(typeof(MmMbew));
            //db.CodeFirst.InitTables(typeof(MmPoResidue));
            //db.CodeFirst.InitTables(typeof(MmSupplier));
            //db.CodeFirst.InitTables(typeof(MmVendor));

            //db.CodeFirst.InitTables(typeof(PpEcLiaison));
            //db.CodeFirst.InitTables(typeof(PpEcMaster));
            //db.CodeFirst.InitTables(typeof(PpEcSlave));

            //db.CodeFirst.InitTables(typeof(PpInspPcbaMa));
            //db.CodeFirst.InitTables(typeof(PpInspPcbaSlv));
            //db.CodeFirst.InitTables(typeof(PpMasterCause));
            //db.CodeFirst.InitTables(typeof(PpMasterManhours));
            //db.CodeFirst.InitTables(typeof(PpMasterProdorder));
            //db.CodeFirst.InitTables(typeof(PpMasterWorkshop));
            //db.CodeFirst.InitTables(typeof(PpOutputAssyMa));
            //db.CodeFirst.InitTables(typeof(PpOutputAssySlv));
            //db.CodeFirst.InitTables(typeof(PpOutputPcbaMa));
            //db.CodeFirst.InitTables(typeof(PpOutputPcbaSlv));
            //db.CodeFirst.InitTables(typeof(PpRepairAssyMa));
            //db.CodeFirst.InitTables(typeof(PpRepairAssySlv));
            //db.CodeFirst.InitTables(typeof(PpRepairPcbaMa));
            //db.CodeFirst.InitTables(typeof(PpRepairPcbaSlv));
            //db.CodeFirst.InitTables(typeof(PpSourceEcMa));
            //db.CodeFirst.InitTables(typeof(PpSourceEcSlv));
            //db.CodeFirst.InitTables(typeof(PpSourceManhours));
            //db.CodeFirst.InitTables(typeof(PpSourceMaterial));
            //db.CodeFirst.InitTables(typeof(PpSourceModelRegion));
            //db.CodeFirst.InitTables(typeof(PpSourceOrder));
            //db.CodeFirst.InitTables(typeof(PpSourceOrderSerial));

            //db.CodeFirst.InitTables(typeof(QmComplaintsQc));
            //db.CodeFirst.InitTables(typeof(QmComplaintsPp));
            //db.CodeFirst.InitTables(typeof(QmCostOperation));
            //db.CodeFirst.InitTables(typeof(QmCostRework));
            //db.CodeFirst.InitTables(typeof(QmCostWaste));
            //db.CodeFirst.InitTables(typeof(QmIncoming));
            //db.CodeFirst.InitTables(typeof(QmInspAql));
            //db.CodeFirst.InitTables(typeof(QmInspItem));
            //db.CodeFirst.InitTables(typeof(QmIpvReply));
            //db.CodeFirst.InitTables(typeof(QmOutgoing));
            //db.CodeFirst.InitTables(typeof(QmSerial));
            //db.CodeFirst.InitTables(typeof(QmUnqLetter));

            //db.CodeFirst.InitTables(typeof(SdClient));
            //db.CodeFirst.InitTables(typeof(SdCustomer));
            //db.CodeFirst.InitTables(typeof(SdSellingInvoice));
            //db.CodeFirst.InitTables(typeof(SdSellingPrice));

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