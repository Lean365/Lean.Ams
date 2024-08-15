
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 月度存货
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:52:42
    /// </summary>
    public class FicoMonthlyInventoryQueryDto : PagerInfo 
    {
        public string MiLfgja { get; set; }
        public string MiLfmon { get; set; }
        public string MiWerks { get; set; }
        public string MiMatnr { get; set; }
        public string MiBklas { get; set; }
        public string MiWaers { get; set; }
    }

    /// <summary>
    /// 月度存货
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:52:42
    /// </summary>
    public class FicoMonthlyInventoryDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MiSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string MiLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string MiLfmon { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string MiWerks { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MiMatnr { get; set; }

        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string MiBklas { get; set; }

        [ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string MiVprsv { get; set; }

        [ExcelColumn(Name = "移动平均价")]
        [ExcelColumnName("移动平均价")]
        public decimal MiVerpr { get; set; }

        [ExcelColumn(Name = "Per单位")]
        [ExcelColumnName("Per单位")]
        public int? MiPeinh { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string MiWaers { get; set; }

        [ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal MiLbkum { get; set; }

        [ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal MiSalk { get; set; }

        [ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]
        public string MiPresp { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? MiZkdat { get; set; }

        [ExcelColumn(Name = "预留A")]
        [ExcelColumnName("预留A")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B")]
        [ExcelColumnName("预留B")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C")]
        [ExcelColumnName("预留C")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1")]
        [ExcelColumnName("预留1")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2")]
        [ExcelColumnName("预留2")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "期间")]
        public string MiLfgjaLabel { get; set; }
        [ExcelColumn(Name = "年月")]
        public string MiLfmonLabel { get; set; }
        [ExcelColumn(Name = "工厂")]
        public string MiWerksLabel { get; set; }
        [ExcelColumn(Name = "评估类")]
        public string MiBklasLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string MiWaersLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 月度存货
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:52:42
    /// </summary>
    public class FicoMonthlyInventoryImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MiSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string MiLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string MiLfmon { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string MiWerks { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MiMatnr { get; set; }

        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string MiBklas { get; set; }

        [ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string MiVprsv { get; set; }

        [ExcelColumn(Name = "移动平均价")]
        [ExcelColumnName("移动平均价")]
        public decimal MiVerpr { get; set; }

        [ExcelColumn(Name = "Per单位")]
        [ExcelColumnName("Per单位")]
        public int? MiPeinh { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string MiWaers { get; set; }

        [ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal MiLbkum { get; set; }

        [ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal MiSalk { get; set; }

        [ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]
        public string MiPresp { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? MiZkdat { get; set; }

        [ExcelColumn(Name = "预留A")]
        [ExcelColumnName("预留A")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B")]
        [ExcelColumnName("预留B")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C")]
        [ExcelColumnName("预留C")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1")]
        [ExcelColumnName("预留1")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2")]
        [ExcelColumnName("预留2")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        [ExcelColumn(Name = "期间")]
        public string MiLfgjaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string MiLfmonLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string MiWerksLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "评估类")]
        public string MiBklasLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string MiWaersLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}