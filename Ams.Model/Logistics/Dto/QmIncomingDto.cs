
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 进料检验
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:45:51
    /// </summary>
    public class QmIncomingQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mf002 { get; set; }
        /// <summary>
        /// 采购订单 
        /// </summary>        
        public string Mf003 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mf004 { get; set; }
        /// <summary>
        /// 检验日期 
        /// </summary>        
        public DateTime? BeginMf008 { get; set; }
        public DateTime? EndMf008 { get; set; }
    }

    /// <summary>
    /// 进料检验
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:45:51
    /// </summary>
    public class QmIncomingDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mf002 { get; set; }

        [Required(ErrorMessage = "采购订单不能为空")]
        //[ExcelColumn(Name = "采购订单")]
        [ExcelColumnName("采购订单")]

        public string Mf003 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mf004 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public decimal Mf005 { get; set; }

        //[ExcelColumn(Name = "进货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("进货日期")]

        public DateTime? Mf006 { get; set; }

        //[ExcelColumn(Name = "检验员")]
        [ExcelColumnName("检验员")]

        public string Mf007 { get; set; }

        //[ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]

        public DateTime? Mf008 { get; set; }

        //[ExcelColumn(Name = "检验项目")]
        [ExcelColumnName("检验项目")]

        public string Mf009 { get; set; }

        //[ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]

        public string Mf010 { get; set; }

        //[ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]

        public string Mf011 { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        //[ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]

        public decimal Mf012 { get; set; }

        //[ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]

        public string Mf013 { get; set; }

        //[ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]

        public string Mf014 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]

        public decimal Mf015 { get; set; }

        //[ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]

        public string Mf016 { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        //[ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]

        public decimal Mf017 { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        //[ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]

        public int Mf018 { get; set; }

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
        public string Mf002Label { get; set; }
        [ExcelColumn(Name = "采购订单")]
        public string Mf003Label { get; set; }
        [ExcelColumn(Name = "检验员")]
        public string Mf007Label { get; set; }
        [ExcelColumn(Name = "检验项目")]
        public string Mf009Label { get; set; }
        [ExcelColumn(Name = "检验水准")]
        public string Mf010Label { get; set; }
        [ExcelColumn(Name = "检验方式")]
        public string Mf011Label { get; set; }
        [ExcelColumn(Name = "判定")]
        public string Mf013Label { get; set; }
        [ExcelColumn(Name = "不良级别")]
        public string Mf014Label { get; set; }
    }

    /// <summary>
    /// 进料检验
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:45:51
    /// </summary>
    public class QmIncomingImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mf002 { get; set; }

        [Required(ErrorMessage = "采购订单不能为空")]
        //[ExcelColumn(Name = "采购订单")]
        [ExcelColumnName("采购订单")]
        public string Mf003 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mf004 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Mf005 { get; set; }

        //[ExcelColumn(Name = "进货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("进货日期")]
        public DateTime? Mf006 { get; set; }

        //[ExcelColumn(Name = "检验员")]
        [ExcelColumnName("检验员")]
        public string Mf007 { get; set; }

        //[ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]
        public DateTime? Mf008 { get; set; }

        //[ExcelColumn(Name = "检验项目")]
        [ExcelColumnName("检验项目")]
        public string Mf009 { get; set; }

        //[ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]
        public string Mf010 { get; set; }

        //[ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]
        public string Mf011 { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        //[ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public decimal Mf012 { get; set; }

        //[ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]
        public string Mf013 { get; set; }

        //[ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string Mf014 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal Mf015 { get; set; }

        //[ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string Mf016 { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        //[ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]
        public decimal Mf017 { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        //[ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]
        public int Mf018 { get; set; }

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
        public string Mf002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购订单")]
        public string Mf003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验员")]
        public string Mf007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验项目")]
        public string Mf009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验水准")]
        public string Mf010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验方式")]
        public string Mf011Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "判定")]
        public string Mf013Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "不良级别")]
        public string Mf014Label { get; set; }
    }

}