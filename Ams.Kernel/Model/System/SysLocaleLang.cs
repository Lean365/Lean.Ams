using Newtonsoft.Json;
using SqlSugar;
using System;
using System.ComponentModel;

namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 多语言配置，数据实体对象
    /// </summary>
    [Tenant("0")]
    [SugarTable("sys_locale_lang", "多语言配置表")]
    public class SysLocaleLang : SysBase
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