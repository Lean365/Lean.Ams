
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 资产类别
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:16:33
    /// </summary>
    public class FicoAssetsCategoryQueryDto : PagerInfo 
    {
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mc002 { get; set; }
        /// <summary>
        /// 类别 
        /// </summary>        
        public string Mc003 { get; set; }
        /// <summary>
        /// 名称 
        /// </summary>        
        public string Mc004 { get; set; }
        /// <summary>
        /// 长文本 
        /// </summary>        
        public string Mc005 { get; set; }
    }

    /// <summary>
    /// 资产类别
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:16:33
    /// </summary>
    public class FicoAssetsCategoryDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mc002 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]

        public string Mc003 { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Mc004 { get; set; }

        [Required(ErrorMessage = "长文本不能为空")]
        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]

        public string Mc005 { get; set; }

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



        [ExcelColumn(Name = "公司")]
        public string Mc002Label { get; set; }
    }

    /// <summary>
    /// 资产类别
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:16:33
    /// </summary>
    public class FicoAssetsCategoryImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mc002 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string Mc003 { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Mc004 { get; set; }

        [Required(ErrorMessage = "长文本不能为空")]
        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Mc005 { get; set; }

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
        [ExcelColumn(Name = "公司")]
        public string Mc002Label { get; set; }
    }

}