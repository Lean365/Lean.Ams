//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 工资率
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:26:01
    /// </summary>
    [AppService(ServiceType = typeof(IFicoWageRatesService), ServiceLifetime = LifeTime.Transient)]
    public class FicoWageRatesService : BaseService<FicoWageRates>, IFicoWageRatesService
    {
        /// <summary>
        /// 查询工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoWageRatesDto> GetList(FicoWageRatesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mr002 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoWageRates, FicoWageRatesDto>(parm);

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
            int count = Count(it => it.Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FicoWageRates GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加工资率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoWageRates AddFicoWageRates(FicoWageRates model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改工资率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoWageRates(FicoWageRates model)
        {
            return Update(model, true, "修改工资率");
        }

        /// <summary>
        /// 导入工资率
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoWageRates(List<FicoWageRates> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mr002.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mr003.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mr004.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mr005.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.Mr006.IsEmpty(), "销售额不能为空")
                .SplitError(x => x.Item.Mr007.IsEmpty(), "工作天数不能为空")
                .SplitError(x => x.Item.Mr008.IsEmpty(), "直接工资率不能为空")
                .SplitError(x => x.Item.Mr009.IsEmpty(), "直接人数不能为空")
                .SplitError(x => x.Item.Mr010.IsEmpty(), "直接加班费不能为空")
                .SplitError(x => x.Item.Mr011.IsEmpty(), "直接工资不能为空")
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
        /// 导出工资率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoWageRatesDto> ExportList(FicoWageRatesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoWageRatesDto()
                {
                    //查询字典: <期间>
                    Mr002Label = it.Mr002.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月>
                    Mr003Label = it.Mr003.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司>
                    Mr004Label = it.Mr004.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <币种>
                    Mr005Label = it.Mr005.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <软删除>
                    //IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_Is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoWageRates> QueryExp(FicoWageRatesQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoWageRates>();

            //查询字段: <期间>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mr002), it => it.Mr002 == parm.Mr002);
            //查询字段: <年月>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mr003), it => it.Mr003 == parm.Mr003);
            //查询字段: <公司>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mr004), it => it.Mr004 == parm.Mr004);
            //查询字段: <币种>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mr005), it => it.Mr005 == parm.Mr005);
            return predicate;
        }
    }
}