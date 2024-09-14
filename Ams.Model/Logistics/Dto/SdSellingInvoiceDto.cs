
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 销售凭证
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:47:09
    /// </summary>
    public class SdSellingInvoiceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mc002 { get; set; }
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Mc003 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mc004 { get; set; }
        /// <summary>
        /// 客户 
        /// </summary>        
        public string Mc007 { get; set; }
        /// <summary>
        /// 利润中心 
        /// </summary>        
        public string Mc008 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mc009 { get; set; }
    }

    /// <summary>
    /// 销售凭证
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:47:09
    /// </summary>
    public class SdSellingInvoiceDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mc002 { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Mc003 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "销售凭证")]
        [ExcelColumnName("销售凭证")]

        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "凭证明细")]
        [ExcelColumnName("凭证明细")]

        public string Mc006 { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]

        public string Mc007 { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]

        public string Mc008 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]

        public string Mc010 { get; set; }

        [Required(ErrorMessage = "销售数量不能为空")]
        //[ExcelColumn(Name = "销售数量")]
        [ExcelColumnName("销售数量")]

        public decimal Mc011 { get; set; }

        //[ExcelColumn(Name = "销售单位")]
        [ExcelColumnName("销售单位")]

        public string Mc012 { get; set; }

        [Required(ErrorMessage = "原币销售额不能为空")]
        //[ExcelColumn(Name = "原币销售额")]
        [ExcelColumnName("原币销售额")]

        public decimal Mc013 { get; set; }

        //[ExcelColumn(Name = "原币币种")]
        [ExcelColumnName("原币币种")]

        public string Mc014 { get; set; }

        [Required(ErrorMessage = "本币销售额不能为空")]
        //[ExcelColumn(Name = "本币销售额")]
        [ExcelColumnName("本币销售额")]

        public decimal Mc015 { get; set; }

        //[ExcelColumn(Name = "本币币种")]
        [ExcelColumnName("本币币种")]

        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "参考凭证")]
        [ExcelColumnName("参考凭证")]

        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "参考明细")]
        [ExcelColumnName("参考明细")]

        public string Mc018 { get; set; }

        //[ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("过账日期")]

        public DateTime? Mc019 { get; set; }

        //[ExcelColumn(Name = "用户")]
        [ExcelColumnName("用户")]

        public string Mc020 { get; set; }

        //[ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日期")]

        public DateTime? Mc021 { get; set; }

        //[ExcelColumn(Name = "输入时间")]
        [ExcelColumnName("输入时间")]

        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "来源")]
        [ExcelColumnName("来源")]

        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]

        public string Mc024 { get; set; }

        //[ExcelColumn(Name = "凭证类型")]
        [ExcelColumnName("凭证类型")]

        public string Mc025 { get; set; }

        //[ExcelColumn(Name = "凭证名称")]
        [ExcelColumnName("凭证名称")]

        public string Mc026 { get; set; }

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

        public string Remark { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "工厂")]
        public string Mc002Label { get; set; }
        [ExcelColumn(Name = "期间")]
        public string Mc003Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mc004Label { get; set; }
    }

    /// <summary>
    /// 销售凭证
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:47:09
    /// </summary>
    public class SdSellingInvoiceImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mc002 { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Mc003 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "销售凭证")]
        [ExcelColumnName("销售凭证")]
        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "凭证明细")]
        [ExcelColumnName("凭证明细")]
        public string Mc006 { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string Mc007 { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Mc008 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string Mc010 { get; set; }

        [Required(ErrorMessage = "销售数量不能为空")]
        //[ExcelColumn(Name = "销售数量")]
        [ExcelColumnName("销售数量")]
        public decimal Mc011 { get; set; }

        //[ExcelColumn(Name = "销售单位")]
        [ExcelColumnName("销售单位")]
        public string Mc012 { get; set; }

        [Required(ErrorMessage = "原币销售额不能为空")]
        //[ExcelColumn(Name = "原币销售额")]
        [ExcelColumnName("原币销售额")]
        public decimal Mc013 { get; set; }

        //[ExcelColumn(Name = "原币币种")]
        [ExcelColumnName("原币币种")]
        public string Mc014 { get; set; }

        [Required(ErrorMessage = "本币销售额不能为空")]
        //[ExcelColumn(Name = "本币销售额")]
        [ExcelColumnName("本币销售额")]
        public decimal Mc015 { get; set; }

        //[ExcelColumn(Name = "本币币种")]
        [ExcelColumnName("本币币种")]
        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "参考凭证")]
        [ExcelColumnName("参考凭证")]
        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "参考明细")]
        [ExcelColumnName("参考明细")]
        public string Mc018 { get; set; }

        //[ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("过账日期")]
        public DateTime? Mc019 { get; set; }

        //[ExcelColumn(Name = "用户")]
        [ExcelColumnName("用户")]
        public string Mc020 { get; set; }

        //[ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日期")]
        public DateTime? Mc021 { get; set; }

        //[ExcelColumn(Name = "输入时间")]
        [ExcelColumnName("输入时间")]
        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "来源")]
        [ExcelColumnName("来源")]
        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]
        public string Mc024 { get; set; }

        //[ExcelColumn(Name = "凭证类型")]
        [ExcelColumnName("凭证类型")]
        public string Mc025 { get; set; }

        //[ExcelColumn(Name = "凭证名称")]
        [ExcelColumnName("凭证名称")]
        public string Mc026 { get; set; }

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
        [ExcelColumn(Name = "工厂")]
        public string Mc002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string Mc003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mc004Label { get; set; }
    }

}