namespace Ams.Model.Routine
{
    /// <summary>
    /// KPI
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:44:18
    /// </summary>
    [SugarTable("inst_kpi", "KPI")]
    public class InstKpi : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long IkSFID { get; set; }

        /// <summary>
        /// 公司简称
        /// </summary>
        public string IkAbbrName { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        public string IkAnnual { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string IkLangKey { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        public string IkTarget { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IsDeleted { get; set; }
    }
}