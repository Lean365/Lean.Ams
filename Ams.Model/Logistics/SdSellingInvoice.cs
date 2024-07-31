namespace Ams.Model.Logistics
{
    /// <summary>
    /// 销售凭证
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:36:22
    /// </summary>
    [SugarTable("sd_selling_invoice", "销售凭证")]
    public class SdSellingInvoice : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "ssi_SfId")]
        public long SsiSfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "ssi_Plnt")]
        public string SsiPlnt { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "ssi_Fy")]
        public string SsiFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "ssi_Ym")]
        public string SsiYm { get; set; }

        /// <summary>
        /// 销售凭证
        /// </summary>
        [SugarColumn(ColumnName = "ssi_AccDocNo")]
        public string SsiAccdocno { get; set; }

        /// <summary>
        /// 凭证明细
        /// </summary>
        [SugarColumn(ColumnName = "ssi_AccDocLineNo")]
        public string SsiAccdoclineno { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [SugarColumn(ColumnName = "ssi_CustomerCode")]
        public string SsiCustomercode { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "ssi_Prctr")]
        public string SsiPrctr { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "ssi_SalesItem")]
        public string SsiSalesitem { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "ssi_AccountCode")]
        public string SsiAccountcode { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        [SugarColumn(ColumnName = "ssi_SalesQty")]
        public decimal SsiSalesqty { get; set; }

        /// <summary>
        /// 销售单位
        /// </summary>
        [SugarColumn(ColumnName = "ssi_SalesUnit")]
        public string SsiSalesunit { get; set; }

        /// <summary>
        /// 原币销售额
        /// </summary>
        [SugarColumn(ColumnName = "ssi_OriginalAmount")]
        public decimal SsiOriginalamount { get; set; }

        /// <summary>
        /// 原币币种
        /// </summary>
        [SugarColumn(ColumnName = "ssi_OriginalCcy")]
        public string SsiOriginalccy { get; set; }

        /// <summary>
        /// 本币销售额
        /// </summary>
        [SugarColumn(ColumnName = "ssi_LocalAmount")]
        public decimal SsiLocalamount { get; set; }

        /// <summary>
        /// 本币币种
        /// </summary>
        [SugarColumn(ColumnName = "ssi_LocalCcy")]
        public string SsiLocalccy { get; set; }

        /// <summary>
        /// 参考凭证
        /// </summary>
        [SugarColumn(ColumnName = "ssi_RefDocNo")]
        public string SsiRefdocno { get; set; }

        /// <summary>
        /// 参考明细
        /// </summary>
        [SugarColumn(ColumnName = "ssi_RefDocLineNo")]
        public string SsiRefdoclineno { get; set; }

        /// <summary>
        /// 过账日期
        /// </summary>
        [SugarColumn(ColumnName = "ssi_PostingDate")]
        public DateTime? SsiPostingdate { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        [SugarColumn(ColumnName = "ssi_PostingUser")]
        public string SsiPostinguser { get; set; }

        /// <summary>
        /// 输入日期
        /// </summary>
        [SugarColumn(ColumnName = "ssi_EntryDate")]
        public DateTime? SsiEntrydate { get; set; }

        /// <summary>
        /// 输入时间
        /// </summary>
        [SugarColumn(ColumnName = "ssi_EntryTime")]
        public string SsiEntrytime { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [SugarColumn(ColumnName = "ssi_Origin")]
        public string SsiOrigin { get; set; }

        /// <summary>
        /// 产品组
        /// </summary>
        [SugarColumn(ColumnName = "ssi_Pgroup")]
        public string SsiPgroup { get; set; }

        /// <summary>
        /// 凭证类型
        /// </summary>
        [SugarColumn(ColumnName = "ssi_AccDocType")]
        public string SsiAccdoctype { get; set; }

        /// <summary>
        /// 凭证名称
        /// </summary>
        [SugarColumn(ColumnName = "ssi_AccDocText")]
        public string SsiAccdoctext { get; set; }
    }
}