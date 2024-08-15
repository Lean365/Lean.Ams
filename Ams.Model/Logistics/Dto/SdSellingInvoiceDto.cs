namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 销售凭证
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:36:22
    /// </summary>
    public class SdSellingInvoiceQueryDto : PagerInfo
    {
        public string SsiPlnt { get; set; }
        public string SsiFy { get; set; }
        public string SsiYm { get; set; }
        public string SsiCustomercode { get; set; }
        public string SsiPrctr { get; set; }
        public string SsiSalesitem { get; set; }
        public string SsiOriginalccy { get; set; }
        public DateTime? BeginSsiPostingdate { get; set; }
        public DateTime? EndSsiPostingdate { get; set; }
    }

    /// <summary>
    /// 销售凭证
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:36:22
    /// </summary>
    public class SdSellingInvoiceDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SsiSfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string SsiPlnt { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string SsiFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string SsiYm { get; set; }

        [Required(ErrorMessage = "销售凭证不能为空")]
        [ExcelColumn(Name = "销售凭证")]
        [ExcelColumnName("销售凭证")]
        public string SsiAccdocno { get; set; }

        [Required(ErrorMessage = "凭证明细不能为空")]
        [ExcelColumn(Name = "凭证明细")]
        [ExcelColumnName("凭证明细")]
        public string SsiAccdoclineno { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        [ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string SsiCustomercode { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string SsiPrctr { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string SsiSalesitem { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string SsiAccountcode { get; set; }

        [Required(ErrorMessage = "销售数量不能为空")]
        [ExcelColumn(Name = "销售数量")]
        [ExcelColumnName("销售数量")]
        public decimal SsiSalesqty { get; set; }

        [Required(ErrorMessage = "销售单位不能为空")]
        [ExcelColumn(Name = "销售单位")]
        [ExcelColumnName("销售单位")]
        public string SsiSalesunit { get; set; }

        [Required(ErrorMessage = "原币销售额不能为空")]
        [ExcelColumn(Name = "原币销售额")]
        [ExcelColumnName("原币销售额")]
        public decimal SsiOriginalamount { get; set; }

        [Required(ErrorMessage = "原币币种不能为空")]
        [ExcelColumn(Name = "原币币种")]
        [ExcelColumnName("原币币种")]
        public string SsiOriginalccy { get; set; }

        [Required(ErrorMessage = "本币销售额不能为空")]
        [ExcelColumn(Name = "本币销售额")]
        [ExcelColumnName("本币销售额")]
        public decimal SsiLocalamount { get; set; }

        [Required(ErrorMessage = "本币币种不能为空")]
        [ExcelColumn(Name = "本币币种")]
        [ExcelColumnName("本币币种")]
        public string SsiLocalccy { get; set; }

        [Required(ErrorMessage = "参考凭证不能为空")]
        [ExcelColumn(Name = "参考凭证")]
        [ExcelColumnName("参考凭证")]
        public string SsiRefdocno { get; set; }

        [Required(ErrorMessage = "参考明细不能为空")]
        [ExcelColumn(Name = "参考明细")]
        [ExcelColumnName("参考明细")]
        public string SsiRefdoclineno { get; set; }

        [Required(ErrorMessage = "过账日期不能为空")]
        [ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("过账日期")]
        public DateTime? SsiPostingdate { get; set; }

        [Required(ErrorMessage = "用户不能为空")]
        [ExcelColumn(Name = "用户")]
        [ExcelColumnName("用户")]
        public string SsiPostinguser { get; set; }

        [Required(ErrorMessage = "输入日期不能为空")]
        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日期")]
        public DateTime? SsiEntrydate { get; set; }

        [Required(ErrorMessage = "输入时间不能为空")]
        [ExcelColumn(Name = "输入时间")]
        [ExcelColumnName("输入时间")]
        public string SsiEntrytime { get; set; }

        [Required(ErrorMessage = "来源不能为空")]
        [ExcelColumn(Name = "来源")]
        [ExcelColumnName("来源")]
        public string SsiOrigin { get; set; }

        [Required(ErrorMessage = "产品组不能为空")]
        [ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]
        public string SsiPgroup { get; set; }

        [Required(ErrorMessage = "凭证类型不能为空")]
        [ExcelColumn(Name = "凭证类型")]
        [ExcelColumnName("凭证类型")]
        public string SsiAccdoctype { get; set; }

        [Required(ErrorMessage = "凭证名称不能为空")]
        [ExcelColumn(Name = "凭证名称")]
        [ExcelColumnName("凭证名称")]
        public string SsiAccdoctext { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string SsiPlntLabel { get; set; }

        [ExcelColumn(Name = "期间")]
        public string SsiFyLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string SsiYmLabel { get; set; }

        [ExcelColumn(Name = "客户")]
        public string SsiCustomercodeLabel { get; set; }

        [ExcelColumn(Name = "利润中心")]
        public string SsiPrctrLabel { get; set; }

        [ExcelColumn(Name = "原币币种")]
        public string SsiOriginalccyLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 销售凭证
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:36:22
    /// </summary>
    public class SdSellingInvoiceImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SsiSfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string SsiPlnt { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string SsiFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string SsiYm { get; set; }

        [Required(ErrorMessage = "销售凭证不能为空")]
        [ExcelColumn(Name = "销售凭证")]
        [ExcelColumnName("销售凭证")]
        public string SsiAccdocno { get; set; }

        [Required(ErrorMessage = "凭证明细不能为空")]
        [ExcelColumn(Name = "凭证明细")]
        [ExcelColumnName("凭证明细")]
        public string SsiAccdoclineno { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        [ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string SsiCustomercode { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string SsiPrctr { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string SsiSalesitem { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string SsiAccountcode { get; set; }

        [Required(ErrorMessage = "销售数量不能为空")]
        [ExcelColumn(Name = "销售数量")]
        [ExcelColumnName("销售数量")]
        public decimal SsiSalesqty { get; set; }

        [Required(ErrorMessage = "销售单位不能为空")]
        [ExcelColumn(Name = "销售单位")]
        [ExcelColumnName("销售单位")]
        public string SsiSalesunit { get; set; }

        [Required(ErrorMessage = "原币销售额不能为空")]
        [ExcelColumn(Name = "原币销售额")]
        [ExcelColumnName("原币销售额")]
        public decimal SsiOriginalamount { get; set; }

        [Required(ErrorMessage = "原币币种不能为空")]
        [ExcelColumn(Name = "原币币种")]
        [ExcelColumnName("原币币种")]
        public string SsiOriginalccy { get; set; }

        [Required(ErrorMessage = "本币销售额不能为空")]
        [ExcelColumn(Name = "本币销售额")]
        [ExcelColumnName("本币销售额")]
        public decimal SsiLocalamount { get; set; }

        [Required(ErrorMessage = "本币币种不能为空")]
        [ExcelColumn(Name = "本币币种")]
        [ExcelColumnName("本币币种")]
        public string SsiLocalccy { get; set; }

        [Required(ErrorMessage = "参考凭证不能为空")]
        [ExcelColumn(Name = "参考凭证")]
        [ExcelColumnName("参考凭证")]
        public string SsiRefdocno { get; set; }

        [Required(ErrorMessage = "参考明细不能为空")]
        [ExcelColumn(Name = "参考明细")]
        [ExcelColumnName("参考明细")]
        public string SsiRefdoclineno { get; set; }

        [Required(ErrorMessage = "过账日期不能为空")]
        [ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("过账日期")]
        public DateTime? SsiPostingdate { get; set; }

        [Required(ErrorMessage = "用户不能为空")]
        [ExcelColumn(Name = "用户")]
        [ExcelColumnName("用户")]
        public string SsiPostinguser { get; set; }

        [Required(ErrorMessage = "输入日期不能为空")]
        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日期")]
        public DateTime? SsiEntrydate { get; set; }

        [Required(ErrorMessage = "输入时间不能为空")]
        [ExcelColumn(Name = "输入时间")]
        [ExcelColumnName("输入时间")]
        public string SsiEntrytime { get; set; }

        [Required(ErrorMessage = "来源不能为空")]
        [ExcelColumn(Name = "来源")]
        [ExcelColumnName("来源")]
        public string SsiOrigin { get; set; }

        [Required(ErrorMessage = "产品组不能为空")]
        [ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]
        public string SsiPgroup { get; set; }

        [Required(ErrorMessage = "凭证类型不能为空")]
        [ExcelColumn(Name = "凭证类型")]
        [ExcelColumnName("凭证类型")]
        public string SsiAccdoctype { get; set; }

        [Required(ErrorMessage = "凭证名称不能为空")]
        [ExcelColumn(Name = "凭证名称")]
        [ExcelColumnName("凭证名称")]
        public string SsiAccdoctext { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string SsiPlntLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string SsiFyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string SsiYmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "客户")]
        public string SsiCustomercodeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "利润中心")]
        public string SsiPrctrLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "原币币种")]
        public string SsiOriginalccyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}