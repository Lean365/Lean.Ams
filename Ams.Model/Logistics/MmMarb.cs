namespace Ams.Model.Logistics
{
    /// <summary>
    /// 物料信息
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 14:13:37
    /// </summary>
    [SugarTable("mm_marb", "物料信息")]
    public class MmMarb : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Werks", ColumnDescription = "工厂 ", Length = 8)]
        public string Werks { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        [SugarColumn(ColumnName = "Matnr", ColumnDescription = "物料号 ", Length = 36)]
        public string Matnr { get; set; }

        /// <summary>
        /// 行业领域
        /// </summary>
        [SugarColumn(ColumnName = "Mbrsh", ColumnDescription = "行业领域 ", Length = 2)]
        public string Mbrsh { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Mtart", ColumnDescription = "物料类型 ", Length = 8)]
        public string Mtart { get; set; }

        /// <summary>
        /// 物料描述（短文本）
        /// </summary>
        [SugarColumn(ColumnName = "Maktx", ColumnDescription = "物料描述（短文本） ", Length = 40)]
        public string Maktx { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Meins", ColumnDescription = "基本计量单位 ", Length = 6)]
        public string Meins { get; set; }

        /// <summary>
        /// 产品层次
        /// </summary>
        [SugarColumn(ColumnName = "Prdha", ColumnDescription = "产品层次 ", Length = 36)]
        public string Prdha { get; set; }

        /// <summary>
        /// 物料组
        /// </summary>
        [SugarColumn(ColumnName = "Matkl", ColumnDescription = "物料组 ", Length = 18)]
        public string Matkl { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Ekgrp", ColumnDescription = "采购组 ", Length = 6)]
        public string Ekgrp { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Beskz", ColumnDescription = "采购类型 ", Length = 2)]
        public string Beskz { get; set; }

        /// <summary>
        /// 特殊采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Sobsl", ColumnDescription = "特殊采购类型 ", Length = 4)]
        public string Sobsl { get; set; }

        /// <summary>
        /// 标识：散装物料
        /// </summary>
        [SugarColumn(ColumnName = "Schgt", ColumnDescription = "标识：散装物料 ", Length = 2)]
        public string Schgt { get; set; }

        /// <summary>
        /// 最小批量
        /// </summary>
        [SugarColumn(ColumnName = "Bstmi", ColumnDescription = "最小批量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bstmi { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Bstme", ColumnDescription = "基本计量单位 ", Length = 6)]
        public string Bstme { get; set; }

        /// <summary>
        /// 采购订单数量的舍入值
        /// </summary>
        [SugarColumn(ColumnName = "Bstrf", ColumnDescription = "采购订单数量的舍入值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bstrf { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Kzwsm", ColumnDescription = "基本计量单位 ", Length = 6)]
        public string Kzwsm { get; set; }

        /// <summary>
        /// 计划的天数内交货
        /// </summary>
        [SugarColumn(ColumnName = "Plifz", ColumnDescription = "计划的天数内交货 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Plifz { get; set; }

        /// <summary>
        /// 厂内生产时间
        /// </summary>
        [SugarColumn(ColumnName = "Dzeit", ColumnDescription = "厂内生产时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Dzeit { get; set; }

        /// <summary>
        /// 过帐到检验库存
        /// </summary>
        [SugarColumn(ColumnName = "Insmk", ColumnDescription = "过帐到检验库存 ", Length = 2)]
        public string Insmk { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Prctr", ColumnDescription = "利润中心 ", Length = 20)]
        public string Prctr { get; set; }

        /// <summary>
        /// 差异码
        /// </summary>
        [SugarColumn(ColumnName = "Awsls", ColumnDescription = "差异码 ", Length = 12)]
        public string Awsls { get; set; }

        /// <summary>
        /// 批次管理需求的标识
        /// </summary>
        [SugarColumn(ColumnName = "Xchpf", ColumnDescription = "批次管理需求的标识 ", Length = 2)]
        public string Xchpf { get; set; }

        /// <summary>
        /// 制造商零件编号
        /// </summary>
        [SugarColumn(ColumnName = "Mfrpn", ColumnDescription = "制造商零件编号 ", Length = 80)]
        public string Mfrpn { get; set; }

        /// <summary>
        /// 制造商编号
        /// </summary>
        [SugarColumn(ColumnName = "Mfrnr", ColumnDescription = "制造商编号 ", Length = 20)]
        public string Mfrnr { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "Bklas", ColumnDescription = "评估类 ", Length = 4)]
        public string Bklas { get; set; }

        /// <summary>
        /// 移动平均价格/周期单价
        /// </summary>
        [SugarColumn(ColumnName = "Verpr", ColumnDescription = "移动平均价格/周期单价 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Verpr { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Waers", ColumnDescription = "币种 ", Length = 3)]
        public string Waers { get; set; }

        /// <summary>
        /// 价格控制指示符
        /// </summary>
        [SugarColumn(ColumnName = "Vprsv", ColumnDescription = "价格控制指示符 ", Length = 1)]
        public string Vprsv { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Peinh", ColumnDescription = "价格单位 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Peinh { get; set; }

        /// <summary>
        /// 发货库存地点
        /// </summary>
        [SugarColumn(ColumnName = "Lgpro", ColumnDescription = "发货库存地点 ", Length = 8)]
        public string Lgpro { get; set; }

        /// <summary>
        /// 外部采购的缺省仓储位置
        /// </summary>
        [SugarColumn(ColumnName = "Lgfsb", ColumnDescription = "外部采购的缺省仓储位置 ", Length = 8)]
        public string Lgfsb { get; set; }

        /// <summary>
        /// 库存仓位
        /// </summary>
        [SugarColumn(ColumnName = "Lgpbe", ColumnDescription = "库存仓位 ", Length = 40)]
        public string Lgpbe { get; set; }

        /// <summary>
        /// 总计已估计库存
        /// </summary>
        [SugarColumn(ColumnName = "Lbkum", ColumnDescription = "总计已估计库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Lbkum { get; set; }

        /// <summary>
        /// 在工厂级标记要删除的物料
        /// </summary>
        [SugarColumn(ColumnName = "Lvorm", ColumnDescription = "在工厂级标记要删除的物料 ", Length = 2)]
        public string Lvorm { get; set; }
    }
}