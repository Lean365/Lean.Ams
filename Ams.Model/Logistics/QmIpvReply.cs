namespace Ams.Model.Logistics
{
    /// <summary>
    /// 分析对策
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:44:05
    /// </summary>
    [SugarTable("qm_ipv_reply", "分析对策")]
    public class QmIpvReply : SysBase
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
        [SugarColumn(ColumnName = "Mi002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mi002 { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "Mi003", ColumnDescription = "检查员", Length = 20)]
        public string Mi003 { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "Mi004", ColumnDescription = "班组", Length = 10)]
        public string Mi004 { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [SugarColumn(ColumnName = "Mi005", ColumnDescription = "订单", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mi005 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Mi006", ColumnDescription = "机种", Length = 20)]
        public string Mi006 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mi007", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mi007 { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "Mi008", ColumnDescription = "仕向", Length = 20)]
        public string Mi008 { get; set; }

        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? Mi009 { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Mi010", ColumnDescription = "批次", Length = 20)]
        public string Mi010 { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "Mi011", ColumnDescription = "序号", Length = 50)]
        public string Mi011 { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "Mi012", ColumnDescription = "验退数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi012 { get; set; }

        /// <summary>
        /// 不良级别
        /// </summary>
        [SugarColumn(ColumnName = "Mi013", ColumnDescription = "不良级别", Length = 10)]
        public string Mi013 { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "Mi014", ColumnDescription = "不良内容", Length = 300)]
        public string Mi014 { get; set; }

        /// <summary>
        /// 对策人员
        /// </summary>
        [SugarColumn(ColumnName = "Mi015", ColumnDescription = "对策人员", Length = 20)]
        public string Mi015 { get; set; }

        /// <summary>
        /// 对应日期
        /// </summary>
        public DateTime? Mi016 { get; set; }

        /// <summary>
        /// 直接原因
        /// </summary>
        [SugarColumn(ColumnName = "Mi017", ColumnDescription = "直接原因", Length = 300)]
        public string Mi017 { get; set; }

        /// <summary>
        /// 间接原因
        /// </summary>
        [SugarColumn(ColumnName = "Mi018", ColumnDescription = "间接原因", Length = 300)]
        public string Mi018 { get; set; }

        /// <summary>
        /// 处置
        /// </summary>
        [SugarColumn(ColumnName = "Mi019", ColumnDescription = "处置", Length = 300)]
        public string Mi019 { get; set; }

        /// <summary>
        /// 直接对策
        /// </summary>
        [SugarColumn(ColumnName = "Mi020", ColumnDescription = "直接对策", Length = 300)]
        public string Mi020 { get; set; }

        /// <summary>
        /// 间接对策
        /// </summary>
        [SugarColumn(ColumnName = "Mi021", ColumnDescription = "间接对策", Length = 300)]
        public string Mi021 { get; set; }

        /// <summary>
        /// 检证人员
        /// </summary>
        [SugarColumn(ColumnName = "Mi022", ColumnDescription = "检证人员", Length = 20)]
        public string Mi022 { get; set; }

        /// <summary>
        /// 实施日期
        /// </summary>
        public DateTime? Mi023 { get; set; }

        /// <summary>
        /// 实施查证
        /// </summary>
        [SugarColumn(ColumnName = "Mi024", ColumnDescription = "实施查证", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mi024 { get; set; }

        /// <summary>
        /// 对策实施查证
        /// </summary>
        [SugarColumn(ColumnName = "Mi025", ColumnDescription = "对策实施查证", Length = 300)]
        public string Mi025 { get; set; }

        /// <summary>
        /// 特记事项
        /// </summary>
        [SugarColumn(ColumnName = "Mi026", ColumnDescription = "特记事项", Length = 300)]
        public string Mi026 { get; set; }

        /// <summary>
        /// 发行号码
        /// </summary>
        [SugarColumn(ColumnName = "Mi027", ColumnDescription = "发行号码", Length = 20)]
        public string Mi027 { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [SugarColumn(ColumnName = "Mi028", ColumnDescription = "附件", Length = 20)]
        public string Mi028 { get; set; }
    }
}