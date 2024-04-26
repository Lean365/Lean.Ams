namespace Ams.Kernel.Model
{
    /// <summary>
    /// 系统用户常量
    /// NORMAL:正常状态，EXCEPTION:异常状态，USER_DISABLE:用户封禁状态，ROLE_DISABLE:角色信息封禁状态，
    /// DEPT_NORMAL:部门信息正常状态，DEPT_DISABLE:部门信息停用状态，DICT_NORMAL:字典正常状态，YES:是否为系统默认（是），
    /// YES_FRAME:是否菜单信息外链（是），NO_FRAME:是否菜单信息外链（否），TYPE_DIR:菜单信息类型（目录），TYPE_MENU:菜单信息类型（菜单信息），
    /// TYPE_BUTTON:菜单信息类型（按钮），LAYOUT:Layout组件标识，PARENT_VIEW:ParentView组件标识，INNER_LINK:InnerLink组件标识，
    /// UNIQUE:校验返回结果码，NOT_UNIQUE:校验返回结果码，HTTP:http请求，HTTPS:https请求，WWW:www主域
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class UserConstants
    {
        /// <summary>
        /// 平台内系统用户的唯一标志
        /// </summary>
        public static string SYS_USER = "SYS_USER";

        /// <summary>
        /// 正常状态
        /// </summary>
        public static string NORMAL = "0";

        /// <summary>
        /// 异常状态
        /// </summary>
        public static string EXCEPTION = "1";

        /// <summary>
        /// 用户封禁状态
        /// </summary>
        public static string USER_DISABLE = "1";

        /// <summary>
        /// 角色信息封禁状态
        /// </summary>
        public static string ROLE_DISABLE = "1";

        /// <summary>
        /// 部门信息正常状态
        /// </summary>
        public static int DEPT_NORMAL = 0;

        /// <summary>
        /// 部门信息停用状态
        /// </summary>
        public static string DEPT_DISABLE = "1";

        /// <summary>
        /// 字典正常状态
        /// </summary>
        public static string DICT_NORMAL = "0";

        /// <summary>
        /// 是否为系统默认（是）
        /// </summary>
        public static string YES = "Y";

        /// <summary>
        /// 是否菜单信息外链（是）
        /// </summary>
        public static string YES_FRAME = "1";

        /// <summary>
        /// 是否菜单信息外链（否）
        /// </summary>
        public static string NO_FRAME = "0";

        /// <summary>
        /// 菜单信息类型（目录）
        /// </summary>
        public static string TYPE_DIR = "M";

        /// <summary>
        /// 菜单信息类型（菜单信息）
        /// </summary>
        public static string TYPE_MENU = "C";

        /// <summary>
        /// 菜单信息类型（按钮）
        /// </summary>
        public static string TYPE_BUTTON = "F";

        ///// <summary>
        ///// 菜单信息类型（链接）
        ///// </summary>
        //public static string TYPE_LINK = "L";

        /// <summary>
        /// Layout组件标识
        /// </summary>
        public static string LAYOUT = "Layout";

        /// <summary>
        /// ParentView组件标识
        /// </summary>
        public static string PARENT_VIEW = "ParentView";

        /// <summary>
        /// InnerLink组件标识
        /// </summary>
        public static string INNER_LINK = "InnerLink";

        /// <summary>
        /// 校验返回结果码
        /// </summary>
        public static string UNIQUE = "0";

        public static string NOT_UNIQUE = "1";

        /// <summary>
        /// http请求
        /// </summary>
        public static string HTTP = "http://";

        /// <summary>
        /// https请求
        /// </summary>
        public static string HTTPS = "https://";

        /// <summary>
        /// www主域
        /// </summary>
        public static string WWW = "www.";
    }
}