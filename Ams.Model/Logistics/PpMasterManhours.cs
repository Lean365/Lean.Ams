namespace Ams.Model.Logistics
{
    /// <summary>
    /// 标准工时
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:31:00
    /// </summary>
    [SugarTable("pp_master_manhours", "标准工时")]
    public class PpMasterManhours : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mb002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb002 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 机种名
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "机种名", Length = 40)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 仕向别
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "仕向别", Length = 20)]
        public string Mb005 { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        [SugarColumn(ColumnName = "Mb006", ColumnDescription = "物料描述", Length = 40)]
        public string Mb006 { get; set; }

        /// <summary>
        /// 工作中心
        /// </summary>
        [SugarColumn(ColumnName = "Mb007", ColumnDescription = "工作中心", Length = 40)]
        public string Mb007 { get; set; }

        /// <summary>
        /// 标准点数
        /// </summary>
        [SugarColumn(ColumnName = "Mb008", ColumnDescription = "标准点数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb008 { get; set; }

        /// <summary>
        /// Short单位
        /// </summary>
        [SugarColumn(ColumnName = "Mb009", ColumnDescription = "Short单位", Length = 1)]
        public string Mb009 { get; set; }

        /// <summary>
        /// 点数换算汇率
        /// </summary>
        [SugarColumn(ColumnName = "Mb010", ColumnDescription = "点数换算汇率", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb010 { get; set; }

        /// <summary>
        /// 标准工时
        /// </summary>
        [SugarColumn(ColumnName = "Mb011", ColumnDescription = "标准工时", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb011 { get; set; }

        /// <summary>
        /// 工时单位
        /// </summary>
        [SugarColumn(ColumnName = "Mb012", ColumnDescription = "工时单位", Length = 3)]
        public string Mb012 { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? Mb013 { get; set; }
    }
}