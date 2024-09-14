using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 主源设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:09:51
    /// </summary>
    public class PpSourceEcMaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 设变No. 
        /// </summary>        
        public string Za002 { get; set; }
        /// <summary>
        /// 标题 
        /// </summary>        
        public string Za004 { get; set; }
        /// <summary>
        /// 发行日 
        /// </summary>        
        public DateTime? BeginZa006 { get; set; }
        public DateTime? EndZa006 { get; set; }
    }

    /// <summary>
    /// 主源设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:09:51
    /// </summary>
    public class PpSourceEcMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]

        public string Za002 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Za003 { get; set; }

        //[ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]

        public string Za004 { get; set; }

        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]

        public string Za005 { get; set; }

        //[ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日")]

        public DateTime? Za006 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]

        public string Za007 { get; set; }

        //[ExcelColumn(Name = "依赖")]
        [ExcelColumnName("依赖")]

        public string Za008 { get; set; }

        //[ExcelColumn(Name = "会议")]
        [ExcelColumnName("会议")]

        public string Za009 { get; set; }

        //[ExcelColumn(Name = "PP番号")]
        [ExcelColumnName("PP番号")]

        public string Za010 { get; set; }

        //[ExcelColumn(Name = "联络书")]
        [ExcelColumnName("联络书")]

        public string Za011 { get; set; }

        //[ExcelColumn(Name = "实施")]
        [ExcelColumnName("实施")]

        public string Za012 { get; set; }

        //[ExcelColumn(Name = "主理由")]
        [ExcelColumnName("主理由")]

        public string Za013 { get; set; }

        //[ExcelColumn(Name = "次理由")]
        [ExcelColumnName("次理由")]

        public string Za014 { get; set; }

        //[ExcelColumn(Name = "安规")]
        [ExcelColumnName("安规")]

        public string Za015 { get; set; }

        //[ExcelColumn(Name = "状况")]
        [ExcelColumnName("状况")]

        public string Za016 { get; set; }

        //[ExcelColumn(Name = "机番")]
        [ExcelColumnName("机番")]

        public string Za017 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]

        public string Za018 { get; set; }

        //[ExcelColumn(Name = "服务手册订正")]
        [ExcelColumnName("服务手册订正")]

        public string Za019 { get; set; }

        //[ExcelColumn(Name = "用户手册订正")]
        [ExcelColumnName("用户手册订正")]

        public string Za020 { get; set; }

        //[ExcelColumn(Name = "宣传手册订正")]
        [ExcelColumnName("宣传手册订正")]

        public string Za021 { get; set; }

        //[ExcelColumn(Name = "SOP订正")]
        [ExcelColumnName("SOP订正")]

        public string Za022 { get; set; }

        //[ExcelColumn(Name = "信息发行")]
        [ExcelColumnName("信息发行")]

        public string Za023 { get; set; }

        //[ExcelColumn(Name = "成本变动")]
        [ExcelColumnName("成本变动")]

        public string Za024 { get; set; }

        [Required(ErrorMessage = "单位成本不能为空")]
        //[ExcelColumn(Name = "单位成本")]
        [ExcelColumnName("单位成本")]

        public decimal Za025 { get; set; }

        [Required(ErrorMessage = "模具改造费不能为空")]
        //[ExcelColumn(Name = "模具改造费")]
        [ExcelColumnName("模具改造费")]

        public decimal Za026 { get; set; }

        //[ExcelColumn(Name = "图纸")]
        [ExcelColumnName("图纸")]

        public string Za027 { get; set; }

        //[ExcelColumn(Name = "设变内容")]
        [ExcelColumnName("设变内容")]

        public string Za028 { get; set; }

        //[ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]

        public string Za029 { get; set; }

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



        [ExcelIgnore]
        public List<PpSourceEcSlvDto> PpSourceEcSlvNav { get; set; }
    }

    /// <summary>
    /// 主源设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:09:51
    /// </summary>
    public class PpSourceEcMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Za002 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Za003 { get; set; }

        //[ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string Za004 { get; set; }

        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string Za005 { get; set; }

        //[ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日")]
        public DateTime? Za006 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Za007 { get; set; }

        //[ExcelColumn(Name = "依赖")]
        [ExcelColumnName("依赖")]
        public string Za008 { get; set; }

        //[ExcelColumn(Name = "会议")]
        [ExcelColumnName("会议")]
        public string Za009 { get; set; }

        //[ExcelColumn(Name = "PP番号")]
        [ExcelColumnName("PP番号")]
        public string Za010 { get; set; }

        //[ExcelColumn(Name = "联络书")]
        [ExcelColumnName("联络书")]
        public string Za011 { get; set; }

        //[ExcelColumn(Name = "实施")]
        [ExcelColumnName("实施")]
        public string Za012 { get; set; }

        //[ExcelColumn(Name = "主理由")]
        [ExcelColumnName("主理由")]
        public string Za013 { get; set; }

        //[ExcelColumn(Name = "次理由")]
        [ExcelColumnName("次理由")]
        public string Za014 { get; set; }

        //[ExcelColumn(Name = "安规")]
        [ExcelColumnName("安规")]
        public string Za015 { get; set; }

        //[ExcelColumn(Name = "状况")]
        [ExcelColumnName("状况")]
        public string Za016 { get; set; }

        //[ExcelColumn(Name = "机番")]
        [ExcelColumnName("机番")]
        public string Za017 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Za018 { get; set; }

        //[ExcelColumn(Name = "服务手册订正")]
        [ExcelColumnName("服务手册订正")]
        public string Za019 { get; set; }

        //[ExcelColumn(Name = "用户手册订正")]
        [ExcelColumnName("用户手册订正")]
        public string Za020 { get; set; }

        //[ExcelColumn(Name = "宣传手册订正")]
        [ExcelColumnName("宣传手册订正")]
        public string Za021 { get; set; }

        //[ExcelColumn(Name = "SOP订正")]
        [ExcelColumnName("SOP订正")]
        public string Za022 { get; set; }

        //[ExcelColumn(Name = "信息发行")]
        [ExcelColumnName("信息发行")]
        public string Za023 { get; set; }

        //[ExcelColumn(Name = "成本变动")]
        [ExcelColumnName("成本变动")]
        public string Za024 { get; set; }

        [Required(ErrorMessage = "单位成本不能为空")]
        //[ExcelColumn(Name = "单位成本")]
        [ExcelColumnName("单位成本")]
        public decimal Za025 { get; set; }

        [Required(ErrorMessage = "模具改造费不能为空")]
        //[ExcelColumn(Name = "模具改造费")]
        [ExcelColumnName("模具改造费")]
        public decimal Za026 { get; set; }

        //[ExcelColumn(Name = "图纸")]
        [ExcelColumnName("图纸")]
        public string Za027 { get; set; }

        //[ExcelColumn(Name = "设变内容")]
        [ExcelColumnName("设变内容")]
        public string Za028 { get; set; }

        //[ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]
        public string Za029 { get; set; }

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



        [ExcelIgnore]
        public List<PpSourceEcSlvDto> PpSourceEcSlvNav { get; set; }
    }

}