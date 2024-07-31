namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 销售价格
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 10:59:46
    /// </summary>
    public class SdSellingPriceQueryDto : PagerInfo
    {
        public string SspPlnt { get; set; }
        public string SspFy { get; set; }
        public string SspYm { get; set; }
        public string SspItem { get; set; }
        public string SspOriginalccy { get; set; }
        public string SspOriginalprctr { get; set; }
        public DateTime? BeginSspExpdate { get; set; }
        public DateTime? EndSspExpdate { get; set; }
    }

    /// <summary>
    /// 销售价格
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 10:59:46
    /// </summary>
    public class SdSellingPriceDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SspSfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string SspPlnt { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string SspFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string SspYm { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string SspItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string SspItemtext { get; set; }

        [Required(ErrorMessage = "原币价格不能为空")]
        [ExcelColumn(Name = "原币价格")]
        [ExcelColumnName("原币价格")]
        public decimal SspOriginalfob { get; set; }

        [Required(ErrorMessage = "原币种不能为空")]
        [ExcelColumn(Name = "原币种")]
        [ExcelColumnName("原币种")]
        public string SspOriginalccy { get; set; }

        [Required(ErrorMessage = "原币Per单位不能为空")]
        [ExcelColumn(Name = "原币Per单位")]
        [ExcelColumnName("原币Per单位")]
        public int SspOriginalperunit { get; set; }

        [Required(ErrorMessage = "原币利润中心不能为空")]
        [ExcelColumn(Name = "原币利润中心")]
        [ExcelColumnName("原币利润中心")]
        public string SspOriginalprctr { get; set; }

        [Required(ErrorMessage = "本币价格不能为空")]
        [ExcelColumn(Name = "本币价格")]
        [ExcelColumnName("本币价格")]
        public decimal SspLocalfob { get; set; }

        [Required(ErrorMessage = "本币种不能为空")]
        [ExcelColumn(Name = "本币种")]
        [ExcelColumnName("本币种")]
        public string SspLocalccy { get; set; }

        [Required(ErrorMessage = "本币Per单位不能为空")]
        [ExcelColumn(Name = "本币Per单位")]
        [ExcelColumnName("本币Per单位")]
        public int SspLocalperunit { get; set; }

        [Required(ErrorMessage = "本币利润中心不能为空")]
        [ExcelColumn(Name = "本币利润中心")]
        [ExcelColumnName("本币利润中心")]
        public string SspLocalprctr { get; set; }

        [Required(ErrorMessage = "生效日期不能为空")]
        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? SspEffdate { get; set; }

        [Required(ErrorMessage = "失效日期不能为空")]
        [ExcelColumn(Name = "失效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("失效日期")]
        public DateTime? SspExpdate { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string SspPlntLabel { get; set; }

        [ExcelColumn(Name = "期间")]
        public string SspFyLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string SspYmLabel { get; set; }

        [ExcelColumn(Name = "原币种")]
        public string SspOriginalccyLabel { get; set; }

        [ExcelColumn(Name = "原币利润中心")]
        public string SspOriginalprctrLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 销售价格
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 10:59:46
    /// </summary>
    public class SdSellingPriceImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SspSfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string SspPlnt { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string SspFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string SspYm { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string SspItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string SspItemtext { get; set; }

        [Required(ErrorMessage = "原币价格不能为空")]
        [ExcelColumn(Name = "原币价格")]
        [ExcelColumnName("原币价格")]
        public decimal SspOriginalfob { get; set; }

        [Required(ErrorMessage = "原币种不能为空")]
        [ExcelColumn(Name = "原币种")]
        [ExcelColumnName("原币种")]
        public string SspOriginalccy { get; set; }

        [Required(ErrorMessage = "原币Per单位不能为空")]
        [ExcelColumn(Name = "原币Per单位")]
        [ExcelColumnName("原币Per单位")]
        public int SspOriginalperunit { get; set; }

        [Required(ErrorMessage = "原币利润中心不能为空")]
        [ExcelColumn(Name = "原币利润中心")]
        [ExcelColumnName("原币利润中心")]
        public string SspOriginalprctr { get; set; }

        [Required(ErrorMessage = "本币价格不能为空")]
        [ExcelColumn(Name = "本币价格")]
        [ExcelColumnName("本币价格")]
        public decimal SspLocalfob { get; set; }

        [Required(ErrorMessage = "本币种不能为空")]
        [ExcelColumn(Name = "本币种")]
        [ExcelColumnName("本币种")]
        public string SspLocalccy { get; set; }

        [Required(ErrorMessage = "本币Per单位不能为空")]
        [ExcelColumn(Name = "本币Per单位")]
        [ExcelColumnName("本币Per单位")]
        public int SspLocalperunit { get; set; }

        [Required(ErrorMessage = "本币利润中心不能为空")]
        [ExcelColumn(Name = "本币利润中心")]
        [ExcelColumnName("本币利润中心")]
        public string SspLocalprctr { get; set; }

        [Required(ErrorMessage = "生效日期不能为空")]
        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? SspEffdate { get; set; }

        [Required(ErrorMessage = "失效日期不能为空")]
        [ExcelColumn(Name = "失效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("失效日期")]
        public DateTime? SspExpdate { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string SspPlntLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string SspFyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string SspYmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "原币种")]
        public string SspOriginalccyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "原币利润中心")]
        public string SspOriginalprctrLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}