namespace Ams.Model.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:51:22
    /// </summary>
    [SugarTable("fico_costing_dept_consuming", "部门消耗")]
    public class FicoCostingDeptConsuming : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Ml002", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml002 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Ml003", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml003 { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Ml004", ColumnDescription = "公司代码", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml004 { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        [SugarColumn(ColumnName = "Ml005", ColumnDescription = "统计类别", Length = 10)]
        public string Ml005 { get; set; }

        /// <summary>
        /// 成本科目
        /// </summary>
        [SugarColumn(ColumnName = "Ml006", ColumnDescription = "成本科目", Length = 10)]
        public string Ml006 { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "Ml007", ColumnDescription = "科目代码", Length = 10)]
        public string Ml007 { get; set; }

        /// <summary>
        /// 科目分类
        /// </summary>
        [SugarColumn(ColumnName = "Ml008", ColumnDescription = "科目分类", Length = 40)]
        public string Ml008 { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "Ml009", ColumnDescription = "预算", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml009 { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "Ml010", ColumnDescription = "实际", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml010 { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "Ml011", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml011 { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Ml012", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml012 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Ml013", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml013 { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "Ml014", ColumnDescription = "仓库", Length = 4)]
        public string Ml014 { get; set; }

        /// <summary>
        /// 移动类型
        /// </summary>
        [SugarColumn(ColumnName = "Ml015", ColumnDescription = "移动类型", Length = 3)]
        public string Ml015 { get; set; }

        /// <summary>
        /// 物料凭证
        /// </summary>
        [SugarColumn(ColumnName = "Ml016", ColumnDescription = "物料凭证", Length = 10)]
        public string Ml016 { get; set; }

        /// <summary>
        /// 项目明细
        /// </summary>
        [SugarColumn(ColumnName = "Ml017", ColumnDescription = "项目明细", Length = 5)]
        public string Ml017 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Ml018", ColumnDescription = "数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml018 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Ml019", ColumnDescription = "币种", Length = 3)]
        public string Ml019 { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "Ml020", ColumnDescription = "金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml020 { get; set; }

        /// <summary>
        /// 预留单
        /// </summary>
        [SugarColumn(ColumnName = "Ml021", ColumnDescription = "预留单", Length = 10)]
        public string Ml021 { get; set; }

        /// <summary>
        /// 预留明细
        /// </summary>
        [SugarColumn(ColumnName = "Ml022", ColumnDescription = "预留明细", Length = 10)]
        public string Ml022 { get; set; }

        /// <summary>
        /// 领用日期
        /// </summary>
        public DateTime? Ml023 { get; set; }
    }
}