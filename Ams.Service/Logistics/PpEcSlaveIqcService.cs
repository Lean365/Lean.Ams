using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// Iqc设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:59
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveIqcService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveIqcService : BaseService<PpEcSlaveIqc>, IPpEcSlaveIqcService
    {
        /// <summary>
        /// 查询Iqc设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveIqcDto> GetList(PpEcSlaveIqcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("IqcEnteredDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlaveIqc, PpEcSlaveIqcDto>(parm);

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
            int count = Count(it => it. IqcSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="IqcSfId"></param>
        /// <returns></returns>
        public PpEcSlaveIqc GetInfo(long IqcSfId)
        {
            var response = Queryable()
                .Where(x => x.IqcSfId == IqcSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加Iqc设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlaveIqc AddPpEcSlaveIqc(PpEcSlaveIqc model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改Iqc设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlaveIqc(PpEcSlaveIqc model)
        {
            return Update(model, true, "修改Iqc设变");
        }

        /// <summary>
        /// 导入Iqc设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlaveIqc(List<PpEcSlaveIqc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.IqcImplStated.IsEmpty(), "实施标记不能为空")
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
        /// 导出Iqc设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveIqcDto> ExportList(PpEcSlaveIqcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveIqcDto()
                {
                    IqcPurTypeLabel = it.IqcPurType.GetConfigValue<SysDictData>("sys_pur_type"),
                    IqcPurGroupLabel = it.IqcPurGroup.GetConfigValue<SysDictData>("sys_pur_group"),
                    IqcInsmkLabel = it.IqcInsmk.GetConfigValue<SysDictData>("sys_flag_list"),
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
        private static Expressionable<PpEcSlaveIqc> QueryExp(PpEcSlaveIqcQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlaveIqc>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IqcEcNo), it => it.IqcEcNo.Contains(parm.IqcEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IqcModel), it => it.IqcModel.Contains(parm.IqcModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IqcPurType), it => it.IqcPurType == parm.IqcPurType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IqcPurGroup), it => it.IqcPurGroup == parm.IqcPurGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IqcInsmk), it => it.IqcInsmk == parm.IqcInsmk);
            predicate = predicate.AndIF(parm.IqcImplStated != null, it => it.IqcImplStated == parm.IqcImplStated);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginIqcEnteredDate == null, it => it.IqcEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginIqcEnteredDate == null, it => it.IqcEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginIqcEnteredDate != null, it => it.IqcEnteredDate >= parm.BeginIqcEnteredDate);
            predicate = predicate.AndIF(parm.EndIqcEnteredDate != null, it => it.IqcEnteredDate <= parm.EndIqcEnteredDate);
            return predicate;
        }
    }
}