namespace Ams.Model.Logistics
{
    /// <summary>
    /// 检查日报slv
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:22
    /// </summary>
    [SugarTable("pp_insp_pcba_slv", "检查日报slv")]
    public class PpInspPcbaSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PdiSfid { get; set; }

        /// <summary>
        /// PdiParentSfid
        /// </summary>
        public long PdiParentSfid { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Pdilot", ColumnDescription = "批次 ", Length = 20)]
        public string Pdilot { get; set; }

        /// <summary>
        /// Lot数
        /// </summary>
        [SugarColumn(ColumnName = "Pdilotqty", ColumnDescription = "Lot数 ", DefaultValue = "0")]
        public int? Pdilotqty { get; set; }

        /// <summary>
        /// 板别
        /// </summary>
        [SugarColumn(ColumnName = "Pdipcbtype", ColumnDescription = "板别 ", Length = 30)]
        public string Pdipcbtype { get; set; }

        /// <summary>
        /// 目视线别
        /// </summary>
        [SugarColumn(ColumnName = "Pdivisualtype", ColumnDescription = "目视线别 ", Length = 30)]
        public string Pdivisualtype { get; set; }

        /// <summary>
        /// AOI线别
        /// </summary>
        [SugarColumn(ColumnName = "Pdivctype", ColumnDescription = "AOI线别 ", Length = 30)]
        public string Pdivctype { get; set; }

        /// <summary>
        /// B面实装
        /// </summary>
        public DateTime? Pdisideadate { get; set; }

        /// <summary>
        /// T面实装
        /// </summary>
        public DateTime? Pdisidebdate { get; set; }

        /// <summary>
        /// 生产班别
        /// </summary>
        [SugarColumn(ColumnName = "Pdidshiftname", ColumnDescription = "生产班别 ", Length = 20)]
        public string Pdidshiftname { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "Pdicensor", ColumnDescription = "检查员 ", Length = 20)]
        public string Pdicensor { get; set; }

        /// <summary>
        /// 当日完成数
        /// </summary>
        [SugarColumn(ColumnName = "Pdirealqty", ColumnDescription = "当日完成数 ", DefaultValue = "0")]
        public int Pdirealqty { get; set; }

        /// <summary>
        /// 累计完成数
        /// </summary>
        [SugarColumn(ColumnName = "Pdirealtotal", ColumnDescription = "累计完成数 ", DefaultValue = "0")]
        public int Pdirealtotal { get; set; }

        /// <summary>
        /// 检查台数
        /// </summary>
        [SugarColumn(ColumnName = "Pdiispqty", ColumnDescription = "检查台数 ", DefaultValue = "0")]
        public int Pdiispqty { get; set; }

        /// <summary>
        /// 检查状态
        /// </summary>
        [SugarColumn(ColumnName = "Pdipcbchecktype", ColumnDescription = "检查状态 ", Length = 30)]
        public string Pdipcbchecktype { get; set; }

        /// <summary>
        /// 生产线别
        /// </summary>
        [SugarColumn(ColumnName = "Pdilinename", ColumnDescription = "生产线别 ", Length = 20)]
        public string Pdilinename { get; set; }

        /// <summary>
        /// 检查工数
        /// </summary>
        [SugarColumn(ColumnName = "Pdiinsqtime", ColumnDescription = "检查工数 ", DefaultValue = "0")]
        public int Pdiinsqtime { get; set; }

        /// <summary>
        /// AOI工数
        /// </summary>
        [SugarColumn(ColumnName = "Pdiaoitime", ColumnDescription = "AOI工数 ", DefaultValue = "0")]
        public int Pdiaoitime { get; set; }

        /// <summary>
        /// 不良数量
        /// </summary>
        [SugarColumn(ColumnName = "Pdibadqty", ColumnDescription = "不良数量 ", DefaultValue = "0")]
        public int Pdibadqty { get; set; }

        /// <summary>
        /// 手贴部品
        /// </summary>
        [SugarColumn(ColumnName = "Pdihandle", ColumnDescription = "手贴部品 ", Length = 30)]
        public string Pdihandle { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Pdibadserial", ColumnDescription = "序列号 ", Length = 200)]
        public string Pdibadserial { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [SugarColumn(ColumnName = "Pdibadcontent", ColumnDescription = "内容 ", Length = 30)]
        public string Pdibadcontent { get; set; }

        /// <summary>
        /// 个所区分
        /// </summary>
        [SugarColumn(ColumnName = "PdibadPosition", ColumnDescription = "个所区分 ", Length = 200)]
        public string PdibadPosition { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        [SugarColumn(ColumnName = "UDF01", ColumnDescription = "自定义A ", Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        [SugarColumn(ColumnName = "UDF02", ColumnDescription = "自定义B ", Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        [SugarColumn(ColumnName = "UDF03", ColumnDescription = "自定义C ", Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        [SugarColumn(ColumnName = "UDF04", ColumnDescription = "自定义D ", Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        [SugarColumn(ColumnName = "UDF05", ColumnDescription = "自定义E ", Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        [SugarColumn(ColumnName = "UDF06", ColumnDescription = "自定义F ", Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(ColumnName = "UDF51", ColumnDescription = "自定义1 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(ColumnName = "UDF52", ColumnDescription = "自定义2 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(ColumnName = "UDF53", ColumnDescription = "自定义3 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(ColumnName = "UDF54", ColumnDescription = "自定义4 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(ColumnName = "UDF55", ColumnDescription = "自定义5 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(ColumnName = "UDF56", ColumnDescription = "自定义6 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnName = "IsDeleted", ColumnDescription = "软删除 ", DefaultValue = "0")]
        public int IsDeleted { get; set; }
    }
}