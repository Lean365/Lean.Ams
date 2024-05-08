using System.ComponentModel;

namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 本地语言
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Tenant("0")]
    [SugarTable("sys_locale", "本地语言")]
    public class SysLocale : SysBase
    {
        /// <summary>
        /// id
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
        /// 语言key
        /// </summary>
        [DisplayName("语言key")]
        [SugarColumn(ColumnName = "lang_key", Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string LangKey { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [SugarColumn(ColumnName = "lang_name", Length = 2000, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string LangName { get; set; }
    }
}