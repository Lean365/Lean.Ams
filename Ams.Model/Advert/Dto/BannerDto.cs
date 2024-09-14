namespace Ams.Model.Advert.Dto
{
    /// <summary>
    /// 广告管理查询对象
    /// </summary>
    public class BannerQueryDto : PagerInfo
    {
        public string Mb002 { get; set; }
        public int? Mb006 { get; set; }
        public int? Mb008 { get; set; }
        public int? Mb009 { get; set; }
    }

    /// <summary>
    /// 广告管理输入输出对象
    /// </summary>
    public class BannerDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title不能为空")]
        [ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string Mb002 { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Mb003 { get; set; }

        [ExcelColumn(Name = "链接")]
        [ExcelColumnName("链接")]
        public string Mb004 { get; set; }

        [ExcelColumn(Name = "图片")]
        [ExcelColumnName("图片")]
        public string Mb005 { get; set; }

        [Required(ErrorMessage = "跳转类型不能为空")]
        [ExcelColumn(Name = "跳转类型")]
        [ExcelColumnName("跳转类型")]
        public int Mb006 { get; set; }

        [ExcelColumn(Name = "点击次数")]
        [ExcelColumnName("点击次数")]
        public int Mb007 { get; set; }

        [Required(ErrorMessage = "是否显示不能为空")]
        [ExcelColumn(Name = "是否显示")]
        [ExcelColumnName("是否显示")]
        public int Mb008 { get; set; }

        [Required(ErrorMessage = "广告类型不能为空")]
        [ExcelColumn(Name = "广告类型")]
        [ExcelColumnName("广告类型")]
        public int Mb009 { get; set; }

        [ExcelColumn(Name = "开始时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("BeginTime")]
        public DateTime? Mb010 { get; set; }

        [ExcelColumn(Name = "结束时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("EndTime")]
        public DateTime? Mb011 { get; set; }

        [ExcelColumn(Name = "排序id")]
        [ExcelColumnName("排序id")]
        public int? Mb012 { get; set; }

        [ExcelColumn(Name = "跳转类型")]
        public string Mb006Label { get; set; }

        [ExcelColumn(Name = "是否显示")]
        public string Mb008Label { get; set; }
    }
}