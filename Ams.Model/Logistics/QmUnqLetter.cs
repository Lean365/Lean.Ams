namespace Ams.Model.Logistics
{
    /// <summary>
    /// 不合格联络
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:41:22
    /// </summary>
    [SugarTable("qm_unq_letter", "不合格联络")]
    public class QmUnqLetter : SysBase
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
        [SugarColumn(ColumnName = "Ml002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml002 { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "Ml003", ColumnDescription = "检查员", Length = 20)]
        public string Ml003 { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "Ml004", ColumnDescription = "班组", Length = 10)]
        public string Ml004 { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [SugarColumn(ColumnName = "Ml005", ColumnDescription = "订单", Length = 20)]
        public string Ml005 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Ml006", ColumnDescription = "机种", Length = 20)]
        public string Ml006 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Ml007", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml007 { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "Ml008", ColumnDescription = "仕向", Length = 20)]
        public string Ml008 { get; set; }

        /// <summary>
        /// 查验日期
        /// </summary>
        public DateTime? Ml009 { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Ml010", ColumnDescription = "批次", Length = 20)]
        public string Ml010 { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "Ml011", ColumnDescription = "序号", Length = 50)]
        public string Ml011 { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "Ml012", ColumnDescription = "验退数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml012 { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [SugarColumn(ColumnName = "Ml013", ColumnDescription = "级别", Length = 10)]
        public string Ml013 { get; set; }

        /// <summary>
        /// 判定说明
        /// </summary>
        [SugarColumn(ColumnName = "Ml014", ColumnDescription = "判定说明", Length = 300)]
        public string Ml014 { get; set; }

        /// <summary>
        /// 发行号码
        /// </summary>
        [SugarColumn(ColumnName = "Ml015", ColumnDescription = "发行号码", Length = 20)]
        public string Ml015 { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [SugarColumn(ColumnName = "Ml016", ColumnDescription = "附件", Length = 20)]
        public string Ml016 { get; set; }
    }
}