namespace Ams.Model.Admin
{
    /// <summary>
    /// 用户岗位
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
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