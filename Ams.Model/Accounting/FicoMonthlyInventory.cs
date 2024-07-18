namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度存货
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:45:33
    /// </summary>
    [SugarTable("fico_monthly_inventory", "月度存货")]
    public class FicoMonthlyInventory : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MiSFID { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        public string MiPlant { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        public string MiFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        public string MiYm { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public string MiItem { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        public string MiValType { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        public string MiPriceControl { get; set; }

        /// <summary>
        /// 移动平均价
        /// </summary>
        public decimal MiMovingAverage { get; set; }

        /// <summary>
        /// Per单位
        /// </summary>
        public int MiPerUnit { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string MiLocalCcy { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public decimal MiInventoryQty { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal MiInventoryAmount { get; set; }

        /// <summary>
        /// 登录日期
        /// </summary>
        public DateTime? MiBalancedate { get; set; }

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