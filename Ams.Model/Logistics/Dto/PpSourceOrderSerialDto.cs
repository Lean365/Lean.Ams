
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源订单序列号
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:55
    /// </summary>
    public class PpSourceOrderSerialQueryDto : PagerInfo 
    {
        public string Serialc002 { get; set; }
        public string Serialc003 { get; set; }
    }

    /// <summary>
    /// 源订单序列号
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:55
    /// </summary>
    public class PpSourceOrderSerialDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        public string SfId { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Serialc001 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Serialc002 { get; set; }

        [ExcelColumn(Name = "品号")]
        [ExcelColumnName("品号")]
        public string Serialc003 { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Serialc004 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        public string Serialc001Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 源订单序列号
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:55
    /// </summary>
    public class PpSourceOrderSerialImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        public string SfId { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Serialc001 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Serialc002 { get; set; }

        [ExcelColumn(Name = "品号")]
        [ExcelColumnName("品号")]
        public string Serialc003 { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Serialc004 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        public string Serialc001Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}