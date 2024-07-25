namespace Ams.Model.Logistics
{
    /// <summary>
    /// 抽样标准
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:24
    /// </summary>
    [SugarTable("qm_check_aql", "抽样标准")]
    public class QmCheckAql : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QcaSFID { get; set; }

        /// <summary>
        /// 查检水平
        /// </summary>
        [SugarColumn(ColumnName = "QcaLevel", ColumnDescription = "查检水平 ", Length = 40)]
        public string QcaLevel { get; set; }

        /// <summary>
        /// 批量范围
        /// </summary>
        [SugarColumn(ColumnName = "QcaRange", ColumnDescription = "批量范围 ", Length = 40)]
        public string QcaRange { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        [SugarColumn(ColumnName = "QcaRangeMinmum", ColumnDescription = "最小值 ", DefaultValue = "0")]
        public int QcaRangeMinmum { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        [SugarColumn(ColumnName = "QcaRangeMaximum", ColumnDescription = "最大值 ", DefaultValue = "0")]
        public int QcaRangeMaximum { get; set; }

        /// <summary>
        /// 样本码
        /// </summary>
        [SugarColumn(ColumnName = "QcaSamplesCode", ColumnDescription = "样本码 ", Length = 4)]
        public string QcaSamplesCode { get; set; }

        /// <summary>
        /// 抽样数
        /// </summary>
        [SugarColumn(ColumnName = "QcaSamplesQty", ColumnDescription = "抽样数 ", DefaultValue = "0")]
        public int QcaSamplesQty { get; set; }

        /// <summary>
        /// 合格项
        /// </summary>
        [SugarColumn(ColumnName = "QcaAcQty", ColumnDescription = "合格项 ", DefaultValue = "0")]
        public int QcaAcQty { get; set; }

        /// <summary>
        /// 不合格项
        /// </summary>
        [SugarColumn(ColumnName = "QcaReQty", ColumnDescription = "不合格项 ", DefaultValue = "0")]
        public int QcaReQty { get; set; }

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