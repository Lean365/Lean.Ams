
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 从源设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:08:51
    /// </summary>
    public class PpSourceEcSlvQueryDto : PagerInfo 
    {
        /// <summary>
        /// 设变No. 
        /// </summary>        
        public string Zb003 { get; set; }
        /// <summary>
        /// 完成品 
        /// </summary>        
        public string Zb004 { get; set; }
    }

    /// <summary>
    /// 从源设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:08:51
    /// </summary>
    public class PpSourceEcSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long Zb002 { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]

        public string Zb003 { get; set; }

        [Required(ErrorMessage = "完成品不能为空")]
        //[ExcelColumn(Name = "完成品")]
        [ExcelColumnName("完成品")]

        public string Zb004 { get; set; }

        //[ExcelColumn(Name = "上阶")]
        [ExcelColumnName("上阶")]

        public string Zb005 { get; set; }

        //[ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]

        public string Zb006 { get; set; }

        //[ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]

        public string Zb007 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public decimal Zb008 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]

        public string Zb009 { get; set; }

        //[ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]

        public string Zb010 { get; set; }

        //[ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]

        public string Zb011 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public decimal Zb012 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]

        public string Zb013 { get; set; }

        //[ExcelColumn(Name = "BOM番号")]
        [ExcelColumnName("BOM番号")]

        public string Zb014 { get; set; }

        //[ExcelColumn(Name = "互换性")]
        [ExcelColumnName("互换性")]

        public string Zb015 { get; set; }

        //[ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]

        public string Zb016 { get; set; }

        //[ExcelColumn(Name = "安排指示")]
        [ExcelColumnName("安排指示")]

        public string Zb017 { get; set; }

        //[ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]

        public string Zb018 { get; set; }

        //[ExcelColumn(Name = "BOM生效", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("BOM生效")]

        public DateTime? Zb019 { get; set; }

        //[ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]

        public string Zb020 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]

        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]

        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]

        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]

        public decimal Udf56 { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



    }

    /// <summary>
    /// 从源设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:08:51
    /// </summary>
    public class PpSourceEcSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long Zb002 { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Zb003 { get; set; }

        [Required(ErrorMessage = "完成品不能为空")]
        //[ExcelColumn(Name = "完成品")]
        [ExcelColumnName("完成品")]
        public string Zb004 { get; set; }

        //[ExcelColumn(Name = "上阶")]
        [ExcelColumnName("上阶")]
        public string Zb005 { get; set; }

        //[ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string Zb006 { get; set; }

        //[ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]
        public string Zb007 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Zb008 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Zb009 { get; set; }

        //[ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string Zb010 { get; set; }

        //[ExcelColumn(Name = "品名")]
        [ExcelColumnName("品名")]
        public string Zb011 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Zb012 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Zb013 { get; set; }

        //[ExcelColumn(Name = "BOM番号")]
        [ExcelColumnName("BOM番号")]
        public string Zb014 { get; set; }

        //[ExcelColumn(Name = "互换性")]
        [ExcelColumnName("互换性")]
        public string Zb015 { get; set; }

        //[ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string Zb016 { get; set; }

        //[ExcelColumn(Name = "安排指示")]
        [ExcelColumnName("安排指示")]
        public string Zb017 { get; set; }

        //[ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string Zb018 { get; set; }

        //[ExcelColumn(Name = "BOM生效", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("BOM生效")]
        public DateTime? Zb019 { get; set; }

        //[ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]
        public string Zb020 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal Udf56 { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }

}