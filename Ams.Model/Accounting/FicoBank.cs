namespace Ams.Model.Accounting
{
    /// <summary>
    /// 银行
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:43:04
    /// </summary>
    [SugarTable("fico_bank", "银行")]
    public class FicoBank : SysBase
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
        [SugarColumn(ColumnName = "Mc002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc002 { get; set; }

        /// <summary>
        /// 关联对象
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "关联对象", Length = 20)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "银行代码", Length = 80, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "银行名称", Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc005 { get; set; }

        /// <summary>
        /// 分行名称
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "分行名称", Length = 255)]
        public string Mc006 { get; set; }

        /// <summary>
        /// 银行所在国
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "银行所在国", Length = 2)]
        public string Mc007 { get; set; }

        /// <summary>
        /// 所在州省
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "所在州省", Length = 40)]
        public string Mc008 { get; set; }

        /// <summary>
        /// 所在市
        /// </summary>
        [SugarColumn(ColumnName = "Mc009", ColumnDescription = "所在市", Length = 40)]
        public string Mc009 { get; set; }

        /// <summary>
        /// 所在县
        /// </summary>
        [SugarColumn(ColumnName = "Mc010", ColumnDescription = "所在县", Length = 40)]
        public string Mc010 { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "地址1", Length = 200)]
        public string Mc011 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "地址2", Length = 200)]
        public string Mc012 { get; set; }

        /// <summary>
        /// 地址3
        /// </summary>
        [SugarColumn(ColumnName = "Mc013", ColumnDescription = "地址3", Length = 200)]
        public string Mc013 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [SugarColumn(ColumnName = "Mc014", ColumnDescription = "邮政编码", Length = 20)]
        public string Mc014 { get; set; }

        /// <summary>
        /// 地址号码
        /// </summary>
        [SugarColumn(ColumnName = "Mc015", ColumnDescription = "地址号码", Length = 20)]
        public string Mc015 { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [SugarColumn(ColumnName = "Mc016", ColumnDescription = "银行账号", Length = 21)]
        public string Mc016 { get; set; }

        /// <summary>
        /// 持有人
        /// </summary>
        [SugarColumn(ColumnName = "Mc017", ColumnDescription = "持有人", Length = 200)]
        public string Mc017 { get; set; }

        /// <summary>
        /// SWIFT代码
        /// </summary>
        [SugarColumn(ColumnName = "Mc018", ColumnDescription = "SWIFT代码", Length = 11)]
        public string Mc018 { get; set; }

        /// <summary>
        /// 交易冻结
        /// </summary>
        [SugarColumn(ColumnName = "Mc019", ColumnDescription = "交易冻结", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc019 { get; set; }
    }
}