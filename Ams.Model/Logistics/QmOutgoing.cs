namespace Ams.Model.Logistics
{
    /// <summary>
    /// 出货检验
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:38:43
    /// </summary>
    [SugarTable("qm_outgoing", "出货检验")]
    public class QmOutgoing : SysBase
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
        [SugarColumn(ColumnName = "Mj002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj002 { get; set; }

        /// <summary>
        /// 生产工单
        /// </summary>
        [SugarColumn(ColumnName = "Mj003", ColumnDescription = "生产工单", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj003 { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "Mj004", ColumnDescription = "班组", Length = 10)]
        public string Mj004 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Mj005", ColumnDescription = "机种", Length = 20)]
        public string Mj005 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mj006", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj006 { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Mj007", ColumnDescription = "批次", Length = 20)]
        public string Mj007 { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "Mj008", ColumnDescription = "序号", Length = 50)]
        public string Mj008 { get; set; }

        /// <summary>
        /// 送检数量
        /// </summary>
        [SugarColumn(ColumnName = "Mj009", ColumnDescription = "送检数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj009 { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? Mj010 { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "Mj011", ColumnDescription = "检查员", Length = 20)]
        public string Mj011 { get; set; }

        /// <summary>
        /// 查验日期
        /// </summary>
        public DateTime? Mj012 { get; set; }

        /// <summary>
        /// 检查项目
        /// </summary>
        [SugarColumn(ColumnName = "Mj013", ColumnDescription = "检查项目", Length = 50)]
        public string Mj013 { get; set; }

        /// <summary>
        /// 检验水准
        /// </summary>
        [SugarColumn(ColumnName = "Mj014", ColumnDescription = "检验水准", Length = 4)]
        public string Mj014 { get; set; }

        /// <summary>
        /// 检验方式
        /// </summary>
        [SugarColumn(ColumnName = "Mj015", ColumnDescription = "检验方式", Length = 4)]
        public string Mj015 { get; set; }

        /// <summary>
        /// 抽样数
        /// </summary>
        [SugarColumn(ColumnName = "Mj016", ColumnDescription = "抽样数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj016 { get; set; }

        /// <summary>
        /// 判定
        /// </summary>
        [SugarColumn(ColumnName = "Mj017", ColumnDescription = "判定", Length = 4)]
        public string Mj017 { get; set; }

        /// <summary>
        /// 不良级别
        /// </summary>
        [SugarColumn(ColumnName = "Mj018", ColumnDescription = "不良级别", Length = 10)]
        public string Mj018 { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "Mj019", ColumnDescription = "验退数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj019 { get; set; }

        /// <summary>
        /// 检查号码
        /// </summary>
        [SugarColumn(ColumnName = "Mj020", ColumnDescription = "检查号码", Length = 500)]
        public string Mj020 { get; set; }

        /// <summary>
        /// 特记事项
        /// </summary>
        [SugarColumn(ColumnName = "Mj021", ColumnDescription = "特记事项", Length = 500)]
        public string Mj021 { get; set; }

        /// <summary>
        /// 验收数量
        /// </summary>
        [SugarColumn(ColumnName = "Mj022", ColumnDescription = "验收数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj022 { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "Mj023", ColumnDescription = "订单数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj023 { get; set; }

        /// <summary>
        /// 检验次数
        /// </summary>
        [SugarColumn(ColumnName = "Mj024", ColumnDescription = "检验次数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj024 { get; set; }
    }
}