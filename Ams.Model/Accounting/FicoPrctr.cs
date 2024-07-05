
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 利润中心
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/5 11:21:00
    /// </summary>
    [SugarTable("fico_prctr","利润中心")]
    public class FicoPrctr
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FpSFID { get; set; }

        /// <summary>
        /// 公司 
        /// </summary>
        public string FpCorp { get; set; }

        /// <summary>
        /// 代码 
        /// </summary>
        public string FpCode { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        public string FpName { get; set; }

        /// <summary>
        /// 类别 
        /// </summary>
        public string FpType { get; set; }

        /// <summary>
        /// 有效从 
        /// </summary>
        public DateTime? FpActDate { get; set; }

        /// <summary>
        /// 有效到 
        /// </summary>
        public DateTime? FpExpDate { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}