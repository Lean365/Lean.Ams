namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 岗位信息
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    [SugarTable("sys_post", "岗位信息")]
    [Tenant("0")]
    public class SysPost : SysBase
    {
        /// <summary>
        /// 岗位Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long PostId { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostCode { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostName { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int PostSort { get; set; }

        [SugarColumn(DefaultValue = "0")]
        public int IsState { get; set; }
    }
}