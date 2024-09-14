
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 序列号扫描
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:36:33
    /// </summary>
    public class QmSerialQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 序列号扫描
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:36:33
    /// </summary>
    public class QmSerialDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]

        public long Id { get; set; }

        //[ExcelColumn(Name = "入库序列号")]
        [ExcelColumnName("入库序列号")]

        public string Mk002 { get; set; }

        //[ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]

        public DateTime? Mk003 { get; set; }

        [Required(ErrorMessage = "入库数量不能为空")]
        //[ExcelColumn(Name = "入库数量")]
        [ExcelColumnName("入库数量")]

        public int Mk004 { get; set; }

        //[ExcelColumn(Name = "HinName")]
        [ExcelColumnName("HinName")]

        public string Mk005 { get; set; }

        //[ExcelColumn(Name = "HinIp")]
        [ExcelColumnName("HinIp")]

        public string Mk006 { get; set; }

        //[ExcelColumn(Name = "HinMac")]
        [ExcelColumnName("HinMac")]

        public string Mk007 { get; set; }

        //[ExcelColumn(Name = "入库扫描")]
        [ExcelColumnName("入库扫描")]

        public string Mk008 { get; set; }

        //[ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]

        public DateTime? Mk009 { get; set; }

        //[ExcelColumn(Name = "出货发票")]
        [ExcelColumnName("出货发票")]

        public string Mk010 { get; set; }

        //[ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]

        public string Mk011 { get; set; }

        //[ExcelColumn(Name = "出库序列号")]
        [ExcelColumnName("出库序列号")]

        public string Mk012 { get; set; }

        //[ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]

        public DateTime? Mk013 { get; set; }

        [Required(ErrorMessage = "出库数量不能为空")]
        //[ExcelColumn(Name = "出库数量")]
        [ExcelColumnName("出库数量")]

        public int Mk014 { get; set; }

        //[ExcelColumn(Name = "区域仕向")]
        [ExcelColumnName("区域仕向")]

        public string Mk015 { get; set; }

        //[ExcelColumn(Name = "HouName")]
        [ExcelColumnName("HouName")]

        public string Mk016 { get; set; }

        //[ExcelColumn(Name = "HouIp")]
        [ExcelColumnName("HouIp")]

        public string Mk017 { get; set; }

        //[ExcelColumn(Name = "HouMac")]
        [ExcelColumnName("HouMac")]

        public string Mk018 { get; set; }

        //[ExcelColumn(Name = "出库扫描")]
        [ExcelColumnName("出库扫描")]

        public string Mk019 { get; set; }

        //[ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]

        public DateTime? Mk020 { get; set; }

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

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string QsWerks { get; set; }



    }

    /// <summary>
    /// 序列号扫描
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:36:33
    /// </summary>
    public class QmSerialImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long Id { get; set; }

        //[ExcelColumn(Name = "入库序列号")]
        [ExcelColumnName("入库序列号")]
        public string Mk002 { get; set; }

        //[ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]
        public DateTime? Mk003 { get; set; }

        [Required(ErrorMessage = "入库数量不能为空")]
        //[ExcelColumn(Name = "入库数量")]
        [ExcelColumnName("入库数量")]
        public int Mk004 { get; set; }

        //[ExcelColumn(Name = "HinName")]
        [ExcelColumnName("HinName")]
        public string Mk005 { get; set; }

        //[ExcelColumn(Name = "HinIp")]
        [ExcelColumnName("HinIp")]
        public string Mk006 { get; set; }

        //[ExcelColumn(Name = "HinMac")]
        [ExcelColumnName("HinMac")]
        public string Mk007 { get; set; }

        //[ExcelColumn(Name = "入库扫描")]
        [ExcelColumnName("入库扫描")]
        public string Mk008 { get; set; }

        //[ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]
        public DateTime? Mk009 { get; set; }

        //[ExcelColumn(Name = "出货发票")]
        [ExcelColumnName("出货发票")]
        public string Mk010 { get; set; }

        //[ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]
        public string Mk011 { get; set; }

        //[ExcelColumn(Name = "出库序列号")]
        [ExcelColumnName("出库序列号")]
        public string Mk012 { get; set; }

        //[ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]
        public DateTime? Mk013 { get; set; }

        [Required(ErrorMessage = "出库数量不能为空")]
        //[ExcelColumn(Name = "出库数量")]
        [ExcelColumnName("出库数量")]
        public int Mk014 { get; set; }

        //[ExcelColumn(Name = "区域仕向")]
        [ExcelColumnName("区域仕向")]
        public string Mk015 { get; set; }

        //[ExcelColumn(Name = "HouName")]
        [ExcelColumnName("HouName")]
        public string Mk016 { get; set; }

        //[ExcelColumn(Name = "HouIp")]
        [ExcelColumnName("HouIp")]
        public string Mk017 { get; set; }

        //[ExcelColumn(Name = "HouMac")]
        [ExcelColumnName("HouMac")]
        public string Mk018 { get; set; }

        //[ExcelColumn(Name = "出库扫描")]
        [ExcelColumnName("出库扫描")]
        public string Mk019 { get; set; }

        //[ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]
        public DateTime? Mk020 { get; set; }

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

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string QsWerks { get; set; }



    }

}