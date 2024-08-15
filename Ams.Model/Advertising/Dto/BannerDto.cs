namespace Ams.Model.Advertising.Dto
{
    /// <summary>
    /// 横幅广告查询对象
    /// </summary>
    public class BannerQueryDto : PagerInfo
    {
        public string Title { get; set; }
        public int? JumpType { get; set; }
        public int? ShowStatus { get; set; }
        public int? AdType { get; set; }
    }

    /// <summary>
    /// 横幅广告输入输出对象
    /// </summary>
    public class BannerDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title不能为空")]
        [ExcelColumn(Name = "标题")]
        [ExcelColumnName("Title")]
        public string Title { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Content { get; set; }

        [ExcelColumn(Name = "链接")]
        [ExcelColumnName("链接")]
        public string Link { get; set; }

        [ExcelColumn(Name = "图片")]
        [ExcelColumnName("图片")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "跳转类型不能为空")]
        [ExcelColumn(Name = "跳转类型")]
        [ExcelColumnName("跳转类型")]
        public int JumpType { get; set; }

        [ExcelColumn(Name = "点击次数")]
        [ExcelColumnName("点击次数")]
        public int ClicksNumber { get; set; }

        [Required(ErrorMessage = "是否显示不能为空")]
        [ExcelColumn(Name = "是否显示")]
        [ExcelColumnName("是否显示")]
        public int ShowStatus { get; set; }

        [Required(ErrorMessage = "广告类型不能为空")]
        [ExcelColumn(Name = "广告类型")]
        [ExcelColumnName("广告类型")]
        public int AdType { get; set; }

        [ExcelColumn(Name = "开始时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("BeginTime")]
        public DateTime? BeginTime { get; set; }

        [ExcelColumn(Name = "结束时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("EndTime")]
        public DateTime? EndTime { get; set; }

        [ExcelColumn(Name = "排序id")]
        [ExcelColumnName("排序id")]
        public int? SortId { get; set; }

        [ExcelColumn(Name = "跳转类型")]
        public string JumpTypeLabel { get; set; }

        [ExcelColumn(Name = "是否显示")]
        public string ShowStatusLabel { get; set; }
    }
}