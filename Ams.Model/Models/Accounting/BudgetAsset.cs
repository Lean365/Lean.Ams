namespace Ams.Model.Accounting
{
    /// <summary>
    /// 资产预算
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    [SugarTable("fico_budget_asset")]
    public class BudgetAsset
    {
        /// <summary>
        /// SFID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbaSFID { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string FbaCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string FbaDept { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        public string FbaFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        public string FbaFm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        public int FbaTitle { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string FbaClass { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FbaName { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string FbaDesc { get; set; }

        /// <summary>
        /// 年限
        /// </summary>
        public int FbaServiceLife { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        public decimal FbaBudgetAmount { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        public decimal FbaActualAmount { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        public decimal FbaDifferenceAmount { get; set; }

        /// <summary>
        /// 折旧
        /// </summary>
        public decimal FbaDepreciation { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public int FbaFlag { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        public int FbaAudit { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public string FbaAuditName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? FbaAuditDate { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        public string FbaUndoName { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? FbaUndoDate { get; set; }

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
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public int? IsDeleted { get; set; }

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