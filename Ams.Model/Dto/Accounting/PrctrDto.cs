
namespace Ams.Model.Dto
{
    /// <summary>
    /// 利润中心
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 17:18:00)
    /// </summary>
    public class PrctrQueryDto : PagerInfo 
    {
        public string FpCorp { get; set; }
        public string FpCode { get; set; }
        public string FpName { get; set; }
        public string FpType { get; set; }
        public DateTime? BeginFpExpDate { get; set; }
        public DateTime? EndFpExpDate { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 输入输出对象
    /// </summary>
    public class PrctrDto
    {
        [Required(ErrorMessage = "唯一标识不能为空")]
        [ExcelColumn(Name = "唯一标识")]
        [ExcelColumnName("唯一标识")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FpCorp { get; set; }

        [Required(ErrorMessage = "代码不能为空")]
        [ExcelColumn(Name = "代码")]
        [ExcelColumnName("代码")]
        public string FpCode { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FpName { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FpType { get; set; }

        [Required(ErrorMessage = "有效从不能为空")]
        [ExcelColumn(Name = "有效从", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效从")]
        public DateTime? FpActDate { get; set; }

        [Required(ErrorMessage = "有效到不能为空")]
        [ExcelColumn(Name = "有效到", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效到")]
        public DateTime? FpExpDate { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FpCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string FpTypeLabel { get; set; }
    }
}