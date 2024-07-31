
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 利润中心
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:41:52
    /// </summary>
    public class FicoProfitCenterQueryDto : PagerInfo 
    {
        public string Prctr { get; set; }
        public string Kokrs { get; set; }
        public DateTime? BeginDatbi { get; set; }
        public DateTime? EndDatbi { get; set; }
        public string Ktext { get; set; }
        public string Ltext { get; set; }
        public string Etype { get; set; }
        public int? LockInd { get; set; }
        public int? Tstate { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:41:52
    /// </summary>
    public class FicoProfitCenterDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSfId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Prctr { get; set; }

        [Required(ErrorMessage = "控制范围不能为空")]
        [ExcelColumn(Name = "控制范围")]
        [ExcelColumnName("控制范围")]
        public string Kokrs { get; set; }

        [ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]
        public DateTime? Datab { get; set; }

        [Required(ErrorMessage = "有效截至日期不能为空")]
        [ExcelColumn(Name = "有效截至日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效截至日期")]
        public DateTime? Datbi { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int? Abtei { get; set; }

        [ExcelColumn(Name = "负责人")]
        [ExcelColumnName("负责人")]
        public string Verak { get; set; }

        [ExcelColumn(Name = "货币")]
        [ExcelColumnName("货币")]
        public int? Waers { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Ktext { get; set; }

        [Required(ErrorMessage = "长文本不能为空")]
        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "利润中心说明")]
        [ExcelColumnName("利润中心说明")]
        public string Mctext { get; set; }

        [ExcelColumn(Name = "利润中心组")]
        [ExcelColumnName("利润中心组")]
        public string Khinr { get; set; }

        [ExcelColumn(Name = "权益类型")]
        [ExcelColumnName("权益类型")]
        public string Etype { get; set; }

        [ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]
        public string Txjcd { get; set; }

        [Required(ErrorMessage = "锁定标记不能为空")]
        [ExcelColumn(Name = "锁定标记")]
        [ExcelColumnName("锁定标记")]
        public int LockInd { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public int Tstate { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "控制范围")]
        public string KokrsLabel { get; set; }
        [ExcelColumn(Name = "部门")]
        public string AbteiLabel { get; set; }
        [ExcelColumn(Name = "货币")]
        public string WaersLabel { get; set; }
        [ExcelColumn(Name = "权益类型")]
        public string EtypeLabel { get; set; }
        [ExcelColumn(Name = "锁定标记")]
        public string LockIndLabel { get; set; }
        [ExcelColumn(Name = "状态")]
        public string TstateLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:41:52
    /// </summary>
    public class FicoProfitCenterImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSfId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Prctr { get; set; }

        [Required(ErrorMessage = "控制范围不能为空")]
        [ExcelColumn(Name = "控制范围")]
        [ExcelColumnName("控制范围")]
        public string Kokrs { get; set; }

        [ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]
        public DateTime? Datab { get; set; }

        [Required(ErrorMessage = "有效截至日期不能为空")]
        [ExcelColumn(Name = "有效截至日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效截至日期")]
        public DateTime? Datbi { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int? Abtei { get; set; }

        [ExcelColumn(Name = "负责人")]
        [ExcelColumnName("负责人")]
        public string Verak { get; set; }

        [ExcelColumn(Name = "货币")]
        [ExcelColumnName("货币")]
        public int? Waers { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Ktext { get; set; }

        [Required(ErrorMessage = "长文本不能为空")]
        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "利润中心说明")]
        [ExcelColumnName("利润中心说明")]
        public string Mctext { get; set; }

        [ExcelColumn(Name = "利润中心组")]
        [ExcelColumnName("利润中心组")]
        public string Khinr { get; set; }

        [ExcelColumn(Name = "权益类型")]
        [ExcelColumnName("权益类型")]
        public string Etype { get; set; }

        [ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]
        public string Txjcd { get; set; }

        [Required(ErrorMessage = "锁定标记不能为空")]
        [ExcelColumn(Name = "锁定标记")]
        [ExcelColumnName("锁定标记")]
        public int LockInd { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public int Tstate { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        [ExcelColumn(Name = "控制范围")]
        public string KokrsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string AbteiLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "货币")]
        public string WaersLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "权益类型")]
        public string EtypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "锁定标记")]
        public string LockIndLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "状态")]
        public string TstateLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}