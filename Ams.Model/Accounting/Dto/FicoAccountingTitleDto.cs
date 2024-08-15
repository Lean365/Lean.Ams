
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 会计科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 12:02:48
    /// </summary>
    public class FicoAccountingTitleQueryDto : PagerInfo 
    {
        public string Bukrs { get; set; }
        public string Waers { get; set; }
        public string Saknr { get; set; }
        public string Xbilk { get; set; }
        public string Gvtyp { get; set; }
        public string Mitkz { get; set; }
        public string Stext { get; set; }
        public string Ltext { get; set; }
        public int? Xspea { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 12:02:48
    /// </summary>
    public class FicoAccountingTitleDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FatSfId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Bukrs { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Waers { get; set; }

        [ExcelColumn(Name = "翻译Key")]
        [ExcelColumnName("翻译Key")]
        public string Spras { get; set; }

        [Required(ErrorMessage = "科目编号不能为空")]
        [ExcelColumn(Name = "科目编号")]
        [ExcelColumnName("科目编号")]
        public string Saknr { get; set; }

        [ExcelColumn(Name = "科目表")]
        [ExcelColumnName("科目表")]
        public string Ktopl { get; set; }

        [ExcelColumn(Name = "BS类别")]
        [ExcelColumnName("BS类别")]
        public string Xbilk { get; set; }

        [ExcelColumn(Name = "PL类别")]
        [ExcelColumnName("PL类别")]
        public string Gvtyp { get; set; }

        [ExcelColumn(Name = "统驭类别")]
        [ExcelColumnName("统驭类别")]
        public string Mitkz { get; set; }

        [ExcelColumn(Name = "短文本")]
        [ExcelColumnName("短文本")]
        public string Stext { get; set; }

        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string Atext { get; set; }

        [ExcelColumn(Name = "科目组")]
        [ExcelColumnName("科目组")]
        public string Ktoks { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        [ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int Xspea { get; set; }

        [ExcelColumn(Name = "预留A")]
        [ExcelColumnName("预留A")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B")]
        [ExcelColumnName("预留B")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C")]
        [ExcelColumnName("预留C")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1")]
        [ExcelColumnName("预留1")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2")]
        [ExcelColumnName("预留2")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3 ")]
        [ExcelColumnName("预留3 ")]
        public decimal REF06 { get; set; }

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
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明 ")]
        [ExcelColumnName("备注说明 ")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "公司代码")]
        public string BukrsLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string WaersLabel { get; set; }
        [ExcelColumn(Name = "BS类别")]
        public string XbilkLabel { get; set; }
        [ExcelColumn(Name = "PL类别")]
        public string GvtypLabel { get; set; }
        [ExcelColumn(Name = "统驭类别")]
        public string MitkzLabel { get; set; }
        [ExcelColumn(Name = "冻结")]
        public string XspeaLabel { get; set; }
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 12:02:48
    /// </summary>
    public class FicoAccountingTitleImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FatSfId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Bukrs { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Waers { get; set; }

        [ExcelColumn(Name = "翻译Key")]
        [ExcelColumnName("翻译Key")]
        public string Spras { get; set; }

        [Required(ErrorMessage = "科目编号不能为空")]
        [ExcelColumn(Name = "科目编号")]
        [ExcelColumnName("科目编号")]
        public string Saknr { get; set; }

        [ExcelColumn(Name = "科目表")]
        [ExcelColumnName("科目表")]
        public string Ktopl { get; set; }

        [ExcelColumn(Name = "BS类别")]
        [ExcelColumnName("BS类别")]
        public string Xbilk { get; set; }

        [ExcelColumn(Name = "PL类别")]
        [ExcelColumnName("PL类别")]
        public string Gvtyp { get; set; }

        [ExcelColumn(Name = "统驭类别")]
        [ExcelColumnName("统驭类别")]
        public string Mitkz { get; set; }

        [ExcelColumn(Name = "短文本")]
        [ExcelColumnName("短文本")]
        public string Stext { get; set; }

        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string Atext { get; set; }

        [ExcelColumn(Name = "科目组")]
        [ExcelColumnName("科目组")]
        public string Ktoks { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        [ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int Xspea { get; set; }

        [ExcelColumn(Name = "预留A")]
        [ExcelColumnName("预留A")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B")]
        [ExcelColumnName("预留B")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C")]
        [ExcelColumnName("预留C")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1")]
        [ExcelColumnName("预留1")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2")]
        [ExcelColumnName("预留2")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3 ")]
        [ExcelColumnName("预留3 ")]
        public decimal REF06 { get; set; }

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
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明 ")]
        [ExcelColumnName("备注说明 ")]
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
        [ExcelColumn(Name = "公司代码")]
        public string BukrsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string WaersLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "BS类别")]
        public string XbilkLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "PL类别")]
        public string GvtypLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭类别")]
        public string MitkzLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "冻结")]
        public string XspeaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

}