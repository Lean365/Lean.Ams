namespace Ams.Model.Kernel
{
    [SugarTable("sys_post", "系统岗位")]
    [Tenant("0")]
    public class SysPost : SysBase
    {
        /// <summary>
        /// 岗位ID
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
        /// 职级
        /// </summary>

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, DefaultValue = "0")]
        public string PostLevel { get; set; }

        /// <summary>
        /// 岗位排序
        /// </summary>

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, DefaultValue = "99")]
        public int SortingNum { get; set; }

        /// <summary>
        /// 状态
        /// </summary>

        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }
    }
}