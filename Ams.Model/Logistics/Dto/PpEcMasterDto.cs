namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 主设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:43
    /// </summary>
    public class PpEcMasterQueryDto : PagerInfo
    {
        public DateTime? BeginEmEcIssueDate { get; set; }
        public DateTime? EndEmEcIssueDate { get; set; }
        public string EmEcNo { get; set; }
        public string EmEcTitle { get; set; }
        public string EmEcAssigned { get; set; }
        public int? EmEcManageCategory { get; set; }
        public string EmEcLiaisonNo { get; set; }
        public string EmEcEppLiaisonNo { get; set; }
        public string EmEcFppLiaisonNo { get; set; }
        public string EmEcExternalNo { get; set; }
        public DateTime? BeginEmEcEntryDate { get; set; }
        public DateTime? EndEmEcEntryDate { get; set; }
        public int? EsSopStae { get; set; }
    }

    /// <summary>
    /// 主设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:43
    /// </summary>
    public class PpEcMasterDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EmSFID { get; set; }

        [Required(ErrorMessage = "发行日不能为空")]
        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日")]
        public DateTime? EmEcIssueDate { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string EmEcNo { get; set; }

        [ExcelColumn(Name = "关联文件")]
        [ExcelColumnName("关联文件")]
        public string EmEcDoc { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string EmEcStatus { get; set; }

        [Required(ErrorMessage = "标题不能为空")]
        [ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string EmEcTitle { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        [ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string EmEcContent { get; set; }

        [Required(ErrorMessage = "担当不能为空")]
        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string EmEcAssigned { get; set; }

        [Required(ErrorMessage = "损失金额不能为空")]
        [ExcelColumn(Name = "损失金额")]
        [ExcelColumnName("损失金额")]
        public decimal EmEcLossAmount { get; set; }

        [Required(ErrorMessage = "管理区分不能为空")]
        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int EmEcManageCategory { get; set; }

        [ExcelColumn(Name = "联络No.")]
        [ExcelColumnName("联络No.")]
        public string EmEcLiaisonNo { get; set; }

        [ExcelColumn(Name = "联络文件")]
        [ExcelColumnName("联络文件")]
        public string EmEcLiaisonDoc { get; set; }

        [ExcelColumn(Name = "EppNo.")]
        [ExcelColumnName("EppNo.")]
        public string EmEcEppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Epp文件")]
        [ExcelColumnName("Epp文件")]
        public string EmEcEppLiaisonDoc { get; set; }

        [ExcelColumn(Name = "FppNo.")]
        [ExcelColumnName("FppNo.")]
        public string EmEcFppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Fpp文件")]
        [ExcelColumnName("Fpp文件")]
        public string EmEcFppLiaisonDoc { get; set; }

        [ExcelColumn(Name = "外部No.")]
        [ExcelColumnName("外部No.")]
        public string EmEcExternalNo { get; set; }

        [ExcelColumn(Name = "外部文件")]
        [ExcelColumnName("外部文件")]
        public string EmEcExternalDoc { get; set; }

        [Required(ErrorMessage = "输入部门不能为空")]
        [ExcelColumn(Name = "输入部门")]
        [ExcelColumnName("输入部门")]
        public string EmEcImpDept { get; set; }

        [Required(ErrorMessage = "输入日不能为空")]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]
        public DateTime? EmEcEntryDate { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int EsSopStae { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        public List<PpEcSlaveDto> PpEcSlaveNav { get; set; }

        [ExcelColumn(Name = "状态")]
        public string EmEcStatusLabel { get; set; }

        [ExcelColumn(Name = "担当")]
        public string EmEcAssignedLabel { get; set; }

        [ExcelColumn(Name = "管理区分")]
        public string EmEcManageCategoryLabel { get; set; }

        [ExcelColumn(Name = "SOP")]
        public string EsSopStaeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }

        [ExcelColumn(Name = "采购类型")]
        public string EsPurTypeLabel { get; set; }

        [ExcelColumn(Name = "检验否")]
        public string EsInsmkLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string SlaIsDeletedLabel { get; set; }
    }
}