using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/18 8:51:20
    /// </summary>
    public class PpEcMasterQueryDto : PagerInfo 
    {
        /// <summary>
        /// 发行日期 
        /// </summary>        
        public DateTime? BeginMb002 { get; set; }
        public DateTime? EndMb002 { get; set; }
        /// <summary>
        /// 设变No. 
        /// </summary>        
        public string Mb003 { get; set; }
        /// <summary>
        /// 标题 
        /// </summary>        
        public string Mb006 { get; set; }
        /// <summary>
        /// 内容 
        /// </summary>        
        public string Mb007 { get; set; }
        /// <summary>
        /// 担当 
        /// </summary>        
        public string Mb008 { get; set; }
        /// <summary>
        /// 管理区分 
        /// </summary>        
        public int? Mb013 { get; set; }
        /// <summary>
        /// 输入日 
        /// </summary>        
        public DateTime? BeginMb023 { get; set; }
        public DateTime? EndMb023 { get; set; }
    }

    /// <summary>
    /// 设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/18 8:51:20
    /// </summary>
    public class PpEcMasterDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        //[ExcelColumn(Name = "发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日期")]

        public DateTime? Mb002 { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]

        public string Mb003 { get; set; }

        //[ExcelColumn(Name = "关联文件")]
        [ExcelColumnName("关联文件")]

        public string Mb004 { get; set; }

        [Required(ErrorMessage = "设变状态不能为空")]
        //[ExcelColumn(Name = "设变状态")]
        [ExcelColumnName("设变状态")]

        public int Mb005 { get; set; }

        //[ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]

        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]

        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]

        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "成本变更")]
        [ExcelColumnName("成本变更")]

        public string Mb009 { get; set; }

        [Required(ErrorMessage = "单位成本不能为空")]
        //[ExcelColumn(Name = "单位成本")]
        [ExcelColumnName("单位成本")]

        public decimal Mb010 { get; set; }

        [Required(ErrorMessage = "模具费用不能为空")]
        //[ExcelColumn(Name = "模具费用")]
        [ExcelColumnName("模具费用")]

        public decimal Mb011 { get; set; }

        //[ExcelColumn(Name = "关联图纸")]
        [ExcelColumnName("关联图纸")]

        public string Mb012 { get; set; }

        [Required(ErrorMessage = "管理区分不能为空")]
        //[ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]

        public int Mb013 { get; set; }

        //[ExcelColumn(Name = "联络No.")]
        [ExcelColumnName("联络No.")]

        public string Mb014 { get; set; }

        //[ExcelColumn(Name = "联络文件")]
        [ExcelColumnName("联络文件")]

        public string Mb015 { get; set; }

        //[ExcelColumn(Name = "EppNo.")]
        [ExcelColumnName("EppNo.")]

        public string Mb016 { get; set; }

        //[ExcelColumn(Name = "Epp文件")]
        [ExcelColumnName("Epp文件")]

        public string Mb017 { get; set; }

        //[ExcelColumn(Name = "FppNo.")]
        [ExcelColumnName("FppNo.")]

        public string Mb018 { get; set; }

        //[ExcelColumn(Name = "Fpp文件")]
        [ExcelColumnName("Fpp文件")]

        public string Mb019 { get; set; }

        //[ExcelColumn(Name = "外部No.")]
        [ExcelColumnName("外部No.")]

        public string Mb020 { get; set; }

        //[ExcelColumn(Name = "外部文件")]
        [ExcelColumnName("外部文件")]

        public string Mb021 { get; set; }

        //[ExcelColumn(Name = "输入部门")]
        [ExcelColumnName("输入部门")]

        public string Mb022 { get; set; }

        //[ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]

        public DateTime? Mb023 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

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

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpEcSlaveDto> PpEcSlaveNav { get; set; }
        [ExcelColumn(Name = "设变状态")]
        public string Mb005Label { get; set; }
        [ExcelColumn(Name = "担当")]
        public string Mb008Label { get; set; }
        [ExcelColumn(Name = "管理区分")]
        public string Mb013Label { get; set; }
        [ExcelColumn(Name = "输入部门")]
        public string Mb022Label { get; set; }
    }

    /// <summary>
    /// 设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/18 8:51:20
    /// </summary>
    public class PpEcMasterImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        //[ExcelColumn(Name = "发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日期")]
        public DateTime? Mb002 { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Mb003 { get; set; }

        //[ExcelColumn(Name = "关联文件")]
        [ExcelColumnName("关联文件")]
        public string Mb004 { get; set; }

        [Required(ErrorMessage = "设变状态不能为空")]
        //[ExcelColumn(Name = "设变状态")]
        [ExcelColumnName("设变状态")]
        public int Mb005 { get; set; }

        //[ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "成本变更")]
        [ExcelColumnName("成本变更")]
        public string Mb009 { get; set; }

        [Required(ErrorMessage = "单位成本不能为空")]
        //[ExcelColumn(Name = "单位成本")]
        [ExcelColumnName("单位成本")]
        public decimal Mb010 { get; set; }

        [Required(ErrorMessage = "模具费用不能为空")]
        //[ExcelColumn(Name = "模具费用")]
        [ExcelColumnName("模具费用")]
        public decimal Mb011 { get; set; }

        //[ExcelColumn(Name = "关联图纸")]
        [ExcelColumnName("关联图纸")]
        public string Mb012 { get; set; }

        [Required(ErrorMessage = "管理区分不能为空")]
        //[ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int Mb013 { get; set; }

        //[ExcelColumn(Name = "联络No.")]
        [ExcelColumnName("联络No.")]
        public string Mb014 { get; set; }

        //[ExcelColumn(Name = "联络文件")]
        [ExcelColumnName("联络文件")]
        public string Mb015 { get; set; }

        //[ExcelColumn(Name = "EppNo.")]
        [ExcelColumnName("EppNo.")]
        public string Mb016 { get; set; }

        //[ExcelColumn(Name = "Epp文件")]
        [ExcelColumnName("Epp文件")]
        public string Mb017 { get; set; }

        //[ExcelColumn(Name = "FppNo.")]
        [ExcelColumnName("FppNo.")]
        public string Mb018 { get; set; }

        //[ExcelColumn(Name = "Fpp文件")]
        [ExcelColumnName("Fpp文件")]
        public string Mb019 { get; set; }

        //[ExcelColumn(Name = "外部No.")]
        [ExcelColumnName("外部No.")]
        public string Mb020 { get; set; }

        //[ExcelColumn(Name = "外部文件")]
        [ExcelColumnName("外部文件")]
        public string Mb021 { get; set; }

        //[ExcelColumn(Name = "输入部门")]
        [ExcelColumnName("输入部门")]
        public string Mb022 { get; set; }

        //[ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]
        public DateTime? Mb023 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

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

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpEcSlaveDto> PpEcSlaveNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "设变状态")]
        public string Mb005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "担当")]
        public string Mb008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "管理区分")]
        public string Mb013Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "输入部门")]
        public string Mb022Label { get; set; }
    }

}