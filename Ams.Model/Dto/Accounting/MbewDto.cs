
namespace Ams.Model.Dto
{
    /// <summary>
    /// 物料评估
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 15:30:16)
    /// </summary>
    public class MbewQueryDto : PagerInfo 
    {
        public string MbewBKLAS { get; set; }
        public string MbewBWKEY { get; set; }
    }

    /// <summary>
    /// 物料评估
    /// 输入输出对象
    /// </summary>
    public class MbewDto
    {
        [Required(ErrorMessage = "ID主键不能为空")]
        [ExcelColumn(Name = "ID主键")]
        [ExcelColumnName("ID主键")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MbewSFID { get; set; }

        [ExcelColumn(Name = "CC 库存盘点")]
        [ExcelColumnName("CC 库存盘点")]
        public string MbewABCIW { get; set; }

        [ExcelColumn(Name = "贬值标识  ")]
        [ExcelColumnName("贬值标识  ")]
        public string MbewABWKZ { get; set; }

        [ExcelColumn(Name = "评估类 ")]
        [ExcelColumnName("评估类 ")]
        public string MbewBKLAS { get; set; }

        [Required(ErrorMessage = "评估范围不能为空")]
        [ExcelColumn(Name = "评估范围")]
        [ExcelColumnName("评估范围")]
        public string MbewBWKEY { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal MbewBWPEI { get; set; }

        [Required(ErrorMessage = "商业价格 2不能为空")]
        [ExcelColumn(Name = "商业价格 2")]
        [ExcelColumnName("商业价格 2")]
        public decimal MbewBWPH1 { get; set; }

        [Required(ErrorMessage = "商业价格 1不能为空")]
        [ExcelColumn(Name = "商业价格 1")]
        [ExcelColumnName("商业价格 1")]
        public decimal MbewBWPRH { get; set; }

        [Required(ErrorMessage = "税价1不能为空")]
        [ExcelColumn(Name = "税价1")]
        [ExcelColumnName("税价1")]
        public decimal MbewBWPRS { get; set; }

        [Required(ErrorMessage = "税价2不能为空")]
        [ExcelColumn(Name = "税价2")]
        [ExcelColumnName("税价2")]
        public decimal MbewBWPS1 { get; set; }

        [Required(ErrorMessage = "评价毛利不能为空")]
        [ExcelColumn(Name = "评价毛利")]
        [ExcelColumnName("评价毛利")]
        public decimal MbewBWSPA { get; set; }

        [Required(ErrorMessage = "评估类型不能为空")]
        [ExcelColumn(Name = "评估类型")]
        [ExcelColumnName("评估类型")]
        public string MbewBWTAR { get; set; }

        [ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]
        public string MbewBWTTY { get; set; }

        [ExcelColumn(Name = "评估变式")]
        [ExcelColumnName("评估变式")]
        public string MbewBWVA1 { get; set; }

        [ExcelColumn(Name = "评估变式")]
        [ExcelColumnName("评估变式")]
        public string MbewBWVA2 { get; set; }

        [ExcelColumn(Name = "评估变式")]
        [ExcelColumnName("评估变式")]
        public string MbewBWVA3 { get; set; }

        [ExcelColumn(Name = "用QS的成本估算")]
        [ExcelColumnName("用QS的成本估算")]
        public string MbewEKALR { get; set; }

        [ExcelColumn(Name = "VC:销售订单库存")]
        [ExcelColumnName("VC:销售订单库存")]
        public string MbewEKLAS { get; set; }

        [ExcelColumn(Name = "未来评估决策")]
        [ExcelColumnName("未来评估决策")]
        public string MbewFBWST { get; set; }

        [Required(ErrorMessage = "固定的未来计划价格不能为空")]
        [ExcelColumn(Name = "固定的未来计划价格")]
        [ExcelColumnName("固定的未来计划价格")]
        public decimal MbewFPLPX { get; set; }

        [ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]
        public string MbewHKMAT { get; set; }

        [ExcelColumn(Name = "原始组 ")]
        [ExcelColumnName("原始组 ")]
        public string MbewHRKFT { get; set; }

        [ExcelColumn(Name = "当前成本估算")]
        [ExcelColumnName("当前成本估算")]
        public string MbewKALKL { get; set; }

        [ExcelColumn(Name = "上期成本估计")]
        [ExcelColumnName("上期成本估计")]
        public string MbewKALKV { get; set; }

        [ExcelColumn(Name = "未来成本估算")]
        [ExcelColumnName("未来成本估算")]
        public string MbewKALKZ { get; set; }

        [ExcelColumn(Name = "产品成本核算号")]
        [ExcelColumnName("产品成本核算号")]
        public string MbewKALN1 { get; set; }

        [ExcelColumn(Name = "成本估算编号")]
        [ExcelColumnName("成本估算编号")]
        public string MbewKALNR { get; set; }

        [ExcelColumn(Name = "一般费用代码 ")]
        [ExcelColumnName("一般费用代码 ")]
        public string MbewKALSC { get; set; }

        [ExcelColumn(Name = "间接费分组 ")]
        [ExcelColumnName("间接费分组 ")]
        public string MbewKOSGR { get; set; }

        [ExcelColumn(Name = "盘点库存VO物料")]
        [ExcelColumnName("盘点库存VO物料")]
        public string MbewKZIWL { get; set; }

        [ExcelColumn(Name = "最近价格更改 ", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最近价格更改 ")]
        public DateTime? MbewLAEPR { get; set; }

        [Required(ErrorMessage = "总库存 不能为空")]
        [ExcelColumn(Name = "总库存 ")]
        [ExcelColumnName("总库存 ")]
        public decimal MbewLBKUM { get; set; }

        [ExcelColumn(Name = "当前的值决策 ")]
        [ExcelColumnName("当前的值决策 ")]
        public string MbewLBWST { get; set; }

        [ExcelColumn(Name = "年  当前期间")]
        [ExcelColumnName("年  当前期间")]
        public string MbewLFGJA { get; set; }

        [ExcelColumn(Name = "本期")]
        [ExcelColumnName("本期")]
        public string MbewLFMON { get; set; }

        [Required(ErrorMessage = "当前计划价格不能为空")]
        [ExcelColumn(Name = "当前计划价格")]
        [ExcelColumnName("当前计划价格")]
        public decimal MbewLPLPR { get; set; }

        [Required(ErrorMessage = "固定的当前计划价格不能为空")]
        [ExcelColumn(Name = "固定的当前计划价格")]
        [ExcelColumnName("固定的当前计划价格")]
        public decimal MbewLPLPX { get; set; }

        [ExcelColumn(Name = "评估类型")]
        [ExcelColumnName("评估类型")]
        public string MbewLVORM { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string MbewMANDT { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MbewMATNR { get; set; }

        [ExcelColumn(Name = "MBEW 最后期间之前，期间的 MBEW")]
        [ExcelColumnName("MBEW 最后期间之前，期间的 MBEW")]
        public string MbewMBRUE { get; set; }

        [ExcelColumn(Name = "价格确定")]
        [ExcelColumnName("价格确定")]
        public string MbewMLAST { get; set; }

        [ExcelColumn(Name = "ML 作业")]
        [ExcelColumnName("ML 作业")]
        public string MbewMLMAA { get; set; }

        [ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]
        public string MbewMTORG { get; set; }

        [ExcelColumn(Name = "物料用途 ")]
        [ExcelColumnName("物料用途 ")]
        public string MbewMTUSE { get; set; }

        [ExcelColumn(Name = "LIFO评估储备号 ")]
        [ExcelColumnName("LIFO评估储备号 ")]
        public string MbewMYPOL { get; set; }

        [ExcelColumn(Name = "预付库存")]
        [ExcelColumnName("预付库存")]
        public string MbewOIPPINV { get; set; }

        [ExcelColumn(Name = "VC: 供应商 ")]
        [ExcelColumnName("VC: 供应商 ")]
        public string MbewOKLAS { get; set; }

        [ExcelColumn(Name = "自制产品")]
        [ExcelColumnName("自制产品")]
        public string MbewOWNPR { get; set; }

        [ExcelColumn(Name = "当前会计年度")]
        [ExcelColumnName("当前会计年度")]
        public string MbewPDATL { get; set; }

        [ExcelColumn(Name = "上一会计年 ")]
        [ExcelColumnName("上一会计年 ")]
        public string MbewPDATV { get; set; }

        [ExcelColumn(Name = "来年会计年度")]
        [ExcelColumnName("来年会计年度")]
        public string MbewPDATZ { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal MbewPEINH { get; set; }

        [ExcelColumn(Name = "期间成本估算")]
        [ExcelColumnName("期间成本估算")]
        public string MbewPPERL { get; set; }

        [ExcelColumn(Name = "上期成本估算")]
        [ExcelColumnName("上期成本估算")]
        public string MbewPPERV { get; set; }

        [ExcelColumn(Name = "未来成本估算")]
        [ExcelColumnName("未来成本估算")]
        public string MbewPPERZ { get; set; }

        [ExcelColumn(Name = "当前期间")]
        [ExcelColumnName("当前期间")]
        public string MbewPPRDL { get; set; }

        [ExcelColumn(Name = "前一期间")]
        [ExcelColumnName("前一期间")]
        public string MbewPPRDV { get; set; }

        [ExcelColumn(Name = "记帐期间")]
        [ExcelColumnName("记帐期间")]
        public string MbewPPRDZ { get; set; }

        [ExcelColumn(Name = "维护状态 ")]
        [ExcelColumnName("维护状态 ")]
        public string MbewPSTAT { get; set; }

        [ExcelColumn(Name = "项目库存评估类")]
        [ExcelColumnName("项目库存评估类")]
        public string MbewQKLAS { get; set; }

        [Required(ErrorMessage = "总价值 不能为空")]
        [ExcelColumn(Name = "总价值 ")]
        [ExcelColumnName("总价值 ")]
        public decimal MbewSALK3 { get; set; }

        [Required(ErrorMessage = "价值/MA价格不能为空")]
        [ExcelColumn(Name = "价值/MA价格")]
        [ExcelColumnName("价值/MA价格")]
        public decimal MbewSALKV { get; set; }

        [ExcelColumn(Name = "库存冻结")]
        [ExcelColumnName("库存冻结")]
        public string MbewSPERW { get; set; }

        [Required(ErrorMessage = "标准价格不能为空")]
        [ExcelColumn(Name = "标准价格")]
        [ExcelColumnName("标准价格")]
        public decimal MbewSTPRS { get; set; }

        [Required(ErrorMessage = "上期价格不能为空")]
        [ExcelColumn(Name = "上期价格")]
        [ExcelColumnName("上期价格")]
        public decimal MbewSTPRV { get; set; }

        [Required(ErrorMessage = "时戳不能为空")]
        [ExcelColumn(Name = "时戳")]
        [ExcelColumnName("时戳")]
        public decimal MbewTIMESTAMP { get; set; }

        [ExcelColumn(Name = "上年评估策略")]
        [ExcelColumnName("上年评估策略")]
        public string MbewVBWST { get; set; }

        [Required(ErrorMessage = "移动价格不能为空")]
        [ExcelColumn(Name = "移动价格")]
        [ExcelColumnName("移动价格")]
        public decimal MbewVERPR { get; set; }

        [ExcelColumn(Name = "成本核算版本")]
        [ExcelColumnName("成本核算版本")]
        public string MbewVERS1 { get; set; }

        [ExcelColumn(Name = "成本核算版本")]
        [ExcelColumnName("成本核算版本")]
        public string MbewVERS2 { get; set; }

        [ExcelColumn(Name = "成本核算版本")]
        [ExcelColumnName("成本核算版本")]
        public string MbewVERS3 { get; set; }

        [ExcelColumn(Name = "上年估价类 ")]
        [ExcelColumnName("上年估价类 ")]
        public string MbewVJBKL { get; set; }

        [Required(ErrorMessage = "商业价格 3不能为空")]
        [ExcelColumn(Name = "商业价格 3")]
        [ExcelColumnName("商业价格 3")]
        public decimal MbewVJBWH { get; set; }

        [Required(ErrorMessage = "税价3不能为空")]
        [ExcelColumn(Name = "税价3")]
        [ExcelColumnName("税价3")]
        public decimal MbewVJBWS { get; set; }

        [Required(ErrorMessage = "前年总库存值 不能为空")]
        [ExcelColumn(Name = "前年总库存值 ")]
        [ExcelColumnName("前年总库存值 ")]
        public decimal MbewVJKUM { get; set; }

        [Required(ErrorMessage = "上年价格单位不能为空")]
        [ExcelColumn(Name = "上年价格单位")]
        [ExcelColumnName("上年价格单位")]
        public decimal MbewVJPEI { get; set; }

        [Required(ErrorMessage = "上年总值 不能为空")]
        [ExcelColumn(Name = "上年总值 ")]
        [ExcelColumnName("上年总值 ")]
        public decimal MbewVJSAL { get; set; }

        [Required(ErrorMessage = "上年价值 不能为空")]
        [ExcelColumn(Name = "上年价值 ")]
        [ExcelColumnName("上年价值 ")]
        public decimal MbewVJSAV { get; set; }

        [Required(ErrorMessage = "去年标准价格不能为空")]
        [ExcelColumn(Name = "去年标准价格")]
        [ExcelColumnName("去年标准价格")]
        public decimal MbewVJSTP { get; set; }

        [Required(ErrorMessage = "去年移动平均价不能为空")]
        [ExcelColumn(Name = "去年移动平均价")]
        [ExcelColumnName("去年移动平均价")]
        public decimal MbewVJVER { get; set; }

        [ExcelColumn(Name = "前一年价格控制")]
        [ExcelColumnName("前一年价格控制")]
        public string MbewVJVPR { get; set; }

        [Required(ErrorMessage = "总SP值 不能为空")]
        [ExcelColumn(Name = "总SP值 ")]
        [ExcelColumnName("总SP值 ")]
        public decimal MbewVKSAL { get; set; }

        [ExcelColumn(Name = "上期的评价分类")]
        [ExcelColumnName("上期的评价分类")]
        public string MbewVMBKL { get; set; }

        [Required(ErrorMessage = "前期总库存 不能为空")]
        [ExcelColumn(Name = "前期总库存 ")]
        [ExcelColumnName("前期总库存 ")]
        public decimal MbewVMKUM { get; set; }

        [Required(ErrorMessage = "上期间价格单位不能为空")]
        [ExcelColumn(Name = "上期间价格单位")]
        [ExcelColumnName("上期间价格单位")]
        public decimal MbewVMPEI { get; set; }

        [Required(ErrorMessage = "前期总值 不能为空")]
        [ExcelColumn(Name = "前期总值 ")]
        [ExcelColumnName("前期总值 ")]
        public decimal MbewVMSAL { get; set; }

        [Required(ErrorMessage = "上期的价值 不能为空")]
        [ExcelColumn(Name = "上期的价值 ")]
        [ExcelColumnName("上期的价值 ")]
        public decimal MbewVMSAV { get; set; }

        [Required(ErrorMessage = "前期标准价格不能为空")]
        [ExcelColumn(Name = "前期标准价格")]
        [ExcelColumnName("前期标准价格")]
        public decimal MbewVMSTP { get; set; }

        [Required(ErrorMessage = "前期移动平均价不能为空")]
        [ExcelColumn(Name = "前期移动平均价")]
        [ExcelColumnName("前期移动平均价")]
        public decimal MbewVMVER { get; set; }

        [ExcelColumn(Name = "前期间价格控制")]
        [ExcelColumnName("前期间价格控制")]
        public string MbewVMVPR { get; set; }

        [Required(ErrorMessage = "上期标准价格不能为空")]
        [ExcelColumn(Name = "上期标准价格")]
        [ExcelColumnName("上期标准价格")]
        public decimal MbewVPLPR { get; set; }

        [Required(ErrorMessage = "固定的上年计划价格不能为空")]
        [ExcelColumn(Name = "固定的上年计划价格")]
        [ExcelColumnName("固定的上年计划价格")]
        public decimal MbewVPLPX { get; set; }

        [ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string MbewVPRSV { get; set; }

        [Required(ErrorMessage = "前年的总库存 不能为空")]
        [ExcelColumn(Name = "前年的总库存 ")]
        [ExcelColumnName("前年的总库存 ")]
        public decimal MbewVVJLB { get; set; }

        [Required(ErrorMessage = "计价在 不能为空")]
        [ExcelColumn(Name = "计价在 ")]
        [ExcelColumnName("计价在 ")]
        public decimal MbewVVJSL { get; set; }

        [Required(ErrorMessage = "前期的总库存值不能为空")]
        [ExcelColumn(Name = "前期的总库存值")]
        [ExcelColumnName("前期的总库存值")]
        public decimal MbewVVMLB { get; set; }

        [Required(ErrorMessage = "计价在 不能为空")]
        [ExcelColumn(Name = "计价在 ")]
        [ExcelColumnName("计价在 ")]
        public decimal MbewVVSAL { get; set; }

        [ExcelColumn(Name = "最后实际盘点日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最后实际盘点日")]
        public DateTime? MbewWLINL { get; set; }

        [ExcelColumn(Name = "评估单位")]
        [ExcelColumnName("评估单位")]
        public string MbewXBEWM { get; set; }

        [ExcelColumn(Name = "LIFO/FIFO-相关")]
        [ExcelColumnName("LIFO/FIFO-相关")]
        public string MbewXLIFO { get; set; }

        [ExcelColumn(Name = "有效起始期 ", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效起始期 ")]
        public DateTime? MbewZKDAT { get; set; }

        [Required(ErrorMessage = "未来价格不能为空")]
        [ExcelColumn(Name = "未来价格")]
        [ExcelColumnName("未来价格")]
        public decimal MbewZKPRS { get; set; }

        [ExcelColumn(Name = "计划价格日期 1", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期 1")]
        public DateTime? MbewZPLD1 { get; set; }

        [ExcelColumn(Name = "计划价格日期 2", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期 2")]
        public DateTime? MbewZPLD2 { get; set; }

        [ExcelColumn(Name = "计划价格日期 3", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期 3")]
        public DateTime? MbewZPLD3 { get; set; }

        [Required(ErrorMessage = "计划价格 1不能为空")]
        [ExcelColumn(Name = "计划价格 1")]
        [ExcelColumnName("计划价格 1")]
        public decimal MbewZPLP1 { get; set; }

        [Required(ErrorMessage = "计划价格 2不能为空")]
        [ExcelColumn(Name = "计划价格 2")]
        [ExcelColumnName("计划价格 2")]
        public decimal MbewZPLP2 { get; set; }

        [Required(ErrorMessage = "计划价格 3不能为空")]
        [ExcelColumn(Name = "计划价格 3")]
        [ExcelColumnName("计划价格 3")]
        public decimal MbewZPLP3 { get; set; }

        [Required(ErrorMessage = "未来计划价格不能为空")]
        [ExcelColumn(Name = "未来计划价格")]
        [ExcelColumnName("未来计划价格")]
        public decimal MbewZPLPR { get; set; }

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
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

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
        [ExcelColumn(Name = "评估类 ")]
        public string MbewBKLASLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "评估范围")]
        public string MbewBWKEYLabel { get; set; }
    }
}