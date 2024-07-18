namespace Ams.Model.Kernel
{
    [SugarTable("sys_post", "系统岗位")]
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
        public string PostLevel { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int SortingNum { get; set; }

        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }
    }
}