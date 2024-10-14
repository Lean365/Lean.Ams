//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 资产类别
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:16:33
    /// </summary>
    [AppService(ServiceType = typeof(IFicoAssetsCategoryService), ServiceLifetime = LifeTime.Transient)]
    public class FicoAssetsCategoryService : BaseService<FicoAssetsCategory>, IFicoAssetsCategoryService
    {
        /// <summary>
        /// 查询资产类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoAssetsCategoryDto> GetList(FicoAssetsCategoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoAssetsCategory, FicoAssetsCategoryDto>(parm);

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
            int count = Count(it => it. Id.ToString() == enterString);
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
        public FicoAssetsCategory GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加资产类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoAssetsCategory AddFicoAssetsCategory(FicoAssetsCategory model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改资产类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoAssetsCategory(FicoAssetsCategory model)
        {
            return Update(model, true, "修改资产类别");
        }

        /// <summary>
        /// 导入资产类别
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoAssetsCategory(List<FicoAssetsCategory> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mc002.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mc003.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.Mc004.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.Mc005.IsEmpty(), "长文本不能为空")
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
        /// 导出资产类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoAssetsCategoryDto> ExportList(FicoAssetsCategoryQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoAssetsCategoryDto()
                {
                    //查询字典: <公司> 
                    Mc002Label = it.Mc002.GetConfigValue<SysDictData>("sql_corp_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoAssetsCategory> QueryExp(FicoAssetsCategoryQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoAssetsCategory>();

            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc002), it => it.Mc002 == parm.Mc002);
            //查询字段: <类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc003), it => it.Mc003.Contains(parm.Mc003));
            //查询字段: <名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc004), it => it.Mc004.Contains(parm.Mc004));
            //查询字段: <长文本> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc005), it => it.Mc005.Contains(parm.Mc005));
            return predicate;
        }
    }
}