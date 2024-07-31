namespace Ams.Model.Kernel.Dto
{
    /// <summary>
    /// 表字段
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 7:59:06
    /// </summary>
    public class SysTableFieldsQueryDto : PagerInfo
    {
        public string Tf001 { get; set; }
        public string Tf003 { get; set; }
    }

    /// <summary>
    /// 表字段
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 7:59:06
    /// </summary>
    public class SysTableFieldsDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long TfId { get; set; }

        [Required(ErrorMessage = "表名 不能为空")]
        [ExcelColumn(Name = "表名 ")]
        [ExcelColumnName("表名 ")]
        public string Tf001 { get; set; }

        [Required(ErrorMessage = "字段编号 不能为空")]
        [ExcelColumn(Name = "字段编号 ")]
        [ExcelColumnName("字段编号 ")]
        public string Tf003 { get; set; }

        [ExcelColumn(Name = "序号 ")]
        [ExcelColumnName("序号 ")]
        public string Tf002 { get; set; }

        [ExcelColumn(Name = "字段名称 ")]
        [ExcelColumnName("字段名称 ")]
        public string Tf004 { get; set; }

        [ExcelColumn(Name = "类型 ")]
        [ExcelColumnName("类型 ")]
        public string Tf005 { get; set; }

        [ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]
        public float Tf006 { get; set; }

        [ExcelColumn(Name = "字段说明 ")]
        [ExcelColumnName("字段说明 ")]
        public string Tf007 { get; set; }

        [ExcelColumn(Name = "实体类型 ")]
        [ExcelColumnName("实体类型 ")]
        public string Tf008 { get; set; }

        [ExcelColumn(Name = "最大长度 ")]
        [ExcelColumnName("最大长度 ")]
        public int? Tf009 { get; set; }

        [ExcelColumn(Name = "精度 ")]
        [ExcelColumnName("精度 ")]
        public int? Tf010 { get; set; }

        [ExcelColumn(Name = "刻度 ")]
        [ExcelColumnName("刻度 ")]
        public int? Tf011 { get; set; }

        [ExcelColumn(Name = "原字段编号 ")]
        [ExcelColumnName("原字段编号 ")]
        public string Tf012 { get; set; }

        [ExcelColumn(Name = "字段名称(tw) ")]
        [ExcelColumnName("字段名称(tw) ")]
        public string Tf013 { get; set; }

        [ExcelColumn(Name = "字段名称(ja) ")]
        [ExcelColumnName("字段名称(ja) ")]
        public string Tf014 { get; set; }

        [ExcelColumn(Name = "字段名称(ko) ")]
        [ExcelColumnName("字段名称(ko) ")]
        public string Tf015 { get; set; }

        [ExcelColumn(Name = "字段名称(ar) ")]
        [ExcelColumnName("字段名称(ar) ")]
        public string Tf016 { get; set; }

        [ExcelColumn(Name = "字段名称(ru) ")]
        [ExcelColumnName("字段名称(ru) ")]
        public string Tf017 { get; set; }

        [ExcelColumn(Name = "字段名称(es) ")]
        [ExcelColumnName("字段名称(es) ")]
        public string Tf018 { get; set; }

        [ExcelColumn(Name = "字段名称(fr) ")]
        [ExcelColumnName("字段名称(fr) ")]
        public string Tf019 { get; set; }

        [ExcelColumn(Name = "字段名称(de) ")]
        [ExcelColumnName("字段名称(de) ")]
        public string Tf020 { get; set; }

        [ExcelColumn(Name = "字段名称(en) ")]
        [ExcelColumnName("字段名称(en) ")]
        public string Tf021 { get; set; }

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
    /// 表字段
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 7:59:06
    /// </summary>
    public class SysTableFieldsImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long TfId { get; set; }

        [Required(ErrorMessage = "表名 不能为空")]
        [ExcelColumn(Name = "表名 ")]
        [ExcelColumnName("表名 ")]
        public string Tf001 { get; set; }

        [Required(ErrorMessage = "字段编号 不能为空")]
        [ExcelColumn(Name = "字段编号 ")]
        [ExcelColumnName("字段编号 ")]
        public string Tf003 { get; set; }

        [ExcelColumn(Name = "序号 ")]
        [ExcelColumnName("序号 ")]
        public string Tf002 { get; set; }

        [ExcelColumn(Name = "字段名称 ")]
        [ExcelColumnName("字段名称 ")]
        public string Tf004 { get; set; }

        [ExcelColumn(Name = "类型 ")]
        [ExcelColumnName("类型 ")]
        public string Tf005 { get; set; }

        [ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]
        public float Tf006 { get; set; }

        [ExcelColumn(Name = "字段说明 ")]
        [ExcelColumnName("字段说明 ")]
        public string Tf007 { get; set; }

        [ExcelColumn(Name = "实体类型 ")]
        [ExcelColumnName("实体类型 ")]
        public string Tf008 { get; set; }

        [ExcelColumn(Name = "最大长度 ")]
        [ExcelColumnName("最大长度 ")]
        public int? Tf009 { get; set; }

        [ExcelColumn(Name = "精度 ")]
        [ExcelColumnName("精度 ")]
        public int? Tf010 { get; set; }

        [ExcelColumn(Name = "刻度 ")]
        [ExcelColumnName("刻度 ")]
        public int? Tf011 { get; set; }

        [ExcelColumn(Name = "原字段编号 ")]
        [ExcelColumnName("原字段编号 ")]
        public string Tf012 { get; set; }

        [ExcelColumn(Name = "字段名称(tw) ")]
        [ExcelColumnName("字段名称(tw) ")]
        public string Tf013 { get; set; }

        [ExcelColumn(Name = "字段名称(ja) ")]
        [ExcelColumnName("字段名称(ja) ")]
        public string Tf014 { get; set; }

        [ExcelColumn(Name = "字段名称(ko) ")]
        [ExcelColumnName("字段名称(ko) ")]
        public string Tf015 { get; set; }

        [ExcelColumn(Name = "字段名称(ar) ")]
        [ExcelColumnName("字段名称(ar) ")]
        public string Tf016 { get; set; }

        [ExcelColumn(Name = "字段名称(ru) ")]
        [ExcelColumnName("字段名称(ru) ")]
        public string Tf017 { get; set; }

        [ExcelColumn(Name = "字段名称(es) ")]
        [ExcelColumnName("字段名称(es) ")]
        public string Tf018 { get; set; }

        [ExcelColumn(Name = "字段名称(fr) ")]
        [ExcelColumnName("字段名称(fr) ")]
        public string Tf019 { get; set; }

        [ExcelColumn(Name = "字段名称(de) ")]
        [ExcelColumnName("字段名称(de) ")]
        public string Tf020 { get; set; }

        [ExcelColumn(Name = "字段名称(en) ")]
        [ExcelColumnName("字段名称(en) ")]
        public string Tf021 { get; set; }

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