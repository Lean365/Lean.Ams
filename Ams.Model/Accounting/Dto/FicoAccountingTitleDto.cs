
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 会计科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:07:29
    /// </summary>
    public class FicoAccountingTitleQueryDto : PagerInfo 
    {
        public string Bukrs { get; set; }
        public string Saknr { get; set; }
        public string Satext { get; set; }
        public string Ltext { get; set; }
        public string Gvtyp { get; set; }
        public int? Xspea { get; set; }
        public string Mitkz { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:07:29
    /// </summary>
    public class FicoAccountingTitleDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FatSfid { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Bukrs { get; set; }

        [Required(ErrorMessage = "语言Key不能为空")]
        [ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string Spras { get; set; }

        [Required(ErrorMessage = "科目表不能为空")]
        [ExcelColumn(Name = "科目表")]
        [ExcelColumnName("科目表")]
        public string Ktopl { get; set; }

        [ExcelColumn(Name = "科目编号")]
        [ExcelColumnName("科目编号")]
        public string Saknr { get; set; }

        [ExcelColumn(Name = "负债科目")]
        [ExcelColumnName("负债科目")]
        public int? Xbilk { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Satext { get; set; }

        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string Stext { get; set; }

        [ExcelColumn(Name = "损益类型")]
        [ExcelColumnName("损益类型")]
        public string Gvtyp { get; set; }

        [ExcelColumn(Name = "科目组")]
        [ExcelColumnName("科目组")]
        public string Ktoks { get; set; }

        [ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int? Xspea { get; set; }

        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string Mitkz { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public int? Waers { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
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
        [ExcelColumn(Name = "损益类型")]
        public string GvtypLabel { get; set; }
        [ExcelColumn(Name = "冻结")]
        public string XspeaLabel { get; set; }
        [ExcelColumn(Name = "统驭科目")]
        public string MitkzLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string WaersLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:07:29
    /// </summary>
    public class FicoAccountingTitleImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FatSfid { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Bukrs { get; set; }

        [Required(ErrorMessage = "语言Key不能为空")]
        [ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string Spras { get; set; }

        [Required(ErrorMessage = "科目表不能为空")]
        [ExcelColumn(Name = "科目表")]
        [ExcelColumnName("科目表")]
        public string Ktopl { get; set; }

        [ExcelColumn(Name = "科目编号")]
        [ExcelColumnName("科目编号")]
        public string Saknr { get; set; }

        [ExcelColumn(Name = "负债科目")]
        [ExcelColumnName("负债科目")]
        public int? Xbilk { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Satext { get; set; }

        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string Stext { get; set; }

        [ExcelColumn(Name = "损益类型")]
        [ExcelColumnName("损益类型")]
        public string Gvtyp { get; set; }

        [ExcelColumn(Name = "科目组")]
        [ExcelColumnName("科目组")]
        public string Ktoks { get; set; }

        [ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int? Xspea { get; set; }

        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string Mitkz { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public int? Waers { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
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
        [ExcelColumn(Name = "损益类型")]
        public string GvtypLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "冻结")]
        public string XspeaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string MitkzLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string WaersLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}