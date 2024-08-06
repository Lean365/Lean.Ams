using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// Pur设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 14:43:11
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlavePurService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlavePurService : BaseService<PpEcSlavePur>, IPpEcSlavePurService
    {
        /// <summary>
        /// 查询Pur设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePurDto> GetList(PpEcSlavePurQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("PurEnteredDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlavePur, PpEcSlavePurDto>(parm);

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
            int count = Count(it => it. PurSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PurSfId"></param>
        /// <returns></returns>
        public PpEcSlavePur GetInfo(long PurSfId)
        {
            var response = Queryable()
                .Where(x => x.PurSfId == PurSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加Pur设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlavePur AddPpEcSlavePur(PpEcSlavePur model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改Pur设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlavePur(PpEcSlavePur model)
        {
            return Update(model, true, "修改Pur设变");
        }

        /// <summary>
        /// 导入Pur设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlavePur(List<PpEcSlavePur> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PurParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.PurEcNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.PurModel.IsEmpty(), "机种不能为空")
                .SplitError(x => x.Item.PurNewCurrStock.IsEmpty(), "新品库存不能为空")
                .SplitError(x => x.Item.PurType.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.PurGroup.IsEmpty(), "采购组不能为空")
                .SplitError(x => x.Item.PurImplStated.IsEmpty(), "实施标记不能为空")
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
        /// 导出Pur设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlavePurDto> ExportList(PpEcSlavePurQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlavePurDto()
                {
                    PurTypeLabel = it.PurType.GetConfigValue<SysDictData>("sys_pur_type"),
                    PurGroupLabel = it.PurGroup.GetConfigValue<SysDictData>("sys_pur_group"),
                    PurInsmkLabel = it.PurInsmk.GetConfigValue<SysDictData>("sys_flag_list"),
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
        private static Expressionable<PpEcSlavePur> QueryExp(PpEcSlavePurQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlavePur>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PurEcNo), it => it.PurEcNo.Contains(parm.PurEcNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PurModel), it => it.PurModel.Contains(parm.PurModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PurType), it => it.PurType == parm.PurType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PurGroup), it => it.PurGroup == parm.PurGroup);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PurInsmk), it => it.PurInsmk == parm.PurInsmk);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPurEnteredDate == null, it => it.PurEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPurEnteredDate == null, it => it.PurEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPurEnteredDate != null, it => it.PurEnteredDate >= parm.BeginPurEnteredDate);
            predicate = predicate.AndIF(parm.EndPurEnteredDate != null, it => it.PurEnteredDate <= parm.EndPurEnteredDate);
            return predicate;
        }
    }
}