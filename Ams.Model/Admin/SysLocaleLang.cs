using System.ComponentModel;

namespace Ams.Model.Admin
{
    /// <summary>
    /// 本地语言
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [Tenant("0")]
    [SugarTable("sys_locale_lang", "本地语言")]
    public class SysLocaleLang : SysBase
    {
        //使用 Insertable + ExecuteReturnSnowflakeIdAsync 为Id赋值时Id字段不能自增，
        //SqlSugarException The entity sets the primary key and is long
        //正确
        //public class EntityExample
        //{
        //    [SugarColumn(IsPrimaryKey = true, ColumnName = "Id", IsOnlyIgnoreUpdate = true)]
        //    public long Id { get; set; }
        //}

        //错误
        //public class EntityExample
        //{
        //    [SugarColumn(IsPrimaryKey = true, ColumnName = "Id", IsOnlyIgnoreUpdate = true)]
        //    public long? Id { get; set; }
        //}

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
        [SugarColumn(ColumnName = "lang_name", Length = 2000, ColumnDataType = "NVARCHAR", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string LangName { get; set; }
    }
}