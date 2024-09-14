
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 分析对策
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:44:05
    /// </summary>
    public class QmIpvReplyQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mi002 { get; set; }
        /// <summary>
        /// 检查员 
        /// </summary>        
        public string Mi003 { get; set; }
        /// <summary>
        /// 班组 
        /// </summary>        
        public string Mi004 { get; set; }
        /// <summary>
        /// 订单 
        /// </summary>        
        public string Mi005 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Mi006 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mi007 { get; set; }
        /// <summary>
        /// 检验日期 
        /// </summary>        
        public DateTime? BeginMi009 { get; set; }
        public DateTime? EndMi009 { get; set; }
        /// <summary>
        /// 实施日期 
        /// </summary>        
        public DateTime? BeginMi023 { get; set; }
        public DateTime? EndMi023 { get; set; }
        /// <summary>
        /// 发行号码 
        /// </summary>        
        public string Mi027 { get; set; }
    }

    /// <summary>
    /// 分析对策
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:44:05
    /// </summary>
    public class QmIpvReplyDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mi002 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]

        public string Mi003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]

        public string Mi004 { get; set; }

        [Required(ErrorMessage = "订单不能为空")]
        //[ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]

        public string Mi005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Mi006 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mi007 { get; set; }

        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]

        public string Mi008 { get; set; }

        //[ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]

        public DateTime? Mi009 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Mi010 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]

        public string Mi011 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]

        public decimal Mi012 { get; set; }

        //[ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]

        public string Mi013 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]

        public string Mi014 { get; set; }

        //[ExcelColumn(Name = "对策人员")]
        [ExcelColumnName("对策人员")]

        public string Mi015 { get; set; }

        //[ExcelColumn(Name = "对应日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("对应日期")]

        public DateTime? Mi016 { get; set; }

        //[ExcelColumn(Name = "直接原因")]
        [ExcelColumnName("直接原因")]

        public string Mi017 { get; set; }

        //[ExcelColumn(Name = "间接原因")]
        [ExcelColumnName("间接原因")]

        public string Mi018 { get; set; }

        //[ExcelColumn(Name = "处置")]
        [ExcelColumnName("处置")]

        public string Mi019 { get; set; }

        //[ExcelColumn(Name = "直接对策")]
        [ExcelColumnName("直接对策")]

        public string Mi020 { get; set; }

        //[ExcelColumn(Name = "间接对策")]
        [ExcelColumnName("间接对策")]

        public string Mi021 { get; set; }

        //[ExcelColumn(Name = "检证人员")]
        [ExcelColumnName("检证人员")]

        public string Mi022 { get; set; }

        //[ExcelColumn(Name = "实施日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("实施日期")]

        public DateTime? Mi023 { get; set; }

        [Required(ErrorMessage = "实施查证不能为空")]
        //[ExcelColumn(Name = "实施查证")]
        [ExcelColumnName("实施查证")]

        public int Mi024 { get; set; }

        //[ExcelColumn(Name = "对策实施查证")]
        [ExcelColumnName("对策实施查证")]

        public string Mi025 { get; set; }

        //[ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]

        public string Mi026 { get; set; }

        //[ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]

        public string Mi027 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]

        public string Mi028 { get; set; }

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
        public string Mi002Label { get; set; }
        [ExcelColumn(Name = "检查员")]
        public string Mi003Label { get; set; }
        [ExcelColumn(Name = "班组")]
        public string Mi004Label { get; set; }
        [ExcelColumn(Name = "不良级别")]
        public string Mi013Label { get; set; }
        [ExcelColumn(Name = "实施查证")]
        public string Mi024Label { get; set; }
    }

    /// <summary>
    /// 分析对策
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:44:05
    /// </summary>
    public class QmIpvReplyImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mi002 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string Mi003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string Mi004 { get; set; }

        [Required(ErrorMessage = "订单不能为空")]
        //[ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string Mi005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Mi006 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mi007 { get; set; }

        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string Mi008 { get; set; }

        //[ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]
        public DateTime? Mi009 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Mi010 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string Mi011 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal Mi012 { get; set; }

        //[ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string Mi013 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Mi014 { get; set; }

        //[ExcelColumn(Name = "对策人员")]
        [ExcelColumnName("对策人员")]
        public string Mi015 { get; set; }

        //[ExcelColumn(Name = "对应日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("对应日期")]
        public DateTime? Mi016 { get; set; }

        //[ExcelColumn(Name = "直接原因")]
        [ExcelColumnName("直接原因")]
        public string Mi017 { get; set; }

        //[ExcelColumn(Name = "间接原因")]
        [ExcelColumnName("间接原因")]
        public string Mi018 { get; set; }

        //[ExcelColumn(Name = "处置")]
        [ExcelColumnName("处置")]
        public string Mi019 { get; set; }

        //[ExcelColumn(Name = "直接对策")]
        [ExcelColumnName("直接对策")]
        public string Mi020 { get; set; }

        //[ExcelColumn(Name = "间接对策")]
        [ExcelColumnName("间接对策")]
        public string Mi021 { get; set; }

        //[ExcelColumn(Name = "检证人员")]
        [ExcelColumnName("检证人员")]
        public string Mi022 { get; set; }

        //[ExcelColumn(Name = "实施日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("实施日期")]
        public DateTime? Mi023 { get; set; }

        [Required(ErrorMessage = "实施查证不能为空")]
        //[ExcelColumn(Name = "实施查证")]
        [ExcelColumnName("实施查证")]
        public int Mi024 { get; set; }

        //[ExcelColumn(Name = "对策实施查证")]
        [ExcelColumnName("对策实施查证")]
        public string Mi025 { get; set; }

        //[ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string Mi026 { get; set; }

        //[ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]
        public string Mi027 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string Mi028 { get; set; }

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
        public string Mi002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检查员")]
        public string Mi003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "班组")]
        public string Mi004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "不良级别")]
        public string Mi013Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "实施查证")]
        public string Mi024Label { get; set; }
    }

}