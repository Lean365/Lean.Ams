using SqlSugar;

namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 用户岗位
    /// </summary>
    [SugarTable("sys_user_post", "用户与岗位关联表")]
    [Tenant("0")]
    public class SysUserPost : SysBase
    {
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long UserId { get; set; }
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long PostId { get; set; }
    }
}
