
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 利润中心
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/5 11:21:00
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
    /// @Date: 2024/7/5 11:21:00
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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

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



        [ExcelColumn(Name = "公司")]
        public string FpCorpLabel { get; set; }
        [ExcelColumn(Name = "类别")]
        public string FpTypeLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
    /// <summary>
    /// 利润中心
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/5 11:21:00
    /// </summary>
    public class FicoPrctrImportTpl
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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

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
        [ExcelColumn(Name = "公司")]
        public string FpCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string FpTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}