namespace Ams.Model.Advert
{
    /// <summary>
    /// 广告管理
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("advert_banner", "广告管理")]
    public class Banner : SysBase
    {
        /// <summary>
        /// id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [SugarColumn(ColumnName = "Mb002", ColumnDescription = "标题", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb002 { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "说明", Length = 200)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "链接", Length = 200)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "图片", Length = 200)]
        public string Mb005 { get; set; }

        /// <summary>
        /// 跳转类型 0、不跳转 1、外链 2、内部跳转
        /// </summary>
        [SugarColumn(ColumnName = "Mb006", ColumnDescription = "跳转类型", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb006 { get; set; }

        /// <summary>
        /// 点击次数
        /// </summary>
        [SugarColumn(ColumnName = "Mb007", ColumnDescription = "点击次数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mb007 { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [SugarColumn(ColumnName = "Mb008", ColumnDescription = "是否显示", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb008 { get; set; }

        /// <summary>
        /// 广告类型
        /// </summary>
        [SugarColumn(ColumnName = "Mb009", ColumnDescription = "广告类型", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb009 { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Mb010 { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? Mb011 { get; set; }

        /// <summary>
        /// 排序id
        /// </summary>
        [SugarColumn(ColumnName = "Mb012", ColumnDescription = "排序id", DefaultValue = "9", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mb012 { get; set; }
    }
}