//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 不良明细
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:50
    /// </summary>
    [AppService(ServiceType = typeof(IPpRepairAssySlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpRepairAssySlvService : BaseService<PpRepairAssySlv>, IPpRepairAssySlvService
    {
        /// <summary>
        /// 查询不良明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairAssySlvDto> GetList(PpRepairAssySlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpRepairAssySlv, PpRepairAssySlvDto>(parm);

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
        public PpRepairAssySlv GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加不良明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpRepairAssySlv AddPpRepairAssySlv(PpRepairAssySlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改不良明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpRepairAssySlv(PpRepairAssySlv model)
        {
            return Update(model, true, "修改不良明细");
        }

        /// <summary>
        /// 导入不良明细
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpRepairAssySlv(List<PpRepairAssySlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mfa004.IsEmpty(), "不良数量不能为空")
                .SplitError(x => x.Item.Mfa005.IsEmpty(), "不良总数不能为空")
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
        /// 导出不良明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairAssySlvDto> ExportList(PpRepairAssySlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpRepairAssySlvDto()
                {
                    //查询字典: <不良区分> 
                    Mfa003Label = it.Mfa003.GetConfigValue<SysDictData>("sql_bad_dist"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpRepairAssySlv> QueryExp(PpRepairAssySlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpRepairAssySlv>();

            return predicate;
        }
    }
}