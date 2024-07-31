using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 公积金
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:02
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrFundsService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrFundsService : BaseService<RoutineEhrFunds>, IRoutineEhrFundsService
    {
        /// <summary>
        /// 查询公积金列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrFundsDto> GetList(RoutineEhrFundsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrFunds, RoutineEhrFundsDto>(parm);

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
            int count = Count(it => it. EfSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EfSfId"></param>
        /// <returns></returns>
        public RoutineEhrFunds GetInfo(long EfSfId)
        {
            var response = Queryable()
                .Where(x => x.EfSfId == EfSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加公积金
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrFunds AddRoutineEhrFunds(RoutineEhrFunds model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改公积金
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrFunds(RoutineEhrFunds model)
        {
            return Update(model, true, "修改公积金");
        }

        /// <summary>
        /// 导入公积金
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrFunds(List<RoutineEhrFunds> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EfSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.EfParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.EfEffectiveDate.IsEmpty(), "生效日不能为空")
                .SplitError(x => x.Item.EfWorkID.IsEmpty(), "工号不能为空")
                .SplitError(x => x.Item.EfFundNo.IsEmpty(), "账号不能为空")
                .SplitError(x => x.Item.EfFundBase.IsEmpty(), "基数不能为空")
                .SplitError(x => x.Item.EeExtract.IsEmpty(), "提取金额不能为空")
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
        /// 导出公积金
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrFundsDto> ExportList(RoutineEhrFundsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrFundsDto()
                {
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
        private static Expressionable<RoutineEhrFunds> QueryExp(RoutineEhrFundsQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrFunds>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEfEffectiveDate == null, it => it.EfEffectiveDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEfEffectiveDate == null, it => it.EfEffectiveDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEfEffectiveDate != null, it => it.EfEffectiveDate >= parm.BeginEfEffectiveDate);
            predicate = predicate.AndIF(parm.EndEfEffectiveDate != null, it => it.EfEffectiveDate <= parm.EndEfEffectiveDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EfWorkID), it => it.EfWorkID.Contains(parm.EfWorkID));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EfFundNo), it => it.EfFundNo.Contains(parm.EfFundNo));
            return predicate;
        }
    }
}