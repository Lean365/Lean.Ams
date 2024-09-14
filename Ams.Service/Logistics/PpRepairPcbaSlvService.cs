//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 修理明细
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:47
    /// </summary>
    [AppService(ServiceType = typeof(IPpRepairPcbaSlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpRepairPcbaSlvService : BaseService<PpRepairPcbaSlv>, IPpRepairPcbaSlvService
    {
        /// <summary>
        /// 查询修理明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairPcbaSlvDto> GetList(PpRepairPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpRepairPcbaSlv, PpRepairPcbaSlvDto>(parm);

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
        public PpRepairPcbaSlv GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加修理明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpRepairPcbaSlv AddPpRepairPcbaSlv(PpRepairPcbaSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改修理明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpRepairPcbaSlv(PpRepairPcbaSlv model)
        {
            return Update(model, true, "修改修理明细");
        }

        /// <summary>
        /// 导入修理明细
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpRepairPcbaSlv(List<PpRepairPcbaSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mha005.IsEmpty(), "Lot数不能为空")
                .SplitError(x => x.Item.Mha006.IsEmpty(), "当日生产数不能为空")
                .SplitError(x => x.Item.Mha007.IsEmpty(), "累计完成数不能为空")
                .SplitError(x => x.Item.Mha013.IsEmpty(), "不良数量不能为空")
                .SplitError(x => x.Item.Mha014.IsEmpty(), "累计不良台数不能为空")
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
        /// 导出修理明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairPcbaSlvDto> ExportList(PpRepairPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpRepairPcbaSlvDto()
                {
                    //查询字典: <板别> 
                    Mha004Label = it.Mha004.GetConfigValue<SysDictData>("sql_pcb_type"),
                    //查询字典: <检出工程> 
                    Mha011Label = it.Mha011.GetConfigValue<SysDictData>("sql_insp_eng"),
                    //查询字典: <责任归属> 
                    Mha015Label = it.Mha015.GetConfigValue<SysDictData>("sql_resp_bel"),
                    //查询字典: <不良性质> 
                    Mha016Label = it.Mha016.GetConfigValue<SysDictData>("sql_bad_prop"),
                    //查询字典: <修理> 
                    Mha018Label = it.Mha018.GetConfigValue<SysDictData>("sql_repair_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpRepairPcbaSlv> QueryExp(PpRepairPcbaSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpRepairPcbaSlv>();

            return predicate;
        }
    }
}