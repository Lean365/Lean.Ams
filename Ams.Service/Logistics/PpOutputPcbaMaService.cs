//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// PCBA OPH
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:18:45
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputPcbaMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputPcbaMaService : BaseService<PpOutputPcbaMa>, IPpOutputPcbaMaService
    {
        /// <summary>
        /// 查询PCBA OPH列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputPcbaMaDto> GetList(PpOutputPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                //.OrderBy("Mca010 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpOutputPcbaMa, PpOutputPcbaMaDto>(parm);

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
        public PpOutputPcbaMa GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加PCBA OPH
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpOutputPcbaMa AddPpOutputPcbaMa(PpOutputPcbaMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpOutputPcbaSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改PCBA OPH
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputPcbaMa(PpOutputPcbaMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpOutputPcbaSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入PCBA OPH
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOutputPcbaMa(List<PpOutputPcbaMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mca003.IsEmpty(), "订单号码不能为空")
                .SplitError(x => x.Item.Mca004.IsEmpty(), "订单数量不能为空")
                .SplitError(x => x.Item.Mca011.IsEmpty(), "直接人数不能为空")
                .SplitError(x => x.Item.Mca012.IsEmpty(), "间接人数不能为空")
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
        /// 导出PCBA OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputPcbaMaDto> ExportList(PpOutputPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpOutputPcbaMaDto()
                {
                    //查询字典: <订单号码>
                    Mca003Label = it.Mca003.GetConfigValue<SysDictData>("sql_moc_pcba"),
                    ////查询字典: <板别>
                    //Mda004Label = it.Mda004.GetConfigValue<SysDictData>("sql_pcb_type"),
                    ////查询字典: <板面>
                    //Mda005Label = it.Mda005.GetConfigValue<SysDictData>("sys_pcb_side"),
                    ////查询字典: <完成情况>
                    //Mda010Label = it.Mda010.GetConfigValue<SysDictData>("sql_comp_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputPcbaMa> QueryExp(PpOutputPcbaMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputPcbaMa>();

            //查询字段: <订单号码>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mca003), it => it.Mca003.Contains(parm.Mca003));
            //查询字段: <生产批次>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mca005), it => it.Mca005.Contains(parm.Mca005));
            //查询字段: <机种>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mca006), it => it.Mca006.Contains(parm.Mca006));
            //查询字段: <物料>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mca007), it => it.Mca007.Contains(parm.Mca007));
            //查询字段: <生产日期>
            //predicate = predicate.AndIF(parm.BeginMca010 == null, it => it.Mca010 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMca010 != null, it => it.Mca010 >= parm.BeginMca010);
            //predicate = predicate.AndIF(parm.EndMca010 != null, it => it.Mca010 <= parm.EndMca010);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMca010 == null, it => it.Mca010 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMca010 == null, it => it.Mca010 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMca010 != null, it => it.Mca010 >= parm.BeginMca010);
            predicate = predicate.AndIF(parm.EndMca010 != null, it => it.Mca010 <= parm.EndMca010);
            return predicate;
        }
    }
}