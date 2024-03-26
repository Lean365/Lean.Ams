
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 标准工时
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 9:28:16)
    /// </summary>
    [SugarTable("pp_manhours")]
    public class Manhours
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MhSFID { get; set; }

        /// <summary>
        /// 生效日期 
        /// </summary>
        public DateTime? MhEffDate { get; set; }

        /// <summary>
        /// 工厂 
        /// </summary>
        public string MhPlant { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string MhItem { get; set; }

        /// <summary>
        /// 机种名 
        /// </summary>
        public string MhModelType { get; set; }

        /// <summary>
        /// 仕向别 
        /// </summary>
        public string MhRegionType { get; set; }

        /// <summary>
        /// 物料文本 
        /// </summary>
        public string MhItemText { get; set; }

        /// <summary>
        /// 工作中心 
        /// </summary>
        public string MhWcName { get; set; }

        /// <summary>
        /// 工作中心文本 
        /// </summary>
        public string MhWcText { get; set; }

        /// <summary>
        /// 标准点数 
        /// </summary>
        public decimal MhStdShort { get; set; }

        /// <summary>
        /// Short单位 
        /// </summary>
        public string MhShortUnit { get; set; }

        /// <summary>
        /// 点数换算汇率 
        /// </summary>
        public decimal MhToMinRate { get; set; }

        /// <summary>
        /// 标准工时 
        /// </summary>
        public decimal MhStdTime { get; set; }

        /// <summary>
        /// 工时单位 
        /// </summary>
        public string MhTimeUnit { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

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