//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:51:22
    /// </summary>
    [AppService(ServiceType = typeof(IFicoCostingDeptConsumingService), ServiceLifetime = LifeTime.Transient)]
    public class FicoCostingDeptConsumingService : BaseService<FicoCostingDeptConsuming>, IFicoCostingDeptConsumingService
    {
        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingDeptConsumingDto> GetList(FicoCostingDeptConsumingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ml003 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoCostingDeptConsuming, FicoCostingDeptConsumingDto>(parm);

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
        public FicoCostingDeptConsuming GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加部门消耗
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoCostingDeptConsuming AddFicoCostingDeptConsuming(FicoCostingDeptConsuming model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改部门消耗
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoCostingDeptConsuming(FicoCostingDeptConsuming model)
        {
            return Update(model, true, "修改部门消耗");
        }

        /// <summary>
        /// 导入部门消耗
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoCostingDeptConsuming(List<FicoCostingDeptConsuming> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Ml002.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Ml003.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Ml004.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.Ml012.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Ml013.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Ref04.IsEmpty(), "预留1不能为空")
                .SplitError(x => x.Item.Ref05.IsEmpty(), "预留2不能为空")
                .SplitError(x => x.Item.Ref06.IsEmpty(), "预留3不能为空")
                .SplitError(x => x.Item.Udf51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.Udf52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.Udf53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.Udf54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.Udf55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.Udf56.IsEmpty(), "自定义6不能为空")
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
        /// 导出部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingDeptConsumingDto> ExportList(FicoCostingDeptConsumingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoCostingDeptConsumingDto()
                {
                    //查询字典: <期间> 
                    Ml002Label = it.Ml002.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Ml003Label = it.Ml003.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司代码> 
                    Ml004Label = it.Ml004.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <工厂> 
                    Ml012Label = it.Ml012.GetConfigValue<SysDictData>("sql_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoCostingDeptConsuming> QueryExp(FicoCostingDeptConsumingQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoCostingDeptConsuming>();

            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml002), it => it.Ml002 == parm.Ml002);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml003), it => it.Ml003 == parm.Ml003);
            //查询字段: <公司代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml004), it => it.Ml004 == parm.Ml004);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml013), it => it.Ml013.Contains(parm.Ml013));
            return predicate;
        }
    }
}