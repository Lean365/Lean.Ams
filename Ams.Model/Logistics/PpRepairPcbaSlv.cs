namespace Ams.Model.Logistics
{
    /// <summary>
    /// 修理日报slv
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:03:40
    /// </summary>
    [SugarTable("pp_repair_pcba_slv", "修理日报slv")]
    public class PpRepairPcbaSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PdrSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdrParentSfId { get; set; }

        /// <summary>
        /// Pdrlot
        /// </summary>
        [SugarColumn(ColumnName = "Pdrlot", ColumnDescription = "Pdrlot ", Length = 20)]
        public string Pdrlot { get; set; }

        /// <summary>
        /// 板别
        /// </summary>
        [SugarColumn(ColumnName = "Pdrpcbtype", ColumnDescription = "板别 ", Length = 30)]
        public string Pdrpcbtype { get; set; }

        /// <summary>
        /// Lot数
        /// </summary>
        [SugarColumn(ColumnName = "Pdrlotqty", ColumnDescription = "Lot数 ", DefaultValue = "0")]
        public int? Pdrlotqty { get; set; }

        /// <summary>
        /// 当日生产数
        /// </summary>
        [SugarColumn(ColumnName = "Pdrrealqty", ColumnDescription = "当日生产数 ", DefaultValue = "0")]
        public int Pdrrealqty { get; set; }

        /// <summary>
        /// 累计完成数
        /// </summary>
        [SugarColumn(ColumnName = "Pdrrealtotal", ColumnDescription = "累计完成数 ", DefaultValue = "0")]
        public int Pdrrealtotal { get; set; }

        /// <summary>
        /// 生产组别
        /// </summary>
        [SugarColumn(ColumnName = "Pdrlinename", ColumnDescription = "生产组别 ", Length = 20)]
        public string Pdrlinename { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        [SugarColumn(ColumnName = "Pdrpcbcardno", ColumnDescription = "卡号 ", Length = 30)]
        public string Pdrpcbcardno { get; set; }

        /// <summary>
        /// 不良症状
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadnote", ColumnDescription = "不良症状 ", Length = 200)]
        public string Pdrbadnote { get; set; }

        /// <summary>
        /// 检出工程
        /// </summary>
        [SugarColumn(ColumnName = "Pdrpcbcheckout", ColumnDescription = "检出工程 ", Length = 30)]
        public string Pdrpcbcheckout { get; set; }

        /// <summary>
        /// 不良原因
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadreason", ColumnDescription = "不良原因 ", Length = 200)]
        public string Pdrbadreason { get; set; }

        /// <summary>
        /// 不良数量
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadqty", ColumnDescription = "不良数量 ", DefaultValue = "0")]
        public int Pdrbadqty { get; set; }

        /// <summary>
        /// 累计不良台数
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadtotal", ColumnDescription = "累计不良台数 ", DefaultValue = "0")]
        public int Pdrbadtotal { get; set; }

        /// <summary>
        /// 责任归属
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadresponsibility", ColumnDescription = "责任归属 ", Length = 200)]
        public string Pdrbadresponsibility { get; set; }

        /// <summary>
        /// 不良性质
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadprop", ColumnDescription = "不良性质 ", Length = 200)]
        public string Pdrbadprop { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadserial", ColumnDescription = "序列号 ", Length = 200)]
        public string Pdrbadserial { get; set; }

        /// <summary>
        /// 修理
        /// </summary>
        [SugarColumn(ColumnName = "Pdrbadrepairman", ColumnDescription = "修理 ", Length = 200)]
        public string Pdrbadrepairman { get; set; }
    }
}