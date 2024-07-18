namespace Ams.Model.Logistics
{
    /// <summary>
    /// 主客诉管理
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 13:25:51
    /// </summary>
    [SugarTable("qm_complaints_master", "主客诉管理")]
    public class QmComplaintsMaster : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
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
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsDeleted { get; set; }
    }
}