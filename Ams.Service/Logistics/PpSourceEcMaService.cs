//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 主源设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:09:51
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceEcMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceEcMaService : BaseService<PpSourceEcMa>, IPpSourceEcMaService
    {
        /// <summary>
        /// 查询主源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcMaDto> GetList(PpSourceEcMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpSourceEcSlvNav) //填充子对象
                //.OrderBy("Za002 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpSourceEcMa, PpSourceEcMaDto>(parm);

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
        public PpSourceEcMa GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.PpSourceEcSlvNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加主源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceEcMa AddPpSourceEcMa(PpSourceEcMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpSourceEcSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改主源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceEcMa(PpSourceEcMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpSourceEcSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入主源设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceEcMa(List<PpSourceEcMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Za002.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.Za025.IsEmpty(), "单位成本不能为空")
                .SplitError(x => x.Item.Za026.IsEmpty(), "模具改造费不能为空")
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
        /// 导出主源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcMaDto> ExportList(PpSourceEcMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceEcMaDto()
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
        private static Expressionable<PpSourceEcMa> QueryExp(PpSourceEcMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceEcMa>();

            //查询字段: <设变No.> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Za002), it => it.Za002.Contains(parm.Za002));
            //查询字段: <标题> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Za004), it => it.Za004.Contains(parm.Za004));
            //查询字段: <发行日> 
            //predicate = predicate.AndIF(parm.BeginZa006 == null, it => it.Za006 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginZa006 != null, it => it.Za006 >= parm.BeginZa006);
            //predicate = predicate.AndIF(parm.EndZa006 != null, it => it.Za006 <= parm.EndZa006);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginZa006 == null, it => it.Za006 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginZa006 == null, it => it.Za006 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginZa006 != null, it => it.Za006 >= parm.BeginZa006);
            predicate = predicate.AndIF(parm.EndZa006 != null, it => it.Za006 <= parm.EndZa006);
            return predicate;
        }
    }
}