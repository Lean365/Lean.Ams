
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 从设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/23 8:52:11
    /// </summary>
    [SugarTable("pp_ec_slave")]
    public class PpEcSlave
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EsSFID { get; set; }

        /// <summary>
        /// 输入日 
        /// </summary>
        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 设变No. 
        /// </summary>
        public string EsEcNo { get; set; }

        /// <summary>
        /// 机种 
        /// </summary>
        public string EsModel { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string EsItem { get; set; }

        /// <summary>
        /// 子物料 
        /// </summary>
        public string EsSubItem { get; set; }

        /// <summary>
        /// 旧物料 
        /// </summary>
        public string EsOldItem { get; set; }

        /// <summary>
        /// 旧文本 
        /// </summary>
        public string EsOldItemText { get; set; }

        /// <summary>
        /// 用量 
        /// </summary>
        public decimal EsOldUsageQty { get; set; }

        /// <summary>
        /// 位置 
        /// </summary>
        public string EsOldSetLoc { get; set; }

        /// <summary>
        /// 新物料 
        /// </summary>
        public string EsNewItem { get; set; }

        /// <summary>
        /// 新文本 
        /// </summary>
        public string EsNewItemText { get; set; }

        /// <summary>
        /// 用量 
        /// </summary>
        public decimal EsNewUsageQty { get; set; }

        /// <summary>
        /// 位置 
        /// </summary>
        public string EsNewSetLoc { get; set; }

        /// <summary>
        /// bom番号 
        /// </summary>
        public string EsBomNo { get; set; }

        /// <summary>
        /// 互换 
        /// </summary>
        public string EsChange { get; set; }

        /// <summary>
        /// 区分 
        /// </summary>
        public string Eslocal { get; set; }

        /// <summary>
        /// 指示 
        /// </summary>
        public string Esnote { get; set; }

        /// <summary>
        /// 旧品处理 
        /// </summary>
        public string EsOldProcess { get; set; }

        /// <summary>
        /// bom日期 
        /// </summary>
        public DateTime? EsBomDate { get; set; }

        /// <summary>
        /// 实施部门 
        /// </summary>
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 采购类型 
        /// </summary>
        public string EsPurType { get; set; }

        /// <summary>
        /// 仓库 
        /// </summary>
        public string EsSloc { get; set; }

        /// <summary>
        /// 检验否 
        /// </summary>
        public string EsInsmk { get; set; }

        /// <summary>
        /// 工厂状态 
        /// </summary>
        public string EsMstae { get; set; }

        /// <summary>
        /// SOP 
        /// </summary>
        public string EsSopStae { get; set; }

        /// <summary>
        /// 旧品库存 
        /// </summary>
        public decimal EsOldCurrStock { get; set; }

        /// <summary>
        /// 新品库存 
        /// </summary>
        public decimal EsNewCurrStock { get; set; }

        /// <summary>
        /// 采购登入日期 
        /// </summary>
        public DateTime? EsPurEntryDate { get; set; }

        /// <summary>
        /// 供应商 
        /// </summary>
        public string EsSupplier { get; set; }

        /// <summary>
        /// 采购PO 
        /// </summary>
        public string EsPurOrder { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string EsPurNote { get; set; }

        /// <summary>
        /// 采购新增 
        /// </summary>
        public string EsPurCreator { get; set; }

        /// <summary>
        /// 采购新增日期 
        /// </summary>
        public DateTime? EsPurCreateTime { get; set; }

        /// <summary>
        /// 采购修改 
        /// </summary>
        public string EsPurModifier { get; set; }

        /// <summary>
        /// 采购修改日期 
        /// </summary>
        public DateTime? EsPurModifyTime { get; set; }

        /// <summary>
        /// 生管登入日期 
        /// </summary>
        public DateTime? EsPmcEntryDate { get; set; }

        /// <summary>
        /// 预投入批次 
        /// </summary>
        public string EsPmcLot { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string EsPmcMemo { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string EsPmcNote { get; set; }

        /// <summary>
        /// 生管新增 
        /// </summary>
        public string EsPmcCreator { get; set; }

        /// <summary>
        /// 生管新增日期 
        /// </summary>
        public DateTime? EsPmcCreateTime { get; set; }

        /// <summary>
        /// 生管修改 
        /// </summary>
        public string EsPmcModifier { get; set; }

        /// <summary>
        /// 生管修改日期 
        /// </summary>
        public DateTime? EsPmcModifyTime { get; set; }

        /// <summary>
        /// IQC登入日期 
        /// </summary>
        public DateTime? EsIqcEntryDate { get; set; }

        /// <summary>
        /// 检验订单 
        /// </summary>
        public string EsIqcOrder { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string EsIqcNote { get; set; }

        /// <summary>
        /// IQC新增 
        /// </summary>
        public string EsIqcCreator { get; set; }

        /// <summary>
        /// IQC新增日期 
        /// </summary>
        public DateTime? EsIqcCreateTime { get; set; }

        /// <summary>
        /// IQC修改 
        /// </summary>
        public string EsIqcModifier { get; set; }

        /// <summary>
        /// IQC修改日期 
        /// </summary>
        public DateTime? EsIqcModifyTime { get; set; }

        /// <summary>
        /// 部管登入日期 
        /// </summary>
        public DateTime? EsMmEntryDate { get; set; }

        /// <summary>
        /// 领用批次 
        /// </summary>
        public string EsMmLot { get; set; }

        /// <summary>
        /// 工单 
        /// </summary>
        public string EsMmMocNo { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string EsMmNote { get; set; }

        /// <summary>
        /// EsMmCreator 
        /// </summary>
        public string EsMmCreator { get; set; }

        /// <summary>
        /// EsMmCreateTime 
        /// </summary>
        public DateTime? EsMmCreateTime { get; set; }

        /// <summary>
        /// EsMmModifier 
        /// </summary>
        public string EsMmModifier { get; set; }

        /// <summary>
        /// EsMmModifyTime 
        /// </summary>
        public DateTime? EsMmModifyTime { get; set; }

        /// <summary>
        /// 制一登入日期 
        /// </summary>
        public DateTime? EsPpEntryDate { get; set; }

        /// <summary>
        /// 班组 
        /// </summary>
        public string EsPpLine { get; set; }

        /// <summary>
        /// 生产批次 
        /// </summary>
        public string EsPpLot { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string EsPpNote { get; set; }

        /// <summary>
        /// EsPpCreator 
        /// </summary>
        public string EsPpCreator { get; set; }

        /// <summary>
        /// EsPpCreateTime 
        /// </summary>
        public DateTime? EsPpCreateTime { get; set; }

        /// <summary>
        /// EsPpModifier 
        /// </summary>
        public string EsPpModifier { get; set; }

        /// <summary>
        /// EsPpModifyTime 
        /// </summary>
        public DateTime? EsPpModifyTime { get; set; }

        /// <summary>
        /// 制二登入日期 
        /// </summary>
        public DateTime? EsPcbaEntryDate { get; set; }

        /// <summary>
        /// Pcba班组 
        /// </summary>
        public string EsPcbaLine { get; set; }

        /// <summary>
        /// Pcba批次 
        /// </summary>
        public string EsPcbaLot { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string EsPcbaNote { get; set; }

        /// <summary>
        /// EsPcbaCreator 
        /// </summary>
        public string EsPcbaCreator { get; set; }

        /// <summary>
        /// EsPcbaCreateTime 
        /// </summary>
        public DateTime? EsPcbaCreateTime { get; set; }

        /// <summary>
        /// EsPcbaModifier 
        /// </summary>
        public string EsPcbaModifier { get; set; }

        /// <summary>
        /// EsPcbaModifyTime 
        /// </summary>
        public DateTime? EsPcbaModifyTime { get; set; }

        /// <summary>
        /// QA确认日期 
        /// </summary>
        public DateTime? EsQaEntryDate { get; set; }

        /// <summary>
        /// 检验批次 
        /// </summary>
        public string EsQaLot { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string EsQaNote { get; set; }

        /// <summary>
        /// EsQaCreator 
        /// </summary>
        public string EsQaCreator { get; set; }

        /// <summary>
        /// EsQaCreateTime 
        /// </summary>
        public DateTime? EsQaCreateTime { get; set; }

        /// <summary>
        /// EsQaModifier 
        /// </summary>
        public string EsQaModifier { get; set; }

        /// <summary>
        /// EsQaModifyTime 
        /// </summary>
        public DateTime? EsQaModifyTime { get; set; }

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