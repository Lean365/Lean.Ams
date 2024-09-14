//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 组立明细
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:52
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputAssySlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputAssySlvService : BaseService<PpOutputAssySlv>, IPpOutputAssySlvService
    {
        /// <summary>
        /// 查询组立明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputAssySlvDto> GetList(PpOutputAssySlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpOutputAssySlv, PpOutputAssySlvDto>(parm);

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
        public PpOutputAssySlv GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加组立明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpOutputAssySlv AddPpOutputAssySlv(PpOutputAssySlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改组立明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputAssySlv(PpOutputAssySlv model)
        {
            return Update(model, true, "修改组立明细");
        }

        /// <summary>
        /// 导入组立明细
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOutputAssySlv(List<PpOutputAssySlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mmb002.IsEmpty(), "生产时段不能为空")
                .SplitError(x => x.Item.Mmb003.IsEmpty(), "实际产能不能为空")
                .SplitError(x => x.Item.Mmb004.IsEmpty(), "停线时间不能为空")
                .SplitError(x => x.Item.Mmb009.IsEmpty(), "实际工数不能为空")
                .SplitError(x => x.Item.Mmb010.IsEmpty(), "投入工数不能为空")
                .SplitError(x => x.Item.Mmb011.IsEmpty(), "工时差异不能为空")
                .SplitError(x => x.Item.Mmb012.IsEmpty(), "产能差异不能为空")
                .SplitError(x => x.Item.Mmb013.IsEmpty(), "达成率不能为空")
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
        /// 导出组立明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputAssySlvDto> ExportList(PpOutputAssySlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpOutputAssySlvDto()
                {
                    //查询字典: <停线> 
                    Mmb005Label = it.Mmb005.GetConfigValue<SysDictData>("sql_line_stop"),
                    //查询字典: <未达成> 
                    Mmb007Label = it.Mmb007.GetConfigValue<SysDictData>("sql_non_conf"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputAssySlv> QueryExp(PpOutputAssySlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputAssySlv>();

            //查询字段: <生产时段> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mmb002), it => it.Mmb002 == parm.Mmb002);
            return predicate;
        }
    }
}