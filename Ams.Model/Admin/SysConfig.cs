namespace Ams.Model.Admin
{
    /// <summary>
    /// 系统参数
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("sys_config", "系统参数")]
    [Tenant("0")]
    public class SysConfig : SysBase
    {
        /// <summary>
        /// 配置id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ConfigId { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        [SugarColumn(Length = 100)]
        public string ConfigName { get; set; }

        /// <summary>
        /// 参数键名
        /// </summary>
        [SugarColumn(Length = 100)]
        public string ConfigKey { get; set; }

        /// <summary>
        /// 参数键值
        /// </summary>
        [SugarColumn(Length = 500)]
        public string ConfigValue { get; set; }

        /// <summary>
        /// 系统内置（Y是 N否）
        /// </summary>
        [SugarColumn(Length = 1)]
        public string ConfigType { get; set; }
    }
}