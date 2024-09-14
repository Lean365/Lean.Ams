
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// PO残清单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:51
    /// </summary>
    public class MmPoResidueQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Me002 { get; set; }
        /// <summary>
        /// 供应商ID 
        /// </summary>        
        public string Me003 { get; set; }
        /// <summary>
        /// 供应商名称 
        /// </summary>        
        public string Me004 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Me005 { get; set; }
        /// <summary>
        /// 交货日期 
        /// </summary>        
        public DateTime? BeginMe007 { get; set; }
        public DateTime? EndMe007 { get; set; }
        /// <summary>
        /// 采购日期 
        /// </summary>        
        public DateTime? BeginMe014 { get; set; }
        public DateTime? EndMe014 { get; set; }
        /// <summary>
        /// PO残发行日期 
        /// </summary>        
        public DateTime? BeginMe020 { get; set; }
        public DateTime? EndMe020 { get; set; }
    }

    /// <summary>
    /// PO残清单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:51
    /// </summary>
    public class MmPoResidueDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]

        public long Id { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Me002 { get; set; }

        //[ExcelColumn(Name = "供应商ID")]
        [ExcelColumnName("供应商ID")]

        public string Me003 { get; set; }

        //[ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]

        public string Me004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Me005 { get; set; }

        //[ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]

        public string Me006 { get; set; }

        //[ExcelColumn(Name = "交货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("交货日期")]

        public DateTime? Me007 { get; set; }

        //[ExcelColumn(Name = "未交")]
        [ExcelColumnName("未交")]

        public decimal Me008 { get; set; }

        //[ExcelColumn(Name = "已交")]
        [ExcelColumnName("已交")]

        public decimal Me009 { get; set; }

        //[ExcelColumn(Name = "订单号")]
        [ExcelColumnName("订单号")]

        public string Me010 { get; set; }

        //[ExcelColumn(Name = "订单明细")]
        [ExcelColumnName("订单明细")]

        public string Me011 { get; set; }

        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]

        public decimal Me012 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]

        public string Me013 { get; set; }

        //[ExcelColumn(Name = "采购日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购日期")]

        public DateTime? Me014 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]

        public string Me015 { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]

        public decimal Me016 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Me017 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]

        public string Me018 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]

        public string Me019 { get; set; }

        //[ExcelColumn(Name = "PO残发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("PO残发行日期")]

        public DateTime? Me020 { get; set; }

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
        public string Me002Label { get; set; }
        [ExcelColumn(Name = "供应商ID")]
        public string Me003Label { get; set; }
    }

    /// <summary>
    /// PO残清单
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:51
    /// </summary>
    public class MmPoResidueImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long Id { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Me002 { get; set; }

        //[ExcelColumn(Name = "供应商ID")]
        [ExcelColumnName("供应商ID")]
        public string Me003 { get; set; }

        //[ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string Me004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Me005 { get; set; }

        //[ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string Me006 { get; set; }

        //[ExcelColumn(Name = "交货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("交货日期")]
        public DateTime? Me007 { get; set; }

        //[ExcelColumn(Name = "未交")]
        [ExcelColumnName("未交")]
        public decimal Me008 { get; set; }

        //[ExcelColumn(Name = "已交")]
        [ExcelColumnName("已交")]
        public decimal Me009 { get; set; }

        //[ExcelColumn(Name = "订单号")]
        [ExcelColumnName("订单号")]
        public string Me010 { get; set; }

        //[ExcelColumn(Name = "订单明细")]
        [ExcelColumnName("订单明细")]
        public string Me011 { get; set; }

        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal Me012 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Me013 { get; set; }

        //[ExcelColumn(Name = "采购日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购日期")]
        public DateTime? Me014 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Me015 { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Me016 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Me017 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string Me018 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Me019 { get; set; }

        //[ExcelColumn(Name = "PO残发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("PO残发行日期")]
        public DateTime? Me020 { get; set; }

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
        public string Me002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "供应商ID")]
        public string Me003Label { get; set; }
    }

}