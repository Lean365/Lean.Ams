
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 物料评估
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 15:30:16)
    /// </summary>
    [SugarTable("mm_mbew")]
    public class Mbew
    {
        /// <summary>
        /// ID主键 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MbewSFID { get; set; }

        /// <summary>
        /// CC 库存盘点 
        /// </summary>
        public string MbewABCIW { get; set; }

        /// <summary>
        /// 贬值标识   
        /// </summary>
        public string MbewABWKZ { get; set; }

        /// <summary>
        /// 评估类  
        /// </summary>
        public string MbewBKLAS { get; set; }

        /// <summary>
        /// 评估范围 
        /// </summary>
        public string MbewBWKEY { get; set; }

        /// <summary>
        /// 价格单位 
        /// </summary>
        public decimal MbewBWPEI { get; set; }

        /// <summary>
        /// 商业价格 2 
        /// </summary>
        public decimal MbewBWPH1 { get; set; }

        /// <summary>
        /// 商业价格 1 
        /// </summary>
        public decimal MbewBWPRH { get; set; }

        /// <summary>
        /// 税价1 
        /// </summary>
        public decimal MbewBWPRS { get; set; }

        /// <summary>
        /// 税价2 
        /// </summary>
        public decimal MbewBWPS1 { get; set; }

        /// <summary>
        /// 评价毛利 
        /// </summary>
        public decimal MbewBWSPA { get; set; }

        /// <summary>
        /// 评估类型 
        /// </summary>
        public string MbewBWTAR { get; set; }

        /// <summary>
        /// 评估类别 
        /// </summary>
        public string MbewBWTTY { get; set; }

        /// <summary>
        /// 评估变式 
        /// </summary>
        public string MbewBWVA1 { get; set; }

        /// <summary>
        /// 评估变式 
        /// </summary>
        public string MbewBWVA2 { get; set; }

        /// <summary>
        /// 评估变式 
        /// </summary>
        public string MbewBWVA3 { get; set; }

        /// <summary>
        /// 用QS的成本估算 
        /// </summary>
        public string MbewEKALR { get; set; }

        /// <summary>
        /// VC:销售订单库存 
        /// </summary>
        public string MbewEKLAS { get; set; }

        /// <summary>
        /// 未来评估决策 
        /// </summary>
        public string MbewFBWST { get; set; }

        /// <summary>
        /// 固定的未来计划价格 
        /// </summary>
        public decimal MbewFPLPX { get; set; }

        /// <summary>
        /// 物料来源 
        /// </summary>
        public string MbewHKMAT { get; set; }

        /// <summary>
        /// 原始组  
        /// </summary>
        public string MbewHRKFT { get; set; }

        /// <summary>
        /// 当前成本估算 
        /// </summary>
        public string MbewKALKL { get; set; }

        /// <summary>
        /// 上期成本估计 
        /// </summary>
        public string MbewKALKV { get; set; }

        /// <summary>
        /// 未来成本估算 
        /// </summary>
        public string MbewKALKZ { get; set; }

        /// <summary>
        /// 产品成本核算号 
        /// </summary>
        public string MbewKALN1 { get; set; }

        /// <summary>
        /// 成本估算编号 
        /// </summary>
        public string MbewKALNR { get; set; }

        /// <summary>
        /// 一般费用代码  
        /// </summary>
        public string MbewKALSC { get; set; }

        /// <summary>
        /// 间接费分组  
        /// </summary>
        public string MbewKOSGR { get; set; }

        /// <summary>
        /// 盘点库存VO物料 
        /// </summary>
        public string MbewKZIWL { get; set; }

        /// <summary>
        /// 最近价格更改  
        /// </summary>
        public DateTime? MbewLAEPR { get; set; }

        /// <summary>
        /// 总库存  
        /// </summary>
        public decimal MbewLBKUM { get; set; }

        /// <summary>
        /// 当前的值决策  
        /// </summary>
        public string MbewLBWST { get; set; }

        /// <summary>
        /// 年  当前期间 
        /// </summary>
        public string MbewLFGJA { get; set; }

        /// <summary>
        /// 本期 
        /// </summary>
        public string MbewLFMON { get; set; }

        /// <summary>
        /// 当前计划价格 
        /// </summary>
        public decimal MbewLPLPR { get; set; }

        /// <summary>
        /// 固定的当前计划价格 
        /// </summary>
        public decimal MbewLPLPX { get; set; }

        /// <summary>
        /// 评估类型 
        /// </summary>
        public string MbewLVORM { get; set; }

        /// <summary>
        /// 集团 
        /// </summary>
        public string MbewMANDT { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string MbewMATNR { get; set; }

        /// <summary>
        /// MBEW 最后期间之前，期间的 MBEW 
        /// </summary>
        public string MbewMBRUE { get; set; }

        /// <summary>
        /// 价格确定 
        /// </summary>
        public string MbewMLAST { get; set; }

        /// <summary>
        /// ML 作业 
        /// </summary>
        public string MbewMLMAA { get; set; }

        /// <summary>
        /// 物料来源 
        /// </summary>
        public string MbewMTORG { get; set; }

        /// <summary>
        /// 物料用途  
        /// </summary>
        public string MbewMTUSE { get; set; }

        /// <summary>
        /// LIFO评估储备号  
        /// </summary>
        public string MbewMYPOL { get; set; }

        /// <summary>
        /// 预付库存 
        /// </summary>
        public string MbewOIPPINV { get; set; }

        /// <summary>
        /// VC: 供应商  
        /// </summary>
        public string MbewOKLAS { get; set; }

        /// <summary>
        /// 自制产品 
        /// </summary>
        public string MbewOWNPR { get; set; }

        /// <summary>
        /// 当前会计年度 
        /// </summary>
        public string MbewPDATL { get; set; }

        /// <summary>
        /// 上一会计年  
        /// </summary>
        public string MbewPDATV { get; set; }

        /// <summary>
        /// 来年会计年度 
        /// </summary>
        public string MbewPDATZ { get; set; }

        /// <summary>
        /// 价格单位 
        /// </summary>
        public decimal MbewPEINH { get; set; }

        /// <summary>
        /// 期间成本估算 
        /// </summary>
        public string MbewPPERL { get; set; }

        /// <summary>
        /// 上期成本估算 
        /// </summary>
        public string MbewPPERV { get; set; }

        /// <summary>
        /// 未来成本估算 
        /// </summary>
        public string MbewPPERZ { get; set; }

        /// <summary>
        /// 当前期间 
        /// </summary>
        public string MbewPPRDL { get; set; }

        /// <summary>
        /// 前一期间 
        /// </summary>
        public string MbewPPRDV { get; set; }

        /// <summary>
        /// 记帐期间 
        /// </summary>
        public string MbewPPRDZ { get; set; }

        /// <summary>
        /// 维护状态  
        /// </summary>
        public string MbewPSTAT { get; set; }

        /// <summary>
        /// 项目库存评估类 
        /// </summary>
        public string MbewQKLAS { get; set; }

        /// <summary>
        /// 总价值  
        /// </summary>
        public decimal MbewSALK3 { get; set; }

        /// <summary>
        /// 价值/MA价格 
        /// </summary>
        public decimal MbewSALKV { get; set; }

        /// <summary>
        /// 库存冻结 
        /// </summary>
        public string MbewSPERW { get; set; }

        /// <summary>
        /// 标准价格 
        /// </summary>
        public decimal MbewSTPRS { get; set; }

        /// <summary>
        /// 上期价格 
        /// </summary>
        public decimal MbewSTPRV { get; set; }

        /// <summary>
        /// 时戳 
        /// </summary>
        public decimal MbewTIMESTAMP { get; set; }

        /// <summary>
        /// 上年评估策略 
        /// </summary>
        public string MbewVBWST { get; set; }

        /// <summary>
        /// 移动价格 
        /// </summary>
        public decimal MbewVERPR { get; set; }

        /// <summary>
        /// 成本核算版本 
        /// </summary>
        public string MbewVERS1 { get; set; }

        /// <summary>
        /// 成本核算版本 
        /// </summary>
        public string MbewVERS2 { get; set; }

        /// <summary>
        /// 成本核算版本 
        /// </summary>
        public string MbewVERS3 { get; set; }

        /// <summary>
        /// 上年估价类  
        /// </summary>
        public string MbewVJBKL { get; set; }

        /// <summary>
        /// 商业价格 3 
        /// </summary>
        public decimal MbewVJBWH { get; set; }

        /// <summary>
        /// 税价3 
        /// </summary>
        public decimal MbewVJBWS { get; set; }

        /// <summary>
        /// 前年总库存值  
        /// </summary>
        public decimal MbewVJKUM { get; set; }

        /// <summary>
        /// 上年价格单位 
        /// </summary>
        public decimal MbewVJPEI { get; set; }

        /// <summary>
        /// 上年总值  
        /// </summary>
        public decimal MbewVJSAL { get; set; }

        /// <summary>
        /// 上年价值  
        /// </summary>
        public decimal MbewVJSAV { get; set; }

        /// <summary>
        /// 去年标准价格 
        /// </summary>
        public decimal MbewVJSTP { get; set; }

        /// <summary>
        /// 去年移动平均价 
        /// </summary>
        public decimal MbewVJVER { get; set; }

        /// <summary>
        /// 前一年价格控制 
        /// </summary>
        public string MbewVJVPR { get; set; }

        /// <summary>
        /// 总SP值  
        /// </summary>
        public decimal MbewVKSAL { get; set; }

        /// <summary>
        /// 上期的评价分类 
        /// </summary>
        public string MbewVMBKL { get; set; }

        /// <summary>
        /// 前期总库存  
        /// </summary>
        public decimal MbewVMKUM { get; set; }

        /// <summary>
        /// 上期间价格单位 
        /// </summary>
        public decimal MbewVMPEI { get; set; }

        /// <summary>
        /// 前期总值  
        /// </summary>
        public decimal MbewVMSAL { get; set; }

        /// <summary>
        /// 上期的价值  
        /// </summary>
        public decimal MbewVMSAV { get; set; }

        /// <summary>
        /// 前期标准价格 
        /// </summary>
        public decimal MbewVMSTP { get; set; }

        /// <summary>
        /// 前期移动平均价 
        /// </summary>
        public decimal MbewVMVER { get; set; }

        /// <summary>
        /// 前期间价格控制 
        /// </summary>
        public string MbewVMVPR { get; set; }

        /// <summary>
        /// 上期标准价格 
        /// </summary>
        public decimal MbewVPLPR { get; set; }

        /// <summary>
        /// 固定的上年计划价格 
        /// </summary>
        public decimal MbewVPLPX { get; set; }

        /// <summary>
        /// 价格控制 
        /// </summary>
        public string MbewVPRSV { get; set; }

        /// <summary>
        /// 前年的总库存  
        /// </summary>
        public decimal MbewVVJLB { get; set; }

        /// <summary>
        /// 计价在  
        /// </summary>
        public decimal MbewVVJSL { get; set; }

        /// <summary>
        /// 前期的总库存值 
        /// </summary>
        public decimal MbewVVMLB { get; set; }

        /// <summary>
        /// 计价在  
        /// </summary>
        public decimal MbewVVSAL { get; set; }

        /// <summary>
        /// 最后实际盘点日 
        /// </summary>
        public DateTime? MbewWLINL { get; set; }

        /// <summary>
        /// 评估单位 
        /// </summary>
        public string MbewXBEWM { get; set; }

        /// <summary>
        /// LIFO/FIFO-相关 
        /// </summary>
        public string MbewXLIFO { get; set; }

        /// <summary>
        /// 有效起始期  
        /// </summary>
        public DateTime? MbewZKDAT { get; set; }

        /// <summary>
        /// 未来价格 
        /// </summary>
        public decimal MbewZKPRS { get; set; }

        /// <summary>
        /// 计划价格日期 1 
        /// </summary>
        public DateTime? MbewZPLD1 { get; set; }

        /// <summary>
        /// 计划价格日期 2 
        /// </summary>
        public DateTime? MbewZPLD2 { get; set; }

        /// <summary>
        /// 计划价格日期 3 
        /// </summary>
        public DateTime? MbewZPLD3 { get; set; }

        /// <summary>
        /// 计划价格 1 
        /// </summary>
        public decimal MbewZPLP1 { get; set; }

        /// <summary>
        /// 计划价格 2 
        /// </summary>
        public decimal MbewZPLP2 { get; set; }

        /// <summary>
        /// 计划价格 3 
        /// </summary>
        public decimal MbewZPLP3 { get; set; }

        /// <summary>
        /// 未来计划价格 
        /// </summary>
        public decimal MbewZPLPR { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}