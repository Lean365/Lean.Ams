//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// PCBA明细
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:35
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputPcbaSlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputPcbaSlvService : BaseService<PpOutputPcbaSlv>, IPpOutputPcbaSlvService
    {
        /// <summary>
        /// 查询PCBA明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputPcbaSlvDto> GetList(PpOutputPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpOutputPcbaSlv, PpOutputPcbaSlvDto>(parm);

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
        public PpOutputPcbaSlv GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加PCBA明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpOutputPcbaSlv AddPpOutputPcbaSlv(PpOutputPcbaSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改PCBA明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputPcbaSlv(PpOutputPcbaSlv model)
        {
            return Update(model, true, "修改PCBA明细");
        }

        /// <summary>
        /// 导入PCBA明细
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOutputPcbaSlv(List<PpOutputPcbaSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mda006.IsEmpty(), "Lot数不能为空")
                .SplitError(x => x.Item.Mda007.IsEmpty(), "生产实绩不能为空")
                .SplitError(x => x.Item.Mda008.IsEmpty(), "累计生产数不能为空")
                .SplitError(x => x.Item.Mda011.IsEmpty(), "总工数不能为空")
                .SplitError(x => x.Item.Mda012.IsEmpty(), "切换次数不能为空")
                .SplitError(x => x.Item.Mda013.IsEmpty(), "切换时间不能为空")
                .SplitError(x => x.Item.Mda014.IsEmpty(), "切停机时间不能为空")
                .SplitError(x => x.Item.Mda015.IsEmpty(), "修工数不能为空")
                .SplitError(x => x.Item.Mda016.IsEmpty(), "投入工数不能为空")
                .SplitError(x => x.Item.Mda017.IsEmpty(), "不良台数不能为空")
                .SplitError(x => x.Item.Mda018.IsEmpty(), "手插仕损不能为空")
                .SplitError(x => x.Item.Mda019.IsEmpty(), "修正仕损不能为空")
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
        /// 导出PCBA明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputPcbaSlvDto> ExportList(PpOutputPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpOutputPcbaSlvDto()
                {
                    //查询字典: <板别> 
                    Mda004Label = it.Mda004.GetConfigValue<SysDictData>("sql_pcb_type"),
                    //查询字典: <板面> 
                    Mda005Label = it.Mda005.GetConfigValue<SysDictData>("sys_pcb_side"),
                    //查询字典: <完成情况> 
                    Mda010Label = it.Mda010.GetConfigValue<SysDictData>("sql_comp_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputPcbaSlv> QueryExp(PpOutputPcbaSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputPcbaSlv>();

            return predicate;
        }
    }
}