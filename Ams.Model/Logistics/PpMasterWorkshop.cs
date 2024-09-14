namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产班组
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:06:17
    /// </summary>
    [SugarTable("pp_master_workshop", "生产班组")]
    public class PpMasterWorkshop : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 班组类别
        /// </summary>
        [SugarColumn(ColumnName = "Md002", ColumnDescription = "班组类别", Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md002 { get; set; }

        /// <summary>
        /// 班组代码
        /// </summary>
        [SugarColumn(ColumnName = "Md003", ColumnDescription = "班组代码", Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md003 { get; set; }

        /// <summary>
        /// 语言Key
        /// </summary>
        [SugarColumn(ColumnName = "Md004", ColumnDescription = "语言Key", Length = 200)]
        public string Md004 { get; set; }

        /// <summary>
        /// 班组名称
        /// </summary>
        [SugarColumn(ColumnName = "Md005", ColumnDescription = "班组名称", Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md005 { get; set; }
    }
}