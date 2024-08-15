namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 主客诉管理
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:33:20
    /// </summary>
    public class QmComplaintsMasterQueryDto : PagerInfo
    {
        public string QmcmDocNo { get; set; }
        public string QmcmIssuesNo { get; set; }
        public string QmcmCustomer { get; set; }
        public string QmcmModel { get; set; }
        public string QmcmItem { get; set; }
        public string QmcmRegion { get; set; }
        public DateTime? BeginQmcmReceivingDate { get; set; }
        public DateTime? EndQmcmReceivingDate { get; set; }
        public string QmcmRootcauseanalysis { get; set; }
        public string QmcmAdmitDept { get; set; }
        public DateTime? BeginQmcmAdmitDate { get; set; }
        public DateTime? EndQmcmAdmitDate { get; set; }
    }

    /// <summary>
    /// 主客诉管理
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:33:20
    /// </summary>
    public class QmComplaintsMasterDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmcmSfId { get; set; }

        [Required(ErrorMessage = "客诉No.不能为空")]
        [ExcelColumn(Name = "客诉No.")]
        [ExcelColumnName("客诉No.")]
        public string QmcmDocNo { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        [ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]
        public string QmcmIssuesNo { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        [ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string QmcmCustomer { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QmcmModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QmcmItem { get; set; }

        [Required(ErrorMessage = "仕向不能为空")]
        [ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string QmcmRegion { get; set; }

        [ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string QmcmOrder { get; set; }

        [Required(ErrorMessage = "接收日期不能为空")]
        [ExcelColumn(Name = "接收日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("接收日期")]
        public DateTime? QmcmReceivingDate { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int QmcmFaultQty { get; set; }

        [ExcelColumn(Name = "投诉事项")]
        [ExcelColumnName("投诉事项")]
        public string QmcmIssues { get; set; }

        [Required(ErrorMessage = "序列号不能为空")]
        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string QmcmSerialno { get; set; }

        [ExcelColumn(Name = "参考文件")]
        [ExcelColumnName("参考文件")]
        public string QmcmReferenceDocs { get; set; }

        [Required(ErrorMessage = "症状不能为空")]
        [ExcelColumn(Name = "症状")]
        [ExcelColumnName("症状")]
        public string QmcmFaultDescription { get; set; }

        [Required(ErrorMessage = "分析不能为空")]
        [ExcelColumn(Name = "分析")]
        [ExcelColumnName("分析")]
        public string QmcmRootcauseanalysis { get; set; }

        [Required(ErrorMessage = "承认部门不能为空")]
        [ExcelColumn(Name = "承认部门")]
        [ExcelColumnName("承认部门")]
        public string QmcmAdmitDept { get; set; }

        [Required(ErrorMessage = "承认日期不能为空")]
        [ExcelColumn(Name = "承认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("承认日期")]
        public DateTime? QmcmAdmitDate { get; set; }

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

        [ExcelColumn(Name = "客户")]
        public string QmcmCustomerLabel { get; set; }

        [ExcelColumn(Name = "仕向")]
        public string QmcmRegionLabel { get; set; }

        [ExcelColumn(Name = "承认部门")]
        public string QmcmAdmitDeptLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 主客诉管理
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:33:20
    /// </summary>
    public class QmComplaintsMasterImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmcmSfId { get; set; }

        [Required(ErrorMessage = "客诉No.不能为空")]
        [ExcelColumn(Name = "客诉No.")]
        [ExcelColumnName("客诉No.")]
        public string QmcmDocNo { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        [ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]
        public string QmcmIssuesNo { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        [ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string QmcmCustomer { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QmcmModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QmcmItem { get; set; }

        [Required(ErrorMessage = "仕向不能为空")]
        [ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string QmcmRegion { get; set; }

        [ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string QmcmOrder { get; set; }

        [Required(ErrorMessage = "接收日期不能为空")]
        [ExcelColumn(Name = "接收日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("接收日期")]
        public DateTime? QmcmReceivingDate { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int QmcmFaultQty { get; set; }

        [ExcelColumn(Name = "投诉事项")]
        [ExcelColumnName("投诉事项")]
        public string QmcmIssues { get; set; }

        [Required(ErrorMessage = "序列号不能为空")]
        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string QmcmSerialno { get; set; }

        [ExcelColumn(Name = "参考文件")]
        [ExcelColumnName("参考文件")]
        public string QmcmReferenceDocs { get; set; }

        [Required(ErrorMessage = "症状不能为空")]
        [ExcelColumn(Name = "症状")]
        [ExcelColumnName("症状")]
        public string QmcmFaultDescription { get; set; }

        [Required(ErrorMessage = "分析不能为空")]
        [ExcelColumn(Name = "分析")]
        [ExcelColumnName("分析")]
        public string QmcmRootcauseanalysis { get; set; }

        [Required(ErrorMessage = "承认部门不能为空")]
        [ExcelColumn(Name = "承认部门")]
        [ExcelColumnName("承认部门")]
        public string QmcmAdmitDept { get; set; }

        [Required(ErrorMessage = "承认日期不能为空")]
        [ExcelColumn(Name = "承认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("承认日期")]
        public DateTime? QmcmAdmitDate { get; set; }

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
        [ExcelColumn(Name = "客户")]
        public string QmcmCustomerLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "仕向")]
        public string QmcmRegionLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "承认部门")]
        public string QmcmAdmitDeptLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}