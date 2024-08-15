namespace Ams.Model.Kernel
{
    /// <summary>
    /// 用户岗位
    /// </summary>
    [SugarTable("sys_user_post", "用户岗位")]
    [Tenant("0")]
    public class SysUserPost : SysBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long UserId { get; set; }

        /// <summary>
        /// 岗位ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long PostId { get; set; }
    }
}