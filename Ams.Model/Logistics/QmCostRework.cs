namespace Ams.Model.Logistics
{
    /// <summary>
    /// 返工改修
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:26
    /// </summary>
    [SugarTable("qm_cost_rework", "返工改修")]
    public class QmCostRework : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QcrdSfId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Qcrd001 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd002", ColumnDescription = "机种 ", Length = 50)]
        public string Qcrd002 { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd003", ColumnDescription = "批次 ", Length = 50)]
        public string Qcrd003 { get; set; }

        /// <summary>
        /// 直接人员赁率
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd004", ColumnDescription = "直接人员赁率 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd004 { get; set; }

        /// <summary>
        /// 间接人员赁率
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd005", ColumnDescription = "间接人员赁率 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd005 { get; set; }

        /// <summary>
        /// 检讨?调查?试验内容
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd006", ColumnDescription = "检讨?调查?试验内容 ", Length = 500)]
        public string Qcrd006 { get; set; }

        /// <summary>
        /// 检讨?调查?试验费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd007", ColumnDescription = "检讨?调查?试验费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd007 { get; set; }

        /// <summary>
        /// 检讨会使用时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd008", ColumnDescription = "检讨会使用时间(分) ", DefaultValue = "0")]
        public int Qcrd008 { get; set; }

        /// <summary>
        /// 直接人员参加人数
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd009", ColumnDescription = "直接人员参加人数 ", DefaultValue = "0")]
        public int Qcrd009 { get; set; }

        /// <summary>
        /// 间接人员参加人数
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd010", ColumnDescription = "间接人员参加人数 ", DefaultValue = "0")]
        public int Qcrd010 { get; set; }

        /// <summary>
        /// 调查评价试验工作时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd011", ColumnDescription = "调查评价试验工作时间(分) ", DefaultValue = "0")]
        public int Qcrd011 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd012", ColumnDescription = "交通费、旅费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd012 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd013", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd013 { get; set; }

        /// <summary>
        /// 其他作业時間(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd014", ColumnDescription = "其他作业時間(分) ", DefaultValue = "0")]
        public int Qcrd014 { get; set; }

        /// <summary>
        /// 其他设备购入费,工程费,搬运费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd015", ColumnDescription = "其他设备购入费,工程费,搬运费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd015 { get; set; }

        /// <summary>
        /// 需要不良改修对应
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd016", ColumnDescription = "需要不良改修对应 ", DefaultValue = "0")]
        public int Qcrd016 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd017", ColumnDescription = "特记 ", Length = 500)]
        public string Qcrd017 { get; set; }

        /// <summary>
        /// 品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Qcrdqarec", ColumnDescription = "品质问题対応记录者 ", Length = 50)]
        public string Qcrdqarec { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Qcrd018 { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd019", ColumnDescription = "不良内容 ", Length = 500)]
        public string Qcrd019 { get; set; }

        /// <summary>
        /// 选别?改修费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd020", ColumnDescription = "选别?改修费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd020 { get; set; }

        /// <summary>
        /// 选别?改修时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd021", ColumnDescription = "选别?改修时间(分) ", DefaultValue = "0")]
        public int Qcrd021 { get; set; }

        /// <summary>
        /// 再检查时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd022", ColumnDescription = "再检查时间(分) ", DefaultValue = "0")]
        public int Qcrd022 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd023", ColumnDescription = "交通费、旅费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd023 { get; set; }

        /// <summary>
        /// 仓库管理费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd024", ColumnDescription = "仓库管理费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd024 { get; set; }

        /// <summary>
        /// 选别?改修其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd025", ColumnDescription = "选别?改修其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd025 { get; set; }

        /// <summary>
        /// 选别?改修备注
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd026", ColumnDescription = "选别?改修备注 ", Length = 500)]
        public string Qcrd026 { get; set; }

        /// <summary>
        /// 向顾客的费用请求
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd027", ColumnDescription = "向顾客的费用请求 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd027 { get; set; }

        /// <summary>
        /// 顾客名
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd028", ColumnDescription = "顾客名 ", Length = 50)]
        public string Qcrd028 { get; set; }

        /// <summary>
        /// Debit Note No
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd029", ColumnDescription = "Debit Note No ", Length = 50)]
        public string Qcrd029 { get; set; }

        /// <summary>
        /// 请求费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd030", ColumnDescription = "请求费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd030 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd031", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd031 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd032", ColumnDescription = "备注 ", Length = 500)]
        public string Qcrd032 { get; set; }

        /// <summary>
        /// 生管品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Qcrdmcrec", ColumnDescription = "生管品质问题対応记录者 ", Length = 50)]
        public string Qcrdmcrec { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Qcrd033 { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd034", ColumnDescription = "不良内容 ", Length = 500)]
        public string Qcrd034 { get; set; }

        /// <summary>
        /// 选别?改修费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd035", ColumnDescription = "选别?改修费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd035 { get; set; }

        /// <summary>
        /// 选别?改修时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd036", ColumnDescription = "选别?改修时间(分) ", DefaultValue = "0")]
        public int Qcrd036 { get; set; }

        /// <summary>
        /// 再检查时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd037", ColumnDescription = "再检查时间(分) ", DefaultValue = "0")]
        public int Qcrd037 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd038", ColumnDescription = "交通费、旅费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd038 { get; set; }

        /// <summary>
        /// 仓库管理费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd039", ColumnDescription = "仓库管理费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd039 { get; set; }

        /// <summary>
        /// 选别?改修其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd040", ColumnDescription = "选别?改修其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd040 { get; set; }

        /// <summary>
        /// 选别?改修备注
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd041", ColumnDescription = "选别?改修备注 ", Length = 500)]
        public string Qcrd041 { get; set; }

        /// <summary>
        /// 向顾客的费用请求
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd042", ColumnDescription = "向顾客的费用请求 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd042 { get; set; }

        /// <summary>
        /// 顾客名
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd043", ColumnDescription = "顾客名 ", Length = 50)]
        public string Qcrd043 { get; set; }

        /// <summary>
        /// Debit Note No
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd044", ColumnDescription = "Debit Note No ", Length = 50)]
        public string Qcrd044 { get; set; }

        /// <summary>
        /// 请求费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd045", ColumnDescription = "请求费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd045 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd046", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd046 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd047", ColumnDescription = "备注 ", Length = 500)]
        public string Qcrd047 { get; set; }

        /// <summary>
        /// M/L不良改修対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Qcrdassrec", ColumnDescription = "M/L不良改修対応记录者 ", Length = 50)]
        public string Qcrdassrec { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Qcrd048 { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd049", ColumnDescription = "不良内容 ", Length = 500)]
        public string Qcrd049 { get; set; }

        /// <summary>
        /// 选别?改修费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd050", ColumnDescription = "选别?改修费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd050 { get; set; }

        /// <summary>
        /// 选别?改修时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd051", ColumnDescription = "选别?改修时间(分) ", DefaultValue = "0")]
        public int Qcrd051 { get; set; }

        /// <summary>
        /// 再检查时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd052", ColumnDescription = "再检查时间(分) ", DefaultValue = "0")]
        public int Qcrd052 { get; set; }

        /// <summary>
        /// 交通费、旅费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd053", ColumnDescription = "交通费、旅费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd053 { get; set; }

        /// <summary>
        /// 仓库管理费
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd054", ColumnDescription = "仓库管理费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd054 { get; set; }

        /// <summary>
        /// 选别?改修其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd055", ColumnDescription = "选别?改修其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd055 { get; set; }

        /// <summary>
        /// 选别?改修备注
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd056", ColumnDescription = "选别?改修备注 ", Length = 500)]
        public string Qcrd056 { get; set; }

        /// <summary>
        /// 向顾客的费用请求
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd057", ColumnDescription = "向顾客的费用请求 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd057 { get; set; }

        /// <summary>
        /// 顾客名
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd058", ColumnDescription = "顾客名 ", Length = 50)]
        public string Qcrd058 { get; set; }

        /// <summary>
        /// Debit Note No
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd059", ColumnDescription = "Debit Note No ", Length = 50)]
        public string Qcrd059 { get; set; }

        /// <summary>
        /// 请求费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd060", ColumnDescription = "请求费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd060 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd061", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcrd061 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Qcrd062", ColumnDescription = "备注 ", Length = 500)]
        public string Qcrd062 { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "Qcrdpcbrec", ColumnDescription = "担当 ", Length = 50)]
        public string Qcrdpcbrec { get; set; }
    }
}