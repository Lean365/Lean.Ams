namespace Ams.Model.Logistics
{
    /// <summary>
    /// 主客诉管理
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:33:20
    /// </summary>
    [SugarTable("qm_complaints_master", "主客诉管理")]
    public class QmComplaintsMaster : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QmcmSfId { get; set; }

        /// <summary>
        /// 客诉No.
        /// </summary>
        [SugarColumn(ColumnName = "QmcmDocNo", ColumnDescription = "客诉No. ", Length = 20)]
        public string QmcmDocNo { get; set; }

        /// <summary>
        /// 外部客诉No.
        /// </summary>
        [SugarColumn(ColumnName = "QmcmIssuesNo", ColumnDescription = "外部客诉No. ", Length = 20)]
        public string QmcmIssuesNo { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [SugarColumn(ColumnName = "QmcmCustomer", ColumnDescription = "客户 ", Length = 20)]
        public string QmcmCustomer { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "QmcmModel", ColumnDescription = "机种 ", Length = 40)]
        public string QmcmModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "QmcmItem", ColumnDescription = "物料 ", Length = 20)]
        public string QmcmItem { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "QmcmRegion", ColumnDescription = "仕向 ", Length = 20)]
        public string QmcmRegion { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [SugarColumn(ColumnName = "QmcmOrder", ColumnDescription = "订单 ", Length = 20)]
        public string QmcmOrder { get; set; }

        /// <summary>
        /// 接收日期
        /// </summary>
        public DateTime? QmcmReceivingDate { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "QmcmFaultQty", ColumnDescription = "数量 ", DefaultValue = "0")]
        public int QmcmFaultQty { get; set; }

        /// <summary>
        /// 投诉事项
        /// </summary>
        [SugarColumn(ColumnName = "QmcmIssues", ColumnDescription = "投诉事项 ", Length = 2000)]
        public string QmcmIssues { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "QmcmSerialno", ColumnDescription = "序列号 ", Length = 200)]
        public string QmcmSerialno { get; set; }

        /// <summary>
        /// 参考文件
        /// </summary>
        [SugarColumn(ColumnName = "QmcmReferenceDocs", ColumnDescription = "参考文件 ", Length = 200)]
        public string QmcmReferenceDocs { get; set; }

        /// <summary>
        /// 症状
        /// </summary>
        [SugarColumn(ColumnName = "QmcmFaultDescription", ColumnDescription = "症状 ", Length = 2000)]
        public string QmcmFaultDescription { get; set; }

        /// <summary>
        /// 分析
        /// </summary>
        [SugarColumn(ColumnName = "QmcmRootcauseanalysis", ColumnDescription = "分析 ", Length = 2000)]
        public string QmcmRootcauseanalysis { get; set; }

        /// <summary>
        /// 承认部门
        /// </summary>
        [SugarColumn(ColumnName = "QmcmAdmitDept", ColumnDescription = "承认部门 ", Length = 40)]
        public string QmcmAdmitDept { get; set; }

        /// <summary>
        /// 承认日期
        /// </summary>
        public DateTime? QmcmAdmitDate { get; set; }
    }
}