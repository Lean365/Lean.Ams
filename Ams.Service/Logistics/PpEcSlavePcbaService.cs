using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// Pcba设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:40:40
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlavePcbaService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlavePcbaService : BaseService<PpEcSlavePcba>, IPpEcSlavePcbaService
    {
        /// <summary>
        /// 查询Pcba设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePcbaDto> GetList(PpEcSlavePcbaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("PcbaEnteredDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlavePcba, PpEcSlavePcbaDto>(parm);

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
            int count = Count(it => it. PcbaSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PcbaSfId"></param>
        /// <returns></returns>
        public PpEcSlavePcba GetInfo(long PcbaSfId)
        {
            var response = Queryable()
                .Where(x => x.PcbaSfId == PcbaSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加Pcba设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlavePcba AddPpEcSlavePcba(PpEcSlavePcba model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改Pcba设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlavePcba(PpEcSlavePcba model)
        {
            return Update(model, true, "修改Pcba设变");
        }

        /// <summary>
        /// 导入Pcba设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlavePcba(List<PpEcSlavePcba> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PcbaImplStated.IsEmpty(), "实施标记不能为空")
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
        /// 导出Pcba设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePcbaDto> ExportList(PpEcSlavePcbaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlavePcbaDto()
                {
                    PcbaImplStatedLabel = it.PcbaImplStated.GetConfigValue<SysDictData>("sys_flag_list"),
                    PcbaLineLabel = it.PcbaLine.GetConfigValue<SysDictData>("sql_line_list"),
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
        private static Expressionable<PpEcSlavePcba> QueryExp(PpEcSlavePcbaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlavePcba>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PcbaEcNo), it => it.PcbaEcNo.Contains(parm.PcbaEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PcbaModel), it => it.PcbaModel.Contains(parm.PcbaModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PcbaItem), it => it.PcbaItem.Contains(parm.PcbaItem));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPcbaEnteredDate == null, it => it.PcbaEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPcbaEnteredDate == null, it => it.PcbaEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPcbaEnteredDate != null, it => it.PcbaEnteredDate >= parm.BeginPcbaEnteredDate);
            predicate = predicate.AndIF(parm.EndPcbaEnteredDate != null, it => it.PcbaEnteredDate <= parm.EndPcbaEnteredDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PcbaLine), it => it.PcbaLine == parm.PcbaLine);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PcbaPutLot), it => it.PcbaPutLot.Contains(parm.PcbaPutLot));
            return predicate;
        }
    }
}