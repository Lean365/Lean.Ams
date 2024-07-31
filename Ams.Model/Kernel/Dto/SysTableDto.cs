
namespace Ams.Model.Kernel.Dto
{
    /// <summary>
    /// 表名称
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 10:27:13
    /// </summary>
    public class SysTableQueryDto : PagerInfo 
    {
        public string Tb001 { get; set; }
        public string Tb002 { get; set; }
    }

    /// <summary>
    /// 表名称
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 10:27:13
    /// </summary>
    public class SysTableDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long TbId { get; set; }

        [Required(ErrorMessage = "表名 不能为空")]
        [ExcelColumn(Name = "表名 ")]
        [ExcelColumnName("表名 ")]
        public string Tb001 { get; set; }

        [ExcelColumn(Name = "表描述")]
        [ExcelColumnName("表描述")]
        public string Tb002 { get; set; }

        [Required(ErrorMessage = "序号 不能为空")]
        [ExcelColumn(Name = "序号 ")]
        [ExcelColumnName("序号 ")]
        public string Tb003 { get; set; }

        [ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]
        public string Tb004 { get; set; }

        [ExcelColumn(Name = "缩写")]
        [ExcelColumnName("缩写")]
        public string Tb005 { get; set; }

        [Required(ErrorMessage = "表名称不能为空")]
        [ExcelColumn(Name = "表名称")]
        [ExcelColumnName("表名称")]
        public string Tb006 { get; set; }

        [ExcelColumn(Name = "字段名称(tw) ")]
        [ExcelColumnName("字段名称(tw) ")]
        public string Tb007 { get; set; }

        [ExcelColumn(Name = "字段名称(ja) ")]
        [ExcelColumnName("字段名称(ja) ")]
        public string Tb008 { get; set; }

        [ExcelColumn(Name = "字段名称(ko) ")]
        [ExcelColumnName("字段名称(ko) ")]
        public string Tb009 { get; set; }

        [ExcelColumn(Name = "字段名称(ar) ")]
        [ExcelColumnName("字段名称(ar) ")]
        public string Tb010 { get; set; }

        [ExcelColumn(Name = "字段名称(ru) ")]
        [ExcelColumnName("字段名称(ru) ")]
        public string Tb011 { get; set; }

        [ExcelColumn(Name = "字段名称(es) ")]
        [ExcelColumnName("字段名称(es) ")]
        public string Tb012 { get; set; }

        [ExcelColumn(Name = "字段名称(fr) ")]
        [ExcelColumnName("字段名称(fr) ")]
        public string Tb013 { get; set; }

        [ExcelColumn(Name = "字段名称(de) ")]
        [ExcelColumnName("字段名称(de) ")]
        public string Tb014 { get; set; }

        [ExcelColumn(Name = "字段名称(en) ")]
        [ExcelColumnName("字段名称(en) ")]
        public string Tb015 { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 表名称
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 10:27:13
    /// </summary>
    public class SysTableImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long TbId { get; set; }

        [Required(ErrorMessage = "表名 不能为空")]
        [ExcelColumn(Name = "表名 ")]
        [ExcelColumnName("表名 ")]
        public string Tb001 { get; set; }

        [ExcelColumn(Name = "表描述")]
        [ExcelColumnName("表描述")]
        public string Tb002 { get; set; }

        [Required(ErrorMessage = "序号 不能为空")]
        [ExcelColumn(Name = "序号 ")]
        [ExcelColumnName("序号 ")]
        public string Tb003 { get; set; }

        [ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]
        public string Tb004 { get; set; }

        [ExcelColumn(Name = "缩写")]
        [ExcelColumnName("缩写")]
        public string Tb005 { get; set; }

        [Required(ErrorMessage = "表名称不能为空")]
        [ExcelColumn(Name = "表名称")]
        [ExcelColumnName("表名称")]
        public string Tb006 { get; set; }

        [ExcelColumn(Name = "字段名称(tw) ")]
        [ExcelColumnName("字段名称(tw) ")]
        public string Tb007 { get; set; }

        [ExcelColumn(Name = "字段名称(ja) ")]
        [ExcelColumnName("字段名称(ja) ")]
        public string Tb008 { get; set; }

        [ExcelColumn(Name = "字段名称(ko) ")]
        [ExcelColumnName("字段名称(ko) ")]
        public string Tb009 { get; set; }

        [ExcelColumn(Name = "字段名称(ar) ")]
        [ExcelColumnName("字段名称(ar) ")]
        public string Tb010 { get; set; }

        [ExcelColumn(Name = "字段名称(ru) ")]
        [ExcelColumnName("字段名称(ru) ")]
        public string Tb011 { get; set; }

        [ExcelColumn(Name = "字段名称(es) ")]
        [ExcelColumnName("字段名称(es) ")]
        public string Tb012 { get; set; }

        [ExcelColumn(Name = "字段名称(fr) ")]
        [ExcelColumnName("字段名称(fr) ")]
        public string Tb013 { get; set; }

        [ExcelColumn(Name = "字段名称(de) ")]
        [ExcelColumnName("字段名称(de) ")]
        public string Tb014 { get; set; }

        [ExcelColumn(Name = "字段名称(en) ")]
        [ExcelColumnName("字段名称(en) ")]
        public string Tb015 { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}