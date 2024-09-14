//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// bom核算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:12:02
    /// </summary>
    [AppService(ServiceType = typeof(IFicoCostingBomService), ServiceLifetime = LifeTime.Transient)]
    public class FicoCostingBomService : BaseService<FicoCostingBom>, IFicoCostingBomService
    {
        /// <summary>
        /// 查询bom核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingBomDto> GetList(FicoCostingBomQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mk003 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoCostingBom, FicoCostingBomDto>(parm);

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
        public FicoCostingBom GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加bom核算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoCostingBom AddFicoCostingBom(FicoCostingBom model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改bom核算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoCostingBom(FicoCostingBom model)
        {
            return Update(model, true, "修改bom核算");
        }

        /// <summary>
        /// 导入bom核算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoCostingBom(List<FicoCostingBom> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mk002.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mk003.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mk004.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mk006.IsEmpty(), "成品物料不能为空")
                .SplitError(x => x.Item.Mk008.IsEmpty(), "成本不能为空")
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
        /// 导出bom核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingBomDto> ExportList(FicoCostingBomQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoCostingBomDto()
                {
                    //查询字典: <期间> 
                    Mk002Label = it.Mk002.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mk003Label = it.Mk003.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <工厂> 
                    Mk004Label = it.Mk004.GetConfigValue<SysDictData>("sql_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoCostingBom> QueryExp(FicoCostingBomQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoCostingBom>();

            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mk002), it => it.Mk002 == parm.Mk002);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mk003), it => it.Mk003 == parm.Mk003);
            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mk004), it => it.Mk004 == parm.Mk004);
            //查询字段: <成品物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mk006), it => it.Mk006.Contains(parm.Mk006));
            return predicate;
        }
    }
}