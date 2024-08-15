namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 修理日报slv
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:03:40
    /// </summary>
    public class PpRepairPcbaSlvQueryDto : PagerInfo
    {
        public string Pdrlot { get; set; }
        public string Pdrpcbtype { get; set; }
        public string Pdrpcbcheckout { get; set; }
        public string Pdrbadresponsibility { get; set; }
    }

    /// <summary>
    /// 修理日报slv
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:03:40
    /// </summary>
    public class PpRepairPcbaSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdrSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long PdrParentSfId { get; set; }

        [ExcelColumn(Name = "Pdrlot")]
        [ExcelColumnName("Pdrlot")]
        public string Pdrlot { get; set; }

        [ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]
        public string Pdrpcbtype { get; set; }

        [ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int? Pdrlotqty { get; set; }

        [Required(ErrorMessage = "当日生产数不能为空")]
        [ExcelColumn(Name = "当日生产数")]
        [ExcelColumnName("当日生产数")]
        public int Pdrrealqty { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        [ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]
        public int Pdrrealtotal { get; set; }

        [ExcelColumn(Name = "生产组别")]
        [ExcelColumnName("生产组别")]
        public string Pdrlinename { get; set; }

        [ExcelColumn(Name = "卡号")]
        [ExcelColumnName("卡号")]
        public string Pdrpcbcardno { get; set; }

        [ExcelColumn(Name = "不良症状")]
        [ExcelColumnName("不良症状")]
        public string Pdrbadnote { get; set; }

        [ExcelColumn(Name = "检出工程")]
        [ExcelColumnName("检出工程")]
        public string Pdrpcbcheckout { get; set; }

        [ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]
        public string Pdrbadreason { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        [ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int Pdrbadqty { get; set; }

        [Required(ErrorMessage = "累计不良台数不能为空")]
        [ExcelColumn(Name = "累计不良台数")]
        [ExcelColumnName("累计不良台数")]
        public int Pdrbadtotal { get; set; }

        [ExcelColumn(Name = "责任归属")]
        [ExcelColumnName("责任归属")]
        public string Pdrbadresponsibility { get; set; }

        [ExcelColumn(Name = "不良性质")]
        [ExcelColumnName("不良性质")]
        public string Pdrbadprop { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Pdrbadserial { get; set; }

        [ExcelColumn(Name = "修理")]
        [ExcelColumnName("修理")]
        public string Pdrbadrepairman { get; set; }

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

        [ExcelColumn(Name = "板别")]
        public string PdrpcbtypeLabel { get; set; }

        [ExcelColumn(Name = "检出工程")]
        public string PdrpcbcheckoutLabel { get; set; }

        [ExcelColumn(Name = "责任归属")]
        public string PdrbadresponsibilityLabel { get; set; }

        [ExcelColumn(Name = "不良性质")]
        public string PdrbadpropLabel { get; set; }

        [ExcelColumn(Name = "修理")]
        public string PdrbadrepairmanLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 修理日报slv
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:03:40
    /// </summary>
    public class PpRepairPcbaSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdrSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long PdrParentSfId { get; set; }

        [ExcelColumn(Name = "Pdrlot")]
        [ExcelColumnName("Pdrlot")]
        public string Pdrlot { get; set; }

        [ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]
        public string Pdrpcbtype { get; set; }

        [ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int? Pdrlotqty { get; set; }

        [Required(ErrorMessage = "当日生产数不能为空")]
        [ExcelColumn(Name = "当日生产数")]
        [ExcelColumnName("当日生产数")]
        public int Pdrrealqty { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        [ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]
        public int Pdrrealtotal { get; set; }

        [ExcelColumn(Name = "生产组别")]
        [ExcelColumnName("生产组别")]
        public string Pdrlinename { get; set; }

        [ExcelColumn(Name = "卡号")]
        [ExcelColumnName("卡号")]
        public string Pdrpcbcardno { get; set; }

        [ExcelColumn(Name = "不良症状")]
        [ExcelColumnName("不良症状")]
        public string Pdrbadnote { get; set; }

        [ExcelColumn(Name = "检出工程")]
        [ExcelColumnName("检出工程")]
        public string Pdrpcbcheckout { get; set; }

        [ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]
        public string Pdrbadreason { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        [ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int Pdrbadqty { get; set; }

        [Required(ErrorMessage = "累计不良台数不能为空")]
        [ExcelColumn(Name = "累计不良台数")]
        [ExcelColumnName("累计不良台数")]
        public int Pdrbadtotal { get; set; }

        [ExcelColumn(Name = "责任归属")]
        [ExcelColumnName("责任归属")]
        public string Pdrbadresponsibility { get; set; }

        [ExcelColumn(Name = "不良性质")]
        [ExcelColumnName("不良性质")]
        public string Pdrbadprop { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Pdrbadserial { get; set; }

        [ExcelColumn(Name = "修理")]
        [ExcelColumnName("修理")]
        public string Pdrbadrepairman { get; set; }

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
        [ExcelColumn(Name = "板别")]
        public string PdrpcbtypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检出工程")]
        public string PdrpcbcheckoutLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "责任归属")]
        public string PdrbadresponsibilityLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "不良性质")]
        public string PdrbadpropLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "修理")]
        public string PdrbadrepairmanLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}