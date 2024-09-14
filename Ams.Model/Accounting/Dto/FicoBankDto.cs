
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 银行
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:43:04
    /// </summary>
    public class FicoBankQueryDto : PagerInfo 
    {
        /// <summary>
        /// 关联对象 
        /// </summary>        
        public string Mc003 { get; set; }
        /// <summary>
        /// 银行代码 
        /// </summary>        
        public string Mc004 { get; set; }
        /// <summary>
        /// 银行名称 
        /// </summary>        
        public string Mc005 { get; set; }
        /// <summary>
        /// 分行名称 
        /// </summary>        
        public string Mc006 { get; set; }
        /// <summary>
        /// 银行所在国 
        /// </summary>        
        public string Mc007 { get; set; }
        /// <summary>
        /// 所在州省 
        /// </summary>        
        public string Mc008 { get; set; }
    }

    /// <summary>
    /// 银行
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:43:04
    /// </summary>
    public class FicoBankDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Mc002 { get; set; }

        //[ExcelColumn(Name = "关联对象")]
        [ExcelColumnName("关联对象")]

        public string Mc003 { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        //[ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]

        public string Mc004 { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        //[ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]

        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]

        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]

        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "所在州省")]
        [ExcelColumnName("所在州省")]

        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "所在市")]
        [ExcelColumnName("所在市")]

        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "所在县")]
        [ExcelColumnName("所在县")]

        public string Mc010 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]

        public string Mc011 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]

        public string Mc012 { get; set; }

        //[ExcelColumn(Name = "地址3")]
        [ExcelColumnName("地址3")]

        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]

        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]

        public string Mc015 { get; set; }

        //[ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]

        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "持有人")]
        [ExcelColumnName("持有人")]

        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]

        public string Mc018 { get; set; }

        [Required(ErrorMessage = "交易冻结不能为空")]
        //[ExcelColumn(Name = "交易冻结")]
        [ExcelColumnName("交易冻结")]

        public int Mc019 { get; set; }

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



        [ExcelColumn(Name = "银行所在国")]
        public string Mc007Label { get; set; }
        [ExcelColumn(Name = "交易冻结")]
        public string Mc019Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 银行
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:43:04
    /// </summary>
    public class FicoBankImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mc002 { get; set; }

        //[ExcelColumn(Name = "关联对象")]
        [ExcelColumnName("关联对象")]
        public string Mc003 { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        //[ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]
        public string Mc004 { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        //[ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]
        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]
        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]
        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "所在州省")]
        [ExcelColumnName("所在州省")]
        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "所在市")]
        [ExcelColumnName("所在市")]
        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "所在县")]
        [ExcelColumnName("所在县")]
        public string Mc010 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string Mc011 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string Mc012 { get; set; }

        //[ExcelColumn(Name = "地址3")]
        [ExcelColumnName("地址3")]
        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]
        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]
        public string Mc015 { get; set; }

        //[ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]
        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "持有人")]
        [ExcelColumnName("持有人")]
        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]
        public string Mc018 { get; set; }

        [Required(ErrorMessage = "交易冻结不能为空")]
        //[ExcelColumn(Name = "交易冻结")]
        [ExcelColumnName("交易冻结")]
        public int Mc019 { get; set; }

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
        [ExcelColumn(Name = "银行所在国")]
        public string Mc007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "交易冻结")]
        public string Mc019Label { get; set; }
    }

}