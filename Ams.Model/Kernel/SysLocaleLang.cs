using System.ComponentModel;

namespace Ams.Model.Kernel
{
    /// <summary>
    /// 本地语言，数据实体对象
    /// </summary>
    [Tenant("0")]
    [SugarTable("sys_locale_lang", "本地语言")]
    public class SysLocaleLang : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }

        /// <summary>
        /// 语言code
        /// </summary>
        [DisplayName("语言code")]
        [SugarColumn(ColumnName = "lang_code", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string LangCode { get; set; }

        /// <summary>
        /// 翻译Key
        /// </summary>
        [DisplayName("翻译Key")]
        [SugarColumn(ColumnName = "lang_key", Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string LangKey { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [SugarColumn(ColumnName = "lang_name", ColumnDataType = StaticConfig.CodeFirst_BigString, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string LangName { get; set; }
    }
}