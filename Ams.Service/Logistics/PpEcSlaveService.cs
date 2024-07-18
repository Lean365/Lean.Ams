using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 从设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:37
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveService : BaseService<PpEcSlave>, IPpEcSlaveService
    {
        /// <summary>
        /// 查询从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlave, PpEcSlaveDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString)
        {
            int count = Count(it => it. EsSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EsSFID"></param>
        /// <returns></returns>
        public PpEcSlave GetInfo(long EsSFID)
        {
            var response = Queryable()
                .Where(x => x.EsSFID == EsSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlave AddPpEcSlave(PpEcSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改从设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlave(PpEcSlave model)
        {
            return Update(model, true, "修改从设变");
        }

        /// <summary>
        /// 导入从设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlave(List<PpEcSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EsSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.EsParentSfid.IsEmpty(), "EsParentSfid不能为空")
                .SplitError(x => x.Item.EsEntryDate.IsEmpty(), "输入日不能为空")
                .SplitError(x => x.Item.EsEcNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EsModel.IsEmpty(), "机种不能为空")
                .SplitError(x => x.Item.EsItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.EsOldUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EsNewUsageQty.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.EsBomDate.IsEmpty(), "bom日期不能为空")
                .SplitError(x => x.Item.EmEcImpDept.IsEmpty(), "实施部门不能为空")
                .SplitError(x => x.Item.EsPurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.EsSloc.IsEmpty(), "仓库不能为空")
                .SplitError(x => x.Item.EsSopStae.IsEmpty(), "SOP不能为空")
                .SplitError(x => x.Item.EsOldCurrStock.IsEmpty(), "旧品库存不能为空")
                .SplitError(x => x.Item.EsNewCurrStock.IsEmpty(), "新品库存不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 导出从设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> ExportList(PpEcSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveDto()
                {
                    EsPurTypeLabel = it.EsPurType.GetConfigValue<SysDictData>("sys_pur_type"),
                    EsInsmkLabel = it.EsInsmk.GetConfigValue<SysDictData>("sys_normal_whether"),
                    EsSopStaeLabel = it.EsSopStae.GetConfigValue<SysDictData>("sys_sop_yn"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcSlave> QueryExp(PpEcSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlave>();

            return predicate;
        }
    }
}