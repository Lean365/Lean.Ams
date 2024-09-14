//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 检查
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    [AppService(ServiceType = typeof(IPpInspPcbaMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpInspPcbaMaService : BaseService<PpInspPcbaMa>, IPpInspPcbaMaService
    {
        /// <summary>
        /// 查询检查列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpInspPcbaMaDto> GetList(PpInspPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpInspPcbaSlvNav) //填充子对象
                //.OrderBy("Mu002 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpInspPcbaMa, PpInspPcbaMaDto>(parm);

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
        public PpInspPcbaMa GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.PpInspPcbaSlvNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加检查
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpInspPcbaMa AddPpInspPcbaMa(PpInspPcbaMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpInspPcbaSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改检查
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpInspPcbaMa(PpInspPcbaMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpInspPcbaSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入检查
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpInspPcbaMa(List<PpInspPcbaMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mu004.IsEmpty(), "生产工单不能为空")
                .SplitError(x => x.Item.Mu006.IsEmpty(), "工单台数不能为空")
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
        /// 导出检查
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpInspPcbaMaDto> ExportList(PpInspPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpInspPcbaMaDto()
                {
                    ////查询字典: <板别>
                    //Mv005Label = it.Mv005.GetConfigValue<SysDictData>("sql_pcb_type"),
                    ////查询字典: <目视线别>
                    //Mv006Label = it.Mv006.GetConfigValue<SysDictData>("sys_visual_type"),
                    ////查询字典: <AOI线别>
                    //Mv007Label = it.Mv007.GetConfigValue<SysDictData>("sys_aoi_type"),
                    ////查询字典: <生产班别>
                    //Mv010Label = it.Mv010.GetConfigValue<SysDictData>("sys_shifts_list"),
                    ////查询字典: <检查状态>
                    //Mv015Label = it.Mv015.GetConfigValue<SysDictData>("sql_smt_status"),
                    ////查询字典: <生产线别>
                    //Mv016Label = it.Mv016.GetConfigValue<SysDictData>("sql_smt_line"),
                    ////查询字典: <个所区分>
                    //Mv023Label = it.Mv023.GetConfigValue<SysDictData>("sql_pcb_place"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpInspPcbaMa> QueryExp(PpInspPcbaMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpInspPcbaMa>();

            //查询字段: <检查日期>
            //predicate = predicate.AndIF(parm.BeginMu002 == null, it => it.Mu002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMu002 != null, it => it.Mu002 >= parm.BeginMu002);
            //predicate = predicate.AndIF(parm.EndMu002 != null, it => it.Mu002 <= parm.EndMu002);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMu002 == null, it => it.Mu002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMu002 == null, it => it.Mu002 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMu002 != null, it => it.Mu002 >= parm.BeginMu002);
            predicate = predicate.AndIF(parm.EndMu002 != null, it => it.Mu002 <= parm.EndMu002);
            //查询字段: <生产机种>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mu003), it => it.Mu003.Contains(parm.Mu003));
            //查询字段: <生产工单>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mu004), it => it.Mu004.Contains(parm.Mu004));
            //查询字段: <生产批次>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mu005), it => it.Mu005.Contains(parm.Mu005));
            return predicate;
        }
    }
}