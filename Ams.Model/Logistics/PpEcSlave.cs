namespace Ams.Model.Logistics
{
    /// <summary>
    /// 设变明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 8:13:42
    /// </summary>
    [SugarTable("pp_ec_slave", "设变明细")]
    public class PpEcSlave : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? ParentId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "设变No.", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "机种", Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "物料", Length = 20)]
        public string Mc005 { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "物料文本", Length = 40)]
        public string Mc006 { get; set; }

        /// <summary>
        /// 子物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "子物料", Length = 20)]
        public string Mc007 { get; set; }

        /// <summary>
        /// 子物料文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "子物料文本", Length = 40)]
        public string Mc008 { get; set; }

        /// <summary>
        /// 旧物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc009", ColumnDescription = "旧物料", Length = 20)]
        public string Mc009 { get; set; }

        /// <summary>
        /// 旧文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc010", ColumnDescription = "旧文本", Length = 40)]
        public string Mc010 { get; set; }

        /// <summary>
        /// 旧品库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "旧品库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc011 { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "用量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc012 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "Mc013", ColumnDescription = "位置", Length = 20)]
        public string Mc013 { get; set; }

        /// <summary>
        /// 新物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc014", ColumnDescription = "新物料", Length = 20)]
        public string Mc014 { get; set; }

        /// <summary>
        /// 新文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc015", ColumnDescription = "新文本", Length = 40)]
        public string Mc015 { get; set; }

        /// <summary>
        /// 新品库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc016", ColumnDescription = "新品库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc016 { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnName = "Mc017", ColumnDescription = "用量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc017 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "Mc018", ColumnDescription = "位置", Length = 20)]
        public string Mc018 { get; set; }

        /// <summary>
        /// bom番号
        /// </summary>
        [SugarColumn(ColumnName = "Mc019", ColumnDescription = "bom番号", Length = 4)]
        public string Mc019 { get; set; }

        /// <summary>
        /// 互换
        /// </summary>
        [SugarColumn(ColumnName = "Mc020", ColumnDescription = "互换", Length = 4)]
        public string Mc020 { get; set; }

        /// <summary>
        /// 区分
        /// </summary>
        [SugarColumn(ColumnName = "Mc021", ColumnDescription = "区分", Length = 4)]
        public string Mc021 { get; set; }

        /// <summary>
        /// 指示
        /// </summary>
        [SugarColumn(ColumnName = "Mc022", ColumnDescription = "指示", Length = 4)]
        public string Mc022 { get; set; }

        /// <summary>
        /// 旧品处理
        /// </summary>
        [SugarColumn(ColumnName = "Mc023", ColumnDescription = "旧品处理", Length = 4)]
        public string Mc023 { get; set; }

        /// <summary>
        /// bom日期
        /// </summary>
        public DateTime? Mc024 { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc025", ColumnDescription = "采购类型", Length = 1)]
        public string Mc025 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Mc026", ColumnDescription = "采购组", Length = 3)]
        public string Mc026 { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "Mc027", ColumnDescription = "仓库", Length = 4)]
        public string Mc027 { get; set; }

        /// <summary>
        /// 检验否
        /// </summary>
        [SugarColumn(ColumnName = "Mc028", ColumnDescription = "检验否", Length = 1)]
        public string Mc028 { get; set; }

        /// <summary>
        /// 工厂状态
        /// </summary>
        [SugarColumn(ColumnName = "Mc029", ColumnDescription = "工厂状态", Length = 4)]
        public string Mc029 { get; set; }

        /// <summary>
        /// SOP
        /// </summary>
        [SugarColumn(ColumnName = "Mc030", ColumnDescription = "SOP", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc030 { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "Mc031", ColumnDescription = "实施标记", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc031 { get; set; }

        /// <summary>
        /// 部管
        /// </summary>
        [SugarColumn(ColumnName = "Mc032", ColumnDescription = "部管", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc032 { get; set; }

        /// <summary>
        /// Pcba
        /// </summary>
        [SugarColumn(ColumnName = "Mc033", ColumnDescription = "Pcba", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc033 { get; set; }

        /// <summary>
        /// 组立
        /// </summary>
        [SugarColumn(ColumnName = "Mc034", ColumnDescription = "组立", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc034 { get; set; }
    }
}