
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 设变明细
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 8:13:42
    /// </summary>
    public class PpEcSlaveQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 设变明细
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 8:13:42
    /// </summary>
    public class PpEcSlaveDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? ParentId { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]

        public string Mc003 { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]

        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]

        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "子物料文本")]
        [ExcelColumnName("子物料文本")]

        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]

        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "旧文本")]
        [ExcelColumnName("旧文本")]

        public string Mc010 { get; set; }

        [Required(ErrorMessage = "旧品库存不能为空")]
        //[ExcelColumn(Name = "旧品库存")]
        [ExcelColumnName("旧品库存")]

        public decimal Mc011 { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        //[ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]

        public decimal Mc012 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]

        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]

        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]

        public string Mc015 { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        //[ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]

        public decimal Mc016 { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        //[ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]

        public decimal Mc017 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]

        public string Mc018 { get; set; }

        //[ExcelColumn(Name = "bom番号")]
        [ExcelColumnName("bom番号")]

        public string Mc019 { get; set; }

        //[ExcelColumn(Name = "互换")]
        [ExcelColumnName("互换")]

        public string Mc020 { get; set; }

        //[ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]

        public string Mc021 { get; set; }

        //[ExcelColumn(Name = "指示")]
        [ExcelColumnName("指示")]

        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]

        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("bom日期")]

        public DateTime? Mc024 { get; set; }

        //[ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]

        public string Mc025 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]

        public string Mc026 { get; set; }

        //[ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]

        public string Mc027 { get; set; }

        //[ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]

        public string Mc028 { get; set; }

        //[ExcelColumn(Name = "工厂状态")]
        [ExcelColumnName("工厂状态")]

        public string Mc029 { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        //[ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]

        public int Mc030 { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        //[ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]

        public int Mc031 { get; set; }

        [Required(ErrorMessage = "部管不能为空")]
        //[ExcelColumn(Name = "部管")]
        [ExcelColumnName("部管")]

        public int Mc032 { get; set; }

        [Required(ErrorMessage = "Pcba不能为空")]
        //[ExcelColumn(Name = "Pcba")]
        [ExcelColumnName("Pcba")]

        public int Mc033 { get; set; }

        [Required(ErrorMessage = "组立不能为空")]
        //[ExcelColumn(Name = "组立")]
        [ExcelColumnName("组立")]

        public int Mc034 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

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

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



    }

    /// <summary>
    /// 设变明细
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 8:13:42
    /// </summary>
    public class PpEcSlaveImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? ParentId { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Mc003 { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "子物料文本")]
        [ExcelColumnName("子物料文本")]
        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "旧文本")]
        [ExcelColumnName("旧文本")]
        public string Mc010 { get; set; }

        [Required(ErrorMessage = "旧品库存不能为空")]
        //[ExcelColumn(Name = "旧品库存")]
        [ExcelColumnName("旧品库存")]
        public decimal Mc011 { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        //[ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal Mc012 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string Mc015 { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        //[ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal Mc016 { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        //[ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal Mc017 { get; set; }

        //[ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string Mc018 { get; set; }

        //[ExcelColumn(Name = "bom番号")]
        [ExcelColumnName("bom番号")]
        public string Mc019 { get; set; }

        //[ExcelColumn(Name = "互换")]
        [ExcelColumnName("互换")]
        public string Mc020 { get; set; }

        //[ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string Mc021 { get; set; }

        //[ExcelColumn(Name = "指示")]
        [ExcelColumnName("指示")]
        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("bom日期")]
        public DateTime? Mc024 { get; set; }

        //[ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Mc025 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Mc026 { get; set; }

        //[ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string Mc027 { get; set; }

        //[ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string Mc028 { get; set; }

        //[ExcelColumn(Name = "工厂状态")]
        [ExcelColumnName("工厂状态")]
        public string Mc029 { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        //[ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int Mc030 { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        //[ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int Mc031 { get; set; }

        [Required(ErrorMessage = "部管不能为空")]
        //[ExcelColumn(Name = "部管")]
        [ExcelColumnName("部管")]
        public int Mc032 { get; set; }

        [Required(ErrorMessage = "Pcba不能为空")]
        //[ExcelColumn(Name = "Pcba")]
        [ExcelColumnName("Pcba")]
        public int Mc033 { get; set; }

        [Required(ErrorMessage = "组立不能为空")]
        //[ExcelColumn(Name = "组立")]
        [ExcelColumnName("组立")]
        public int Mc034 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

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
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }

}