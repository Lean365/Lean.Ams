namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 从源设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:04:44
    /// </summary>
    public class PpSourceEcSlvQueryDto : PagerInfo
    {
        public string Zpabds001 { get; set; }
        public string Zpabds002 { get; set; }
        public string Zpabds003 { get; set; }
        public string Zpabds004 { get; set; }
        public string Zpabds008 { get; set; }
        public string IsSolved { get; set; }
    }

    /// <summary>
    /// 从源设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:04:44
    /// </summary>
    public class PpSourceEcSlvDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long ParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Zpabds001 { get; set; }

        [ExcelColumn(Name = "完成品")]
        [ExcelColumnName("完成品")]
        public string Zpabds002 { get; set; }

        [ExcelColumn(Name = "上阶")]
        [ExcelColumnName("上阶")]
        public string Zpabds003 { get; set; }

        [ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string Zpabds004 { get; set; }

        [ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]
        public string Zpabds005 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Zpabds006 { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Zpabds007 { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string Zpabds008 { get; set; }

        [ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]
        public string Zpabds009 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Zpabds010 { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Zpabds011 { get; set; }

        [ExcelColumn(Name = "BOM番号")]
        [ExcelColumnName("BOM番号")]
        public string Zpabds012 { get; set; }

        [ExcelColumn(Name = "互换性")]
        [ExcelColumnName("互换性")]
        public string Zpabds013 { get; set; }

        [ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string Zpabds014 { get; set; }

        [ExcelColumn(Name = "安排指示")]
        [ExcelColumnName("安排指示")]
        public string Zpabds015 { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string Zpabds016 { get; set; }

        [ExcelColumn(Name = "BOM生效", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("BOM生效")]
        public DateTime? Zpabds017 { get; set; }

        [Required(ErrorMessage = "处理标记不能为空")]
        [ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]
        public string IsSolved { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "处理标记")]
        public string IsSolvedLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 从源设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:04:44
    /// </summary>
    public class PpSourceEcSlvImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long ParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Zpabds001 { get; set; }

        [ExcelColumn(Name = "完成品")]
        [ExcelColumnName("完成品")]
        public string Zpabds002 { get; set; }

        [ExcelColumn(Name = "上阶")]
        [ExcelColumnName("上阶")]
        public string Zpabds003 { get; set; }

        [ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string Zpabds004 { get; set; }

        [ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]
        public string Zpabds005 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Zpabds006 { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Zpabds007 { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string Zpabds008 { get; set; }

        [ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]
        public string Zpabds009 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Zpabds010 { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Zpabds011 { get; set; }

        [ExcelColumn(Name = "BOM番号")]
        [ExcelColumnName("BOM番号")]
        public string Zpabds012 { get; set; }

        [ExcelColumn(Name = "互换性")]
        [ExcelColumnName("互换性")]
        public string Zpabds013 { get; set; }

        [ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string Zpabds014 { get; set; }

        [ExcelColumn(Name = "安排指示")]
        [ExcelColumnName("安排指示")]
        public string Zpabds015 { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string Zpabds016 { get; set; }

        [ExcelColumn(Name = "BOM生效", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("BOM生效")]
        public DateTime? Zpabds017 { get; set; }

        [Required(ErrorMessage = "处理标记不能为空")]
        [ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]
        public string IsSolved { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "处理标记")]
        public string IsSolvedLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}