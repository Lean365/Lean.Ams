namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制技
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:21
    /// </summary>
    [SugarTable("pp_ec_master_pe", "制技")]
    public class PpEcMasterPe : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? EcmSfId { get; set; }

        /// <summary>
        /// 发行日期
        /// </summary>
        public DateTime? EcmIssueDate { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "EcmNo", ColumnDescription = "设变No. ", Length = 20)]
        public string EcmNo { get; set; }

        /// <summary>
        /// 关联文件
        /// </summary>
        [SugarColumn(ColumnName = "EcmFileUrl", ColumnDescription = "关联文件 ", Length = 500)]
        public string EcmFileUrl { get; set; }

        /// <summary>
        /// 设变状态
        /// </summary>
        [SugarColumn(ColumnName = "EcmStated", ColumnDescription = "设变状态 ", DefaultValue = "0")]
        public int? EcmStated { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [SugarColumn(ColumnName = "EcmTitle", ColumnDescription = "标题 ", Length = 500)]
        public string EcmTitle { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [SugarColumn(ColumnName = "EcmContent", ColumnDescription = "内容 ", Length = -1)]
        public string EcmContent { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "EcmLeader", ColumnDescription = "担当 ", Length = 50)]
        public string EcmLeader { get; set; }

        /// <summary>
        /// 损失金额
        /// </summary>
        [SugarColumn(ColumnName = "EcmLossAmount", ColumnDescription = "损失金额 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EcmLossAmount { get; set; }

        /// <summary>
        /// 管理区分
        /// </summary>
        [SugarColumn(ColumnName = "EcmManageCategory", ColumnDescription = "管理区分 ", DefaultValue = "0")]
        public int? EcmManageCategory { get; set; }

        /// <summary>
        /// 联络No.
        /// </summary>
        [SugarColumn(ColumnName = "EcmLiaisonNo", ColumnDescription = "联络No. ", Length = 10)]
        public string EcmLiaisonNo { get; set; }

        /// <summary>
        /// 联络文件
        /// </summary>
        [SugarColumn(ColumnName = "EcmLiaisonFileUrl", ColumnDescription = "联络文件 ", Length = 500)]
        public string EcmLiaisonFileUrl { get; set; }

        /// <summary>
        /// EppNo.
        /// </summary>
        [SugarColumn(ColumnName = "EcmEppLiaisonNo", ColumnDescription = "EppNo. ", Length = 10)]
        public string EcmEppLiaisonNo { get; set; }

        /// <summary>
        /// Epp文件
        /// </summary>
        [SugarColumn(ColumnName = "EcmEppLiaisonFileUrl", ColumnDescription = "Epp文件 ", Length = 500)]
        public string EcmEppLiaisonFileUrl { get; set; }

        /// <summary>
        /// FppNo.
        /// </summary>
        [SugarColumn(ColumnName = "EcmFppLiaisonNo", ColumnDescription = "FppNo. ", Length = 10)]
        public string EcmFppLiaisonNo { get; set; }

        /// <summary>
        /// Fpp文件
        /// </summary>
        [SugarColumn(ColumnName = "EcmFppLiaisonFileUrl", ColumnDescription = "Fpp文件 ", Length = 500)]
        public string EcmFppLiaisonFileUrl { get; set; }

        /// <summary>
        /// 外部No.
        /// </summary>
        [SugarColumn(ColumnName = "EcmExternalNo", ColumnDescription = "外部No. ", Length = 10)]
        public string EcmExternalNo { get; set; }

        /// <summary>
        /// 外部文件
        /// </summary>
        [SugarColumn(ColumnName = "EcmExternalFileUrl", ColumnDescription = "外部文件 ", Length = 500)]
        public string EcmExternalFileUrl { get; set; }

        /// <summary>
        /// 输入部门
        /// </summary>
        [SugarColumn(ColumnName = "EcmEnteredDept", ColumnDescription = "输入部门 ", Length = 50)]
        public string EcmEnteredDept { get; set; }

        /// <summary>
        /// 输入日
        /// </summary>
        public DateTime? EcmEnteredDate { get; set; }

        /// <summary>
        /// SOP更新否
        /// </summary>
        [SugarColumn(ColumnName = "EcmSopStated", ColumnDescription = "SOP更新否 ", DefaultValue = "0")]
        public int? EcmSopStated { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "EcmImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int? EcmImplStated { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpEcSlavePe.PeParentSfId), nameof(EcmSfId))] //自定义关系映射
        public List<PpEcSlavePe> PpEcSlavePeNav { get; set; }
    }
}