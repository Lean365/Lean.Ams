namespace Ams.Kernel.Model.Dto.Generator
{
    /// <summary>
    /// 生成表信息
    /// 输入输出对象，用于生成代码
    /// 调用 app.UseMiddlewareGlobalExceptionMiddleware>();
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class GenTableDto
    {
        /// <summary>
        /// 表ID
        /// </summary>
        public int TableId { get; set; }

        /// <summary>
        /// 数据表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 数据表描述
        /// </summary>
        public string TableComment { get; set; }

        /// <summary>
        /// 子表名
        /// </summary>
        public string SubTableName { get; set; }

        /// <summary>
        /// 子表外键名
        /// </summary>
        public string SubTableFkName { get; set; }

        /// <summary>
        /// C#类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 模板分类
        /// crud：单表（增删改查）, tree：树表（增删改查）, subNavMore:主子表（增删改查）
        /// </summary>
        public string TplCategory { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string BaseNameSpace { get; set; }

        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 业务名
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// 功能名
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string FunctionAuthor { get; set; }

        /// <summary>
        /// 生成类型
        /// </summary>
        public string GenType { get; set; }

        /// <summary>
        /// 生成路径
        /// </summary>
        public string GenPath { get; set; }

        //public string PermissionPrefix { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 额外参数
        /// </summary>
        public CodeOptions Params { get; set; }

        /// <summary>
        /// 表列
        /// </summary>
        public List<GenTableColumnDto> Columns { get; set; }
    }

    /// <summary>
    /// 生成表字段
    /// 输入输出对象，用于生成代码
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class GenTableColumnDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ColumnId { get; set; }

        /// <summary>
        /// 表ID
        /// </summary>
        public int TableId { get; set; }

        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnComment { get; set; }

        public string CsharpType { get; set; }
        public string CsharpField { get; set; }
        public bool IsInsert { get; set; }
        public bool IsEdit { get; set; }
        public bool IsList { get; set; }
        public bool IsQuery { get; set; }
        public bool IsSort { get; set; }
        public bool IsRequired { get; set; }
        public bool IsExport { get; set; }

        /// <summary>
        /// 显示类型（文本框、文本域、下拉框、复选框、单选框、日期控件）
        /// </summary>
        public string HtmlType { get; set; }

        /// <summary>
        /// 查询类型（等于、不等于、大于、小于、范围）
        /// </summary>
        public string QueryType { get; set; } = "EQ";

        public int Sort { get; set; }

        /// <summary>
        /// 字典类别
        /// </summary>
        public string DictType { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 自动填充类型
        /// </summary>
        public int? AutoFillType { get; set; }
    }
}