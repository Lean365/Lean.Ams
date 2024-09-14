
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 出货检验
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:38:43
    /// </summary>
    public class QmOutgoingQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mj002 { get; set; }
        /// <summary>
        /// 生产工单 
        /// </summary>        
        public string Mj003 { get; set; }
        /// <summary>
        /// 班组 
        /// </summary>        
        public string Mj004 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Mj005 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mj006 { get; set; }
        /// <summary>
        /// 批次 
        /// </summary>        
        public string Mj007 { get; set; }
        /// <summary>
        /// 查验日期 
        /// </summary>        
        public DateTime? BeginMj012 { get; set; }
        public DateTime? EndMj012 { get; set; }
    }

    /// <summary>
    /// 出货检验
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:38:43
    /// </summary>
    public class QmOutgoingDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mj002 { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        //[ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]

        public string Mj003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]

        public string Mj004 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Mj005 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mj006 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Mj007 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]

        public string Mj008 { get; set; }

        [Required(ErrorMessage = "送检数量不能为空")]
        //[ExcelColumn(Name = "送检数量")]
        [ExcelColumnName("送检数量")]

        public decimal Mj009 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]

        public DateTime? Mj010 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]

        public string Mj011 { get; set; }

        //[ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]

        public DateTime? Mj012 { get; set; }

        //[ExcelColumn(Name = "检查项目")]
        [ExcelColumnName("检查项目")]

        public string Mj013 { get; set; }

        //[ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]

        public string Mj014 { get; set; }

        //[ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]

        public string Mj015 { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        //[ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]

        public decimal Mj016 { get; set; }

        //[ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]

        public string Mj017 { get; set; }

        //[ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]

        public string Mj018 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]

        public decimal Mj019 { get; set; }

        //[ExcelColumn(Name = "检查号码")]
        [ExcelColumnName("检查号码")]

        public string Mj020 { get; set; }

        //[ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]

        public string Mj021 { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        //[ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]

        public decimal Mj022 { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]

        public decimal Mj023 { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        //[ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]

        public int Mj024 { get; set; }

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
        public string Mj002Label { get; set; }
        [ExcelColumn(Name = "生产工单")]
        public string Mj003Label { get; set; }
        [ExcelColumn(Name = "检查员")]
        public string Mj011Label { get; set; }
        [ExcelColumn(Name = "检验水准")]
        public string Mj014Label { get; set; }
        [ExcelColumn(Name = "检验方式")]
        public string Mj015Label { get; set; }
        [ExcelColumn(Name = "判定")]
        public string Mj017Label { get; set; }
        [ExcelColumn(Name = "不良级别")]
        public string Mj018Label { get; set; }
    }

    /// <summary>
    /// 出货检验
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:38:43
    /// </summary>
    public class QmOutgoingImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mj002 { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        //[ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string Mj003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string Mj004 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Mj005 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mj006 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Mj007 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string Mj008 { get; set; }

        [Required(ErrorMessage = "送检数量不能为空")]
        //[ExcelColumn(Name = "送检数量")]
        [ExcelColumnName("送检数量")]
        public decimal Mj009 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? Mj010 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string Mj011 { get; set; }

        //[ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]
        public DateTime? Mj012 { get; set; }

        //[ExcelColumn(Name = "检查项目")]
        [ExcelColumnName("检查项目")]
        public string Mj013 { get; set; }

        //[ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]
        public string Mj014 { get; set; }

        //[ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]
        public string Mj015 { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        //[ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public decimal Mj016 { get; set; }

        //[ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]
        public string Mj017 { get; set; }

        //[ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string Mj018 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal Mj019 { get; set; }

        //[ExcelColumn(Name = "检查号码")]
        [ExcelColumnName("检查号码")]
        public string Mj020 { get; set; }

        //[ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string Mj021 { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        //[ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]
        public decimal Mj022 { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal Mj023 { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        //[ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]
        public int Mj024 { get; set; }

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
        public string Mj002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产工单")]
        public string Mj003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检查员")]
        public string Mj011Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验水准")]
        public string Mj014Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验方式")]
        public string Mj015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "判定")]
        public string Mj017Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "不良级别")]
        public string Mj018Label { get; set; }
    }

}