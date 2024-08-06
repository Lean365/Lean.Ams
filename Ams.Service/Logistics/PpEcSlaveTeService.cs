using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// Te设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:03
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveTeService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveTeService : BaseService<PpEcSlaveTe>, IPpEcSlaveTeService
    {
        /// <summary>
        /// 查询Te设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveTeDto> GetList(PpEcSlaveTeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlaveTe, PpEcSlaveTeDto>(parm);

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
            int count = Count(it => it. TeSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="TeSfId"></param>
        /// <returns></returns>
        public PpEcSlaveTe GetInfo(long TeSfId)
        {
            var response = Queryable()
                .Where(x => x.TeSfId == TeSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加Te设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlaveTe AddPpEcSlaveTe(PpEcSlaveTe model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改Te设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlaveTe(PpEcSlaveTe model)
        {
            return Update(model, true, "修改Te设变");
        }

        /// <summary>
        /// 导入Te设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlaveTe(List<PpEcSlaveTe> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.TePurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.TeSloc.IsEmpty(), "仓库不能为空")
                .SplitError(x => x.Item.TeSopStated.IsEmpty(), "SOP不能为空")
                .SplitError(x => x.Item.TeImplStated.IsEmpty(), "实施标记不能为空")
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
        /// 导出Te设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveTeDto> ExportList(PpEcSlaveTeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveTeDto()
                {
                    TePurTypeLabel = it.TePurType.GetConfigValue<SysDictData>("sys_pur_type"),
                    TeSlocLabel = it.TeSloc.GetConfigValue<SysDictData>("sys_sloc_list"),
                    TeInsmkLabel = it.TeInsmk.GetConfigValue<SysDictData>("sys_flag_list"),
                    TePlntStatedLabel = it.TePlntStated.GetConfigValue<SysDictData>("sys_eol_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcSlaveTe> QueryExp(PpEcSlaveTeQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlaveTe>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TeEcNo), it => it.TeEcNo.Contains(parm.TeEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TeModel), it => it.TeModel.Contains(parm.TeModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TeItem), it => it.TeItem.Contains(parm.TeItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TePurType), it => it.TePurType == parm.TePurType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TeSloc), it => it.TeSloc == parm.TeSloc);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TeInsmk), it => it.TeInsmk == parm.TeInsmk);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TePlntStated), it => it.TePlntStated == parm.TePlntStated);
            predicate = predicate.AndIF(parm.TeSopStated != null, it => it.TeSopStated == parm.TeSopStated);
            return predicate;
        }
    }
}