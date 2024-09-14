//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 银行
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:43:04
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBankService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBankService : BaseService<FicoBank>, IFicoBankService
    {
        /// <summary>
        /// 查询银行列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBankDto> GetList(FicoBankQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mc004 asc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBank, FicoBankDto>(parm);

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
        public FicoBank GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加银行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBank AddFicoBank(FicoBank model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改银行
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBank(FicoBank model)
        {
            return Update(model, true, "修改银行");
        }

        /// <summary>
        /// 导入银行
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBank(List<FicoBank> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mc002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Mc004.IsEmpty(), "银行代码不能为空")
                .SplitError(x => x.Item.Mc005.IsEmpty(), "银行名称不能为空")
                .SplitError(x => x.Item.Mc019.IsEmpty(), "交易冻结不能为空")
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
        /// 导出银行
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBankDto> ExportList(FicoBankQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBankDto()
                {
                    //查询字典: <银行所在国>
                    Mc007Label = it.Mc007.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <交易冻结>
                    Mc019Label = it.Mc019.GetConfigValue<SysDictData>("sys_freeze_flag"),
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
        private static Expressionable<FicoBank> QueryExp(FicoBankQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBank>();

            //查询字段: <关联对象>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc003), it => it.Mc003.Contains(parm.Mc003));
            //查询字段: <银行代码>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc004), it => it.Mc004.Contains(parm.Mc004));
            //查询字段: <银行名称>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc005), it => it.Mc005.Contains(parm.Mc005));
            //查询字段: <分行名称>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc006), it => it.Mc006.Contains(parm.Mc006));
            //查询字段: <银行所在国>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc007), it => it.Mc007 == parm.Mc007);
            //查询字段: <所在州省>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc008), it => it.Mc008 == parm.Mc008);
            return predicate;
        }
    }
}