
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 公司科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:35:01
    /// </summary>
    public class FicoAccountingCorpQueryDto : PagerInfo 
    {
        /// <summary>
        /// 帐目表 
        /// </summary>        
        public string Ma003 { get; set; }
        /// <summary>
        /// 总帐科目 
        /// </summary>        
        public string Ma004 { get; set; }
        /// <summary>
        /// 短文本 
        /// </summary>        
        public string Ma014 { get; set; }
        /// <summary>
        /// 冻结 
        /// </summary>        
        public int? Ma017 { get; set; }
    }

    /// <summary>
    /// 公司科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:35:01
    /// </summary>
    public class FicoAccountingCorpDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Ma002 { get; set; }

        [Required(ErrorMessage = "帐目表不能为空")]
        //[ExcelColumn(Name = "帐目表")]
        [ExcelColumnName("帐目表")]

        public string Ma003 { get; set; }

        [Required(ErrorMessage = "总帐科目不能为空")]
        //[ExcelColumn(Name = "总帐科目")]
        [ExcelColumnName("总帐科目")]

        public string Ma004 { get; set; }

        //[ExcelColumn(Name = "负债科目")]
        [ExcelColumnName("负债科目")]

        public string Ma005 { get; set; }

        //[ExcelColumn(Name = "总帐科目")]
        [ExcelColumnName("总帐科目")]

        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "组科目号")]
        [ExcelColumnName("组科目号")]

        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "损益科目")]
        [ExcelColumnName("损益科目")]

        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "总帐科目组")]
        [ExcelColumnName("总帐科目组")]

        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "样本科目")]
        [ExcelColumnName("样本科目")]

        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "贸易伙伴")]
        [ExcelColumnName("贸易伙伴")]

        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "搜索条件")]
        [ExcelColumnName("搜索条件")]

        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "功能范围")]
        [ExcelColumnName("功能范围")]

        public string Ma013 { get; set; }

        [Required(ErrorMessage = "短文本不能为空")]
        //[ExcelColumn(Name = "短文本")]
        [ExcelColumnName("短文本")]

        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]

        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]

        public string Ma016 { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        //[ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]

        public int Ma017 { get; set; }

        [Required(ErrorMessage = "冻结过账不能为空")]
        //[ExcelColumn(Name = "冻结过账")]
        [ExcelColumnName("冻结过账")]

        public int Ma018 { get; set; }

        [Required(ErrorMessage = "冻结计划不能为空")]
        //[ExcelColumn(Name = "冻结计划")]
        [ExcelColumnName("冻结计划")]

        public int Ma019 { get; set; }

        [ExcelIgnore]

        public string REF01 { get; set; }

        [ExcelIgnore]

        public string REF02 { get; set; }

        [ExcelIgnore]

        public string REF03 { get; set; }

        [ExcelIgnore]

        public decimal REF04 { get; set; }

        [ExcelIgnore]

        public decimal REF05 { get; set; }

        [ExcelIgnore]

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

        //[ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]

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



        [ExcelColumn(Name = "冻结")]
        public string Ma017Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 公司科目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:35:01
    /// </summary>
    public class FicoAccountingCorpImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Ma002 { get; set; }

        [Required(ErrorMessage = "帐目表不能为空")]
        //[ExcelColumn(Name = "帐目表")]
        [ExcelColumnName("帐目表")]
        public string Ma003 { get; set; }

        [Required(ErrorMessage = "总帐科目不能为空")]
        //[ExcelColumn(Name = "总帐科目")]
        [ExcelColumnName("总帐科目")]
        public string Ma004 { get; set; }

        //[ExcelColumn(Name = "负债科目")]
        [ExcelColumnName("负债科目")]
        public string Ma005 { get; set; }

        //[ExcelColumn(Name = "总帐科目")]
        [ExcelColumnName("总帐科目")]
        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "组科目号")]
        [ExcelColumnName("组科目号")]
        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "损益科目")]
        [ExcelColumnName("损益科目")]
        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "总帐科目组")]
        [ExcelColumnName("总帐科目组")]
        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "样本科目")]
        [ExcelColumnName("样本科目")]
        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "贸易伙伴")]
        [ExcelColumnName("贸易伙伴")]
        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "搜索条件")]
        [ExcelColumnName("搜索条件")]
        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "功能范围")]
        [ExcelColumnName("功能范围")]
        public string Ma013 { get; set; }

        [Required(ErrorMessage = "短文本不能为空")]
        //[ExcelColumn(Name = "短文本")]
        [ExcelColumnName("短文本")]
        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string Ma016 { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        //[ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int Ma017 { get; set; }

        [Required(ErrorMessage = "冻结过账不能为空")]
        //[ExcelColumn(Name = "冻结过账")]
        [ExcelColumnName("冻结过账")]
        public int Ma018 { get; set; }

        [Required(ErrorMessage = "冻结计划不能为空")]
        //[ExcelColumn(Name = "冻结计划")]
        [ExcelColumnName("冻结计划")]
        public int Ma019 { get; set; }

        [ExcelIgnore]
        public string REF01 { get; set; }

        [ExcelIgnore]
        public string REF02 { get; set; }

        [ExcelIgnore]
        public string REF03 { get; set; }

        [ExcelIgnore]
        public decimal REF04 { get; set; }

        [ExcelIgnore]
        public decimal REF05 { get; set; }

        [ExcelIgnore]
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

        //[ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
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
        [ExcelColumn(Name = "冻结")]
        public string Ma017Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}