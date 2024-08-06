using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 品管
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:42:29
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveFqcService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveFqcService : BaseService<PpEcSlaveFqc>, IPpEcSlaveFqcService
    {
        /// <summary>
        /// 查询品管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveFqcDto> GetList(PpEcSlaveFqcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("FqcEnteredDate asc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlaveFqc, PpEcSlaveFqcDto>(parm);

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
            int count = Count(it => it. FqcSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FqcSfId"></param>
        /// <returns></returns>
        public PpEcSlaveFqc GetInfo(long FqcSfId)
        {
            var response = Queryable()
                .Where(x => x.FqcSfId == FqcSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加品管
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlaveFqc AddPpEcSlaveFqc(PpEcSlaveFqc model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改品管
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlaveFqc(PpEcSlaveFqc model)
        {
            return Update(model, true, "修改品管");
        }

        /// <summary>
        /// 导入品管
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlaveFqc(List<PpEcSlaveFqc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FqcImplStated.IsEmpty(), "实施标记不能为空")
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
        /// 导出品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveFqcDto> ExportList(PpEcSlaveFqcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveFqcDto()
                {
                    FqcImplStatedLabel = it.FqcImplStated.GetConfigValue<SysDictData>("sys_flag_list"),
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
        private static Expressionable<PpEcSlaveFqc> QueryExp(PpEcSlaveFqcQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlaveFqc>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FqcEcNo), it => it.FqcEcNo.Contains(parm.FqcEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FqcModel), it => it.FqcModel.Contains(parm.FqcModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FqcItem), it => it.FqcItem.Contains(parm.FqcItem));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFqcEnteredDate == null, it => it.FqcEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFqcEnteredDate == null, it => it.FqcEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFqcEnteredDate != null, it => it.FqcEnteredDate >= parm.BeginFqcEnteredDate);
            predicate = predicate.AndIF(parm.EndFqcEnteredDate != null, it => it.FqcEnteredDate <= parm.EndFqcEnteredDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FqcImplLot), it => it.FqcImplLot.Contains(parm.FqcImplLot));
            return predicate;
        }
    }
}