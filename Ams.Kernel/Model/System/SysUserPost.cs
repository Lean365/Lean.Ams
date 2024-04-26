namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 用户岗位
    /// 数据实体类：sys_user_post
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("sys_user_post", "用户岗位")]
    [Tenant("0")]
    public class SysUserPost : SysBase
    {
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long UserId { get; set; }

        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long PostId { get; set; }
    }
}