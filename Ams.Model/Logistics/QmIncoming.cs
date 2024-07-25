namespace Ams.Model.Logistics
{
    /// <summary>
    /// 进料检验
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:53:50
    /// </summary>
    [SugarTable("qm_incoming", "进料检验")]
    public class QmIncoming : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QminSFID { get; set; }

        /// <summary>
        /// 采购订单
        /// </summary>
        [SugarColumn(ColumnName = "QminPurOrder", ColumnDescription = "采购订单 ", Length = 20)]
        public string QminPurOrder { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "QminMaterial", ColumnDescription = "物料 ", Length = 20)]
        public string QminMaterial { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "QminPurOrderQty", ColumnDescription = "数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QminPurOrderQty { get; set; }

        /// <summary>
        /// 进货日期
        /// </summary>
        public DateTime? QminPurDate { get; set; }

        /// <summary>
        /// 检验员
        /// </summary>
        [SugarColumn(ColumnName = "QminInspector", ColumnDescription = "检验员 ", Length = 20)]
        public string QminInspector { get; set; }

        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? QminCheckDate { get; set; }

        /// <summary>
        /// 检验项目
        /// </summary>
        [SugarColumn(ColumnName = "QminInspectingItem", ColumnDescription = "检验项目 ", Length = 50)]
        public string QminInspectingItem { get; set; }

        /// <summary>
        /// 检验水准
        /// </summary>
        [SugarColumn(ColumnName = "QminSamplingLevel", ColumnDescription = "检验水准 ", Length = 4)]
        public string QminSamplingLevel { get; set; }

        /// <summary>
        /// 检验方式
        /// </summary>
        [SugarColumn(ColumnName = "QminCheckMethod", ColumnDescription = "检验方式 ", Length = 4)]
        public string QminCheckMethod { get; set; }

        /// <summary>
        /// 抽样数
        /// </summary>
        [SugarColumn(ColumnName = "QminSamplingQty", ColumnDescription = "抽样数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QminSamplingQty { get; set; }

        /// <summary>
        /// 判定
        /// </summary>
        [SugarColumn(ColumnName = "QminJudgment", ColumnDescription = "判定 ", Length = 4)]
        public string QminJudgment { get; set; }

        /// <summary>
        /// 不良级别
        /// </summary>
        [SugarColumn(ColumnName = "QminJudgmentLevel", ColumnDescription = "不良级别 ", Length = 10)]
        public string QminJudgmentLevel { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "QminRejectQty", ColumnDescription = "验退数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QminRejectQty { get; set; }

        /// <summary>
        /// 特记事项
        /// </summary>
        [SugarColumn(ColumnName = "QminSpecialNotes", ColumnDescription = "特记事项 ", Length = 500)]
        public string QminSpecialNotes { get; set; }

        /// <summary>
        /// 验收数量
        /// </summary>
        [SugarColumn(ColumnName = "QminAcceptQty", ColumnDescription = "验收数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QminAcceptQty { get; set; }

        /// <summary>
        /// 检验次数
        /// </summary>
        [SugarColumn(ColumnName = "QminCheckoutSequence", ColumnDescription = "检验次数 ", DefaultValue = "0")]
        public int QminCheckoutSequence { get; set; }

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