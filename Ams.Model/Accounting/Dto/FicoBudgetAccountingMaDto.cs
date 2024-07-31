using Ams.Model.Accounting;

namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 预算科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:42:51
    /// </summary>
    public class FicoBudgetAccountingMaQueryDto : PagerInfo 
    {
        public string FbasBukrs { get; set; }
        public string FbasFipls { get; set; }
        public string FbasSaknr { get; set; }
        public string FbasSatext { get; set; }
        public string FbasLtext { get; set; }
        public string FbasGvtyp { get; set; }
        public int? FbasXspea { get; set; }
        public string FbasMitkz { get; set; }
        public int? FbasWaers { get; set; }
    }

    /// <summary>
    /// 预算科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:42:51
    /// </summary>
    public class FicoBudgetAccountingMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbasSfId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string FbasMandt { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string FbasBukrs { get; set; }

        [Required(ErrorMessage = "语言Key不能为空")]
        [ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string FbasSpras { get; set; }

        [ExcelColumn(Name = "预算科目")]
        [ExcelColumnName("预算科目")]
        public string FbasFipls { get; set; }

        [ExcelColumn(Name = "会计科目")]
        [ExcelColumnName("会计科目")]
        public string FbasSaknr { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbasSatext { get; set; }

        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string FbasLtext { get; set; }

        [ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string FbasStext { get; set; }

        [ExcelColumn(Name = "费用类型")]
        [ExcelColumnName("费用类型")]
        public string FbasGvtyp { get; set; }

        [ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int? FbasXspea { get; set; }

        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string FbasMitkz { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public int? FbasWaers { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
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
        public List<FicoBudgetAccountingSlvDto> FicoBudgetAccountingSlvNav { get; set; }
        [ExcelColumn(Name = "公司代码")]
        public string FbasBukrsLabel { get; set; }
        [ExcelColumn(Name = "会计科目")]
        public string FbasSaknrLabel { get; set; }
        [ExcelColumn(Name = "费用类型")]
        public string FbasGvtypLabel { get; set; }
        [ExcelColumn(Name = "冻结")]
        public string FbasXspeaLabel { get; set; }
        [ExcelColumn(Name = "统驭科目")]
        public string FbasMitkzLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string FbasWaersLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 预算科目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:42:51
    /// </summary>
    public class FicoBudgetAccountingMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbasSfId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string FbasMandt { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string FbasBukrs { get; set; }

        [Required(ErrorMessage = "语言Key不能为空")]
        [ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string FbasSpras { get; set; }

        [ExcelColumn(Name = "预算科目")]
        [ExcelColumnName("预算科目")]
        public string FbasFipls { get; set; }

        [ExcelColumn(Name = "会计科目")]
        [ExcelColumnName("会计科目")]
        public string FbasSaknr { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbasSatext { get; set; }

        [ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string FbasLtext { get; set; }

        [ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string FbasStext { get; set; }

        [ExcelColumn(Name = "费用类型")]
        [ExcelColumnName("费用类型")]
        public string FbasGvtyp { get; set; }

        [ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int? FbasXspea { get; set; }

        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string FbasMitkz { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public int? FbasWaers { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
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
        public List<FicoBudgetAccountingSlvDto> FicoBudgetAccountingSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码")]
        public string FbasBukrsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "会计科目")]
        public string FbasSaknrLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "费用类型")]
        public string FbasGvtypLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "冻结")]
        public string FbasXspeaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string FbasMitkzLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string FbasWaersLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}