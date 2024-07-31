namespace Ams.Model.Routine
{
    /// <summary>
    /// 机构信息
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:51:09
    /// </summary>
    [SugarTable("inst_info", "机构信息")]
    public class InstInfo : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long IiSfId { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string IiLangkey { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string IiCategory { get; set; }

        /// <summary>
        /// 编号
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string IiInstCode { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string IiShortName { get; set; }

        /// <summary>
        /// 全称
        /// </summary>
        public string IiFullName { get; set; }

        /// <summary>
        /// 性质
        /// </summary>
        public string IiNature { get; set; }

        /// <summary>
        /// 外线
        /// </summary>
        public string IiOuterPhone { get; set; }

        /// <summary>
        /// 内线
        /// </summary>
        public string IiInnerPhone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string IiFax { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string IiPostalcode { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string IiEmail { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string IiOrgCode { get; set; }

        /// <summary>
        /// 法人
        /// </summary>
        public string IiCorporate { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string IiRegionId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string IiProvinceId { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string IiCityId { get; set; }

        /// <summary>
        /// 县/区
        /// </summary>
        public string IiCountyId { get; set; }

        /// <summary>
        /// 镇
        /// </summary>
        public string IiTownId { get; set; }

        /// <summary>
        /// 村
        /// </summary>
        public string IiVillageId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string IiAddress { get; set; }

        /// <summary>
        /// 英文地址
        /// </summary>
        public string IiEnAddress { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        public string IiWebSite { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        public DateTime? IiFoundedTime { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        public string IiBusinessScope { get; set; }

        /// <summary>
        /// 母公司
        /// </summary>
        public string IiParentCorp { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IiSortCode { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IiisEnabled { get; set; }

        /// <summary>
        /// 企业口号
        /// </summary>
        public string IiSlogan { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        public string IiLicenseAnnex { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        public string IiOtherAnnex { get; set; }
    }
}