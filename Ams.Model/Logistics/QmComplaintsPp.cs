namespace Ams.Model.Logistics
{
    /// <summary>
    /// PP客诉
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:14:58
    /// </summary>
    [SugarTable("qm_complaints_pp", "PP客诉")]
    public class QmComplaintsPp : SysBase
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
        [SugarColumn(ColumnName = "Ma002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma002 { get; set; }

        /// <summary>
        /// 外部客诉No.
        /// </summary>
        [SugarColumn(ColumnName = "Ma003", ColumnDescription = "外部客诉No.", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma003 { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "Ma004", ColumnDescription = "班组", Length = 20)]
        public string Ma004 { get; set; }

        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime? Ma005 { get; set; }

        /// <summary>
        /// 问题描述
        /// </summary>
        [SugarColumn(ColumnName = "Ma006", ColumnDescription = "问题描述", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Ma006 { get; set; }

        /// <summary>
        /// 原因分析
        /// </summary>
        [SugarColumn(ColumnName = "Ma007", ColumnDescription = "原因分析", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Ma007 { get; set; }

        /// <summary>
        /// 作业员
        /// </summary>
        [SugarColumn(ColumnName = "Ma008", ColumnDescription = "作业员", Length = 40)]
        public string Ma008 { get; set; }

        /// <summary>
        /// 工位
        /// </summary>
        [SugarColumn(ColumnName = "Ma009", ColumnDescription = "工位", Length = 40)]
        public string Ma009 { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Ma010", ColumnDescription = "批次", Length = 40)]
        public string Ma010 { get; set; }

        /// <summary>
        /// 改善对策
        /// </summary>
        [SugarColumn(ColumnName = "Ma011", ColumnDescription = "改善对策", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Ma011 { get; set; }

        /// <summary>
        /// 改善文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma012", ColumnDescription = "改善文件", Length = 200)]
        public string Ma012 { get; set; }
    }
}