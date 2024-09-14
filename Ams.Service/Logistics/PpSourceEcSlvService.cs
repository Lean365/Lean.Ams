//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 从源设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:08:51
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceEcSlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceEcSlvService : BaseService<PpSourceEcSlv>, IPpSourceEcSlvService
    {
        /// <summary>
        /// 查询从源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcSlvDto> GetList(PpSourceEcSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Zb004 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpSourceEcSlv, PpSourceEcSlvDto>(parm);

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
        public PpSourceEcSlv GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加从源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceEcSlv AddPpSourceEcSlv(PpSourceEcSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改从源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceEcSlv(PpSourceEcSlv model)
        {
            return Update(model, true, "修改从源设变");
        }

        /// <summary>
        /// 导入从源设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceEcSlv(List<PpSourceEcSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Zb002.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.Zb003.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.Zb004.IsEmpty(), "完成品不能为空")
                .SplitError(x => x.Item.Zb008.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Zb012.IsEmpty(), "数量不能为空")
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
        /// 导出从源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcSlvDto> ExportList(PpSourceEcSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceEcSlvDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpSourceEcSlv> QueryExp(PpSourceEcSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceEcSlv>();

            //查询字段: <设变No.> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zb003), it => it.Zb003.Contains(parm.Zb003));
            //查询字段: <完成品> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zb004), it => it.Zb004.Contains(parm.Zb004));
            return predicate;
        }
    }
}