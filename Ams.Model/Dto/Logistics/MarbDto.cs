
namespace Ams.Model.Dto
{
    /// <summary>
    /// 物料信息
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 11:34:57)
    /// </summary>
    public class MarbQueryDto : PagerInfo 
    {
        public string MmPlnt { get; set; }
        public string MmMatItem { get; set; }
        public string MmIndustry { get; set; }
        public string MmMatType { get; set; }
        public string MmMatDes { get; set; }
        public string MmBaseUnit { get; set; }
        public string MmMatGroup { get; set; }
        public string MmPurGroup { get; set; }
        public string MmPurType { get; set; }
        public string MmSpecType { get; set; }
        public string MmBulkMat { get; set; }
        public string MmisChecked { get; set; }
        public string MmProfitCenter { get; set; }
        public string MmisLot { get; set; }
        public string MmValType { get; set; }
        public string MmCcy { get; set; }
        public int? MmPriceUnit { get; set; }
        public string MmSLoc { get; set; }
        public string MmESLoc { get; set; }
        public string MmLocPosn { get; set; }
        public string MmLocEol { get; set; }
    }

    /// <summary>
    /// 物料信息
    /// 输入输出对象
    /// </summary>
    public class MarbDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MmSFID { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string MmPlnt { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MmMatItem { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string MmIndustry { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        [ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string MmMatType { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string MmMatDes { get; set; }

        [Required(ErrorMessage = "标准单位不能为空")]
        [ExcelColumn(Name = "标准单位")]
        [ExcelColumnName("标准单位")]
        public string MmBaseUnit { get; set; }

        [ExcelColumn(Name = "层次")]
        [ExcelColumnName("层次")]
        public string MmProLevel { get; set; }

        [Required(ErrorMessage = "物料组不能为空")]
        [ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string MmMatGroup { get; set; }

        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string MmPurGroup { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string MmPurType { get; set; }

        [ExcelColumn(Name = "特殊采购类")]
        [ExcelColumnName("特殊采购类")]
        public string MmSpecType { get; set; }

        [ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]
        public string MmBulkMat { get; set; }

        [Required(ErrorMessage = "最小批量不能为空")]
        [ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public int MmMoq { get; set; }

        [Required(ErrorMessage = "舍入值不能为空")]
        [ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]
        public int MmRoundingVal { get; set; }

        [Required(ErrorMessage = "交货时间不能为空")]
        [ExcelColumn(Name = "交货时间")]
        [ExcelColumnName("交货时间")]
        public int MmLeadTime { get; set; }

        [Required(ErrorMessage = "生产天数不能为空")]
        [ExcelColumn(Name = "生产天数")]
        [ExcelColumnName("生产天数")]
        public decimal MmProDays { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string MmisChecked { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string MmProfitCenter { get; set; }

        [ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string MmDiffCode { get; set; }

        [ExcelColumn(Name = "批次管理")]
        [ExcelColumnName("批次管理")]
        public string MmisLot { get; set; }

        [ExcelColumn(Name = "制造商物料")]
        [ExcelColumnName("制造商物料")]
        public string MmMpn { get; set; }

        [ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]
        public string MmMfrs { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string MmValType { get; set; }

        [Required(ErrorMessage = "移动平均价不能为空")]
        [ExcelColumn(Name = "移动平均价")]
        [ExcelColumnName("移动平均价")]
        public decimal MmMovingAvg { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string MmCcy { get; set; }

        [Required(ErrorMessage = "价格控制不能为空")]
        [ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string MmPriceControl { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public int MmPriceUnit { get; set; }

        [ExcelColumn(Name = "采购仓库")]
        [ExcelColumnName("采购仓库")]
        public string MmSLoc { get; set; }

        [ExcelColumn(Name = "生产仓库")]
        [ExcelColumnName("生产仓库")]
        public string MmESLoc { get; set; }

        [ExcelColumn(Name = "仓位")]
        [ExcelColumnName("仓位")]
        public string MmLocPosn { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        [ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal MmInventory { get; set; }

        [ExcelColumn(Name = "EOL")]
        [ExcelColumnName("EOL")]
        public string MmLocEol { get; set; }

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
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string MmPlntLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "行业类别")]
        public string MmIndustryLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料类型")]
        public string MmMatTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "标准单位")]
        public string MmBaseUnitLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料组")]
        public string MmMatGroupLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string MmPurGroupLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购类型")]
        public string MmPurTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "特殊采购类")]
        public string MmSpecTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "散装物料")]
        public string MmBulkMatLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "利润中心")]
        public string MmProfitCenterLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "评估类")]
        public string MmValTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string MmCcyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购仓库")]
        public string MmSLocLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "仓位")]
        public string MmLocPosnLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "EOL")]
        public string MmLocEolLabel { get; set; }
    }
}