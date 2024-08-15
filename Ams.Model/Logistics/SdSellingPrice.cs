namespace Ams.Model.Logistics
{
    /// <summary>
    /// 销售价格
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 10:59:46
    /// </summary>
    [SugarTable("sd_selling_price", "销售价格")]
    public class SdSellingPrice : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "ssp_SfId")]
        public long SspSfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "ssp_Plnt")]
        public string SspPlnt { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "ssp_Fy")]
        public string SspFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "ssp_Ym")]
        public string SspYm { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "ssp_Item")]
        public string SspItem { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "ssp_ItemText")]
        public string SspItemtext { get; set; }

        /// <summary>
        /// 原币价格
        /// </summary>
        [SugarColumn(ColumnName = "ssp_OriginalFob")]
        public decimal SspOriginalfob { get; set; }

        /// <summary>
        /// 原币种
        /// </summary>
        [SugarColumn(ColumnName = "ssp_OriginalCcy")]
        public string SspOriginalccy { get; set; }

        /// <summary>
        /// 原币Per单位
        /// </summary>
        [SugarColumn(ColumnName = "ssp_OriginalPerUnit")]
        public int SspOriginalperunit { get; set; }

        /// <summary>
        /// 原币利润中心
        /// </summary>
        [SugarColumn(ColumnName = "ssp_OriginalPrctr")]
        public string SspOriginalprctr { get; set; }

        /// <summary>
        /// 本币价格
        /// </summary>
        [SugarColumn(ColumnName = "ssp_LocalFob")]
        public decimal SspLocalfob { get; set; }

        /// <summary>
        /// 本币种
        /// </summary>
        [SugarColumn(ColumnName = "ssp_LocalCcy")]
        public string SspLocalccy { get; set; }

        /// <summary>
        /// 本币Per单位
        /// </summary>
        [SugarColumn(ColumnName = "ssp_LocalPerUnit")]
        public int SspLocalperunit { get; set; }

        /// <summary>
        /// 本币利润中心
        /// </summary>
        [SugarColumn(ColumnName = "ssp_LocalPrctr")]
        public string SspLocalprctr { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        [SugarColumn(ColumnName = "ssp_EffDate")]
        public DateTime? SspEffdate { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        [SugarColumn(ColumnName = "ssp_ExpDate")]
        public DateTime? SspExpdate { get; set; }
    }
}