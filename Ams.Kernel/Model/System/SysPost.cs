namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 岗位信息
    /// 数据实体类：sys_post
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("sys_post", "岗位信息")]
    [Tenant("0")]
    public class SysPost : SysBase
    {
        /// <summary>
        /// 岗位信息Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long PostId { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostCode { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostName { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int PostSort { get; set; }

        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStated { get; set; }
    }
}