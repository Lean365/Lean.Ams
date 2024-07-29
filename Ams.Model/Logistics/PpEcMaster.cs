using Ams.Model.Logistics;

namespace Ams.Model.Logistics
{
    /// <summary>
    /// 主设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:35:09
    /// </summary>
    [SugarTable("pp_ec_master","主设变")]
    public class PpEcMaster
    {
        /// <summary>
        /// Sfid 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long EcmSfid { get; set; }

        /// <summary>
        /// 发行日期 
        /// </summary>
        public DateTime? EcmIssueDate { get; set; }

        /// <summary>
        /// 设变No. 
        /// </summary>
        [SugarColumn(ColumnName="EcmNo", ColumnDescription = "设变No. ",Length = 20)]
        public string EcmNo { get; set; }

        /// <summary>
        /// 关联文件 
        /// </summary>
        [SugarColumn(ColumnName="EcmFileUrl", ColumnDescription = "关联文件 ",Length = 500)]
        public string EcmFileUrl { get; set; }

        /// <summary>
        /// 设变状态 
        /// </summary>
        [SugarColumn(ColumnName="EcmStated", ColumnDescription = "设变状态 ",DefaultValue = "0")]
        public int EcmStated { get; set; }

        /// <summary>
        /// 标题 
        /// </summary>
        [SugarColumn(ColumnName="EcmTitle", ColumnDescription = "标题 ",Length = 500)]
        public string EcmTitle { get; set; }

        /// <summary>
        /// 内容 
        /// </summary>
        [SugarColumn(ColumnName="EcmContent", ColumnDescription = "内容 ",Length = -1)]
        public string EcmContent { get; set; }

        /// <summary>
        /// 担当 
        /// </summary>
        [SugarColumn(ColumnName="EcmLeader", ColumnDescription = "担当 ",Length = 50)]
        public string EcmLeader { get; set; }

        /// <summary>
        /// 损失金额 
        /// </summary>
        [SugarColumn(ColumnName="EcmLossAmount", ColumnDescription = "损失金额 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal EcmLossAmount { get; set; }

        /// <summary>
        /// 管理区分 
        /// </summary>
        [SugarColumn(ColumnName="EcmManageCategory", ColumnDescription = "管理区分 ",DefaultValue = "0")]
        public int EcmManageCategory { get; set; }

        /// <summary>
        /// 联络No. 
        /// </summary>
        [SugarColumn(ColumnName="EcmLiaisonNo", ColumnDescription = "联络No. ",Length = 10)]
        public string EcmLiaisonNo { get; set; }

        /// <summary>
        /// 联络文件 
        /// </summary>
        [SugarColumn(ColumnName="EcmLiaisonFileUrl", ColumnDescription = "联络文件 ",Length = 500)]
        public string EcmLiaisonFileUrl { get; set; }

        /// <summary>
        /// EppNo. 
        /// </summary>
        [SugarColumn(ColumnName="EcmEppLiaisonNo", ColumnDescription = "EppNo. ",Length = 10)]
        public string EcmEppLiaisonNo { get; set; }

        /// <summary>
        /// Epp文件 
        /// </summary>
        [SugarColumn(ColumnName="EcmEppLiaisonFileUrl", ColumnDescription = "Epp文件 ",Length = 500)]
        public string EcmEppLiaisonFileUrl { get; set; }

        /// <summary>
        /// FppNo. 
        /// </summary>
        [SugarColumn(ColumnName="EcmFppLiaisonNo", ColumnDescription = "FppNo. ",Length = 10)]
        public string EcmFppLiaisonNo { get; set; }

        /// <summary>
        /// Fpp文件 
        /// </summary>
        [SugarColumn(ColumnName="EcmFppLiaisonFileUrl", ColumnDescription = "Fpp文件 ",Length = 500)]
        public string EcmFppLiaisonFileUrl { get; set; }

        /// <summary>
        /// 外部No. 
        /// </summary>
        [SugarColumn(ColumnName="EcmExternalNo", ColumnDescription = "外部No. ",Length = 10)]
        public string EcmExternalNo { get; set; }

        /// <summary>
        /// 外部文件 
        /// </summary>
        [SugarColumn(ColumnName="EcmExternalFileUrl", ColumnDescription = "外部文件 ",Length = 500)]
        public string EcmExternalFileUrl { get; set; }

        /// <summary>
        /// 输入部门 
        /// </summary>
        [SugarColumn(ColumnName="EcmEnteredDept", ColumnDescription = "输入部门 ",Length = 50)]
        public string EcmEnteredDept { get; set; }

        /// <summary>
        /// 输入日 
        /// </summary>
        public DateTime? EcmEnteredDate { get; set; }

        /// <summary>
        /// SOP更新否 
        /// </summary>
        [SugarColumn(ColumnName="EcmSopStated", ColumnDescription = "SOP更新否 ",DefaultValue = "0")]
        public int EcmSopStated { get; set; }

        /// <summary>
        /// 实施标记 
        /// </summary>
        [SugarColumn(ColumnName="EcmImplStated", ColumnDescription = "实施标记 ",DefaultValue = "0")]
        public int EcmImplStated { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        [SugarColumn(ColumnName="UDF01", ColumnDescription = "自定义A ",Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        [SugarColumn(ColumnName="UDF02", ColumnDescription = "自定义B ",Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        [SugarColumn(ColumnName="UDF03", ColumnDescription = "自定义C ",Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        [SugarColumn(ColumnName="UDF04", ColumnDescription = "自定义D ",Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        [SugarColumn(ColumnName="UDF05", ColumnDescription = "自定义E ",Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        [SugarColumn(ColumnName="UDF06", ColumnDescription = "自定义F ",Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        [SugarColumn(ColumnName="UDF51", ColumnDescription = "自定义1 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        [SugarColumn(ColumnName="UDF52", ColumnDescription = "自定义2 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        [SugarColumn(ColumnName="UDF53", ColumnDescription = "自定义3 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        [SugarColumn(ColumnName="UDF54", ColumnDescription = "自定义4 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        [SugarColumn(ColumnName="UDF55", ColumnDescription = "自定义5 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        [SugarColumn(ColumnName="UDF56", ColumnDescription = "自定义6 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除 ",DefaultValue = "0")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注 ",Length = 2000)]
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

        [Navigate(NavigateType.OneToMany, nameof(PpEcSlave.EcsParentSfid), nameof(EcmSfid))] //自定义关系映射
        public List<PpEcSlave> PpEcSlaveNav { get; set; }
    }
}