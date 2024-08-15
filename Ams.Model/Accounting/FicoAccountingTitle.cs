namespace Ams.Model.Accounting
{
    /// <summary>
    /// 会计科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 12:02:48
    /// </summary>
    [SugarTable("fico_accounting_title", "会计科目")]
    public class FicoAccountingTitle : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FatSfId { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Mandt", ColumnDescription = "集团 ", Length = 10)]
        public string Mandt { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Bukrs", ColumnDescription = "公司代码 ", Length = 8)]
        public string Bukrs { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Waers", ColumnDescription = "币种 ", Length = 3)]
        public string Waers { get; set; }

        /// <summary>
        /// 语言Key
        /// </summary>
        [SugarColumn(ColumnName = "Spras", ColumnDescription = "语言Key ", Length = 100)]
        public string Spras { get; set; }

        /// <summary>
        /// 科目编号
        /// </summary>
        [SugarColumn(ColumnName = "Saknr", ColumnDescription = "科目编号 ", Length = 20)]
        public string Saknr { get; set; }

        /// <summary>
        /// 科目表
        /// </summary>
        [SugarColumn(ColumnName = "Ktopl", ColumnDescription = "科目表 ", Length = 8)]
        public string Ktopl { get; set; }

        /// <summary>
        /// BS类别
        /// </summary>
        [SugarColumn(ColumnName = "Xbilk", ColumnDescription = "BS类别 ", Length = 1)]
        public string Xbilk { get; set; }

        /// <summary>
        /// PL类别
        /// </summary>
        [SugarColumn(ColumnName = "Gvtyp", ColumnDescription = "PL类别 ", Length = 1)]
        public string Gvtyp { get; set; }

        /// <summary>
        /// 统驭类别
        /// </summary>
        [SugarColumn(ColumnName = "Mitkz", ColumnDescription = "统驭类别 ", Length = 2)]
        public string Mitkz { get; set; }

        /// <summary>
        /// 短文本
        /// </summary>
        [SugarColumn(ColumnName = "Stext", ColumnDescription = "短文本 ", Length = 40)]
        public string Stext { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Ltext", ColumnDescription = "长文本 ", Length = 80)]
        public string Ltext { get; set; }

        /// <summary>
        /// 附加文本
        /// </summary>
        [SugarColumn(ColumnName = "Atext", ColumnDescription = "附加文本 ", Length = 120)]
        public string Atext { get; set; }

        /// <summary>
        /// 科目组
        /// </summary>
        [SugarColumn(ColumnName = "Ktoks", ColumnDescription = "科目组 ", Length = 8)]
        public string Ktoks { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>
        [SugarColumn(ColumnName = "Xspea", ColumnDescription = "冻结 ", DefaultValue = "0")]
        public int Xspea { get; set; }
    }
}