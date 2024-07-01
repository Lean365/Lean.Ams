namespace Ams.Model.Systems
{
    [SugarTable("sys_post", "岗位表")]
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
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostCode { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostName { get; set; }

        /// <summary>
        /// 岗位级别
        /// </summary>

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string PostLevel { get; set; }

        /// <summary>
        /// 岗位排序
        /// </summary>

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int PostSort { get; set; }

        /// <summary>
        /// 岗位状态（0正常 1停用）
        /// </summary>

        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }
    }
}