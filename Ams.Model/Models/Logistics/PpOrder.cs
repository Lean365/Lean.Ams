
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产工单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/23 17:16:30
    /// </summary>
    [SugarTable("pp_order")]
    public class PpOrder
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MoSFID { get; set; }

        /// <summary>
        /// 生产工厂 
        /// </summary>
        public string MoPlant { get; set; }

        /// <summary>
        /// 订单类型 
        /// </summary>
        public string MoOrderType { get; set; }

        /// <summary>
        /// 生产订单 
        /// </summary>
        public string MoOrderNo { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string MoOrderItem { get; set; }

        /// <summary>
        /// 批次 
        /// </summary>
        public string MoOrderlot { get; set; }

        /// <summary>
        /// 工单数量 
        /// </summary>
        public decimal MoOrderQty { get; set; }

        /// <summary>
        /// 生产数量 
        /// </summary>
        public decimal MoOrderProQty { get; set; }

        /// <summary>
        /// 订单日期 
        /// </summary>
        public DateTime? MoOrderDate { get; set; }

        /// <summary>
        /// 工艺路线 
        /// </summary>
        public string MoOrderRoute { get; set; }

        /// <summary>
        /// 序列号 
        /// </summary>
        public string MoOrderSerial { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public int IsStated { get; set; }

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