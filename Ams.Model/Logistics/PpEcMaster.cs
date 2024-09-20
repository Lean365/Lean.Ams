namespace Ams.Model.Logistics
{
    /// <summary>
    /// 设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/18 8:51:20
    /// </summary>
    [SugarTable("pp_ec_master", "设变")]
    public class PpEcMaster : SysBase
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 发行日期 
        /// </summary>
        public DateTime? Mb002 { get; set; }

        /// <summary>
        /// 设变No. 
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "设变No.", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 关联文件 
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "关联文件", Length = 500)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 设变状态 
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "设变状态", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb005 { get; set; }

        /// <summary>
        /// 标题 
        /// </summary>
        [SugarColumn(ColumnName = "Mb006", ColumnDescription = "标题", Length = 500, ColumnDataType = "NVARCHAR")]
        public string Mb006 { get; set; }

        /// <summary>
        /// 内容 
        /// </summary>
        [SugarColumn(ColumnName = "Mb007", ColumnDescription = "内容", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Mb007 { get; set; }

        /// <summary>
        /// 担当 
        /// </summary>
        [SugarColumn(ColumnName = "Mb008", ColumnDescription = "担当", Length = 50)]
        public string Mb008 { get; set; }

        /// <summary>
        /// 成本变更 
        /// </summary>
        [SugarColumn(ColumnName = "Mb009", ColumnDescription = "成本变更", Length = 40)]
        public string Mb009 { get; set; }

        /// <summary>
        /// 单位成本 
        /// </summary>
        [SugarColumn(ColumnName = "Mb010", ColumnDescription = "单位成本", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb010 { get; set; }

        /// <summary>
        /// 模具费用 
        /// </summary>
        [SugarColumn(ColumnName = "Mb011", ColumnDescription = "模具费用", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb011 { get; set; }

        /// <summary>
        /// 关联图纸 
        /// </summary>
        [SugarColumn(ColumnName = "Mb012", ColumnDescription = "关联图纸", Length = 200)]
        public string Mb012 { get; set; }

        /// <summary>
        /// 管理区分 
        /// </summary>
        [SugarColumn(ColumnName = "Mb013", ColumnDescription = "管理区分", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb013 { get; set; }

        /// <summary>
        /// 联络No. 
        /// </summary>
        [SugarColumn(ColumnName = "Mb014", ColumnDescription = "联络No.", Length = 10)]
        public string Mb014 { get; set; }

        /// <summary>
        /// 联络文件 
        /// </summary>
        [SugarColumn(ColumnName = "Mb015", ColumnDescription = "联络文件", Length = 500)]
        public string Mb015 { get; set; }

        /// <summary>
        /// EppNo. 
        /// </summary>
        [SugarColumn(ColumnName = "Mb016", ColumnDescription = "EppNo.", Length = 10)]
        public string Mb016 { get; set; }

        /// <summary>
        /// Epp文件 
        /// </summary>
        [SugarColumn(ColumnName = "Mb017", ColumnDescription = "Epp文件", Length = 500)]
        public string Mb017 { get; set; }

        /// <summary>
        /// FppNo. 
        /// </summary>
        [SugarColumn(ColumnName = "Mb018", ColumnDescription = "FppNo.", Length = 10)]
        public string Mb018 { get; set; }

        /// <summary>
        /// Fpp文件 
        /// </summary>
        [SugarColumn(ColumnName = "Mb019", ColumnDescription = "Fpp文件", Length = 500)]
        public string Mb019 { get; set; }

        /// <summary>
        /// 外部No. 
        /// </summary>
        [SugarColumn(ColumnName = "Mb020", ColumnDescription = "外部No.", Length = 10)]
        public string Mb020 { get; set; }

        /// <summary>
        /// 外部文件 
        /// </summary>
        [SugarColumn(ColumnName = "Mb021", ColumnDescription = "外部文件", Length = 500)]
        public string Mb021 { get; set; }

        /// <summary>
        /// 输入部门 
        /// </summary>
        [SugarColumn(ColumnName = "Mb022", ColumnDescription = "输入部门", Length = 50)]
        public string Mb022 { get; set; }

        /// <summary>
        /// 输入日 
        /// </summary>
        public DateTime? Mb023 { get; set; }



        [Navigate(NavigateType.OneToMany, nameof(PpEcSlave.ParentId), nameof(Id))] //自定义关系映射
        public List<PpEcSlave> PpEcSlaveNav { get; set; }
    }
}