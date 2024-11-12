
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 流程
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 11:32:52
    /// </summary>
    public class FlowSchemeQueryDto : PagerInfo 
    {
        /// <summary>
        /// 流程编号 
        /// </summary>        
        public string SchemeCode { get; set; }
        /// <summary>
        /// 流程名称 
        /// </summary>        
        public string SchemeName { get; set; }
        /// <summary>
        /// 流程类型 
        /// </summary>        
        public string SchemeType { get; set; }
        /// <summary>
        /// 表单类型 
        /// </summary>        
        public int? FrmType { get; set; }
    }

    /// <summary>
    /// 流程
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 11:32:52
    /// </summary>
    public class FlowSchemeDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        //[ExcelColumn(Name = "流程编号")]
        [ExcelColumnName("流程编号")]

        public string SchemeCode { get; set; }

        //[ExcelColumn(Name = "流程名称")]
        [ExcelColumnName("流程名称")]

        public string SchemeName { get; set; }

        //[ExcelColumn(Name = "流程类型")]
        [ExcelColumnName("流程类型")]

        public string SchemeType { get; set; }

        //[ExcelColumn(Name = "流程版本")]
        [ExcelColumnName("流程版本")]

        public string SchemeVersion { get; set; }

        //[ExcelColumn(Name = "流程使用人")]
        [ExcelColumnName("流程使用人")]

        public string SchemeCanUser { get; set; }

        //[ExcelColumn(Name = "流程内容")]
        [ExcelColumnName("流程内容")]

        public string SchemeContent { get; set; }

        //[ExcelColumn(Name = "表单Id")]
        [ExcelColumnName("表单Id")]

        public long? FrmId { get; set; }

        [Required(ErrorMessage = "表单类型不能为空")]
        //[ExcelColumn(Name = "表单类型")]
        [ExcelColumnName("表单类型")]

        public int FrmType { get; set; }

        //[ExcelColumn(Name = "权限类型")]
        [ExcelColumnName("权限类型")]

        public int? AuthorizeType { get; set; }

        //[ExcelColumn(Name = "所属部门")]
        [ExcelColumnName("所属部门")]

        public long? DeptId { get; set; }

        //[ExcelColumn(Name = "激活标识")]
        [ExcelColumnName("激活标识")]

        public int? IsActive { get; set; }

        [Required(ErrorMessage = "状态标识不能为空")]
        //[ExcelColumn(Name = "状态标识")]
        [ExcelColumnName("状态标识")]

        public int IsStatus { get; set; }

        [Required(ErrorMessage = "排序不能为空")]
        //[ExcelColumn(Name = "排序")]
        [ExcelColumnName("排序")]

        public int SortingNum { get; set; }



        [ExcelColumn(Name = "流程类型")]
        public string SchemeTypeLabel { get; set; }
    }

    /// <summary>
    /// 流程
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 11:32:52
    /// </summary>
    public class FlowSchemeImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        //[ExcelColumn(Name = "流程编号")]
        [ExcelColumnName("流程编号")]
        public string SchemeCode { get; set; }

        //[ExcelColumn(Name = "流程名称")]
        [ExcelColumnName("流程名称")]
        public string SchemeName { get; set; }

        //[ExcelColumn(Name = "流程类型")]
        [ExcelColumnName("流程类型")]
        public string SchemeType { get; set; }

        //[ExcelColumn(Name = "流程版本")]
        [ExcelColumnName("流程版本")]
        public string SchemeVersion { get; set; }

        //[ExcelColumn(Name = "流程使用人")]
        [ExcelColumnName("流程使用人")]
        public string SchemeCanUser { get; set; }

        //[ExcelColumn(Name = "流程内容")]
        [ExcelColumnName("流程内容")]
        public string SchemeContent { get; set; }

        //[ExcelColumn(Name = "表单Id")]
        [ExcelColumnName("表单Id")]
        public long? FrmId { get; set; }

        [Required(ErrorMessage = "表单类型不能为空")]
        //[ExcelColumn(Name = "表单类型")]
        [ExcelColumnName("表单类型")]
        public int FrmType { get; set; }

        //[ExcelColumn(Name = "权限类型")]
        [ExcelColumnName("权限类型")]
        public int? AuthorizeType { get; set; }

        //[ExcelColumn(Name = "所属部门")]
        [ExcelColumnName("所属部门")]
        public long? DeptId { get; set; }

        //[ExcelColumn(Name = "激活标识")]
        [ExcelColumnName("激活标识")]
        public int? IsActive { get; set; }

        [Required(ErrorMessage = "状态标识不能为空")]
        //[ExcelColumn(Name = "状态标识")]
        [ExcelColumnName("状态标识")]
        public int IsStatus { get; set; }

        [Required(ErrorMessage = "排序不能为空")]
        //[ExcelColumn(Name = "排序")]
        [ExcelColumnName("排序")]
        public int SortingNum { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "流程类型")]
        public string SchemeTypeLabel { get; set; }
    }

}