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
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QcaSfId { get; set; }

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
    }
}