
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 主客诉管理
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 17:38:17)
    /// </summary>
    [SugarTable("qm_complaints_master")]
    public class ComplaintsMaster
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QmcmSFID { get; set; }

        /// <summary>
        /// 客诉No. 
        /// </summary>
        public string QmcmDocNo { get; set; }

        /// <summary>
        /// 外部客诉No. 
        /// </summary>
        public string QmcmIssuesNo { get; set; }

        /// <summary>
        /// 客户 
        /// </summary>
        public string QmcmCustomer { get; set; }

        /// <summary>
        /// 机种 
        /// </summary>
        public string QmcmModel { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string QmcmItem { get; set; }

        /// <summary>
        /// 仕向 
        /// </summary>
        public string QmcmRegion { get; set; }

        /// <summary>
        /// 订单 
        /// </summary>
        public string QmcmOrder { get; set; }

        /// <summary>
        /// 接收日期 
        /// </summary>
        public DateTime? QmcmReceivingDate { get; set; }

        /// <summary>
        /// 数量 
        /// </summary>
        public int QmcmFaultQty { get; set; }

        /// <summary>
        /// 投诉事项 
        /// </summary>
        public string QmcmIssues { get; set; }

        /// <summary>
        /// 序列号 
        /// </summary>
        public string QmcmSerialno { get; set; }

        /// <summary>
        /// 参考文件 
        /// </summary>
        public string QmcmReferenceDocs { get; set; }

        /// <summary>
        /// 症状 
        /// </summary>
        public string QmcmFaultDescription { get; set; }

        /// <summary>
        /// 分析 
        /// </summary>
        public string QmcmRootcauseanalysis { get; set; }

        /// <summary>
        /// 承认部门 
        /// </summary>
        public string QmcmAdmitDept { get; set; }

        /// <summary>
        /// 承认日期 
        /// </summary>
        public DateTime? QmcmAdmitDate { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        public decimal UDF56 { get; set; }

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