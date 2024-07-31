namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 机构信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:51:09
    /// </summary>
    public class InstInfoQueryDto : PagerInfo
    {
        public string IiCategory { get; set; }
        public string IiInstCode { get; set; }
        public string IiShortName { get; set; }
        public string IiFullName { get; set; }
        public string IiNature { get; set; }
        public DateTime? BeginIiFoundedTime { get; set; }
        public DateTime? EndIiFoundedTime { get; set; }
        public int? IiisEnabled { get; set; }
    }

    /// <summary>
    /// 机构信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:51:09
    /// </summary>
    public class InstInfoDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IiSfId { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IiLangkey { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string IiCategory { get; set; }

        [Required(ErrorMessage = "编号不能为空")]
        [ExcelColumn(Name = "编号")]
        [ExcelColumnName("编号")]
        public string IiInstCode { get; set; }

        [Required(ErrorMessage = "简称不能为空")]
        [ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]
        public string IiShortName { get; set; }

        [Required(ErrorMessage = "全称不能为空")]
        [ExcelColumn(Name = "全称")]
        [ExcelColumnName("全称")]
        public string IiFullName { get; set; }

        [Required(ErrorMessage = "性质不能为空")]
        [ExcelColumn(Name = "性质")]
        [ExcelColumnName("性质")]
        public string IiNature { get; set; }

        [Required(ErrorMessage = "外线不能为空")]
        [ExcelColumn(Name = "外线")]
        [ExcelColumnName("外线")]
        public string IiOuterPhone { get; set; }

        [Required(ErrorMessage = "内线不能为空")]
        [ExcelColumn(Name = "内线")]
        [ExcelColumnName("内线")]
        public string IiInnerPhone { get; set; }

        [Required(ErrorMessage = "传真不能为空")]
        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string IiFax { get; set; }

        [ExcelColumn(Name = "邮编")]
        [ExcelColumnName("邮编")]
        public string IiPostalcode { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string IiEmail { get; set; }

        [Required(ErrorMessage = "组织代码不能为空")]
        [ExcelColumn(Name = "组织代码")]
        [ExcelColumnName("组织代码")]
        public string IiOrgCode { get; set; }

        [Required(ErrorMessage = "法人不能为空")]
        [ExcelColumn(Name = "法人")]
        [ExcelColumnName("法人")]
        public string IiCorporate { get; set; }

        [Required(ErrorMessage = "地区不能为空")]
        [ExcelColumn(Name = "地区")]
        [ExcelColumnName("地区")]
        public string IiRegionId { get; set; }

        [Required(ErrorMessage = "省不能为空")]
        [ExcelColumn(Name = "省")]
        [ExcelColumnName("省")]
        public string IiProvinceId { get; set; }

        [Required(ErrorMessage = "市不能为空")]
        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string IiCityId { get; set; }

        [Required(ErrorMessage = "县/区不能为空")]
        [ExcelColumn(Name = "县/区")]
        [ExcelColumnName("县/区")]
        public string IiCountyId { get; set; }

        [ExcelColumn(Name = "镇")]
        [ExcelColumnName("镇")]
        public string IiTownId { get; set; }

        [ExcelColumn(Name = "村")]
        [ExcelColumnName("村")]
        public string IiVillageId { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string IiAddress { get; set; }

        [Required(ErrorMessage = "英文地址不能为空")]
        [ExcelColumn(Name = "英文地址")]
        [ExcelColumnName("英文地址")]
        public string IiEnAddress { get; set; }

        [ExcelColumn(Name = "网址")]
        [ExcelColumnName("网址")]
        public string IiWebSite { get; set; }

        [Required(ErrorMessage = "成立日期不能为空")]
        [ExcelColumn(Name = "成立日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("成立日期")]
        public DateTime? IiFoundedTime { get; set; }

        [Required(ErrorMessage = "经营范围不能为空")]
        [ExcelColumn(Name = "经营范围")]
        [ExcelColumnName("经营范围")]
        public string IiBusinessScope { get; set; }

        [ExcelColumn(Name = "母公司")]
        [ExcelColumnName("母公司")]
        public string IiParentCorp { get; set; }

        [Required(ErrorMessage = "排序不能为空")]
        [ExcelColumn(Name = "排序")]
        [ExcelColumnName("排序")]
        public int IiSortCode { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int IiisEnabled { get; set; }

        [ExcelColumn(Name = "企业口号")]
        [ExcelColumnName("企业口号")]
        public string IiSlogan { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string IiLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string IiOtherAnnex { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "语言")]
        public string IiLangkeyLabel { get; set; }

        [ExcelColumn(Name = "类别")]
        public string IiCategoryLabel { get; set; }

        [ExcelColumn(Name = "性质")]
        public string IiNatureLabel { get; set; }

        [ExcelColumn(Name = "启用")]
        public string IiisEnabledLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 机构信息
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:51:09
    /// </summary>
    public class InstInfoImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IiSfId { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IiLangkey { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string IiCategory { get; set; }

        [Required(ErrorMessage = "编号不能为空")]
        [ExcelColumn(Name = "编号")]
        [ExcelColumnName("编号")]
        public string IiInstCode { get; set; }

        [Required(ErrorMessage = "简称不能为空")]
        [ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]
        public string IiShortName { get; set; }

        [Required(ErrorMessage = "全称不能为空")]
        [ExcelColumn(Name = "全称")]
        [ExcelColumnName("全称")]
        public string IiFullName { get; set; }

        [Required(ErrorMessage = "性质不能为空")]
        [ExcelColumn(Name = "性质")]
        [ExcelColumnName("性质")]
        public string IiNature { get; set; }

        [Required(ErrorMessage = "外线不能为空")]
        [ExcelColumn(Name = "外线")]
        [ExcelColumnName("外线")]
        public string IiOuterPhone { get; set; }

        [Required(ErrorMessage = "内线不能为空")]
        [ExcelColumn(Name = "内线")]
        [ExcelColumnName("内线")]
        public string IiInnerPhone { get; set; }

        [Required(ErrorMessage = "传真不能为空")]
        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string IiFax { get; set; }

        [ExcelColumn(Name = "邮编")]
        [ExcelColumnName("邮编")]
        public string IiPostalcode { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string IiEmail { get; set; }

        [Required(ErrorMessage = "组织代码不能为空")]
        [ExcelColumn(Name = "组织代码")]
        [ExcelColumnName("组织代码")]
        public string IiOrgCode { get; set; }

        [Required(ErrorMessage = "法人不能为空")]
        [ExcelColumn(Name = "法人")]
        [ExcelColumnName("法人")]
        public string IiCorporate { get; set; }

        [Required(ErrorMessage = "地区不能为空")]
        [ExcelColumn(Name = "地区")]
        [ExcelColumnName("地区")]
        public string IiRegionId { get; set; }

        [Required(ErrorMessage = "省不能为空")]
        [ExcelColumn(Name = "省")]
        [ExcelColumnName("省")]
        public string IiProvinceId { get; set; }

        [Required(ErrorMessage = "市不能为空")]
        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string IiCityId { get; set; }

        [Required(ErrorMessage = "县/区不能为空")]
        [ExcelColumn(Name = "县/区")]
        [ExcelColumnName("县/区")]
        public string IiCountyId { get; set; }

        [ExcelColumn(Name = "镇")]
        [ExcelColumnName("镇")]
        public string IiTownId { get; set; }

        [ExcelColumn(Name = "村")]
        [ExcelColumnName("村")]
        public string IiVillageId { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string IiAddress { get; set; }

        [Required(ErrorMessage = "英文地址不能为空")]
        [ExcelColumn(Name = "英文地址")]
        [ExcelColumnName("英文地址")]
        public string IiEnAddress { get; set; }

        [ExcelColumn(Name = "网址")]
        [ExcelColumnName("网址")]
        public string IiWebSite { get; set; }

        [Required(ErrorMessage = "成立日期不能为空")]
        [ExcelColumn(Name = "成立日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("成立日期")]
        public DateTime? IiFoundedTime { get; set; }

        [Required(ErrorMessage = "经营范围不能为空")]
        [ExcelColumn(Name = "经营范围")]
        [ExcelColumnName("经营范围")]
        public string IiBusinessScope { get; set; }

        [ExcelColumn(Name = "母公司")]
        [ExcelColumnName("母公司")]
        public string IiParentCorp { get; set; }

        [Required(ErrorMessage = "排序不能为空")]
        [ExcelColumn(Name = "排序")]
        [ExcelColumnName("排序")]
        public int IiSortCode { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int IiisEnabled { get; set; }

        [ExcelColumn(Name = "企业口号")]
        [ExcelColumnName("企业口号")]
        public string IiSlogan { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string IiLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string IiOtherAnnex { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "语言")]
        public string IiLangkeyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string IiCategoryLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "性质")]
        public string IiNatureLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string IiisEnabledLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}