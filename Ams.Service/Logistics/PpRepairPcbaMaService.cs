//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 修理
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:10:27
    /// </summary>
    [AppService(ServiceType = typeof(IPpRepairPcbaMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpRepairPcbaMaService : BaseService<PpRepairPcbaMa>, IPpRepairPcbaMaService
    {
        /// <summary>
        /// 查询修理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairPcbaMaDto> GetList(PpRepairPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpRepairPcbaSlvNav) //填充子对象
                //.OrderBy("Mga002 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpRepairPcbaMa, PpRepairPcbaMaDto>(parm);

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
        public PpRepairPcbaMa GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.PpRepairPcbaSlvNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加修理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpRepairPcbaMa AddPpRepairPcbaMa(PpRepairPcbaMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpRepairPcbaSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改修理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpRepairPcbaMa(PpRepairPcbaMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpRepairPcbaSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入修理
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpRepairPcbaMa(List<PpRepairPcbaMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mga004.IsEmpty(), "生产订单不能为空")
                .SplitError(x => x.Item.Mga006.IsEmpty(), "订单台数不能为空")
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
        /// 导出修理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairPcbaMaDto> ExportList(PpRepairPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpRepairPcbaMaDto()
                {
                    ////查询字典: <板别>
                    //Mha004Label = it.Mha004.GetConfigValue<SysDictData>("sql_pcb_type"),
                    ////查询字典: <检出工程>
                    //Mha011Label = it.Mha011.GetConfigValue<SysDictData>("sql_insp_eng"),
                    ////查询字典: <责任归属>
                    //Mha015Label = it.Mha015.GetConfigValue<SysDictData>("sql_resp_bel"),
                    ////查询字典: <不良性质>
                    //Mha016Label = it.Mha016.GetConfigValue<SysDictData>("sql_bad_prop"),
                    ////查询字典: <修理>
                    //Mha018Label = it.Mha018.GetConfigValue<SysDictData>("sql_repair_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpRepairPcbaMa> QueryExp(PpRepairPcbaMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpRepairPcbaMa>();

            //查询字段: <生产日期>
            //predicate = predicate.AndIF(parm.BeginMga002 == null, it => it.Mga002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMga002 != null, it => it.Mga002 >= parm.BeginMga002);
            //predicate = predicate.AndIF(parm.EndMga002 != null, it => it.Mga002 <= parm.EndMga002);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMga002 == null, it => it.Mga002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMga002 == null, it => it.Mga002 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMga002 != null, it => it.Mga002 >= parm.BeginMga002);
            predicate = predicate.AndIF(parm.EndMga002 != null, it => it.Mga002 <= parm.EndMga002);
            //查询字段: <生产机种>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mga003), it => it.Mga003.Contains(parm.Mga003));
            //查询字段: <生产订单>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mga004), it => it.Mga004.Contains(parm.Mga004));
            //查询字段: <生产LOT>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mga005), it => it.Mga005.Contains(parm.Mga005));
            return predicate;
        }
    }
}