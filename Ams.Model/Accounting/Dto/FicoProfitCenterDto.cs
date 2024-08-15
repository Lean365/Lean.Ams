
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 利润中心
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 14:40:21
    /// </summary>
    public class FicoProfitCenterQueryDto : PagerInfo 
    {
        public string Prctr { get; set; }
        public string Kokrs { get; set; }
        public DateTime? BeginDatbi { get; set; }
        public DateTime? EndDatbi { get; set; }
        public string Ltext { get; set; }
        public int? LockInd { get; set; }
        public int? Tstate { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 14:40:21
    /// </summary>
    public class FicoProfitCenterDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSfId { get; set; }

        [ExcelColumn(Name = "集团  ")]
        [ExcelColumnName("集团  ")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "利润中心  不能为空")]
        [ExcelColumn(Name = "利润中心  ")]
        [ExcelColumnName("利润中心  ")]
        public string Prctr { get; set; }

        [Required(ErrorMessage = "控制范围  不能为空")]
        [ExcelColumn(Name = "控制范围  ")]
        [ExcelColumnName("控制范围  ")]
        public string Kokrs { get; set; }

        [ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]
        public DateTime? Datab { get; set; }

        [ExcelColumn(Name = "有效截至日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效截至日期")]
        public DateTime? Datbi { get; set; }

        [ExcelColumn(Name = "部门  ")]
        [ExcelColumnName("部门  ")]
        public int? Abtei { get; set; }

        [ExcelColumn(Name = "负责人  ")]
        [ExcelColumnName("负责人  ")]
        public string Verak { get; set; }

        [ExcelColumn(Name = "货币  ")]
        [ExcelColumnName("货币  ")]
        public string Waers { get; set; }

        [ExcelColumn(Name = "名称  ")]
        [ExcelColumnName("名称  ")]
        public string Stext { get; set; }

        [ExcelColumn(Name = "长文本  ")]
        [ExcelColumnName("长文本  ")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "利润中心说明  ")]
        [ExcelColumnName("利润中心说明  ")]
        public string Atext { get; set; }

        [ExcelColumn(Name = "利润中心组  ")]
        [ExcelColumnName("利润中心组  ")]
        public string Khinr { get; set; }

        [ExcelColumn(Name = "权益类型  ")]
        [ExcelColumnName("权益类型  ")]
        public string Etype { get; set; }

        [ExcelColumn(Name = "地区税务代码  ")]
        [ExcelColumnName("地区税务代码  ")]
        public string Txjcd { get; set; }

        [ExcelColumn(Name = "锁定标记  ")]
        [ExcelColumnName("锁定标记  ")]
        public int? LockInd { get; set; }

        [ExcelColumn(Name = "状态  ")]
        [ExcelColumnName("状态  ")]
        public int? Tstate { get; set; }

        [ExcelColumn(Name = "预留A  ")]
        [ExcelColumnName("预留A  ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B  ")]
        [ExcelColumnName("预留B  ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C  ")]
        [ExcelColumnName("预留C  ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1  ")]
        [ExcelColumnName("预留1  ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2  ")]
        [ExcelColumnName("预留2  ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3 ")]
        [ExcelColumnName("预留3 ")]
        public decimal REF06 { get; set; }

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

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明 ")]
        [ExcelColumnName("备注说明 ")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "控制范围  ")]
        public string KokrsLabel { get; set; }
        [ExcelColumn(Name = "部门  ")]
        public string AbteiLabel { get; set; }
        [ExcelColumn(Name = "货币  ")]
        public string WaersLabel { get; set; }
        [ExcelColumn(Name = "权益类型  ")]
        public string EtypeLabel { get; set; }
        [ExcelColumn(Name = "锁定标记  ")]
        public string LockIndLabel { get; set; }
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 14:40:21
    /// </summary>
    public class FicoProfitCenterImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSfId { get; set; }

        [ExcelColumn(Name = "集团  ")]
        [ExcelColumnName("集团  ")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "利润中心  不能为空")]
        [ExcelColumn(Name = "利润中心  ")]
        [ExcelColumnName("利润中心  ")]
        public string Prctr { get; set; }

        [Required(ErrorMessage = "控制范围  不能为空")]
        [ExcelColumn(Name = "控制范围  ")]
        [ExcelColumnName("控制范围  ")]
        public string Kokrs { get; set; }

        [ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]
        public DateTime? Datab { get; set; }

        [ExcelColumn(Name = "有效截至日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效截至日期")]
        public DateTime? Datbi { get; set; }

        [ExcelColumn(Name = "部门  ")]
        [ExcelColumnName("部门  ")]
        public int? Abtei { get; set; }

        [ExcelColumn(Name = "负责人  ")]
        [ExcelColumnName("负责人  ")]
        public string Verak { get; set; }

        [ExcelColumn(Name = "货币  ")]
        [ExcelColumnName("货币  ")]
        public string Waers { get; set; }

        [ExcelColumn(Name = "名称  ")]
        [ExcelColumnName("名称  ")]
        public string Stext { get; set; }

        [ExcelColumn(Name = "长文本  ")]
        [ExcelColumnName("长文本  ")]
        public string Ltext { get; set; }

        [ExcelColumn(Name = "利润中心说明  ")]
        [ExcelColumnName("利润中心说明  ")]
        public string Atext { get; set; }

        [ExcelColumn(Name = "利润中心组  ")]
        [ExcelColumnName("利润中心组  ")]
        public string Khinr { get; set; }

        [ExcelColumn(Name = "权益类型  ")]
        [ExcelColumnName("权益类型  ")]
        public string Etype { get; set; }

        [ExcelColumn(Name = "地区税务代码  ")]
        [ExcelColumnName("地区税务代码  ")]
        public string Txjcd { get; set; }

        [ExcelColumn(Name = "锁定标记  ")]
        [ExcelColumnName("锁定标记  ")]
        public int? LockInd { get; set; }

        [ExcelColumn(Name = "状态  ")]
        [ExcelColumnName("状态  ")]
        public int? Tstate { get; set; }

        [ExcelColumn(Name = "预留A  ")]
        [ExcelColumnName("预留A  ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B  ")]
        [ExcelColumnName("预留B  ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C  ")]
        [ExcelColumnName("预留C  ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1  ")]
        [ExcelColumnName("预留1  ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2  ")]
        [ExcelColumnName("预留2  ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3 ")]
        [ExcelColumnName("预留3 ")]
        public decimal REF06 { get; set; }

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

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明 ")]
        [ExcelColumnName("备注说明 ")]
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
        [ExcelColumn(Name = "控制范围  ")]
        public string KokrsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门  ")]
        public string AbteiLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "货币  ")]
        public string WaersLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "权益类型  ")]
        public string EtypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "锁定标记  ")]
        public string LockIndLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

}