//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 利润中心
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:56
    /// </summary>
    [AppService(ServiceType = typeof(IFicoProfitCenterService), ServiceLifetime = LifeTime.Transient)]
    public class FicoProfitCenterService : BaseService<FicoProfitCenter>, IFicoProfitCenterService
    {
        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoProfitCenterDto> GetList(FicoProfitCenterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mq003 asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoProfitCenter, FicoProfitCenterDto>(parm);

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
        public FicoProfitCenter GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoProfitCenter AddFicoProfitCenter(FicoProfitCenter model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改利润中心
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoProfitCenter(FicoProfitCenter model)
        {
            return Update(model, true, "修改利润中心");
        }

        /// <summary>
        /// 导入利润中心
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoProfitCenter(List<FicoProfitCenter> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mq003.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.Mq010.IsEmpty(), "名称不能为空")
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
        /// 导出利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoProfitCenterDto> ExportList(FicoProfitCenterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoProfitCenterDto()
                {
                    //查询字典: <控制范围>
                    Mq004Label = it.Mq004.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <货币>
                    Mq009Label = it.Mq009.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <锁定标记>
                    Mq016Label = it.Mq016.GetConfigValue<SysDictData>("sys_locked_flag"),
                    //查询字典: <状态>
                    Mq017Label = it.Mq017.GetConfigValue<SysDictData>("sys_is_status"),
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
        private static Expressionable<FicoProfitCenter> QueryExp(FicoProfitCenterQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoProfitCenter>();

            //查询字段: <利润中心>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq003), it => it.Mq003.Contains(parm.Mq003));
            //查询字段: <控制范围>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq004), it => it.Mq004 == parm.Mq004);
            //查询字段: <名称>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mq010), it => it.Mq010 == parm.Mq010);
            return predicate;
        }
    }
}