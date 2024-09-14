namespace Ams.Model.Logistics
{
    /// <summary>
    /// 进料检验
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:45:51
    /// </summary>
    [SugarTable("qm_incoming", "进料检验")]
    public class QmIncoming : SysBase
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
        [SugarColumn(ColumnName = "Mf002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mf002 { get; set; }

        /// <summary>
        /// 采购订单
        /// </summary>
        [SugarColumn(ColumnName = "Mf003", ColumnDescription = "采购订单", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mf003 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mf004", ColumnDescription = "物料", Length = 20)]
        public string Mf004 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Mf005", ColumnDescription = "数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mf005 { get; set; }

        /// <summary>
        /// 进货日期
        /// </summary>
        public DateTime? Mf006 { get; set; }

        /// <summary>
        /// 检验员
        /// </summary>
        [SugarColumn(ColumnName = "Mf007", ColumnDescription = "检验员", Length = 20)]
        public string Mf007 { get; set; }

        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? Mf008 { get; set; }

        /// <summary>
        /// 检验项目
        /// </summary>
        [SugarColumn(ColumnName = "Mf009", ColumnDescription = "检验项目", Length = 50)]
        public string Mf009 { get; set; }

        /// <summary>
        /// 检验水准
        /// </summary>
        [SugarColumn(ColumnName = "Mf010", ColumnDescription = "检验水准", Length = 4)]
        public string Mf010 { get; set; }

        /// <summary>
        /// 检验方式
        /// </summary>
        [SugarColumn(ColumnName = "Mf011", ColumnDescription = "检验方式", Length = 4)]
        public string Mf011 { get; set; }

        /// <summary>
        /// 抽样数
        /// </summary>
        [SugarColumn(ColumnName = "Mf012", ColumnDescription = "抽样数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mf012 { get; set; }

        /// <summary>
        /// 判定
        /// </summary>
        [SugarColumn(ColumnName = "Mf013", ColumnDescription = "判定", Length = 4)]
        public string Mf013 { get; set; }

        /// <summary>
        /// 不良级别
        /// </summary>
        [SugarColumn(ColumnName = "Mf014", ColumnDescription = "不良级别", Length = 10)]
        public string Mf014 { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "Mf015", ColumnDescription = "验退数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mf015 { get; set; }

        /// <summary>
        /// 特记事项
        /// </summary>
        [SugarColumn(ColumnName = "Mf016", ColumnDescription = "特记事项", Length = 500)]
        public string Mf016 { get; set; }

        /// <summary>
        /// 验收数量
        /// </summary>
        [SugarColumn(ColumnName = "Mf017", ColumnDescription = "验收数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mf017 { get; set; }

        /// <summary>
        /// 检验次数
        /// </summary>
        [SugarColumn(ColumnName = "Mf018", ColumnDescription = "检验次数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mf018 { get; set; }
    }
}