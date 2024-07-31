namespace Ams.Model.Routine
{
    /// <summary>
    /// 计算公式
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 10:24:50
    /// </summary>
    [SugarTable("inst_formula", "计算公式")]
    public class InstFormula : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long IfSfId { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string IfType { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string IfLangKey { get; set; }

        /// <summary>
        /// 公式
        /// </summary>
        public string IfFormula { get; set; }
    }
}