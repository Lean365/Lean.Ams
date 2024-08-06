using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// Pe设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:48
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlavePeService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlavePeService : BaseService<PpEcSlavePe>, IPpEcSlavePeService
    {
        /// <summary>
        /// 查询Pe设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePeDto> GetList(PpEcSlavePeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("PeEnteredDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlavePe, PpEcSlavePeDto>(parm);

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
            int count = Count(it => it. PeSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PeSfId"></param>
        /// <returns></returns>
        public PpEcSlavePe GetInfo(long PeSfId)
        {
            var response = Queryable()
                .Where(x => x.PeSfId == PeSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加Pe设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlavePe AddPpEcSlavePe(PpEcSlavePe model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改Pe设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlavePe(PpEcSlavePe model)
        {
            return Update(model, true, "修改Pe设变");
        }

        /// <summary>
        /// 导入Pe设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlavePe(List<PpEcSlavePe> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PeSopStated.IsEmpty(), "SOP不能为空")
                .SplitError(x => x.Item.PeImplStated.IsEmpty(), "实施标记不能为空")
                .SplitError(x => x.Item.PeDeptSop.IsEmpty(), "SOP部门不能为空")
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
        /// 导出Pe设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePeDto> ExportList(PpEcSlavePeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlavePeDto()
                {
                    PeSopStatedLabel = it.PeSopStated.GetConfigValue<SysDictData>("sys_flag_list"),
                    PeDeptSopLabel = it.PeDeptSop.GetConfigValue<SysDictData>("sql_dept_list"),
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
        private static Expressionable<PpEcSlavePe> QueryExp(PpEcSlavePeQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlavePe>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PeEcNo), it => it.PeEcNo.Contains(parm.PeEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PeModel), it => it.PeModel.Contains(parm.PeModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PeItem), it => it.PeItem.Contains(parm.PeItem));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPeEnteredDate == null, it => it.PeEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPeEnteredDate == null, it => it.PeEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPeEnteredDate != null, it => it.PeEnteredDate >= parm.BeginPeEnteredDate);
            predicate = predicate.AndIF(parm.EndPeEnteredDate != null, it => it.PeEnteredDate <= parm.EndPeEnteredDate);
            return predicate;
        }
    }
}