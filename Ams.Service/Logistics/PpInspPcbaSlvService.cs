using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 检查日报slv
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:22
    /// </summary>
    [AppService(ServiceType = typeof(IPpInspPcbaSlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpInspPcbaSlvService : BaseService<PpInspPcbaSlv>, IPpInspPcbaSlvService
    {
        /// <summary>
        /// 查询检查日报slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpInspPcbaSlvDto> GetList(PpInspPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpInspPcbaSlv, PpInspPcbaSlvDto>(parm);

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
            int count = Count(it => it. PdiSfId.ToString() == enterString);
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
        public PpInspPcbaSlv GetInfo(long PdiSfId)
        {
            var response = Queryable()
                .Where(x => x.PdiSfId == PdiSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加检查日报slv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpInspPcbaSlv AddPpInspPcbaSlv(PpInspPcbaSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改检查日报slv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpInspPcbaSlv(PpInspPcbaSlv model)
        {
            return Update(model, true, "修改检查日报slv");
        }

        /// <summary>
        /// 导入检查日报slv
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpInspPcbaSlv(List<PpInspPcbaSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PdiSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.PdiParentSfId.IsEmpty(), "PdiParentSfId不能为空")
                .SplitError(x => x.Item.Pdirealqty.IsEmpty(), "当日完成数不能为空")
                .SplitError(x => x.Item.Pdirealtotal.IsEmpty(), "累计完成数不能为空")
                .SplitError(x => x.Item.Pdiispqty.IsEmpty(), "检查台数不能为空")
                .SplitError(x => x.Item.Pdiinsqtime.IsEmpty(), "检查工数不能为空")
                .SplitError(x => x.Item.Pdiaoitime.IsEmpty(), "AOI工数不能为空")
                .SplitError(x => x.Item.Pdibadqty.IsEmpty(), "不良数量不能为空")
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
        /// 导出检查日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpInspPcbaSlvDto> ExportList(PpInspPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpInspPcbaSlvDto()
                {
                    PdipcbtypeLabel = it.Pdipcbtype.GetConfigValue<SysDictData>("sql_pcb_type"),
                    PdivisualtypeLabel = it.Pdivisualtype.GetConfigValue<SysDictData>("sys_visual_type"),
                    PdivctypeLabel = it.Pdivctype.GetConfigValue<SysDictData>("sys_aoi_type"),
                    PdidshiftnameLabel = it.Pdidshiftname.GetConfigValue<SysDictData>("sql_smt_class"),
                    PdipcbchecktypeLabel = it.Pdipcbchecktype.GetConfigValue<SysDictData>("sql_smt_status"),
                    PdilinenameLabel = it.Pdilinename.GetConfigValue<SysDictData>("sql_smt_line"),
                    PdibadPositionLabel = it.PdibadPosition.GetConfigValue<SysDictData>("sql_pcb_place"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpInspPcbaSlv> QueryExp(PpInspPcbaSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpInspPcbaSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdilot), it => it.Pdilot.Contains(parm.Pdilot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdipcbtype), it => it.Pdipcbtype == parm.Pdipcbtype);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdivisualtype), it => it.Pdivisualtype == parm.Pdivisualtype);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdivctype), it => it.Pdivctype == parm.Pdivctype);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPdisideadate == null, it => it.Pdisideadate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPdisideadate == null, it => it.Pdisideadate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPdisideadate != null, it => it.Pdisideadate >= parm.BeginPdisideadate);
            predicate = predicate.AndIF(parm.EndPdisideadate != null, it => it.Pdisideadate <= parm.EndPdisideadate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPdisidebdate == null, it => it.Pdisidebdate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPdisidebdate == null, it => it.Pdisidebdate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPdisidebdate != null, it => it.Pdisidebdate >= parm.BeginPdisidebdate);
            predicate = predicate.AndIF(parm.EndPdisidebdate != null, it => it.Pdisidebdate <= parm.EndPdisidebdate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PdibadPosition), it => it.PdibadPosition == parm.PdibadPosition);
            return predicate;
        }
    }
}