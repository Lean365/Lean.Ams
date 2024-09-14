
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 返工改修
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:47:36
    /// </summary>
    public class QmCostReworkQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Md002 { get; set; }
        /// <summary>
        /// 日期 
        /// </summary>        
        public DateTime? BeginMd003 { get; set; }
        public DateTime? EndMd003 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Md004 { get; set; }
    }

    /// <summary>
    /// 返工改修
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:47:36
    /// </summary>
    public class QmCostReworkDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Md002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Md003 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Md004 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Md005 { get; set; }

        [Required(ErrorMessage = "直接人员赁率不能为空")]
        //[ExcelColumn(Name = "直接人员赁率")]
        [ExcelColumnName("直接人员赁率")]

        public decimal Md006 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        //[ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]

        public decimal Md007 { get; set; }

        //[ExcelColumn(Name = "检讨.调查.试验内容")]
        [ExcelColumnName("检讨.调查.试验内容")]

        public string Md008 { get; set; }

        [Required(ErrorMessage = "检讨.调查.试验费用不能为空")]
        //[ExcelColumn(Name = "检讨.调查.试验费用")]
        [ExcelColumnName("检讨.调查.试验费用")]

        public decimal Md009 { get; set; }

        [Required(ErrorMessage = "检讨会使用时间(分)不能为空")]
        //[ExcelColumn(Name = "检讨会使用时间(分)")]
        [ExcelColumnName("检讨会使用时间(分)")]

        public int Md010 { get; set; }

        [Required(ErrorMessage = "直接人员参加人数不能为空")]
        //[ExcelColumn(Name = "直接人员参加人数")]
        [ExcelColumnName("直接人员参加人数")]

        public int Md011 { get; set; }

        [Required(ErrorMessage = "间接人员参加人数不能为空")]
        //[ExcelColumn(Name = "间接人员参加人数")]
        [ExcelColumnName("间接人员参加人数")]

        public int Md012 { get; set; }

        [Required(ErrorMessage = "调查评价试验工作时间(分)不能为空")]
        //[ExcelColumn(Name = "调查评价试验工作时间(分)")]
        [ExcelColumnName("调查评价试验工作时间(分)")]

        public int Md013 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]

        public decimal Md014 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Md015 { get; set; }

        [Required(ErrorMessage = "其他作业時間(分)不能为空")]
        //[ExcelColumn(Name = "其他作业時間(分)")]
        [ExcelColumnName("其他作业時間(分)")]

        public int Md016 { get; set; }

        [Required(ErrorMessage = "其他设备购入费,工程费,搬运费不能为空")]
        //[ExcelColumn(Name = "其他设备购入费,工程费,搬运费")]
        [ExcelColumnName("其他设备购入费,工程费,搬运费")]

        public decimal Md017 { get; set; }

        [Required(ErrorMessage = "需要不良改修对应不能为空")]
        //[ExcelColumn(Name = "需要不良改修对应")]
        [ExcelColumnName("需要不良改修对应")]

        public int Md018 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Md019 { get; set; }

        //[ExcelColumn(Name = "品质问题対応记录者")]
        [ExcelColumnName("品质问题対応记录者")]

        public string Md020 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Md021 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]

        public string Md022 { get; set; }

        [Required(ErrorMessage = "选别.改修费用不能为空")]
        //[ExcelColumn(Name = "选别.改修费用")]
        [ExcelColumnName("选别.改修费用")]

        public decimal Md023 { get; set; }

        [Required(ErrorMessage = "选别.改修时间(分)不能为空")]
        //[ExcelColumn(Name = "选别.改修时间(分)")]
        [ExcelColumnName("选别.改修时间(分)")]

        public int Md024 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        //[ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]

        public int Md025 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]

        public decimal Md026 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        //[ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]

        public decimal Md027 { get; set; }

        [Required(ErrorMessage = "选别.改修其他费用不能为空")]
        //[ExcelColumn(Name = "选别.改修其他费用")]
        [ExcelColumnName("选别.改修其他费用")]

        public decimal Md028 { get; set; }

        //[ExcelColumn(Name = "选别.改修备注")]
        [ExcelColumnName("选别.改修备注")]

        public string Md029 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        //[ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]

        public decimal Md030 { get; set; }

        //[ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]

        public string Md031 { get; set; }

        //[ExcelColumn(Name = "请求号码")]
        [ExcelColumnName("请求号码")]

        public string Md032 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        //[ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]

        public decimal Md033 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Md034 { get; set; }

        //[ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]

        public string Md035 { get; set; }

        //[ExcelColumn(Name = "附件2")]
        [ExcelColumnName("附件2")]

        public string Md036 { get; set; }

        //[ExcelColumn(Name = "生管品质问题対応记录者")]
        [ExcelColumnName("生管品质问题対応记录者")]

        public string Md037 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Md038 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]

        public string Md039 { get; set; }

        [Required(ErrorMessage = "选别.改修费用不能为空")]
        //[ExcelColumn(Name = "选别.改修费用")]
        [ExcelColumnName("选别.改修费用")]

        public decimal Md040 { get; set; }

        [Required(ErrorMessage = "选别.改修时间(分)不能为空")]
        //[ExcelColumn(Name = "选别.改修时间(分)")]
        [ExcelColumnName("选别.改修时间(分)")]

        public int Md041 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        //[ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]

        public int Md042 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]

        public decimal Md043 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        //[ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]

        public decimal Md044 { get; set; }

        [Required(ErrorMessage = "选别.改修其他费用不能为空")]
        //[ExcelColumn(Name = "选别.改修其他费用")]
        [ExcelColumnName("选别.改修其他费用")]

        public decimal Md045 { get; set; }

        //[ExcelColumn(Name = "选别.改修备注")]
        [ExcelColumnName("选别.改修备注")]

        public string Md046 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        //[ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]

        public decimal Md047 { get; set; }

        //[ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]

        public string Md048 { get; set; }

        //[ExcelColumn(Name = "请求号码")]
        [ExcelColumnName("请求号码")]

        public string Md049 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        //[ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]

        public decimal Md050 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Md051 { get; set; }

        //[ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]

        public string Md052 { get; set; }

        //[ExcelColumn(Name = "附件1")]
        [ExcelColumnName("附件1")]

        public string Md053 { get; set; }

        //[ExcelColumn(Name = "M/L不良改修対応记录者")]
        [ExcelColumnName("M/L不良改修対応记录者")]

        public string Md054 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Md055 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]

        public string Md056 { get; set; }

        [Required(ErrorMessage = "选别.改修费用不能为空")]
        //[ExcelColumn(Name = "选别.改修费用")]
        [ExcelColumnName("选别.改修费用")]

        public decimal Md057 { get; set; }

        [Required(ErrorMessage = "选别.改修时间(分)不能为空")]
        //[ExcelColumn(Name = "选别.改修时间(分)")]
        [ExcelColumnName("选别.改修时间(分)")]

        public int Md058 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        //[ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]

        public int Md059 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]

        public decimal Md060 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        //[ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]

        public decimal Md061 { get; set; }

        [Required(ErrorMessage = "选别.改修其他费用不能为空")]
        //[ExcelColumn(Name = "选别.改修其他费用")]
        [ExcelColumnName("选别.改修其他费用")]

        public decimal Md062 { get; set; }

        //[ExcelColumn(Name = "选别.改修备注")]
        [ExcelColumnName("选别.改修备注")]

        public string Md063 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        //[ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]

        public decimal Md064 { get; set; }

        //[ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]

        public string Md065 { get; set; }

        //[ExcelColumn(Name = "请求号码")]
        [ExcelColumnName("请求号码")]

        public string Md066 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        //[ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]

        public decimal Md067 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Md068 { get; set; }

        //[ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]

        public string Md069 { get; set; }

        //[ExcelColumn(Name = "附件3")]
        [ExcelColumnName("附件3")]

        public string Md070 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]

        public string Md071 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "工厂")]
        public string Md002Label { get; set; }
        [ExcelColumn(Name = "机种")]
        public string Md004Label { get; set; }
    }

    /// <summary>
    /// 返工改修
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:47:36
    /// </summary>
    public class QmCostReworkImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Md002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Md003 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Md004 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Md005 { get; set; }

        [Required(ErrorMessage = "直接人员赁率不能为空")]
        //[ExcelColumn(Name = "直接人员赁率")]
        [ExcelColumnName("直接人员赁率")]
        public decimal Md006 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        //[ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]
        public decimal Md007 { get; set; }

        //[ExcelColumn(Name = "检讨.调查.试验内容")]
        [ExcelColumnName("检讨.调查.试验内容")]
        public string Md008 { get; set; }

        [Required(ErrorMessage = "检讨.调查.试验费用不能为空")]
        //[ExcelColumn(Name = "检讨.调查.试验费用")]
        [ExcelColumnName("检讨.调查.试验费用")]
        public decimal Md009 { get; set; }

        [Required(ErrorMessage = "检讨会使用时间(分)不能为空")]
        //[ExcelColumn(Name = "检讨会使用时间(分)")]
        [ExcelColumnName("检讨会使用时间(分)")]
        public int Md010 { get; set; }

        [Required(ErrorMessage = "直接人员参加人数不能为空")]
        //[ExcelColumn(Name = "直接人员参加人数")]
        [ExcelColumnName("直接人员参加人数")]
        public int Md011 { get; set; }

        [Required(ErrorMessage = "间接人员参加人数不能为空")]
        //[ExcelColumn(Name = "间接人员参加人数")]
        [ExcelColumnName("间接人员参加人数")]
        public int Md012 { get; set; }

        [Required(ErrorMessage = "调查评价试验工作时间(分)不能为空")]
        //[ExcelColumn(Name = "调查评价试验工作时间(分)")]
        [ExcelColumnName("调查评价试验工作时间(分)")]
        public int Md013 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Md014 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Md015 { get; set; }

        [Required(ErrorMessage = "其他作业時間(分)不能为空")]
        //[ExcelColumn(Name = "其他作业時間(分)")]
        [ExcelColumnName("其他作业時間(分)")]
        public int Md016 { get; set; }

        [Required(ErrorMessage = "其他设备购入费,工程费,搬运费不能为空")]
        //[ExcelColumn(Name = "其他设备购入费,工程费,搬运费")]
        [ExcelColumnName("其他设备购入费,工程费,搬运费")]
        public decimal Md017 { get; set; }

        [Required(ErrorMessage = "需要不良改修对应不能为空")]
        //[ExcelColumn(Name = "需要不良改修对应")]
        [ExcelColumnName("需要不良改修对应")]
        public int Md018 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Md019 { get; set; }

        //[ExcelColumn(Name = "品质问题対応记录者")]
        [ExcelColumnName("品质问题対応记录者")]
        public string Md020 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Md021 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Md022 { get; set; }

        [Required(ErrorMessage = "选别.改修费用不能为空")]
        //[ExcelColumn(Name = "选别.改修费用")]
        [ExcelColumnName("选别.改修费用")]
        public decimal Md023 { get; set; }

        [Required(ErrorMessage = "选别.改修时间(分)不能为空")]
        //[ExcelColumn(Name = "选别.改修时间(分)")]
        [ExcelColumnName("选别.改修时间(分)")]
        public int Md024 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        //[ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Md025 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Md026 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        //[ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Md027 { get; set; }

        [Required(ErrorMessage = "选别.改修其他费用不能为空")]
        //[ExcelColumn(Name = "选别.改修其他费用")]
        [ExcelColumnName("选别.改修其他费用")]
        public decimal Md028 { get; set; }

        //[ExcelColumn(Name = "选别.改修备注")]
        [ExcelColumnName("选别.改修备注")]
        public string Md029 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        //[ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Md030 { get; set; }

        //[ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Md031 { get; set; }

        //[ExcelColumn(Name = "请求号码")]
        [ExcelColumnName("请求号码")]
        public string Md032 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        //[ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Md033 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Md034 { get; set; }

        //[ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Md035 { get; set; }

        //[ExcelColumn(Name = "附件2")]
        [ExcelColumnName("附件2")]
        public string Md036 { get; set; }

        //[ExcelColumn(Name = "生管品质问题対応记录者")]
        [ExcelColumnName("生管品质问题対応记录者")]
        public string Md037 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Md038 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Md039 { get; set; }

        [Required(ErrorMessage = "选别.改修费用不能为空")]
        //[ExcelColumn(Name = "选别.改修费用")]
        [ExcelColumnName("选别.改修费用")]
        public decimal Md040 { get; set; }

        [Required(ErrorMessage = "选别.改修时间(分)不能为空")]
        //[ExcelColumn(Name = "选别.改修时间(分)")]
        [ExcelColumnName("选别.改修时间(分)")]
        public int Md041 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        //[ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Md042 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Md043 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        //[ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Md044 { get; set; }

        [Required(ErrorMessage = "选别.改修其他费用不能为空")]
        //[ExcelColumn(Name = "选别.改修其他费用")]
        [ExcelColumnName("选别.改修其他费用")]
        public decimal Md045 { get; set; }

        //[ExcelColumn(Name = "选别.改修备注")]
        [ExcelColumnName("选别.改修备注")]
        public string Md046 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        //[ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Md047 { get; set; }

        //[ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Md048 { get; set; }

        //[ExcelColumn(Name = "请求号码")]
        [ExcelColumnName("请求号码")]
        public string Md049 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        //[ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Md050 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Md051 { get; set; }

        //[ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Md052 { get; set; }

        //[ExcelColumn(Name = "附件1")]
        [ExcelColumnName("附件1")]
        public string Md053 { get; set; }

        //[ExcelColumn(Name = "M/L不良改修対応记录者")]
        [ExcelColumnName("M/L不良改修対応记录者")]
        public string Md054 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Md055 { get; set; }

        //[ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string Md056 { get; set; }

        [Required(ErrorMessage = "选别.改修费用不能为空")]
        //[ExcelColumn(Name = "选别.改修费用")]
        [ExcelColumnName("选别.改修费用")]
        public decimal Md057 { get; set; }

        [Required(ErrorMessage = "选别.改修时间(分)不能为空")]
        //[ExcelColumn(Name = "选别.改修时间(分)")]
        [ExcelColumnName("选别.改修时间(分)")]
        public int Md058 { get; set; }

        [Required(ErrorMessage = "再检查时间(分)不能为空")]
        //[ExcelColumn(Name = "再检查时间(分)")]
        [ExcelColumnName("再检查时间(分)")]
        public int Md059 { get; set; }

        [Required(ErrorMessage = "交通费、旅费不能为空")]
        //[ExcelColumn(Name = "交通费、旅费")]
        [ExcelColumnName("交通费、旅费")]
        public decimal Md060 { get; set; }

        [Required(ErrorMessage = "仓库管理费不能为空")]
        //[ExcelColumn(Name = "仓库管理费")]
        [ExcelColumnName("仓库管理费")]
        public decimal Md061 { get; set; }

        [Required(ErrorMessage = "选别.改修其他费用不能为空")]
        //[ExcelColumn(Name = "选别.改修其他费用")]
        [ExcelColumnName("选别.改修其他费用")]
        public decimal Md062 { get; set; }

        //[ExcelColumn(Name = "选别.改修备注")]
        [ExcelColumnName("选别.改修备注")]
        public string Md063 { get; set; }

        [Required(ErrorMessage = "向顾客的费用请求不能为空")]
        //[ExcelColumn(Name = "向顾客的费用请求")]
        [ExcelColumnName("向顾客的费用请求")]
        public decimal Md064 { get; set; }

        //[ExcelColumn(Name = "顾客名")]
        [ExcelColumnName("顾客名")]
        public string Md065 { get; set; }

        //[ExcelColumn(Name = "请求号码")]
        [ExcelColumnName("请求号码")]
        public string Md066 { get; set; }

        [Required(ErrorMessage = "请求费用不能为空")]
        //[ExcelColumn(Name = "请求费用")]
        [ExcelColumnName("请求费用")]
        public decimal Md067 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Md068 { get; set; }

        //[ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Md069 { get; set; }

        //[ExcelColumn(Name = "附件3")]
        [ExcelColumnName("附件3")]
        public string Md070 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Md071 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Md002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "机种")]
        public string Md004Label { get; set; }
    }

}