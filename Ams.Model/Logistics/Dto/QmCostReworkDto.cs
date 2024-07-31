namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 返工改修
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:26
    /// </summary>
    public class QmCostReworkQueryDto : PagerInfo
    {
        public DateTime? BeginQcrd001 { get; set; }
        public DateTime? EndQcrd001 { get; set; }
        public string Qcrd002 { get; set; }
        public string Qcrd003 { get; set; }
        public DateTime? BeginQcrd018 { get; set; }
        public DateTime? EndQcrd018 { get; set; }
        public string Qcrd028 { get; set; }
        public DateTime? BeginQcrd033 { get; set; }
        public DateTime? EndQcrd033 { get; set; }
        public DateTime? BeginQcrd048 { get; set; }
        public DateTime? EndQcrd048 { get; set; }
    }

    /// <summary>
    /// 返工改修
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:26
    /// </summary>
    public class QmCostReworkDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcrdSfId { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd001 { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Qcrd002 { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Qcrd003 { get; set; }

        [Required(ErrorMessage = "直接人员赁率不能为空")]
        [ExcelColumn(Name = "直接人员赁率")]
        [ExcelColumnName("直接人员赁率")]
        public decimal Qcrd004 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        [ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]
        public decimal Qcrd005 { get; set; }

        [ExcelColumn(Name = "检讨?调查?试验内容")]
        [ExcelColumnName("检讨?调查?试验内容")]
        public string Qcrd006 { get; set; }

        [Required(ErrorMessage = "检讨?调查?试验费用不能为空")]
        [ExcelColumn(Name = "检讨?调查?试验费用")]
        [ExcelColumnName("检讨?调查?试验费用")]
        public decimal Qcrd007 { get; set; }

        [Required(ErrorMessage = "检讨会使用时间(分)不能为空")]
        [ExcelColumn(Name = "检讨会使用时间(分)")]
        [ExcelColumnName("检讨会使用时间(分)")]
        public int Qcrd008 { get; set; }

        [Required(ErrorMessage = "直接人员参加人数不能为空")]
        [ExcelColumn(Name = "直接人员参加人数")]
        [ExcelColumnName("直接人员参加人数")]
        public int Qcrd009 { get; set; }

        [Required(ErrorMessage = "间接人员参加人数不能为空")]
        [ExcelColumn(Name = "间接人员参加人数")]
        [ExcelColumnName("间接人员参加人数")]
        public int Qcrd010 { get; set; }

        [Required(ErrorMessage = "调查评价试验工作时间(分)不能为空")]
        [ExcelColumn(Name = "调查评价试验工作时间(分)")]
        [ExcelColumnName("调查评价试验工作时间(分)")]
        public int Qcrd011 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd012 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd013 { get; set; }

        [Required(ErrorMessage = "其他作业時間(分)不能为空")]
        [ExcelColumn(Name = "其他作业時間(分)")]
        [ExcelColumnName("其他作业時間(分)")]
        public int Qcrd014 { get; set; }

        [Required(ErrorMessage = "其他设备购入费,工程费,搬运费不能为空")]
        [ExcelColumn(Name = "其他设备购入费,工程费,搬运费")]
        [ExcelColumnName("其他设备购入费,工程费,搬运费")]
        public decimal Qcrd015 { get; set; }

        [Required(ErrorMessage = "需要不良改修对应不能为空")]
        [ExcelColumn(Name = "需要不良改修对应")]
        [ExcelColumnName("需要不良改修对应")]
        public int Qcrd016 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcrd017 { get; set; }

        [ExcelColumn(Name = "品质问题対応记录者")]
        [ExcelColumnName("品质问题対応记录者")]
        public string Qcrdqarec { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd018 { get; set; }

        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Qcrd019 { get; set; }

        [Required(ErrorMessage = "选别?改修费用不能为空")]
        [ExcelColumn(Name = "选别?改修费用")]
        [ExcelColumnName("选别?改修费用")]
        public decimal Qcrd020 { get; set; }

        [Required(ErrorMessage = "选别?改修时间(分)不能为空")]
        [ExcelColumn(Name = "选别?改修时间(分)")]
        [ExcelColumnName("选别?改修时间(分)")]
        public int Qcrd021 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        [ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Qcrd022 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd023 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        [ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Qcrd024 { get; set; }

        [Required(ErrorMessage = "选别?改修其他费用不能为空")]
        [ExcelColumn(Name = "选别?改修其他费用")]
        [ExcelColumnName("选别?改修其他费用")]
        public decimal Qcrd025 { get; set; }

        [ExcelColumn(Name = "选别?改修备注")]
        [ExcelColumnName("选别?改修备注")]
        public string Qcrd026 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        [ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Qcrd027 { get; set; }

        [ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Qcrd028 { get; set; }

        [ExcelColumn(Name = "Debit Note No")]
        [ExcelColumnName("Debit Note No")]
        public string Qcrd029 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        [ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Qcrd030 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd031 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Qcrd032 { get; set; }

        [ExcelColumn(Name = "生管品质问题対応记录者")]
        [ExcelColumnName("生管品质问题対応记录者")]
        public string Qcrdmcrec { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd033 { get; set; }

        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Qcrd034 { get; set; }

        [Required(ErrorMessage = "选别?改修费用不能为空")]
        [ExcelColumn(Name = "选别?改修费用")]
        [ExcelColumnName("选别?改修费用")]
        public decimal Qcrd035 { get; set; }

        [Required(ErrorMessage = "选别?改修时间(分)不能为空")]
        [ExcelColumn(Name = "选别?改修时间(分)")]
        [ExcelColumnName("选别?改修时间(分)")]
        public int Qcrd036 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        [ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Qcrd037 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd038 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        [ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Qcrd039 { get; set; }

        [Required(ErrorMessage = "选别?改修其他费用不能为空")]
        [ExcelColumn(Name = "选别?改修其他费用")]
        [ExcelColumnName("选别?改修其他费用")]
        public decimal Qcrd040 { get; set; }

        [ExcelColumn(Name = "选别?改修备注")]
        [ExcelColumnName("选别?改修备注")]
        public string Qcrd041 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        [ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Qcrd042 { get; set; }

        [ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Qcrd043 { get; set; }

        [ExcelColumn(Name = "Debit Note No")]
        [ExcelColumnName("Debit Note No")]
        public string Qcrd044 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        [ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Qcrd045 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd046 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Qcrd047 { get; set; }

        [ExcelColumn(Name = "M/L不良改修対応记录者")]
        [ExcelColumnName("M/L不良改修対応记录者")]
        public string Qcrdassrec { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd048 { get; set; }

        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Qcrd049 { get; set; }

        [Required(ErrorMessage = "选别?改修费用不能为空")]
        [ExcelColumn(Name = "选别?改修费用")]
        [ExcelColumnName("选别?改修费用")]
        public decimal Qcrd050 { get; set; }

        [Required(ErrorMessage = "选别?改修时间(分)不能为空")]
        [ExcelColumn(Name = "选别?改修时间(分)")]
        [ExcelColumnName("选别?改修时间(分)")]
        public int Qcrd051 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        [ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Qcrd052 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd053 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        [ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Qcrd054 { get; set; }

        [Required(ErrorMessage = "选别?改修其他费用不能为空")]
        [ExcelColumn(Name = "选别?改修其他费用")]
        [ExcelColumnName("选别?改修其他费用")]
        public decimal Qcrd055 { get; set; }

        [ExcelColumn(Name = "选别?改修备注")]
        [ExcelColumnName("选别?改修备注")]
        public string Qcrd056 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        [ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Qcrd057 { get; set; }

        [ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Qcrd058 { get; set; }

        [ExcelColumn(Name = "Debit Note No")]
        [ExcelColumnName("Debit Note No")]
        public string Qcrd059 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        [ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Qcrd060 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd061 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Qcrd062 { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Qcrdpcbrec { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "顾客名")]
        public string Qcrd028Label { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 返工改修
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:26
    /// </summary>
    public class QmCostReworkImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcrdSfId { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd001 { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Qcrd002 { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Qcrd003 { get; set; }

        [Required(ErrorMessage = "直接人员赁率不能为空")]
        [ExcelColumn(Name = "直接人员赁率")]
        [ExcelColumnName("直接人员赁率")]
        public decimal Qcrd004 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        [ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]
        public decimal Qcrd005 { get; set; }

        [ExcelColumn(Name = "检讨?调查?试验内容")]
        [ExcelColumnName("检讨?调查?试验内容")]
        public string Qcrd006 { get; set; }

        [Required(ErrorMessage = "检讨?调查?试验费用不能为空")]
        [ExcelColumn(Name = "检讨?调查?试验费用")]
        [ExcelColumnName("检讨?调查?试验费用")]
        public decimal Qcrd007 { get; set; }

        [Required(ErrorMessage = "检讨会使用时间(分)不能为空")]
        [ExcelColumn(Name = "检讨会使用时间(分)")]
        [ExcelColumnName("检讨会使用时间(分)")]
        public int Qcrd008 { get; set; }

        [Required(ErrorMessage = "直接人员参加人数不能为空")]
        [ExcelColumn(Name = "直接人员参加人数")]
        [ExcelColumnName("直接人员参加人数")]
        public int Qcrd009 { get; set; }

        [Required(ErrorMessage = "间接人员参加人数不能为空")]
        [ExcelColumn(Name = "间接人员参加人数")]
        [ExcelColumnName("间接人员参加人数")]
        public int Qcrd010 { get; set; }

        [Required(ErrorMessage = "调查评价试验工作时间(分)不能为空")]
        [ExcelColumn(Name = "调查评价试验工作时间(分)")]
        [ExcelColumnName("调查评价试验工作时间(分)")]
        public int Qcrd011 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd012 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd013 { get; set; }

        [Required(ErrorMessage = "其他作业時間(分)不能为空")]
        [ExcelColumn(Name = "其他作业時間(分)")]
        [ExcelColumnName("其他作业時間(分)")]
        public int Qcrd014 { get; set; }

        [Required(ErrorMessage = "其他设备购入费,工程费,搬运费不能为空")]
        [ExcelColumn(Name = "其他设备购入费,工程费,搬运费")]
        [ExcelColumnName("其他设备购入费,工程费,搬运费")]
        public decimal Qcrd015 { get; set; }

        [Required(ErrorMessage = "需要不良改修对应不能为空")]
        [ExcelColumn(Name = "需要不良改修对应")]
        [ExcelColumnName("需要不良改修对应")]
        public int Qcrd016 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcrd017 { get; set; }

        [ExcelColumn(Name = "品质问题対応记录者")]
        [ExcelColumnName("品质问题対応记录者")]
        public string Qcrdqarec { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd018 { get; set; }

        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Qcrd019 { get; set; }

        [Required(ErrorMessage = "选别?改修费用不能为空")]
        [ExcelColumn(Name = "选别?改修费用")]
        [ExcelColumnName("选别?改修费用")]
        public decimal Qcrd020 { get; set; }

        [Required(ErrorMessage = "选别?改修时间(分)不能为空")]
        [ExcelColumn(Name = "选别?改修时间(分)")]
        [ExcelColumnName("选别?改修时间(分)")]
        public int Qcrd021 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        [ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Qcrd022 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd023 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        [ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Qcrd024 { get; set; }

        [Required(ErrorMessage = "选别?改修其他费用不能为空")]
        [ExcelColumn(Name = "选别?改修其他费用")]
        [ExcelColumnName("选别?改修其他费用")]
        public decimal Qcrd025 { get; set; }

        [ExcelColumn(Name = "选别?改修备注")]
        [ExcelColumnName("选别?改修备注")]
        public string Qcrd026 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        [ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Qcrd027 { get; set; }

        [ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Qcrd028 { get; set; }

        [ExcelColumn(Name = "Debit Note No")]
        [ExcelColumnName("Debit Note No")]
        public string Qcrd029 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        [ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Qcrd030 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd031 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Qcrd032 { get; set; }

        [ExcelColumn(Name = "生管品质问题対応记录者")]
        [ExcelColumnName("生管品质问题対応记录者")]
        public string Qcrdmcrec { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd033 { get; set; }

        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Qcrd034 { get; set; }

        [Required(ErrorMessage = "选别?改修费用不能为空")]
        [ExcelColumn(Name = "选别?改修费用")]
        [ExcelColumnName("选别?改修费用")]
        public decimal Qcrd035 { get; set; }

        [Required(ErrorMessage = "选别?改修时间(分)不能为空")]
        [ExcelColumn(Name = "选别?改修时间(分)")]
        [ExcelColumnName("选别?改修时间(分)")]
        public int Qcrd036 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        [ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Qcrd037 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd038 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        [ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Qcrd039 { get; set; }

        [Required(ErrorMessage = "选别?改修其他费用不能为空")]
        [ExcelColumn(Name = "选别?改修其他费用")]
        [ExcelColumnName("选别?改修其他费用")]
        public decimal Qcrd040 { get; set; }

        [ExcelColumn(Name = "选别?改修备注")]
        [ExcelColumnName("选别?改修备注")]
        public string Qcrd041 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        [ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Qcrd042 { get; set; }

        [ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Qcrd043 { get; set; }

        [ExcelColumn(Name = "Debit Note No")]
        [ExcelColumnName("Debit Note No")]
        public string Qcrd044 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        [ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Qcrd045 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd046 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Qcrd047 { get; set; }

        [ExcelColumn(Name = "M/L不良改修対応记录者")]
        [ExcelColumnName("M/L不良改修対応记录者")]
        public string Qcrdassrec { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcrd048 { get; set; }

        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Qcrd049 { get; set; }

        [Required(ErrorMessage = "选别?改修费用不能为空")]
        [ExcelColumn(Name = "选别?改修费用")]
        [ExcelColumnName("选别?改修费用")]
        public decimal Qcrd050 { get; set; }

        [Required(ErrorMessage = "选别?改修时间(分)不能为空")]
        [ExcelColumn(Name = "选别?改修时间(分)")]
        [ExcelColumnName("选别?改修时间(分)")]
        public int Qcrd051 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        [ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Qcrd052 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        [ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Qcrd053 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        [ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Qcrd054 { get; set; }

        [Required(ErrorMessage = "选别?改修其他费用不能为空")]
        [ExcelColumn(Name = "选别?改修其他费用")]
        [ExcelColumnName("选别?改修其他费用")]
        public decimal Qcrd055 { get; set; }

        [ExcelColumn(Name = "选别?改修备注")]
        [ExcelColumnName("选别?改修备注")]
        public string Qcrd056 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        [ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Qcrd057 { get; set; }

        [ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Qcrd058 { get; set; }

        [ExcelColumn(Name = "Debit Note No")]
        [ExcelColumnName("Debit Note No")]
        public string Qcrd059 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        [ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Qcrd060 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcrd061 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Qcrd062 { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Qcrdpcbrec { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "顾客名")]
        public string Qcrd028Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}