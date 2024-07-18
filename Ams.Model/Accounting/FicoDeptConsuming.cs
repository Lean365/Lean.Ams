namespace Ams.Model.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:47:09
    /// </summary>
    [SugarTable("fico_dept_consuming", "部门消耗")]
    public class FicoDeptConsuming : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long DcSFID { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        public string DcFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        public string DcYm { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        public string DcCorpCode { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string DcCorpName { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        public string DcExpCategory { get; set; }

        /// <summary>
        /// 成本代码
        /// </summary>
        public string DcCostCode { get; set; }

        /// <summary>
        /// 成本名称
        /// </summary>
        public string DcCostName { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        public string DcTitleCode { get; set; }

        /// <summary>
        /// 科目名称
        /// </summary>
        public string DcTitleName { get; set; }

        /// <summary>
        /// 科目分类
        /// </summary>
        public string DcTitleNote { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        public decimal DcBudgetAmt { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        public decimal DcActualAmt { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        public decimal DcDiffAmt { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        public string DcPlant { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public string DcMateriel { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public string DcStorageLocation { get; set; }

        /// <summary>
        /// 移动类型
        /// </summary>
        public string DcMoveType { get; set; }

        /// <summary>
        /// 物料凭证
        /// </summary>
        public string DcMaterielDoc { get; set; }

        /// <summary>
        /// 凭证明细
        /// </summary>
        public string DcMaterielDocDetails { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal DcUseQty { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal DcUseAmt { get; set; }

        /// <summary>
        /// 预留单
        /// </summary>
        public string DcReserveDoc { get; set; }

        /// <summary>
        /// 预留明细
        /// </summary>
        public string DcAccountant { get; set; }

        /// <summary>
        /// 登录日期
        /// </summary>
        public DateTime? DcBalanceDate { get; set; }

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