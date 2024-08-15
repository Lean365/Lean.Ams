
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 月度资产
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:59:43
    /// </summary>
    public class FicoMonthlyAssetsQueryDto : PagerInfo 
    {
        public string FaLfgja { get; set; }
        public string FaLfmon { get; set; }
        public string FaBukrs { get; set; }
        public string FaBtabt { get; set; }
        public string FaAnlkl { get; set; }
        public string FaAnln { get; set; }
        public string FaKostl { get; set; }
        public string FaStext { get; set; }
        public DateTime? BeginFaAktiv { get; set; }
        public DateTime? EndFaAktiv { get; set; }
        public DateTime? BeginFaDeakt { get; set; }
        public DateTime? EndFaDeakt { get; set; }
        public int? FaParkflg { get; set; }
    }

    /// <summary>
    /// 月度资产
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:59:43
    /// </summary>
    public class FicoMonthlyAssetsDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FaSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string FaLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FaLfmon { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FaBukrs { get; set; }

        [ExcelColumn(Name = "使用部门")]
        [ExcelColumnName("使用部门")]
        public string FaBtabt { get; set; }

        [ExcelColumn(Name = "资产类别")]
        [ExcelColumnName("资产类别")]
        public string FaAnlkl { get; set; }

        [ExcelColumn(Name = "资产编码")]
        [ExcelColumnName("资产编码")]
        public string FaAnln { get; set; }

        [ExcelColumn(Name = "成本中心")]
        [ExcelColumnName("成本中心")]
        public string FaKostl { get; set; }

        [ExcelColumn(Name = "资产简称")]
        [ExcelColumnName("资产简称")]
        public string FaStext { get; set; }

        [ExcelColumn(Name = "资产全称")]
        [ExcelColumnName("资产全称")]
        public string FaLtext { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string FaMeins { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int? FaMenge { get; set; }

        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int? FaBsakz { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FaWaers { get; set; }

        [ExcelColumn(Name = "购买价格")]
        [ExcelColumnName("购买价格")]
        public decimal FaBubtr { get; set; }

        [ExcelColumn(Name = "资本化日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("资本化日期")]
        public DateTime? FaAktiv { get; set; }

        [ExcelColumn(Name = "折旧价值")]
        [ExcelColumnName("折旧价值")]
        public decimal FaNafaz { get; set; }

        [ExcelColumn(Name = "报废日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("报废日期")]
        public DateTime? FaDeakt { get; set; }

        [ExcelColumn(Name = "残值")]
        [ExcelColumnName("残值")]
        public decimal FaSchrw { get; set; }

        [ExcelColumn(Name = "存放位置")]
        [ExcelColumnName("存放位置")]
        public string FaPosnr { get; set; }

        [ExcelColumn(Name = "使用年限")]
        [ExcelColumnName("使用年限")]
        public decimal FaSrvvy { get; set; }

        [ExcelColumn(Name = "是否停用")]
        [ExcelColumnName("是否停用")]
        public int? FaParkflg { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string FaLifnr { get; set; }

        [ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]
        public string FaHerst { get; set; }

        [ExcelColumn(Name = "供应商物料")]
        [ExcelColumnName("供应商物料")]
        public string FaVenpn { get; set; }

        [ExcelColumn(Name = "制造商物料")]
        [ExcelColumnName("制造商物料")]
        public string FaMfrpn { get; set; }

        [ExcelColumn(Name = "资产形态")]
        [ExcelColumnName("资产形态")]
        public int? FaEntity { get; set; }

        [ExcelColumn(Name = "资产存在否")]
        [ExcelColumnName("资产存在否")]
        public int? FaNxtfl { get; set; }

        [ExcelColumn(Name = "盘点人员")]
        [ExcelColumnName("盘点人员")]
        public string FaPresp { get; set; }

        [ExcelIgnore]
        public DateTime? FaIdatu { get; set; }

        [ExcelIgnore]
        public string REF01 { get; set; }

        [ExcelIgnore]
        public string REF02 { get; set; }

        [ExcelIgnore]
        public string REF03 { get; set; }

        [ExcelIgnore]
        public decimal REF04 { get; set; }

        [ExcelIgnore]
        public decimal REF05 { get; set; }

        [ExcelIgnore]
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

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "期间")]
        public string FaLfgjaLabel { get; set; }
        [ExcelColumn(Name = "年月")]
        public string FaLfmonLabel { get; set; }
        [ExcelColumn(Name = "公司")]
        public string FaBukrsLabel { get; set; }
        [ExcelColumn(Name = "使用部门")]
        public string FaBtabtLabel { get; set; }
        [ExcelColumn(Name = "资产类别")]
        public string FaAnlklLabel { get; set; }
        [ExcelColumn(Name = "成本中心")]
        public string FaKostlLabel { get; set; }
        [ExcelColumn(Name = "管理区分")]
        public string FaBsakzLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string FaWaersLabel { get; set; }
        [ExcelColumn(Name = "是否停用")]
        public string FaParkflgLabel { get; set; }
        [ExcelColumn(Name = "资产形态")]
        public string FaEntityLabel { get; set; }
    }

    /// <summary>
    /// 月度资产
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:59:43
    /// </summary>
    public class FicoMonthlyAssetsImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FaSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string FaLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FaLfmon { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FaBukrs { get; set; }

        [ExcelColumn(Name = "使用部门")]
        [ExcelColumnName("使用部门")]
        public string FaBtabt { get; set; }

        [ExcelColumn(Name = "资产类别")]
        [ExcelColumnName("资产类别")]
        public string FaAnlkl { get; set; }

        [ExcelColumn(Name = "资产编码")]
        [ExcelColumnName("资产编码")]
        public string FaAnln { get; set; }

        [ExcelColumn(Name = "成本中心")]
        [ExcelColumnName("成本中心")]
        public string FaKostl { get; set; }

        [ExcelColumn(Name = "资产简称")]
        [ExcelColumnName("资产简称")]
        public string FaStext { get; set; }

        [ExcelColumn(Name = "资产全称")]
        [ExcelColumnName("资产全称")]
        public string FaLtext { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string FaMeins { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int? FaMenge { get; set; }

        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int? FaBsakz { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FaWaers { get; set; }

        [ExcelColumn(Name = "购买价格")]
        [ExcelColumnName("购买价格")]
        public decimal FaBubtr { get; set; }

        [ExcelColumn(Name = "资本化日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("资本化日期")]
        public DateTime? FaAktiv { get; set; }

        [ExcelColumn(Name = "折旧价值")]
        [ExcelColumnName("折旧价值")]
        public decimal FaNafaz { get; set; }

        [ExcelColumn(Name = "报废日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("报废日期")]
        public DateTime? FaDeakt { get; set; }

        [ExcelColumn(Name = "残值")]
        [ExcelColumnName("残值")]
        public decimal FaSchrw { get; set; }

        [ExcelColumn(Name = "存放位置")]
        [ExcelColumnName("存放位置")]
        public string FaPosnr { get; set; }

        [ExcelColumn(Name = "使用年限")]
        [ExcelColumnName("使用年限")]
        public decimal FaSrvvy { get; set; }

        [ExcelColumn(Name = "是否停用")]
        [ExcelColumnName("是否停用")]
        public int? FaParkflg { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string FaLifnr { get; set; }

        [ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]
        public string FaHerst { get; set; }

        [ExcelColumn(Name = "供应商物料")]
        [ExcelColumnName("供应商物料")]
        public string FaVenpn { get; set; }

        [ExcelColumn(Name = "制造商物料")]
        [ExcelColumnName("制造商物料")]
        public string FaMfrpn { get; set; }

        [ExcelColumn(Name = "资产形态")]
        [ExcelColumnName("资产形态")]
        public int? FaEntity { get; set; }

        [ExcelColumn(Name = "资产存在否")]
        [ExcelColumnName("资产存在否")]
        public int? FaNxtfl { get; set; }

        [ExcelColumn(Name = "盘点人员")]
        [ExcelColumnName("盘点人员")]
        public string FaPresp { get; set; }

        [ExcelIgnore]
        public DateTime? FaIdatu { get; set; }

        [ExcelIgnore]
        public string REF01 { get; set; }

        [ExcelIgnore]
        public string REF02 { get; set; }

        [ExcelIgnore]
        public string REF03 { get; set; }

        [ExcelIgnore]
        public decimal REF04 { get; set; }

        [ExcelIgnore]
        public decimal REF05 { get; set; }

        [ExcelIgnore]
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

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string FaLfgjaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FaLfmonLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FaBukrsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "使用部门")]
        public string FaBtabtLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "资产类别")]
        public string FaAnlklLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成本中心")]
        public string FaKostlLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "管理区分")]
        public string FaBsakzLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string FaWaersLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "是否停用")]
        public string FaParkflgLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "资产形态")]
        public string FaEntityLabel { get; set; }
    }

}