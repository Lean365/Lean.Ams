namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度资产
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:59:43
    /// </summary>
    [SugarTable("fico_monthly_assets", "月度资产")]
    public class FicoMonthlyAssets : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FaSfId { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "FaLfgja", ColumnDescription = "期间", Length = 6)]
        public string FaLfgja { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FaLfmon", ColumnDescription = "年月", Length = 6)]
        public string FaLfmon { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FaBukrs", ColumnDescription = "公司", Length = 255)]
        public string FaBukrs { get; set; }

        /// <summary>
        /// 使用部门
        /// </summary>
        [SugarColumn(ColumnName = "FaBtabt", ColumnDescription = "使用部门", Length = 255)]
        public string FaBtabt { get; set; }

        /// <summary>
        /// 资产类别
        /// </summary>
        [SugarColumn(ColumnName = "FaAnlkl", ColumnDescription = "资产类别", Length = 255)]
        public string FaAnlkl { get; set; }

        /// <summary>
        /// 资产编码
        /// </summary>
        [SugarColumn(ColumnName = "FaAnln", ColumnDescription = "资产编码", Length = 255)]
        public string FaAnln { get; set; }

        /// <summary>
        /// 成本中心
        /// </summary>
        [SugarColumn(ColumnName = "FaKostl", ColumnDescription = "成本中心", Length = 255)]
        public string FaKostl { get; set; }

        /// <summary>
        /// 资产简称
        /// </summary>
        [SugarColumn(ColumnName = "FaStext", ColumnDescription = "资产简称", Length = 255)]
        public string FaStext { get; set; }

        /// <summary>
        /// 资产全称
        /// </summary>
        [SugarColumn(ColumnName = "FaLtext", ColumnDescription = "资产全称", Length = 255)]
        public string FaLtext { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "FaMeins", ColumnDescription = "单位", Length = 255)]
        public string FaMeins { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "FaMenge", ColumnDescription = "数量", DefaultValue = "0")]
        public int? FaMenge { get; set; }

        /// <summary>
        /// 管理区分
        /// </summary>
        [SugarColumn(ColumnName = "FaBsakz", ColumnDescription = "管理区分", DefaultValue = "0")]
        public int? FaBsakz { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "FaWaers", ColumnDescription = "币种", Length = 3)]
        public string FaWaers { get; set; }

        /// <summary>
        /// 购买价格
        /// </summary>
        [SugarColumn(ColumnName = "FaBubtr", ColumnDescription = "购买价格", DefaultValue = "0", Length = 18, DecimalDigits = 0)]
        public decimal FaBubtr { get; set; }

        /// <summary>
        /// 资本化日期
        /// </summary>
        public DateTime? FaAktiv { get; set; }

        /// <summary>
        /// 折旧价值
        /// </summary>
        [SugarColumn(ColumnName = "FaNafaz", ColumnDescription = "折旧价值", DefaultValue = "0", Length = 18, DecimalDigits = 0)]
        public decimal FaNafaz { get; set; }

        /// <summary>
        /// 报废日期
        /// </summary>
        public DateTime? FaDeakt { get; set; }

        /// <summary>
        /// 残值
        /// </summary>
        [SugarColumn(ColumnName = "FaSchrw", ColumnDescription = "残值", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FaSchrw { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        [SugarColumn(ColumnName = "FaPosnr", ColumnDescription = "存放位置", Length = 255)]
        public string FaPosnr { get; set; }

        /// <summary>
        /// 使用年限
        /// </summary>
        [SugarColumn(ColumnName = "FaSrvvy", ColumnDescription = "使用年限", DefaultValue = "0", Length = 18, DecimalDigits = 0)]
        public decimal FaSrvvy { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        [SugarColumn(ColumnName = "FaParkflg", ColumnDescription = "是否停用", DefaultValue = "0")]
        public int? FaParkflg { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "FaLifnr", ColumnDescription = "供应商", Length = 255)]
        public string FaLifnr { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        [SugarColumn(ColumnName = "FaHerst", ColumnDescription = "制造商", Length = 255)]
        public string FaHerst { get; set; }

        /// <summary>
        /// 供应商物料
        /// </summary>
        [SugarColumn(ColumnName = "FaVenpn", ColumnDescription = "供应商物料", Length = 255)]
        public string FaVenpn { get; set; }

        /// <summary>
        /// 制造商物料
        /// </summary>
        [SugarColumn(ColumnName = "FaMfrpn", ColumnDescription = "制造商物料", Length = 255)]
        public string FaMfrpn { get; set; }

        /// <summary>
        /// 资产形态
        /// </summary>
        [SugarColumn(ColumnName = "FaEntity", ColumnDescription = "资产形态", DefaultValue = "0")]
        public int? FaEntity { get; set; }

        /// <summary>
        /// 资产存在否
        /// </summary>
        [SugarColumn(ColumnName = "FaNxtfl", ColumnDescription = "资产存在否", DefaultValue = "0")]
        public int? FaNxtfl { get; set; }

        /// <summary>
        /// 盘点人员
        /// </summary>
        [SugarColumn(ColumnName = "FaPresp", ColumnDescription = "盘点人员", Length = 255)]
        public string FaPresp { get; set; }

        /// <summary>
        /// 周期盘点日期
        /// </summary>
        public DateTime? FaIdatu { get; set; }
    }
}