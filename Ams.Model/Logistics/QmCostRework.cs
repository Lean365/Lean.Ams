namespace Ams.Model.Logistics
{
    /// <summary>
    /// 返工改修
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:47:36
    /// </summary>
    [SugarTable("qm_cost_rework", "返工改修")]
    public class QmCostRework : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Md002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md002 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Md003 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Md004", ColumnDescription = "机种", Length = 50)]
        public string Md004 { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Md005", ColumnDescription = "批次", Length = 50)]
        public string Md005 { get; set; }

        /// <summary>
        /// 直接人员赁率
        /// </summary>
        [SugarColumn(ColumnName = "Md006", ColumnDescription = "直接人员赁率", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md006 { get; set; }

        /// <summary>
        /// 间接人员赁率
        /// </summary>
        [SugarColumn(ColumnName = "Md007", ColumnDescription = "间接人员赁率", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md007 { get; set; }

        /// <summary>
        /// 检讨.调查.试验内容
        /// </summary>
        [SugarColumn(ColumnName = "Md008", ColumnDescription = "检讨.调查.试验内容", Length = 500)]
        public string Md008 { get; set; }

        /// <summary>
        /// 检讨.调查.试验费用
        /// </summary>
        [SugarColumn(ColumnName = "Md009", ColumnDescription = "检讨.调查.试验费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md009 { get; set; }

        /// <summary>
        /// 检讨会使用时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md010", ColumnDescription = "检讨会使用时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md010 { get; set; }

        /// <summary>
        /// 直接人员参加人数
        /// </summary>
        [SugarColumn(ColumnName = "Md011", ColumnDescription = "直接人员参加人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md011 { get; set; }

        /// <summary>
        /// 间接人员参加人数
        /// </summary>
        [SugarColumn(ColumnName = "Md012", ColumnDescription = "间接人员参加人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md012 { get; set; }

        /// <summary>
        /// 调查评价试验工作时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md013", ColumnDescription = "调查评价试验工作时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md013 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Md014", ColumnDescription = "交通费、旅费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md014 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Md015", ColumnDescription = "其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md015 { get; set; }

        /// <summary>
        /// 其他作业時間(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md016", ColumnDescription = "其他作业時間(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md016 { get; set; }

        /// <summary>
        /// 其他设备购入费,工程费,搬运费
        /// </summary>
        [SugarColumn(ColumnName = "Md017", ColumnDescription = "其他设备购入费,工程费,搬运费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md017 { get; set; }

        /// <summary>
        /// 需要不良改修对应
        /// </summary>
        [SugarColumn(ColumnName = "Md018", ColumnDescription = "需要不良改修对应", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md018 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Md019", ColumnDescription = "特记", Length = 500)]
        public string Md019 { get; set; }

        /// <summary>
        /// 品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Md020", ColumnDescription = "品质问题対応记录者", Length = 50)]
        public string Md020 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Md021 { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "Md022", ColumnDescription = "不良内容", Length = 500)]
        public string Md022 { get; set; }

        /// <summary>
        /// 选别.改修费用
        /// </summary>
        [SugarColumn(ColumnName = "Md023", ColumnDescription = "选别.改修费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md023 { get; set; }

        /// <summary>
        /// 选别.改修时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md024", ColumnDescription = "选别.改修时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md024 { get; set; }

        /// <summary>
        /// 再检查时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md025", ColumnDescription = "再检查时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md025 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Md026", ColumnDescription = "交通费、旅费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md026 { get; set; }

        /// <summary>
        /// 仓库管理费
        /// </summary>
        [SugarColumn(ColumnName = "Md027", ColumnDescription = "仓库管理费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md027 { get; set; }

        /// <summary>
        /// 选别.改修其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Md028", ColumnDescription = "选别.改修其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md028 { get; set; }

        /// <summary>
        /// 选别.改修备注
        /// </summary>
        [SugarColumn(ColumnName = "Md029", ColumnDescription = "选别.改修备注", Length = 500)]
        public string Md029 { get; set; }

        /// <summary>
        /// 向顾客的费用请求
        /// </summary>
        [SugarColumn(ColumnName = "Md030", ColumnDescription = "向顾客的费用请求", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md030 { get; set; }

        /// <summary>
        /// 顾客名
        /// </summary>
        [SugarColumn(ColumnName = "Md031", ColumnDescription = "顾客名", Length = 50)]
        public string Md031 { get; set; }

        /// <summary>
        /// 请求号码
        /// </summary>
        [SugarColumn(ColumnName = "Md032", ColumnDescription = "请求号码", Length = 50)]
        public string Md032 { get; set; }

        /// <summary>
        /// 请求费用
        /// </summary>
        [SugarColumn(ColumnName = "Md033", ColumnDescription = "请求费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md033 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Md034", ColumnDescription = "其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md034 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Md035", ColumnDescription = "备注", Length = 500)]
        public string Md035 { get; set; }

        /// <summary>
        /// 附件2
        /// </summary>
        [SugarColumn(ColumnName = "Md036", ColumnDescription = "附件2", Length = 255)]
        public string Md036 { get; set; }

        /// <summary>
        /// 生管品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Md037", ColumnDescription = "生管品质问题対応记录者", Length = 50)]
        public string Md037 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Md038 { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "Md039", ColumnDescription = "不良内容", Length = 500)]
        public string Md039 { get; set; }

        /// <summary>
        /// 选别.改修费用
        /// </summary>
        [SugarColumn(ColumnName = "Md040", ColumnDescription = "选别.改修费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md040 { get; set; }

        /// <summary>
        /// 选别.改修时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md041", ColumnDescription = "选别.改修时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md041 { get; set; }

        /// <summary>
        /// 再检查时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md042", ColumnDescription = "再检查时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md042 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Md043", ColumnDescription = "交通费、旅费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md043 { get; set; }

        /// <summary>
        /// 仓库管理费
        /// </summary>
        [SugarColumn(ColumnName = "Md044", ColumnDescription = "仓库管理费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md044 { get; set; }

        /// <summary>
        /// 选别.改修其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Md045", ColumnDescription = "选别.改修其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md045 { get; set; }

        /// <summary>
        /// 选别.改修备注
        /// </summary>
        [SugarColumn(ColumnName = "Md046", ColumnDescription = "选别.改修备注", Length = 500)]
        public string Md046 { get; set; }

        /// <summary>
        /// 向顾客的费用请求
        /// </summary>
        [SugarColumn(ColumnName = "Md047", ColumnDescription = "向顾客的费用请求", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md047 { get; set; }

        /// <summary>
        /// 顾客名
        /// </summary>
        [SugarColumn(ColumnName = "Md048", ColumnDescription = "顾客名", Length = 50)]
        public string Md048 { get; set; }

        /// <summary>
        /// 请求号码
        /// </summary>
        [SugarColumn(ColumnName = "Md049", ColumnDescription = "请求号码", Length = 50)]
        public string Md049 { get; set; }

        /// <summary>
        /// 请求费用
        /// </summary>
        [SugarColumn(ColumnName = "Md050", ColumnDescription = "请求费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md050 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Md051", ColumnDescription = "其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md051 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Md052", ColumnDescription = "备注", Length = 500)]
        public string Md052 { get; set; }

        /// <summary>
        /// 附件1
        /// </summary>
        [SugarColumn(ColumnName = "Md053", ColumnDescription = "附件1", Length = 255)]
        public string Md053 { get; set; }

        /// <summary>
        /// M/L不良改修対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Md054", ColumnDescription = "M/L不良改修対応记录者", Length = 50)]
        public string Md054 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Md055 { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "Md056", ColumnDescription = "不良内容", Length = 500)]
        public string Md056 { get; set; }

        /// <summary>
        /// 选别.改修费用
        /// </summary>
        [SugarColumn(ColumnName = "Md057", ColumnDescription = "选别.改修费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md057 { get; set; }

        /// <summary>
        /// 选别.改修时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md058", ColumnDescription = "选别.改修时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md058 { get; set; }

        /// <summary>
        /// 再检查时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Md059", ColumnDescription = "再检查时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md059 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Md060", ColumnDescription = "交通费、旅费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md060 { get; set; }

        /// <summary>
        /// 仓库管理费
        /// </summary>
        [SugarColumn(ColumnName = "Md061", ColumnDescription = "仓库管理费", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md061 { get; set; }

        /// <summary>
        /// 选别.改修其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Md062", ColumnDescription = "选别.改修其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md062 { get; set; }

        /// <summary>
        /// 选别.改修备注
        /// </summary>
        [SugarColumn(ColumnName = "Md063", ColumnDescription = "选别.改修备注", Length = 500)]
        public string Md063 { get; set; }

        /// <summary>
        /// 向顾客的费用请求
        /// </summary>
        [SugarColumn(ColumnName = "Md064", ColumnDescription = "向顾客的费用请求", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md064 { get; set; }

        /// <summary>
        /// 顾客名
        /// </summary>
        [SugarColumn(ColumnName = "Md065", ColumnDescription = "顾客名", Length = 50)]
        public string Md065 { get; set; }

        /// <summary>
        /// 请求号码
        /// </summary>
        [SugarColumn(ColumnName = "Md066", ColumnDescription = "请求号码", Length = 50)]
        public string Md066 { get; set; }

        /// <summary>
        /// 请求费用
        /// </summary>
        [SugarColumn(ColumnName = "Md067", ColumnDescription = "请求费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md067 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Md068", ColumnDescription = "其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md068 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Md069", ColumnDescription = "备注", Length = 500)]
        public string Md069 { get; set; }

        /// <summary>
        /// 附件3
        /// </summary>
        [SugarColumn(ColumnName = "Md070", ColumnDescription = "附件3", Length = 255)]
        public string Md070 { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "Md071", ColumnDescription = "担当", Length = 50)]
        public string Md071 { get; set; }
    }
}