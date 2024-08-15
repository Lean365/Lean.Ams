namespace Ams.Model.Accounting
{
    /// <summary>
    /// 利润中心
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 14:40:21
    /// </summary>
    [SugarTable("fico_profit_center", "利润中心")]
    public class FicoProfitCenter : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FpSfId { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Mandt", ColumnDescription = "集团   ", Length = 3)]
        public string Mandt { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Prctr", ColumnDescription = "利润中心   ", Length = 10)]
        public string Prctr { get; set; }

        /// <summary>
        /// 控制范围
        /// </summary>
        [SugarColumn(ColumnName = "Kokrs", ColumnDescription = "控制范围   ", Length = 4)]
        public string Kokrs { get; set; }

        /// <summary>
        /// 开始生效日期
        /// </summary>
        public DateTime? Datab { get; set; }

        /// <summary>
        /// 有效截至日期
        /// </summary>
        public DateTime? Datbi { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "Abtei", ColumnDescription = "部门   ", DefaultValue = "0")]
        public int? Abtei { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [SugarColumn(ColumnName = "Verak", ColumnDescription = "负责人   ", Length = 40)]
        public string Verak { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
        [SugarColumn(ColumnName = "Waers", ColumnDescription = "货币   ", Length = 3)]
        public string Waers { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Stext", ColumnDescription = "名称   ", Length = 40)]
        public string Stext { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Ltext", ColumnDescription = "长文本   ", Length = 80)]
        public string Ltext { get; set; }

        /// <summary>
        /// 利润中心说明
        /// </summary>
        [SugarColumn(ColumnName = "Atext", ColumnDescription = "利润中心说明   ", Length = 120)]
        public string Atext { get; set; }

        /// <summary>
        /// 利润中心组
        /// </summary>
        [SugarColumn(ColumnName = "Khinr", ColumnDescription = "利润中心组   ", Length = 12)]
        public string Khinr { get; set; }

        /// <summary>
        /// 权益类型
        /// </summary>
        [SugarColumn(ColumnName = "Etype", ColumnDescription = "权益类型   ", Length = 3)]
        public string Etype { get; set; }

        /// <summary>
        /// 地区税务代码
        /// </summary>
        [SugarColumn(ColumnName = "Txjcd", ColumnDescription = "地区税务代码   ", Length = 15)]
        public string Txjcd { get; set; }

        /// <summary>
        /// 锁定标记
        /// </summary>
        [SugarColumn(ColumnName = "LockInd", ColumnDescription = "锁定标记   ", DefaultValue = "0")]
        public int? LockInd { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "Tstate", ColumnDescription = "状态   ", DefaultValue = "0")]
        public int? Tstate { get; set; }
    }
}