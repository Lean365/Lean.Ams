namespace Ams.CodeGenerator
{
    /// <summary>
    /// 代码生成常量
    /// </summary>
    public class GenConstants
    {
        public static string Gen_dbname = "CodeGenDbConfig:DbName";
        public static string Gen_author = "codeGen:author";
        public static string CodeGenDbConfig;

        /// <summary>
        /// InputDto输入实体是不包含字段
        /// </summary>
        public static readonly string[] inputDtoNoField = new string[] {"id",  "IsDeleted","isDeleted","Is_deleted",
            "createTime", "create_time", "createBy", "create_by",
            "updateTime", "update_time", "updateBy", "update_by" ,
            "Create_time", "Update_time", "Create_by", "Update_by",
             "Ref01", "Ref02", "Ref03", "Ref04", "Ref05", "Ref06",
            "Udf01", "Udf02", "Udf03", "Udf04", "Udf05", "Udf06", "Udf51", "Udf52", "Udf53", "Udf54", "Udf55", "Udf56",
                     "REF01", "REF02", "REF03", "REF04", "REF05", "REF06",
            "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56"
        };

        /// <summary>
        /// 图片字段
        /// </summary>
        public static readonly string[] imageFiled = new string[] { "icon", "img", "image", "url", "pic", "photo", "avatar" };

        /// <summary>
        /// 下拉框字段
        /// </summary>
        public static readonly string[] selectFiled = new string[] { "IsStatus", "type", "sex", "gender" };

        /// <summary>
        /// 单选按钮字段
        /// </summary>
        public static readonly string[] radioFiled = new string[] { "IsStatus" };

        /// <summary>
        /// 单表（增删改查）
        /// </summary>
        public static string TPL_CRUD = "crud";

        /// <summary>
        /// 树表（增删改查）
        /// </summary>
        public static string TPL_TREE = "tree";

        /// <summary>
        /// 主子表（增删改查）
        /// </summary>
        public static string TPL_SUB = "sub";

        /// <summary>
        /// 树编码字段
        /// </summary>
        public static string TREE_CODE = "treeCode";

        /// <summary>
        /// 树父编码字段
        /// </summary>
        public static string TREE_PARENT_CODE = "treeParentCode";

        /// <summary>
        /// 树名称字段
        /// </summary>
        public static string TREE_NAME = "treeName";

        /// <summary>
        /// 上级菜单ID字段
        /// </summary>
        public static string PARENT_MENU_ID = "parentMenuId";

        /// <summary>
        /// 上级菜单名称字段
        /// </summary>
        public static string PARENT_MENU_NAME = "parentMenuName";

        /// <summary>
        /// 数据库字符串类型
        /// </summary>
        public static string[] COLUMNTYPE_STR = { "char", "varchar", "nvarchar", "varchar2" };

        /// <summary>
        /// 数据库文本类型
        /// </summary>
        public static string[] COLUMNTYPE_TEXT = { "tinytext", "text", "mediumtext", "longtext" };

        /// <summary>
        /// 数据库时间类型
        /// </summary>
        public static string[] COLUMNTYPE_TIME = { "datetime", "time", "date", "timestamp" };

        /// <summary>
        /// 页面不需要编辑字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_EDIT = { "id",  "IsDeleted","isDeleted","Is_deleted",
           "createBy", "createTime", "updateBy", "updateTime",
            "CreateBy","CreateTime","UpdateBy","UpdateTime",
            "create_time", "update_time", "create_by", "update_by",
             "Create_time", "Update_time", "Create_by", "Update_by",
             "Ref01", "Ref02", "Ref03", "Ref04", "Ref05", "Ref06",
            "Udf01", "Udf02", "Udf03", "Udf04", "Udf05", "Udf06", "Udf51", "Udf52", "Udf53", "Udf54", "Udf55", "Udf56",
                             "REF01", "REF02", "REF03", "REF04", "REF05", "REF06",
            "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56"};

        /// <summary>
        /// 页面不需要显示的列表字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_LIST = {  "IsDeleted",  "password","isDeleted","Is_deleted",
           "createBy", "createTime", "updateBy", "updateTime",
            "CreateBy","CreateTime","UpdateBy","UpdateTime",
            "create_time", "update_time", "create_by", "update_by",
             "Create_time", "Update_time", "Create_by", "Update_by",
             "Ref01", "Ref02", "Ref03", "Ref04", "Ref05", "Ref06",
            "Udf01", "Udf02", "Udf03", "Udf04", "Udf05", "Udf06", "Udf51", "Udf52", "Udf53", "Udf54", "Udf55", "Udf56",
                             "REF01", "REF02", "REF03", "REF04", "REF05", "REF06",
            "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56"};

        /// <summary>
        /// 页面不需要查询字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_QUERY = { "id","IsDeleted", "remark" ,"isDeleted","Is_deleted",
           "createBy", "createTime", "updateBy", "updateTime",
            "CreateBy","CreateTime","UpdateBy","UpdateTime",
            "create_time", "update_time", "create_by", "update_by",
             "Create_time", "Update_time", "Create_by", "Update_by",
             "Ref01", "Ref02", "Ref03", "Ref04", "Ref05", "Ref06",
             "Udf01", "Udf02", "Udf03", "Udf04", "Udf05", "Udf06", "Udf51", "Udf52", "Udf53", "Udf54", "Udf55", "Udf56",
                             "REF01", "REF02", "REF03", "REF04", "REF05", "REF06",
            "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56"};

        /// <summary>
        /// 页面不需要导出字段
        /// </summary>
        public static string[] COLUMNNAME_NOT_EXPORT = {"IsDeleted", "remark" ,"isDeleted","Is_deleted",
            "createBy", "createTime", "updateBy", "updateTime",
            "CreateBy","CreateTime","UpdateBy","UpdateTime",
            "create_time", "update_time", "create_by", "update_by",
             "Create_time", "Update_time", "Create_by", "Update_by",
             "Ref01", "Ref02", "Ref03", "Ref04", "Ref05", "Ref06",
            "Udf01", "Udf02", "Udf03", "Udf04", "Udf05", "Udf06", "Udf51", "Udf52", "Udf53", "Udf54", "Udf55", "Udf56" ,
                             "REF01", "REF02", "REF03", "REF04", "REF05", "REF06",
            "UDF01", "UDF02", "UDF03", "UDF04", "UDF05", "UDF06", "UDF51", "UDF52", "UDF53", "UDF54", "UDF55", "UDF56"};

        /// <summary>
        /// 页面不需要填写字段
        /// </summary>

        //public static string[] COLUMNNAME_NOT_REQUIRED = { "IsDeleted",
        //   "createBy", "createTime", "updateBy", "updateTime",
        //    "CreateBy","CreateTime","UpdateBy","UpdateTime",
        //    "create_time", "update_time", "create_by", "update_by",
        //    "Udf01", "Udf02", "Udf03", "Udf04", "Udf05", "Udf06", "Udf51", "Udf52", "Udf53", "Udf54", "Udf55", "Udf56" };

        /// <summary>
        /// Entity基类字段
        /// </summary>
        public static string[] BASE_ENTITY = { "remark", "createBy", "createTime", "updateBy", "updateTime" };

        /// <summary>
        /// Tree基类字段
        /// </summary>
        public static string[] TREE_ENTITY = { "parentName", "parentId", "SortingNum", "ancestors", "children" };

        /// <summary>
        /// 文本框
        /// </summary>
        public static string HTML_INPUT = "input";

        /// <summary>
        /// 数字框
        /// </summary>
        public static string HTML_INPUT_NUMBER = "inputNumber";

        /// <summary>
        /// 文本域
        /// </summary>
        public static string HTML_TEXTAREA = "textarea";

        /** 下拉框 */
        public static string HTML_SELECT = "select";

        /// <summary>
        /// 下拉多选
        /// </summary>
        public static string HTML_SELECT_MULTI = "selectMulti";

        /// <summary>
        /// 下拉远程
        /// </summary>
        public static string HTML_SELECT_REMOTE = "selectRemote";

        /// <summary>
        /// 虚拟化下拉框
        /// </summary>
        public static string HTML_SELECT_VIRTUAL = "selectVirtual";

        /// <summary>
        /// 多选虚拟化下拉框
        /// </summary>
        public static string HTML_SELECT_VIRTUAL_MULTI = "selectVirtualMulti";

        /// <summary>
        /// 远程虚拟化下拉框
        /// </summary>
        public static string HTML_SELECT_VIRTUAL_REMOTE = "selectVirtualRemote";

        /// <summary>
        /// 单选框
        /// </summary>
        public static string HTML_RADIO = "radio";

        /// <summary>
        /// 复选框
        /// </summary>
        public static string HTML_CHECKBOX = "checkbox";

        /// <summary>
        /// 日期控件
        /// </summary>
        public static string HTML_DATETIME = "datetime";

        /// <summary>
        /// 图片上传控件
        /// </summary>
        public static string HTML_IMAGE_UPLOAD = "imageUpload";

        /// <summary>
        /// 文件上传控件
        /// </summary>
        public static string HTML_FILE_UPLOAD = "fileUpload";

        /// <summary>
        /// 富文本控件
        /// </summary>
        public static string HTML_EDITOR = "editor";

        /// <summary>
        /// 自定义输入框
        /// </summary>
        public static string HTML_CUSTOM_INPUT = "customInput";

        /// <summary>
        /// 颜色选择器
        /// </summary>
        public static string HTML_COLORPICKER = "colorPicker";

        /// <summary>
        /// 模糊查询
        /// </summary>
        public static string QUERY_LIKE = "LIKE";

        /// <summary>
        /// 需要
        /// </summary>
        public static string REQUIRE = "1";

        /// <summary>
        /// 时间类型
        /// </summary>
        public static string TYPE_DATE = "DateTime";
    }
}