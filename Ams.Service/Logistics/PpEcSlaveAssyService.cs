using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 组立
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:43:00
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveAssyService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveAssyService : BaseService<PpEcSlaveAssy>, IPpEcSlaveAssyService
    {
        /// <summary>
        /// 查询组立列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveAssyDto> GetList(PpEcSlaveAssyQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("AssyEnteredDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlaveAssy, PpEcSlaveAssyDto>(parm);

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
            int count = Count(it => it. AssySfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="AssySfId"></param>
        /// <returns></returns>
        public PpEcSlaveAssy GetInfo(long AssySfId)
        {
            var response = Queryable()
                .Where(x => x.AssySfId == AssySfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加组立
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlaveAssy AddPpEcSlaveAssy(PpEcSlaveAssy model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改组立
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlaveAssy(PpEcSlaveAssy model)
        {
            return Update(model, true, "修改组立");
        }

        /// <summary>
        /// 导入组立
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlaveAssy(List<PpEcSlaveAssy> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
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
        /// 导出组立
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveAssyDto> ExportList(PpEcSlaveAssyQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveAssyDto()
                {
                    AssyImplStatedLabel = it.AssyImplStated.GetConfigValue<SysDictData>("sys_flag_list"),
                    AssyLineLabel = it.AssyLine.GetConfigValue<SysDictData>("sql_line_list"),
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
        private static Expressionable<PpEcSlaveAssy> QueryExp(PpEcSlaveAssyQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlaveAssy>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.AssyEcNo), it => it.AssyEcNo.Contains(parm.AssyEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.AssyModel), it => it.AssyModel.Contains(parm.AssyModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.AssyItem), it => it.AssyItem.Contains(parm.AssyItem));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginAssyEnteredDate == null, it => it.AssyEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginAssyEnteredDate == null, it => it.AssyEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginAssyEnteredDate != null, it => it.AssyEnteredDate >= parm.BeginAssyEnteredDate);
            predicate = predicate.AndIF(parm.EndAssyEnteredDate != null, it => it.AssyEnteredDate <= parm.EndAssyEnteredDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.AssyLine), it => it.AssyLine == parm.AssyLine);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.AssyPutLot), it => it.AssyPutLot.Contains(parm.AssyPutLot));
            return predicate;
        }
    }
}