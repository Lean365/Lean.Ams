namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 利润中心
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:49
    /// </summary>
    public class FicoPrctrQueryDto : PagerInfo
    {
        public string FpCorp { get; set; }
        public string FpCode { get; set; }
        public string FpName { get; set; }
        public string FpType { get; set; }
        public DateTime? BeginFpActDate { get; set; }
        public DateTime? EndFpActDate { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:49
    /// </summary>
    public class FicoPrctrDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FpCorp { get; set; }

        [Required(ErrorMessage = "代码不能为空")]
        [ExcelColumn(Name = "代码")]
        [ExcelColumnName("代码")]
        public string FpCode { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FpName { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FpType { get; set; }

        [Required(ErrorMessage = "有效从不能为空")]
        [ExcelColumn(Name = "有效从", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效从")]
        public DateTime? FpActDate { get; set; }

        [Required(ErrorMessage = "有效到不能为空")]
        [ExcelColumn(Name = "有效到", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效到")]
        public DateTime? FpExpDate { get; set; }

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

        [ExcelColumn(Name = "公司")]
        public string FpCorpLabel { get; set; }

        [ExcelColumn(Name = "类别")]
        public string FpTypeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}