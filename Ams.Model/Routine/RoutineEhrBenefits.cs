namespace Ams.Model.Routine
{
    /// <summary>
    /// 福利
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:35
    /// </summary>
    [SugarTable("routine_ehr_benefits", "福利")]
    public class RoutineEhrBenefits : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EeSfId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "EeWorkID", ColumnDescription = "工号 ", Length = 8)]
        public string EeWorkID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "EeName", ColumnDescription = "姓名 ", Length = 40)]
        public string EeName { get; set; }

        /// <summary>
        /// 工资日期
        /// </summary>
        public DateTime? EeBirthday { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "EeDepartmentId", ColumnDescription = "部门 ", DefaultValue = "0")]
        public int EeDepartmentId { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        [SugarColumn(ColumnName = "EeTitlesId", ColumnDescription = "职称 ", DefaultValue = "0")]
        public int EeTitlesId { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        [SugarColumn(ColumnName = "EePostId", ColumnDescription = "岗位 ", DefaultValue = "0")]
        public int EePostId { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [SugarColumn(ColumnName = "EePostLevel", ColumnDescription = "等级 ", DefaultValue = "0")]
        public int EePostLevel { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [SugarColumn(ColumnName = "EeDutyName", ColumnDescription = "职务 ", DefaultValue = "0")]
        public int EeDutyName { get; set; }

        /// <summary>
        /// 聘用形式
        /// </summary>
        [SugarColumn(ColumnName = "EeEngageForm", ColumnDescription = "聘用形式 ", Length = 8)]
        public string EeEngageForm { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? EeBeginDate { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        [SugarColumn(ColumnName = "EeWorkState", ColumnDescription = "在职状态 ", Length = 3)]
        public string EeWorkState { get; set; }

        /// <summary>
        /// 试用期
        /// </summary>
        [SugarColumn(ColumnName = "EeProbation", ColumnDescription = "试用期 ", Length = 3)]
        public string EeProbation { get; set; }

        /// <summary>
        /// 合同期限
        /// </summary>
        [SugarColumn(ColumnName = "EeContractTerm", ColumnDescription = "合同期限 ", Length = 3)]
        public string EeContractTerm { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime? EeConversionTime { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? EeLeaveDate { get; set; }

        /// <summary>
        /// 合同起始日
        /// </summary>
        public DateTime? EeBeginContract { get; set; }

        /// <summary>
        /// 合同终止日
        /// </summary>
        public DateTime? EeBndContract { get; set; }

        /// <summary>
        /// 工龄
        /// </summary>
        [SugarColumn(ColumnName = "EeWorkAge", ColumnDescription = "工龄 ", DefaultValue = "0")]
        public int? EeWorkAge { get; set; }
    }
}