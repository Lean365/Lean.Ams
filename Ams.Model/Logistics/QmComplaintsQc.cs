namespace Ams.Model.Logistics
{
    /// <summary>
    /// QC客诉
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:13:49
    /// </summary>
    [SugarTable("qm_complaints_qc", "QC客诉")]
    public class QmComplaintsQc : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工厂代码
        /// </summary>
        [SugarColumn(ColumnName = "Mb002", ColumnDescription = "工厂代码", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb002 { get; set; }

        /// <summary>
        /// 客诉No.
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "客诉No.", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 外部客诉No.
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "外部客诉No.", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "客户", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb005 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Mb006", ColumnDescription = "机种", Length = 40)]
        public string Mb006 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mb007", ColumnDescription = "物料", Length = 20)]
        public string Mb007 { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "Mb008", ColumnDescription = "仕向", Length = 20)]
        public string Mb008 { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [SugarColumn(ColumnName = "Mb009", ColumnDescription = "订单", Length = 20)]
        public string Mb009 { get; set; }

        /// <summary>
        /// 接收日期
        /// </summary>
        public DateTime? Mb010 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Mb011", ColumnDescription = "数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb011 { get; set; }

        /// <summary>
        /// 投诉事项
        /// </summary>
        [SugarColumn(ColumnName = "Mb012", ColumnDescription = "投诉事项", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Mb012 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mb013", ColumnDescription = "序列号", Length = 200)]
        public string Mb013 { get; set; }

        /// <summary>
        /// 参考文件
        /// </summary>
        [SugarColumn(ColumnName = "Mb014", ColumnDescription = "参考文件", Length = 200)]
        public string Mb014 { get; set; }

        /// <summary>
        /// 症状
        /// </summary>
        [SugarColumn(ColumnName = "Mb015", ColumnDescription = "症状", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Mb015 { get; set; }

        /// <summary>
        /// 分析
        /// </summary>
        [SugarColumn(ColumnName = "Mb016", ColumnDescription = "分析", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Mb016 { get; set; }

        /// <summary>
        /// 承认部门
        /// </summary>
        [SugarColumn(ColumnName = "Mb017", ColumnDescription = "承认部门", Length = 40)]
        public string Mb017 { get; set; }

        /// <summary>
        /// 承认日期
        /// </summary>
        public DateTime? Mb018 { get; set; }
    }
}