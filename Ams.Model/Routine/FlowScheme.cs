
namespace Ams.Model.Routine
{
    /// <summary>
    /// 流程
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 11:32:52
    /// </summary>
    [SugarTable("flow_scheme","流程")]
    public class FlowScheme : SysBase
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 流程编号 
        /// </summary>
        [SugarColumn(ColumnName="SchemeCode", ColumnDescription = "流程编号",Length = 64,ColumnDataType = "NVARCHAR")]
        public string SchemeCode { get; set; }

        /// <summary>
        /// 流程名称 
        /// </summary>
        [SugarColumn(ColumnName="SchemeName", ColumnDescription = "流程名称",Length = 64,ColumnDataType = "NVARCHAR")]
        public string SchemeName { get; set; }

        /// <summary>
        /// 流程类型 
        /// </summary>
        [SugarColumn(ColumnName="SchemeType", ColumnDescription = "流程类型",Length = 64,ColumnDataType = "NVARCHAR")]
        public string SchemeType { get; set; }

        /// <summary>
        /// 流程版本 
        /// </summary>
        [SugarColumn(ColumnName="SchemeVersion", ColumnDescription = "流程版本",Length = 64,ColumnDataType = "NVARCHAR")]
        public string SchemeVersion { get; set; }

        /// <summary>
        /// 流程使用人 
        /// </summary>
        [SugarColumn(ColumnName="SchemeCanUser", ColumnDescription = "流程使用人",Length = 64,ColumnDataType = "NVARCHAR")]
        public string SchemeCanUser { get; set; }

        /// <summary>
        /// 流程内容 
        /// </summary>
        [SugarColumn(ColumnName="SchemeContent", ColumnDescription = "流程内容",Length = 2147483647)]
        public string SchemeContent { get; set; }

        /// <summary>
        /// 表单Id 
        /// </summary>
        public long? FrmId { get; set; }

        /// <summary>
        /// 表单类型 
        /// </summary>
        [SugarColumn(ColumnName="FrmType", ColumnDescription = "表单类型",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int FrmType { get; set; }

        /// <summary>
        /// 权限类型 
        /// </summary>
        [SugarColumn(ColumnName="AuthorizeType", ColumnDescription = "权限类型",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? AuthorizeType { get; set; }

        /// <summary>
        /// 所属部门 
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// 激活标识 
        /// </summary>
        [SugarColumn(ColumnName="IsActive", ColumnDescription = "激活标识",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? IsActive { get; set; }

        /// <summary>
        /// 状态标识 
        /// </summary>
        [SugarColumn(ColumnName="IsStatus", ColumnDescription = "状态标识",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }

        /// <summary>
        /// 排序 
        /// </summary>
        [SugarColumn(ColumnName="SortingNum", ColumnDescription = "排序",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int SortingNum { get; set; }

    }
}