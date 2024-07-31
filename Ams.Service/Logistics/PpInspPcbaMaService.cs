using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 检查日报ma
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:30
    /// </summary>
    [AppService(ServiceType = typeof(IPpInspPcbaMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpInspPcbaMaService : BaseService<PpInspPcbaMa>, IPpInspPcbaMaService
    {
        /// <summary>
        /// 查询检查日报ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpInspPcbaMaDto> GetList(PpInspPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpInspPcbaSlvNav) //填充子对象
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
            int count = Count(it => it.PdiSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PdiSfId"></param>
        /// <returns></returns>
        public PpInspPcbaMa GetInfo(long PdiSfId)
        {
            var response = Queryable()
                .Includes(x => x.PpInspPcbaSlvNav) //填充子对象
                .Where(x => x.PdiSfId == PdiSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加检查日报ma
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpInspPcbaMa AddPpInspPcbaMa(PpInspPcbaMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpInspPcbaSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改检查日报ma
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpInspPcbaMa(PpInspPcbaMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpInspPcbaSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入检查日报ma
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpInspPcbaMa(List<PpInspPcbaMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PdiSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Pdiorderqty.IsEmpty(), "工单台数不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
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
        /// 导出检查日报ma
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
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //PdipcbtypeLabel = it.Pdipcbtype.GetConfigValue<SysDictData>("sql_pcb_type"),
                    //PdivisualtypeLabel = it.Pdivisualtype.GetConfigValue<SysDictData>("sys_visual_type"),
                    //PdivctypeLabel = it.Pdivctype.GetConfigValue<SysDictData>("sys_aoi_type"),
                    //PdidshiftnameLabel = it.Pdidshiftname.GetConfigValue<SysDictData>("sql_smt_class"),
                    //PdipcbchecktypeLabel = it.Pdipcbchecktype.GetConfigValue<SysDictData>("sql_smt_status"),
                    //PdilinenameLabel = it.Pdilinename.GetConfigValue<SysDictData>("sql_smt_line"),
                    //PdibadPositionLabel = it.PdibadPosition.GetConfigValue<SysDictData>("sql_pcb_place"),
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

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPdiinspdate == null, it => it.Pdiinspdate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPdiinspdate == null, it => it.Pdiinspdate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPdiinspdate != null, it => it.Pdiinspdate >= parm.BeginPdiinspdate);
            predicate = predicate.AndIF(parm.EndPdiinspdate != null, it => it.Pdiinspdate <= parm.EndPdiinspdate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdimodel), it => it.Pdimodel.Contains(parm.Pdimodel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdiorder), it => it.Pdiorder == parm.Pdiorder);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdilot), it => it.Pdilot.Contains(parm.Pdilot));
            return predicate;
        }
    }
}