namespace Ams.Model.Logistics
{
    /// <summary>
    /// 主设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:43
    /// </summary>
    [SugarTable("pp_ec_master", "主设变")]
    public class PpEcMaster : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EmSFID { get; set; }

        /// <summary>
        /// 发行日
        /// </summary>
        public DateTime? EmEcIssueDate { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        public string EmEcNo { get; set; }

        /// <summary>
        /// 关联文件
        /// </summary>
        public string EmEcDoc { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string EmEcStatus { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string EmEcTitle { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string EmEcContent { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        public string EmEcAssigned { get; set; }

        /// <summary>
        /// 损失金额
        /// </summary>
        public decimal EmEcLossAmount { get; set; }

        /// <summary>
        /// 管理区分
        /// </summary>
        public int EmEcManageCategory { get; set; }

        /// <summary>
        /// 联络No.
        /// </summary>
        public string EmEcLiaisonNo { get; set; }

        /// <summary>
        /// 联络文件
        /// </summary>
        public string EmEcLiaisonDoc { get; set; }

        /// <summary>
        /// EppNo.
        /// </summary>
        public string EmEcEppLiaisonNo { get; set; }

        /// <summary>
        /// Epp文件
        /// </summary>
        public string EmEcEppLiaisonDoc { get; set; }

        /// <summary>
        /// FppNo.
        /// </summary>
        public string EmEcFppLiaisonNo { get; set; }

        /// <summary>
        /// Fpp文件
        /// </summary>
        public string EmEcFppLiaisonDoc { get; set; }

        /// <summary>
        /// 外部No.
        /// </summary>
        public string EmEcExternalNo { get; set; }

        /// <summary>
        /// 外部文件
        /// </summary>
        public string EmEcExternalDoc { get; set; }

        /// <summary>
        /// 输入部门
        /// </summary>
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 输入日
        /// </summary>
        public DateTime? EmEcEntryDate { get; set; }

        /// <summary>
        /// SOP
        /// </summary>
        public int EsSopStae { get; set; }

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

        [Navigate(NavigateType.OneToMany, nameof(PpEcSlave.EsParentSfid), nameof(EmSFID))] //自定义关系映射
        public List<PpEcSlave> PpEcSlaveNav { get; set; }
    }
}