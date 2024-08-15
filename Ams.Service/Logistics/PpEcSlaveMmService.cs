using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// Mm设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:14
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveMmService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveMmService : BaseService<PpEcSlaveMm>, IPpEcSlaveMmService
    {
        /// <summary>
        /// 查询Mm设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveMmDto> GetList(PpEcSlaveMmQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("MmEnteredDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlaveMm, PpEcSlaveMmDto>(parm);

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
            int count = Count(it => it. MmSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MmSfId"></param>
        /// <returns></returns>
        public PpEcSlaveMm GetInfo(long MmSfId)
        {
            var response = Queryable()
                .Where(x => x.MmSfId == MmSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加Mm设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlaveMm AddPpEcSlaveMm(PpEcSlaveMm model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改Mm设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlaveMm(PpEcSlaveMm model)
        {
            return Update(model, true, "修改Mm设变");
        }

        /// <summary>
        /// 导入Mm设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlaveMm(List<PpEcSlaveMm> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MmImplStated.IsEmpty(), "实施标记不能为空")
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
        /// 导出Mm设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveMmDto> ExportList(PpEcSlaveMmQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveMmDto()
                {
                    MmImplStatedLabel = it.MmImplStated.GetConfigValue<SysDictData>("sys_flag_list"),
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
        private static Expressionable<PpEcSlaveMm> QueryExp(PpEcSlaveMmQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlaveMm>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmEcNo), it => it.MmEcNo.Contains(parm.MmEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmModel), it => it.MmModel.Contains(parm.MmModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmItem), it => it.MmItem.Contains(parm.MmItem));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMmEnteredDate == null, it => it.MmEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMmEnteredDate == null, it => it.MmEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMmEnteredDate != null, it => it.MmEnteredDate >= parm.BeginMmEnteredDate);
            predicate = predicate.AndIF(parm.EndMmEnteredDate != null, it => it.MmEnteredDate <= parm.EndMmEnteredDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmLot), it => it.MmLot.Contains(parm.MmLot));
            return predicate;
        }
    }
}