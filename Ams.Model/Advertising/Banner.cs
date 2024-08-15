namespace Ams.Model.Advertising
{
    /// <summary>
    /// 横幅广告
    /// </summary>
    [SugarTable("advertising_banner", "横幅广告")]
    public class Banner : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true)]
        public int SfId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 跳转类型 0、不跳转 1、外链 2、内部跳转
        /// </summary>
        public int JumpType { get; set; }

        /// <summary>
        /// 点击次数
        /// </summary>
        public int? ClicksNumber { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int ShowStatus { get; set; }

        /// <summary>
        /// 广告类型
        /// </summary>
        public int AdType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int? SortingNum { get; set; }
    }
}