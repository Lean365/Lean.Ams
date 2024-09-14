namespace Ams.Model.Accounting
{
    /// <summary>
    /// 利润中心
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:56
    /// </summary>
    [SugarTable("fico_profit_center", "利润中心")]
    public class FicoProfitCenter : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Mq002", ColumnDescription = "集团", Length = 3)]
        public string Mq002 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Mq003", ColumnDescription = "利润中心", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mq003 { get; set; }

        /// <summary>
        /// 控制范围
        /// </summary>
        [SugarColumn(ColumnName = "Mq004", ColumnDescription = "控制范围", Length = 4)]
        public string Mq004 { get; set; }

        /// <summary>
        /// 开始生效日期
        /// </summary>
        public DateTime? Mq005 { get; set; }

        /// <summary>
        /// 有效截至日期
        /// </summary>
        public DateTime? Mq006 { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "Mq007", ColumnDescription = "部门", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mq007 { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [SugarColumn(ColumnName = "Mq008", ColumnDescription = "负责人", Length = 40)]
        public string Mq008 { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
        [SugarColumn(ColumnName = "Mq009", ColumnDescription = "货币", Length = 3)]
        public string Mq009 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Mq010", ColumnDescription = "名称", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mq010 { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Mq011", ColumnDescription = "长文本", Length = 80)]
        public string Mq011 { get; set; }

        /// <summary>
        /// 利润中心说明
        /// </summary>
        [SugarColumn(ColumnName = "Mq012", ColumnDescription = "利润中心说明", Length = 120)]
        public string Mq012 { get; set; }

        /// <summary>
        /// 利润中心组
        /// </summary>
        [SugarColumn(ColumnName = "Mq013", ColumnDescription = "利润中心组", Length = 12)]
        public string Mq013 { get; set; }

        /// <summary>
        /// 权益类型
        /// </summary>
        [SugarColumn(ColumnName = "Mq014", ColumnDescription = "权益类型", Length = 3)]
        public string Mq014 { get; set; }

        /// <summary>
        /// 地区税务代码
        /// </summary>
        [SugarColumn(ColumnName = "Mq015", ColumnDescription = "地区税务代码", Length = 15)]
        public string Mq015 { get; set; }

        /// <summary>
        /// 锁定标记
        /// </summary>
        [SugarColumn(ColumnName = "Mq016", ColumnDescription = "锁定标记", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mq016 { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "Mq017", ColumnDescription = "状态", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mq017 { get; set; }
    }
}