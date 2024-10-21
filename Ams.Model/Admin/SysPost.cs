namespace Ams.Model.Admin
{
    /// <summary>
    /// 系统岗位
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("sys_post", "系统岗位")]
    [Tenant("0")]
    public class SysPost : SysBase
    {
        /// <summary>
        /// 岗位Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long PostId { get; set; }

        /// <summary>
        /// 岗位编码
        /// </summary>
        [SugarColumn(Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostCode { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        [SugarColumn(Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostName { get; set; }

        /// <summary>
        /// 职级编码
        /// </summary>
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int PostLevel { get; set; }

        /// <summary>
        /// 岗位排序
        /// </summary>
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int SortingNum { get; set; }

        /// <summary>
        /// 岗位状态
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; } = 0;
    }
}