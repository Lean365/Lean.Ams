using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 受检
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:15
    /// </summary>
    public class PpEcMasterIqcQueryDto : PagerInfo 
    {
        public DateTime? BeginEcmIssueDate { get; set; }
        public DateTime? EndEcmIssueDate { get; set; }
        public string EcmNo { get; set; }
        public string EcmTitle { get; set; }
        public string EcmContent { get; set; }
        public string EcmLeader { get; set; }
        public int? EcmManageCategory { get; set; }
        public DateTime? BeginEcmEnteredDate { get; set; }
        public DateTime? EndEcmEnteredDate { get; set; }
        public int? EcmSopStated { get; set; }
        public int? EcmImplStated { get; set; }
    }

    /// <summary>
    /// 受检
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:15
    /// </summary>
    public class PpEcMasterIqcDto
    {
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        public long? EcmSfId { get; set; }

        [ExcelColumn(Name = "发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日期")]
        public DateTime? EcmIssueDate { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string EcmNo { get; set; }

        [ExcelColumn(Name = "关联文件")]
        [ExcelColumnName("关联文件")]
        public string EcmFileUrl { get; set; }

        [ExcelColumn(Name = "设变状态")]
        [ExcelColumnName("设变状态")]
        public int? EcmStated { get; set; }

        [ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string EcmTitle { get; set; }

        [ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string EcmContent { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string EcmLeader { get; set; }

        [ExcelColumn(Name = "损失金额")]
        [ExcelColumnName("损失金额")]
        public decimal EcmLossAmount { get; set; }

        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int? EcmManageCategory { get; set; }

        [ExcelColumn(Name = "联络No.")]
        [ExcelColumnName("联络No.")]
        public string EcmLiaisonNo { get; set; }

        [ExcelColumn(Name = "联络文件")]
        [ExcelColumnName("联络文件")]
        public string EcmLiaisonFileUrl { get; set; }

        [ExcelColumn(Name = "EppNo.")]
        [ExcelColumnName("EppNo.")]
        public string EcmEppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Epp文件")]
        [ExcelColumnName("Epp文件")]
        public string EcmEppLiaisonFileUrl { get; set; }

        [ExcelColumn(Name = "FppNo.")]
        [ExcelColumnName("FppNo.")]
        public string EcmFppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Fpp文件")]
        [ExcelColumnName("Fpp文件")]
        public string EcmFppLiaisonFileUrl { get; set; }

        [ExcelColumn(Name = "外部No.")]
        [ExcelColumnName("外部No.")]
        public string EcmExternalNo { get; set; }

        [ExcelColumn(Name = "外部文件")]
        [ExcelColumnName("外部文件")]
        public string EcmExternalFileUrl { get; set; }

        [ExcelColumn(Name = "输入部门")]
        [ExcelColumnName("输入部门")]
        public string EcmEnteredDept { get; set; }

        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]
        public DateTime? EcmEnteredDate { get; set; }

        [ExcelColumn(Name = "SOP更新否")]
        [ExcelColumnName("SOP更新否")]
        public int? EcmSopStated { get; set; }

        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int? EcmImplStated { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpEcSlaveIqcDto> PpEcSlaveIqcNav { get; set; }
        [ExcelColumn(Name = "担当")]
        public string EcmLeaderLabel { get; set; }
        [ExcelColumn(Name = "管理区分")]
        public string EcmManageCategoryLabel { get; set; }
        [ExcelColumn(Name = "SOP更新否")]
        public string EcmSopStatedLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
        [ExcelColumn(Name = "采购类型")]
        public string IqcPurTypeLabel { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string IqcPurGroupLabel { get; set; }
    }

    /// <summary>
    /// 受检
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:15
    /// </summary>
    public class PpEcMasterIqcImportTpl
    {
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        public long? EcmSfId { get; set; }

        [ExcelColumn(Name = "发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日期")]
        public DateTime? EcmIssueDate { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string EcmNo { get; set; }

        [ExcelColumn(Name = "关联文件")]
        [ExcelColumnName("关联文件")]
        public string EcmFileUrl { get; set; }

        [ExcelColumn(Name = "设变状态")]
        [ExcelColumnName("设变状态")]
        public int? EcmStated { get; set; }

        [ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string EcmTitle { get; set; }

        [ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string EcmContent { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string EcmLeader { get; set; }

        [ExcelColumn(Name = "损失金额")]
        [ExcelColumnName("损失金额")]
        public decimal EcmLossAmount { get; set; }

        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int? EcmManageCategory { get; set; }

        [ExcelColumn(Name = "联络No.")]
        [ExcelColumnName("联络No.")]
        public string EcmLiaisonNo { get; set; }

        [ExcelColumn(Name = "联络文件")]
        [ExcelColumnName("联络文件")]
        public string EcmLiaisonFileUrl { get; set; }

        [ExcelColumn(Name = "EppNo.")]
        [ExcelColumnName("EppNo.")]
        public string EcmEppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Epp文件")]
        [ExcelColumnName("Epp文件")]
        public string EcmEppLiaisonFileUrl { get; set; }

        [ExcelColumn(Name = "FppNo.")]
        [ExcelColumnName("FppNo.")]
        public string EcmFppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Fpp文件")]
        [ExcelColumnName("Fpp文件")]
        public string EcmFppLiaisonFileUrl { get; set; }

        [ExcelColumn(Name = "外部No.")]
        [ExcelColumnName("外部No.")]
        public string EcmExternalNo { get; set; }

        [ExcelColumn(Name = "外部文件")]
        [ExcelColumnName("外部文件")]
        public string EcmExternalFileUrl { get; set; }

        [ExcelColumn(Name = "输入部门")]
        [ExcelColumnName("输入部门")]
        public string EcmEnteredDept { get; set; }

        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]
        public DateTime? EcmEnteredDate { get; set; }

        [ExcelColumn(Name = "SOP更新否")]
        [ExcelColumnName("SOP更新否")]
        public int? EcmSopStated { get; set; }

        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int? EcmImplStated { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpEcSlaveIqcDto> PpEcSlaveIqcNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "担当")]
        public string EcmLeaderLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "管理区分")]
        public string EcmManageCategoryLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "SOP更新否")]
        public string EcmSopStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购类型")]
        public string IqcPurTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string IqcPurGroupLabel { get; set; }
    }

}