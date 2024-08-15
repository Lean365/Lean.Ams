using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 修理日报ma
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:04:48
    /// </summary>
    [AppService(ServiceType = typeof(IPpRepairPcbaMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpRepairPcbaMaService : BaseService<PpRepairPcbaMa>, IPpRepairPcbaMaService
    {
        /// <summary>
        /// 查询修理日报ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairPcbaMaDto> GetList(PpRepairPcbaMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpRepairPcbaSlvNav) //填充子对象
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
            int count = Count(it => it.PdrSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PdrSfId"></param>
        /// <returns></returns>
        public PpRepairPcbaMa GetInfo(long PdrSfId)
        {
            var response = Queryable()
                .Includes(x => x.PpRepairPcbaSlvNav) //填充子对象
                .Where(x => x.PdrSfId == PdrSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加修理日报ma
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpRepairPcbaMa AddPpRepairPcbaMa(PpRepairPcbaMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpRepairPcbaSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改修理日报ma
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpRepairPcbaMa(PpRepairPcbaMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpRepairPcbaSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入修理日报ma
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpRepairPcbaMa(List<PpRepairPcbaMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PdrSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Pdrorderqty.IsEmpty(), "订单台数不能为空")
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
        /// 导出修理日报ma
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
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //PdrpcbtypeLabel = it.Pdrpcbtype.GetConfigValue<SysDictData>("sql_pcb_type"),
                    //PdrpcbcheckoutLabel = it.Pdrpcbcheckout.GetConfigValue<SysDictData>("sql_insp_eng"),
                    //PdrbadresponsibilityLabel = it.Pdrbadresponsibility.GetConfigValue<SysDictData>("sql_resp_bel"),
                    //PdrbadpropLabel = it.Pdrbadprop.GetConfigValue<SysDictData>("sql_bad_prop"),
                    //PdrbadrepairmanLabel = it.Pdrbadrepairman.GetConfigValue<SysDictData>("sql_repair_list"),
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

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPdrdate == null, it => it.Pdrdate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPdrdate == null, it => it.Pdrdate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPdrdate != null, it => it.Pdrdate >= parm.BeginPdrdate);
            predicate = predicate.AndIF(parm.EndPdrdate != null, it => it.Pdrdate <= parm.EndPdrdate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdrmodel), it => it.Pdrmodel.Contains(parm.Pdrmodel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdrorder), it => it.Pdrorder == parm.Pdrorder);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdrlot), it => it.Pdrlot.Contains(parm.Pdrlot));
            return predicate;
        }
    }
}